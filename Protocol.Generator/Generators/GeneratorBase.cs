namespace Protocol.Generator.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Schema;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using Protocol.Generator.XSD;

    internal class GeneratorBase
    {
        protected static Dictionary<INode, string> GenerateMemberNames(ElementNode element)
        {
            var mapping = new Dictionary<INode, string>();
            var memberNames = new HashSet<string> { "Value", "Items", "Parent", "Item", "Object" }; // reserved names
            foreach (var a in element.Attributes)
            {
                string name = Tools.ToPascalCase(a.Name);
                if (memberNames.Contains(name))
                {
                    name += "Attribute";
                }

                mapping.Add(a, name);
                memberNames.Add(name);
            }

            foreach (var e in element.Elements)
            {
                string name = Tools.ToPascalCase(e.Name);
                if (memberNames.Contains(name))
                {
                    name += "Element";
                }

                mapping.Add(e, name);
                memberNames.Add(name);
            }

            return mapping;
        }

        protected static bool CreateInterfaceOrClass(ProtocolXsd xsd, Element e)
        {
            if (xsd.KnownTypes.TryGetValue(e.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
            {
                return false;
            }

            if (e.HasMixedContent)
            {
                return true;
            }

            if (e.Parent != null && e.Parent.IsCollection)
            {
                return true;
            }

            if (!IsValueType(e))
            {
                return true;
            }

            return false;
        }

        protected static bool GenerateKnownType(SchemaType e)
        {
            return e.HasMixedContent || !IsValueType(e);
        }

        protected static string GetClassName(ElementNode e)
        {
            int skip = 0;

            var ancestors = e.Ancestors.Where(x => x.Name != null).ToList();

            if (ancestors.Count >= 1 && ancestors[0].Name == "Protocol")
            {
                if (ancestors.Count == 2)
                {
                    // don't skip parts, to not conflict met System.Type
                    if (e.Name != "Type")
                    {
                        skip = 1;
                    }
                }
                else if (ancestors.Count > 2)
                {
                    skip = 1;
                }
            }

            return String.Join("", ancestors.Skip(skip).Select(x => Tools.ToPascalCase(x.Name)));
        }

        protected static string GetInterfaceName(ElementNode e)
        {
            return "I" + GetClassName(e);
        }

        private static bool TryGetMatchingValueType(XmlSchemaType xmlSchemaType, out string type)
        {
            if (xmlSchemaType == null)
            {
                throw new ArgumentNullException(nameof(xmlSchemaType));
            }

            Type valueType = xmlSchemaType.Datatype?.ValueType;

            if (xmlSchemaType is XmlSchemaSimpleType st && st.Content is XmlSchemaSimpleTypeUnion stu && stu.BaseMemberTypes != null)
            {
                var types = stu.BaseMemberTypes.Select(x => x.Datatype?.ValueType).Where(x => x != null).ToList();
                if (types.Count > 0)
                {
                    var first = types.First();
                    if (types.All(x => x == first))
                    {
                        // all member types are the same
                        valueType = first;
                    }
                }
            }

            if (valueType != null)
            {
                GetType(xmlSchemaType, valueType, out type);
            }
            else
            {
                type = null;
            }

            return type != null;
        }

        private static void GetType(XmlSchemaType xmlSchemaType, Type valueType, out string type)
        {
            if (valueType == typeof(string))
            {
                type = "string";
            }
            else if (valueType == typeof(uint))
            {
                type = "uint?";
            }
            else if (valueType == typeof(int))
            {
                type = "int?";
            }
            else if (valueType == typeof(decimal))
            {
                type = "decimal?";
            }
            else if (valueType == typeof(double))
            {
                type = "double?";
            }
            else if (valueType == typeof(DateTime))
            {
                type = "System.DateTime?";
            }
            else if (valueType == typeof(TimeSpan))
            {
                type = "System.TimeSpan?";
            }
            else if (valueType == typeof(object))
            {
                switch (xmlSchemaType.Name)
                {
                    case "TypeParamId":
                        type = "uint?";
                        break;
                    default:
                        type = "string";
                        break;
                }
            }
            else
            {
                throw new InvalidOperationException("Unknown type: " + valueType);
            }
        }

        private static bool IsValueType(ElementNode e)
        {
            XmlSchemaType xmlSchemaType = e.SchemaType;
            Type valueType = xmlSchemaType?.Datatype?.ValueType;
            return valueType != null;
        }

        protected static bool TryGetEnum(ProtocolXsd xsd, XmlSchemaType type, out EnumList enumValues)
        {
            if (type is XmlSchemaSimpleType simpleType &&
                xsd.Enums.TryGetValue(Convert.ToString(simpleType.QualifiedName), out enumValues))
            {
                return true;
            }

            if (type is XmlSchemaComplexType complexType &&
                complexType.ContentModel?.Content is XmlSchemaSimpleContentExtension simpleContent &&
                xsd.Enums.TryGetValue(Convert.ToString(simpleContent.BaseTypeName), out enumValues))
            {
                return true;
            }

            enumValues = null;
            return false;
        }

        protected static bool TryDetermineValueType(ProtocolXsd xsd, XmlSchemaType type, out string valueType)
        {
            return TryDetermineValueType(xsd, type, out valueType, out _);
        }

        protected static bool TryDetermineValueType(ProtocolXsd xsd, XmlSchemaType type, out string valueType, out bool isEnumType)
        {
            if (TryGetEnum(xsd, type, out var ev))
            {
                if (ev.Name == "EnumTrueFalse")
                {
                    valueType = "bool?";
                    isEnumType = false;
                    return true;
                }

                valueType = "Enums." + ev.Name + "?";
                isEnumType = true;
                return true;
            }

            if (TryGetMatchingValueType(type, out valueType))
            {
                isEnumType = false;
                return true;
            }

            valueType = null;
            isEnumType = false;
            return false;
        }
        
        protected static UsingDirectiveSyntax CreateUsing(string name)
        {
            var declaration = SyntaxFactory.UsingDirective(
                    SyntaxFactory.ParseName(name));

            return declaration;
        }


        protected static ObjectCreationExpressionSyntax GenerateTypeMappingDictionary(ElementNode element)
        {
            var initializers = new List<InitializerExpressionSyntax>();

            foreach (var e in element.Elements)
            {
                var className = GetClassName(e);

                var initializer = SyntaxFactory.InitializerExpression(
                    SyntaxKind.ComplexElementInitializerExpression,
                    SyntaxFactory.SeparatedList<ExpressionSyntax>(
                        new SyntaxNodeOrToken[]
                        {
                            SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(e.Name)),
                            SyntaxFactory.Token(SyntaxKind.CommaToken),
                            SyntaxFactory.TypeOfExpression(SyntaxFactory.IdentifierName(className))
                        }));

                initializers.Add(initializer);
            }

            initializers.Add(SyntaxFactory.InitializerExpression(
                    SyntaxKind.ComplexElementInitializerExpression,
                    SyntaxFactory.SeparatedList<ExpressionSyntax>(
                        new SyntaxNodeOrToken[]
                        {
                            SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal("")),
                            SyntaxFactory.Token(SyntaxKind.CommaToken),
                            SyntaxFactory.TypeOfExpression(SyntaxFactory.IdentifierName(GetClassName(element) + "Item"))
                        })));

            return SyntaxFactory.ObjectCreationExpression(
                SyntaxFactory.GenericName(
                    SyntaxFactory.Identifier("Dictionary"))
                .WithTypeArgumentList(
                    SyntaxFactory.TypeArgumentList(
                        SyntaxFactory.SeparatedList<TypeSyntax>(
                            new SyntaxNodeOrToken[]{
                                SyntaxFactory.PredefinedType(
                                    SyntaxFactory.Token(SyntaxKind.StringKeyword)),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.IdentifierName("Type")}))))
                .WithArgumentList(SyntaxFactory.ArgumentList())
                .WithInitializer(SyntaxFactory.InitializerExpression(
                    SyntaxKind.CollectionInitializerExpression,
                    SyntaxFactory.SeparatedList<ExpressionSyntax>(initializers)));
        }
    }
}
