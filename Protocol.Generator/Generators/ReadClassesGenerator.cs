namespace Protocol.Generator.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using Protocol.Generator.XSD;

    using Attribute = Protocol.Generator.XSD.Attribute;

    internal class ReadClassesGenerator : GeneratorBase
    {
        public static NamespaceDeclarationSyntax GenerateRootNamespace(ProtocolXsd xsd)
        {
            NameSyntax nameSyntax = SyntaxFactory.IdentifierName("Skyline.DataMiner.CICD.Models.Protocol.Read");
            var root = xsd.Node;

            var members = new List<MemberDeclarationSyntax>();
            members.AddRange(GenerateClassesRecursive(xsd, root));

            // create classes for known types
            foreach (var type in xsd.KnownTypes.Values)
            {
                if (GenerateKnownType(type))
                {
                    members.AddRange(GenerateClassesRecursive(xsd, type));
                }
            }

            NamespaceDeclarationSyntax declaration = SyntaxFactory.NamespaceDeclaration(nameSyntax)
                .WithMembers(SyntaxFactory.List(members))
                .WithUsings(SyntaxFactory.List(new[]
                {
                    CreateUsing("System"),
                    CreateUsing("System.Collections.Generic")
                }));

            return declaration;
        }

        private static IEnumerable<TypeDeclarationSyntax> GenerateClassesRecursive(ProtocolXsd xsd, ElementNode element)
        {
            yield return GenerateClass(xsd, element);

            if (element.IsCollection && element.GetCollectionItemElements().Skip(1).Any())
            {
                // generate extra interface and class for collection items
                yield return GenerateInterfaceForCollectionItems(element);
                yield return GenerateClassForCollectionItems(xsd, element);
            }

            foreach (var child in element.Elements)
            {
                if (CreateInterfaceOrClass(xsd, child))
                {
                    foreach (var e in GenerateClassesRecursive(xsd, child))
                    {
                        yield return e;
                    }
                }
                else if (TryDetermineValueType(xsd, child.SchemaType, out string enumType, out bool isEnum) && isEnum)
                {
                    yield return GenerateClassForEnumType(xsd, child, enumType);
                }
            }

            foreach (var child in element.Attributes)
            {
                if (TryDetermineValueType(xsd, child.SchemaType, out string enumType, out bool isEnum) && isEnum)
                {
                    yield return GenerateClassForEnumType(xsd, child, enumType);
                }
            }
        }

        private static ClassDeclarationSyntax GenerateClass(ProtocolXsd xsd, ElementNode element)
        {
            string className = GetClassName(element);

            string baseInterface = GetInterfaceName(element);
            string extraInterface = null;

            bool isEnumType = false;

            var parent = element.Parent;

            if (parent != null && parent.GetCollectionItemElements().Skip(1).Any())
            {
                var parentIntfName = GetInterfaceName(parent);
                extraInterface = parentIntfName + "Object";
            }

            string baseClass = GetBaseClass(xsd, element, className, ref isEnumType);

            List<MemberDeclarationSyntax> members = GenerateMembers(xsd, element, className, baseInterface, isEnumType);

            var baseTypes = new List<BaseTypeSyntax>
            {
                SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseClass)),
                SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseInterface))
            };
            if (extraInterface != null)
            {
                baseTypes.Add(SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(extraInterface)));
            }

            ClassDeclarationSyntax declaration = SyntaxFactory.ClassDeclaration(className)
                .WithMembers(SyntaxFactory.List(members))
                .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(baseTypes)))
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.InternalKeyword),
                    SyntaxFactory.Token(SyntaxKind.PartialKeyword)));

            if (!String.IsNullOrWhiteSpace(element.Documentation))
            {
                SyntaxTrivia docTrivia = Tools.CreateDocumentationTrivia(element.Documentation);
                declaration = declaration.WithLeadingTrivia(SyntaxFactory.TriviaList(docTrivia));
            }

            return declaration;
        }

        private static string GetBaseClass(ProtocolXsd xsd, ElementNode element, string className, ref bool isEnumType)
        {
            string baseClass;
            if (element.IsCollection)
            {
                baseClass = GetBaseClassAsCollection(xsd, element, className);
            }
            else
            {
                if (xsd.KnownTypes.TryGetValue(element.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt) && kt != element)
                {
                    baseClass = "ElementValueTag<" + GetClassName(kt) + ">";
                }
                else if (!element.HasMixedElementContent && TryDetermineValueType(xsd, element.SchemaType, out string valueType, out isEnumType))
                {
                    baseClass = "ElementValueTag<" + valueType + ">";
                }
                else if (element.SchemaType.IsMixed)
                {
                    baseClass = "ElementValueTag<string>";
                }
                else
                {
                    baseClass = "ElementTag";
                }
            }

            return baseClass;
        }

        private static string GetBaseClassAsCollection(ProtocolXsd xsd, ElementNode element, string className)
        {
            string baseClass;
            var collectionItemElements = element.GetCollectionItemElements().ToList();
            if (collectionItemElements.Count == 1)
            {
                var first = collectionItemElements.First();
                if (xsd.KnownTypes.TryGetValue(first.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
                {
                    baseClass = "SimpleProtocolListNode<" + GetClassName(kt) + ">";
                }
                else
                {
                    baseClass = "SimpleProtocolListNode<" + GetClassName(first) + ">";
                }
            }
            else
            {
                // multiple child element types, so we need to link them with the in-between class
                baseClass = "MultipleValueProtocolListNode<I" + className + "Object>";
            }

            return baseClass;
        }

        private static List<MemberDeclarationSyntax> GenerateMembers(ProtocolXsd xsd, ElementNode element, string className, string baseInterface, bool isEnumType)
        {
            var memberNames = GenerateMemberNames(element);

            var members = new List<MemberDeclarationSyntax> { GenerateConstructor(element, className) };
            members.AddRange(GenerateFields(xsd, element, memberNames));
            members.AddRange(GenerateProperties(xsd, element, memberNames));

            if (element.IsCollection)
            {
                string childType;

                var collectionItemElements = element.GetCollectionItemElements().ToList();
                if (collectionItemElements.Count == 1)
                {
                    var first = collectionItemElements.First();

                    if (xsd.KnownTypes.TryGetValue(first.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
                    {
                        childType = GetInterfaceName(kt);
                    }
                    else
                    {
                        childType = GetInterfaceName(first);
                    }
                }
                else
                {
                    // multiple child element types, so we need to link them with the in-between interface
                    childType = baseInterface + "Item";
                }

                members.Add(GenerateIndexer(childType));
                members.Add(GenerateGetEnumeratorMethod(childType));
            }

            if (element.Attributes.Any() || element.Elements.Any(e => !e.IsCollectionItem))
            {
                members.Add(GenerateParseMethod(element, memberNames));
            }

            if (isEnumType)
            {
                members.Add(GenerateConvertRawValueMethod(xsd, element));
            }

            members.Add(GenerateVisitorAcceptMethod(className));
            return members;
        }

        private static InterfaceDeclarationSyntax GenerateInterfaceForCollectionItems(ElementNode element)
        {
            string interfaceName = GetInterfaceName(element) + "Object";
            string baseInterface = GetInterfaceName(element) + "Item";

            InterfaceDeclarationSyntax declaration = SyntaxFactory.InterfaceDeclaration(interfaceName)
                .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(new[] {
                    (BaseTypeSyntax)SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName("IProtocolTag")),
                    (BaseTypeSyntax)SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName("Read." + baseInterface))
                })))
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.InternalKeyword),
                    SyntaxFactory.Token(SyntaxKind.PartialKeyword)));

            return declaration;
        }

        private static ClassDeclarationSyntax GenerateClassForCollectionItems(ProtocolXsd xsd, ElementNode element)
        {
            string className = GetClassName(element) + "Item";

            string baseInterface = GetInterfaceName(element) + "Object";

            string baseClass;

            HashSet<string> valueTypes = new HashSet<string>();
            foreach (var e in element.Elements)
            {
                if (TryDetermineValueType(xsd, e.Definition.ElementSchemaType, out string valueType, out bool _))
                {
                    valueTypes.Add(valueType);
                }
            }

            if (valueTypes.Count == 1)
            {
                baseClass = "ElementValueTag<" + valueTypes.First() + ">";
            }
            else
            {
                baseClass = "ProtocolTag";
            }

            var members = new List<MemberDeclarationSyntax>
            {
                GenerateConstructor(element, className, isListItem: true),
                GenerateEmptyParseMethod(),
                GenerateVisitorAcceptMethod(className)
            };

            ClassDeclarationSyntax declaration = SyntaxFactory.ClassDeclaration(className)
                                                              .WithMembers(SyntaxFactory.List(members))
                                                              .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(new[] {
                                                                  (BaseTypeSyntax)SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseClass)),
                                                                  (BaseTypeSyntax)SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseInterface))
                                                              })))
                                                              .WithModifiers(SyntaxFactory.TokenList(
                                                                  SyntaxFactory.Token(SyntaxKind.InternalKeyword),
                                                                  SyntaxFactory.Token(SyntaxKind.PartialKeyword)));

            return declaration;
        }

        private static ClassDeclarationSyntax GenerateClassForEnumType(ProtocolXsd xsd, INode node, string enumType)
        {
            string className = GetClassName(node.Parent) + Tools.ToPascalCase(node.Name);

            string baseClass;

            if (node is XSD.Attribute)
            {
                baseClass = "AttributeTag<" + enumType + ">";
            }
            else
            {
                baseClass = "ElementValueTag<" + enumType + ">";
            }

            var members = new List<MemberDeclarationSyntax>
            {
                GenerateConstructorForEnumClass(node, className),
                GenerateConvertRawValueMethod(xsd, node)
            };

            ClassDeclarationSyntax declaration = SyntaxFactory.ClassDeclaration(className)
                                                              .WithMembers(SyntaxFactory.List(members))
                                                              .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(new[] {
                                                                  (BaseTypeSyntax)SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseClass)),
                                                              })))
                                                              .WithModifiers(SyntaxFactory.TokenList(
                                                                  SyntaxFactory.Token(SyntaxKind.InternalKeyword),
                                                                  SyntaxFactory.Token(SyntaxKind.PartialKeyword)));

            return declaration;
        }

        public static ConstructorDeclarationSyntax GenerateConstructor(ElementNode element, string className, bool isListItem = false)
        {
            // parameters
            var modelParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("model"))
                .WithType(SyntaxFactory.IdentifierName("ProtocolModel"));
            var parentParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("parent"))
                .WithType(SyntaxFactory.IdentifierName("ProtocolTag"));

            ParameterListSyntax parameterList;
            if (isListItem)
            {
                var tagNameParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("tagName"))
                    .WithType(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.StringKeyword)));

                parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(new[] { modelParameter, parentParameter, tagNameParameter }));
            }
            else
            {
                parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(new[] { modelParameter, parentParameter }));
            }

            // base initializer
            ArgumentSyntax modelArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("model"));
            ArgumentSyntax parentArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("parent"));

            ArgumentSyntax tagNameArgument;
            if (isListItem)
            {
                tagNameArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("tagName"));
            }
            else
            {
                tagNameArgument = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(
                    SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(element.Name)));
            }


            ArgumentListSyntax argumentList;

            var collectionItemElements = element.GetCollectionItemElements().ToList();

            if (!isListItem && collectionItemElements.Count > 0)
            {
                if (collectionItemElements.Count == 1)
                {
                    var firstElement = collectionItemElements.First();
                    var childTagNameArgument = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(
                        SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(firstElement.Name)));

                    argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(new[] { modelArgument, parentArgument, tagNameArgument, childTagNameArgument }));
                }
                else
                {
                    var typeDictionaryArgument = SyntaxFactory.Argument(GenerateTypeMappingDictionary(element));

                    argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(new[] { modelArgument, parentArgument, tagNameArgument, typeDictionaryArgument }));
                }
            }
            else
            {
                argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(new[] { modelArgument, parentArgument, tagNameArgument }));
            }

            var declaration = SyntaxFactory.ConstructorDeclaration(className)
                .WithParameterList(parameterList)
                .WithInitializer(SyntaxFactory.ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, argumentList))
                .WithBody(SyntaxFactory.Block())
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.InternalKeyword)));

            return declaration;
        }

        private static ConstructorDeclarationSyntax GenerateConstructorForEnumClass(INode node, string className)
        {
            // parameters
            var modelParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("model"))
                .WithType(SyntaxFactory.IdentifierName("ProtocolModel"));
            var parentParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("parent"))
                .WithType(SyntaxFactory.IdentifierName("ProtocolTag"));

            ParameterListSyntax parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(new[] { modelParameter, parentParameter }));

            // base initializer
            ArgumentSyntax modelArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("model"));
            ArgumentSyntax parentArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("parent"));

            ArgumentSyntax tagNameArgument = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(
                    SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(node.Name)));


            ArgumentListSyntax argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(new[] { modelArgument, parentArgument, tagNameArgument }));

            var declaration = SyntaxFactory.ConstructorDeclaration(className)
                .WithParameterList(parameterList)
                .WithInitializer(SyntaxFactory.ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, argumentList))
                .WithBody(SyntaxFactory.Block())
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.InternalKeyword)));

            return declaration;
        }

        private static MethodDeclarationSyntax GenerateParseMethod(ElementNode element, Dictionary<INode, string> memberNames)
        {
            var invocations = new List<InvocationExpressionSyntax>();

            // base.Parse(propertyName);
            var propertyNameArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("notifyPropertyName"));
            var callBase = SyntaxFactory.InvocationExpression(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.BaseExpression(),
                    SyntaxFactory.IdentifierName("Parse")))
                .WithArgumentList(SyntaxFactory.ArgumentList(SyntaxFactory.SingletonSeparatedList(propertyNameArgument)));
            invocations.Add(callBase);

            foreach (var a in element.Attributes)
            {
                var propName = memberNames[a];
                var fieldName = "_" + Tools.WithLowercaseFirstLetter(propName);
                invocations.Add(GenerateParseAttributeInvocation(a.Name, fieldName, propName));
            }

            foreach (var e in element.Elements.Where(e => !e.IsCollectionItem))
            {
                var propName = memberNames[e];
                var fieldName = "_" + Tools.WithLowercaseFirstLetter(propName);
                invocations.Add(GenerateParseElementInvocation(e.Name, fieldName, propName));
            }

            // parameters
            var propertyNameParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("notifyPropertyName"))
                .WithType(SyntaxFactory.IdentifierName("string"));

            var parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SingletonSeparatedList(propertyNameParameter));

            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)), SyntaxFactory.Identifier("Parse"))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword)))
                .WithParameterList(parameterList)
                .WithBody(SyntaxFactory.Block(invocations.Select(SyntaxFactory.ExpressionStatement)));

            return declaration;
        }

        private static MethodDeclarationSyntax GenerateEmptyParseMethod()
        {
            // parameters
            var propertyNameParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("notifyPropertyName"))
                .WithType(SyntaxFactory.IdentifierName("string"));

            var parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SingletonSeparatedList(propertyNameParameter));

            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)), SyntaxFactory.Identifier("Parse"))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword)))
                .WithParameterList(parameterList)
                .WithBody(SyntaxFactory.Block());

            return declaration;
        }

        private static InvocationExpressionSyntax GenerateParseAttributeInvocation(string attributeName, string fieldName, string propertyName)
        {
            // ParseAttributeTag("id", nameof(Id), id, value => { id = value; });

            var attributeNameArgument = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(
                SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(attributeName)));

            var propertyNameArgument = SyntaxFactory.Argument(SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
               .WithArgumentList(SyntaxFactory.ArgumentList(
                       SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(SyntaxFactory.IdentifierName(propertyName)))
                       )));

            var fieldNameArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName(fieldName));

            var setterArgument = SyntaxFactory.Argument(
                    SyntaxFactory.SimpleLambdaExpression(
                        SyntaxFactory.Parameter(SyntaxFactory.Identifier("value")),
                        SyntaxFactory.AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            SyntaxFactory.IdentifierName(fieldName),
                            SyntaxFactory.IdentifierName("value"))));

            var argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(
                new[] { attributeNameArgument, propertyNameArgument, fieldNameArgument, setterArgument }));

            var invocation = SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("ParseAttributeTag"), argumentList);

            return invocation;
        }

        private static InvocationExpressionSyntax GenerateParseElementInvocation(string tagName, string fieldName, string propertyName)
        {
            // ParseElementTag("Name", nameof(Name), name, value => { name = value; });

            var tagNameArgument = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(
            SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(tagName)));

            var propertyNameArgument = SyntaxFactory.Argument(SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("nameof"))
               .WithArgumentList(SyntaxFactory.ArgumentList(
                       SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Argument(SyntaxFactory.IdentifierName(propertyName)))
                       )));

            var fieldNameArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName(fieldName));

            var setterArgument = SyntaxFactory.Argument(
                    SyntaxFactory.SimpleLambdaExpression(
                        SyntaxFactory.Parameter(SyntaxFactory.Identifier("value")),
                        SyntaxFactory.AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            SyntaxFactory.IdentifierName(fieldName),
                            SyntaxFactory.IdentifierName("value"))));

            var argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(
                new[] { tagNameArgument, propertyNameArgument, fieldNameArgument, setterArgument }));

            var invocation = SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("ParseElementTag"), argumentList);

            return invocation;
        }

        private static MethodDeclarationSyntax GenerateConvertRawValueMethod(ProtocolXsd xsd, INode element)
        {
            string returnType;

            // parameters
            var valueParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("rawValue"))
                .WithType(SyntaxFactory.IdentifierName("string"));
            var parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SingletonSeparatedList(valueParameter));

            // expression
            StatementSyntax statement;
            if (TryGetEnum(xsd, element.SchemaType, out var e))
            {
                returnType = "Enums." + e.Name + "?";

                // return Enums.EnumActionOnConverter.Convert(value);
                statement = SyntaxFactory.ReturnStatement(
                    SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName("Enums"),
                                SyntaxFactory.IdentifierName(e.Name + "Converter")),
                            SyntaxFactory.IdentifierName("Convert")))
                        .WithArgumentList(
                            SyntaxFactory.ArgumentList(
                               SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                   SyntaxFactory.Argument(
                                       SyntaxFactory.ConditionalAccessExpression(
                                           SyntaxFactory.IdentifierName("rawValue"),
                                           SyntaxFactory.InvocationExpression(
                                               SyntaxFactory.MemberBindingExpression(
                                                    SyntaxFactory.IdentifierName("Trim")))))))));
            }
            else
            {
                returnType = "string";

                // return value;
                statement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("rawValue"));
            }

            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.IdentifierName(returnType),
                SyntaxFactory.Identifier("ConvertRawValue"))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword)))
                .WithParameterList(parameterList)
                .WithBody(SyntaxFactory.Block(SyntaxFactory.SingletonList(statement)));

            return declaration;
        }

        private static MethodDeclarationSyntax GenerateGetEnumeratorMethod(string childType)
        {
            var typeArguments = SyntaxFactory.TypeArgumentList(
                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                        SyntaxFactory.IdentifierName(childType)));

            var body = SyntaxFactory.Block(SyntaxFactory.SingletonList<StatementSyntax>(
                SyntaxFactory.ReturnStatement(SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("GetEnumerator")))));

            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.GenericName(SyntaxFactory.Identifier("IEnumerator"), typeArguments),
                SyntaxFactory.Identifier("GetEnumerator"))
                .WithExplicitInterfaceSpecifier(SyntaxFactory.ExplicitInterfaceSpecifier(
                    SyntaxFactory.GenericName(SyntaxFactory.Identifier("IEnumerable"), typeArguments)))
                .WithBody(body);

            return declaration;
        }

        private static MethodDeclarationSyntax GenerateVisitorAcceptMethod(string className)
        {
            // public void Accept(IProtocolVisitor visitor)
            // {
            //     visitor.VisitProtocol(this);
            // }

            var parameters = SyntaxFactory.ParameterList(
                SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
                    SyntaxFactory.Parameter(
                        SyntaxFactory.Identifier("visitor"))
                    .WithType(
                        SyntaxFactory.IdentifierName("ProtocolVisitor"))));

            var body = SyntaxFactory.Block(
                SyntaxFactory.SingletonList<StatementSyntax>(
                    SyntaxFactory.ExpressionStatement(
                        SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName("visitor"),
                                SyntaxFactory.IdentifierName("Visit" + className)))
                        .WithArgumentList(
                            SyntaxFactory.ArgumentList(
                                SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                    SyntaxFactory.Argument(
                                        SyntaxFactory.ThisExpression())))))));

            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                SyntaxFactory.Identifier("Accept"))
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                    SyntaxFactory.Token(SyntaxKind.OverrideKeyword)))
                .WithParameterList(parameters)
                .WithBody(body);

            return declaration;
        }

        private static IndexerDeclarationSyntax GenerateIndexer(string childType)
        {
            // IPair IReadOnlyList<IPair>.this[int index] { get { return this[index]; } }

            var declaration = SyntaxFactory.IndexerDeclaration(
            SyntaxFactory.IdentifierName(childType))
                .WithExplicitInterfaceSpecifier(
                    SyntaxFactory.ExplicitInterfaceSpecifier(
                        SyntaxFactory.GenericName(
                            SyntaxFactory.Identifier("IReadOnlyList"))
                        .WithTypeArgumentList(
                            SyntaxFactory.TypeArgumentList(
                                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                    SyntaxFactory.IdentifierName(childType))))))
                .WithParameterList(
                    SyntaxFactory.BracketedParameterList(
                        SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
                            SyntaxFactory.Parameter(
                                SyntaxFactory.Identifier("index"))
                            .WithType(
                                SyntaxFactory.PredefinedType(
                                    SyntaxFactory.Token(SyntaxKind.IntKeyword))))))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.SingletonList<AccessorDeclarationSyntax>(
                            SyntaxFactory.AccessorDeclaration(
                                SyntaxKind.GetAccessorDeclaration)
                            .WithBody(
                                SyntaxFactory.Block(
                                    SyntaxFactory.SingletonList<StatementSyntax>(
                                        SyntaxFactory.ReturnStatement(
                                            SyntaxFactory.ElementAccessExpression(
                                                SyntaxFactory.ThisExpression())
                                            .WithArgumentList(
                                                SyntaxFactory.BracketedArgumentList(
                                                    SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                        SyntaxFactory.Argument(
                                                            SyntaxFactory.IdentifierName("index"))))))))))));

            return declaration;
        }

        private static IEnumerable<FieldDeclarationSyntax> GenerateFields(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames)
        {
            var members = new List<FieldDeclarationSyntax>();

            // fields for child elements
            foreach (var e in element.Elements.Where(e => !e.IsCollectionItem))
            {
                GenerateFieldForElement(xsd, memberNames, e, members);
            }

            // fields for attributes
            foreach (var a in element.Attributes)
            {
                GenerateFieldForAttribute(xsd, element, memberNames, a, members);
            }

            return members;
        }

        private static void GenerateFieldForElement(ProtocolXsd xsd, Dictionary<INode, string> memberNames, Element e, List<FieldDeclarationSyntax> members)
        {
            var propName = memberNames[e];
            var fieldName = "_" + Tools.WithLowercaseFirstLetter(propName);
            string typeName;

            if (CreateInterfaceOrClass(xsd, e))
            {
                typeName = GetClassName(e);
            }
            else if (xsd.KnownTypes.TryGetValue(e.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
            {
                typeName = GetClassName(kt);
            }
            else if (TryDetermineValueType(xsd, e.Definition.ElementSchemaType, out string valueType, out bool isEnum) && !e.HasMixedContent)
            {
                if (isEnum)
                {
                    typeName = GetClassName(e);
                }
                else
                {
                    typeName = "ElementValueTag<" + valueType + ">";
                }
            }
            else
            {
                typeName = GetClassName(e);
            }

            members.Add(GenerateField(fieldName, typeName));
        }

        private static void GenerateFieldForAttribute(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames, Attribute a, List<FieldDeclarationSyntax> members)
        {
            string propName = memberNames[a];
            string fieldName = "_" + Tools.WithLowercaseFirstLetter(propName);
            string typeName;

            if (xsd.KnownTypes.TryGetValue(a.Definition.AttributeSchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
            {
                typeName = GetClassName(kt);
            }
            else if (TryDetermineValueType(xsd, a.Definition.AttributeSchemaType, out string valueType, out bool isEnum))
            {
                if (isEnum)
                {
                    typeName = GetClassName(element) + Tools.ToPascalCase(a.Name);
                }
                else
                {
                    typeName = "AttributeTag<" + valueType + ">";
                }
            }
            else
            {
                typeName = "AttributeTag<string>";
            }

            members.Add(GenerateField(fieldName, typeName));
        }

        private static FieldDeclarationSyntax GenerateField(string identifier, string typeName)
        {
            TypeSyntax typeSyntax = SyntaxFactory.ParseTypeName(typeName);

            var variable = SyntaxFactory.VariableDeclaration(typeSyntax)
                .WithVariables(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.VariableDeclarator(identifier)));

            var declaration = SyntaxFactory.FieldDeclaration(variable)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PrivateKeyword)));

            return declaration;
        }

        private static IEnumerable<PropertyDeclarationSyntax> GenerateProperties(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames)
        {
            var members = new List<PropertyDeclarationSyntax>();

            // properties for child elements
            foreach (var e in element.Elements.Where(e => !e.IsCollectionItem))
            {
                GeneratePropertyForElement(xsd, memberNames, e, members);
            }

            // properties for attributes
            foreach (var a in element.Attributes)
            {
                GeneratePropertyForAttribute(xsd, memberNames, a, members);
            }

            return members;
        }

        private static void GeneratePropertyForElement(ProtocolXsd xsd, Dictionary<INode, string> memberNames, Element e, List<PropertyDeclarationSyntax> members)
        {
            var propName = memberNames[e];
            string typeName;

            if (CreateInterfaceOrClass(xsd, e))
            {
                typeName = GetInterfaceName(e);
            }
            else if (xsd.KnownTypes.TryGetValue(e.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
            {
                typeName = GetInterfaceName(kt);
            }
            else if (TryDetermineValueType(xsd, e.Definition.ElementSchemaType, out string valueType) && !e.HasMixedContent)
            {
                typeName = "IValueTag<" + valueType + ">";
            }
            else
            {
                typeName = GetInterfaceName(e);
            }

            members.Add(GenerateProperty(propName, typeName, e.Documentation));
        }

        private static void GeneratePropertyForAttribute(ProtocolXsd xsd, Dictionary<INode, string> memberNames, Attribute a, List<PropertyDeclarationSyntax> members)
        {
            string propName = memberNames[a];
            string typeName;

            if (xsd.KnownTypes.TryGetValue(a.Definition.AttributeSchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
            {
                typeName = GetInterfaceName(kt);
            }
            else if (TryDetermineValueType(xsd, a.Definition.AttributeSchemaType, out string valueType))
            {
                typeName = "IValueTag<" + valueType + ">";
            }
            else
            {
                typeName = "IValueTag<string>";
            }

            members.Add(GenerateProperty(propName, typeName, a.Documentation));
        }

        private static PropertyDeclarationSyntax GenerateProperty(string identifier, string typeName, string documentation)
        {
            TypeSyntax typeSyntax = SyntaxFactory.ParseTypeName(typeName);
            string fieldName = "_" + Tools.WithLowercaseFirstLetter(identifier);

            var declaration = SyntaxFactory.PropertyDeclaration(typeSyntax, identifier)
                .WithExpressionBody(SyntaxFactory.ArrowExpressionClause(SyntaxFactory.IdentifierName(fieldName)))
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            if (!String.IsNullOrWhiteSpace(documentation))
            {
                SyntaxTrivia docTrivia = Tools.CreateDocumentationTrivia(documentation);
                declaration = declaration.WithLeadingTrivia(SyntaxFactory.TriviaList(docTrivia));
            }

            return declaration;
        }
    }
}
