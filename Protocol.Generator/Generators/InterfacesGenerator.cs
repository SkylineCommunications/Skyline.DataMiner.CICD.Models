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

    internal class InterfacesGenerator : GeneratorBase
    {
        public static NamespaceDeclarationSyntax GenerateRootNamespace(ProtocolXsd xsd)
        {
            NameSyntax nameSyntax = SyntaxFactory.IdentifierName("Skyline.DataMiner.CICD.Models.Protocol.Read");
            var root = xsd.Node;

            var members = new List<MemberDeclarationSyntax>();
            members.AddRange(GenerateInterfacesRecursive(xsd, root));

            // create interfaces for known types
            foreach (var type in xsd.KnownTypes.Values)
            {
                if (GenerateKnownType(type))
                {
                    members.AddRange(GenerateInterfacesRecursive(xsd, type));
                }
            }

            NamespaceDeclarationSyntax declaration = SyntaxFactory.NamespaceDeclaration(nameSyntax)
                .WithMembers(SyntaxFactory.List(members));

            return declaration;
        }

        private static IEnumerable<InterfaceDeclarationSyntax> GenerateInterfacesRecursive(ProtocolXsd xsd, ElementNode element)
        {
            yield return GenerateInterface(xsd, element);

            if (element.IsCollection && element.GetCollectionItemElements().Skip(1).Any())
            {
                // generate extra (in between) interface for collection items, because there are multiple types
                yield return GenerateInterfaceForCollectionItems(xsd, element);
            }

            foreach (var child in element.Elements)
            {
                if (!CreateInterfaceOrClass(xsd, child))
                {
                    continue;
                }

                foreach (var e in GenerateInterfacesRecursive(xsd, child))
                {
                    yield return e;
                }
            }
        }

        private static InterfaceDeclarationSyntax GenerateInterface(ProtocolXsd xsd, ElementNode element)
        {
            string interfaceName = GetInterfaceName(element);

            string extraInterface = null;

            var memberNames = GenerateMemberNames(element);

            var members = new List<MemberDeclarationSyntax>();

            var parent = element.Parent;
            if (parent != null && parent.GetCollectionItemElements().Skip(1).Any())
            {
                var parentIntfName = GetInterfaceName(parent);
                extraInterface = parentIntfName + "Item";
            }

            // properties for elements
            foreach (var item in element.Elements.Where(e => !e.IsCollectionItem))
            {
                GeneratePropertyForElement(xsd, memberNames, item, members);
            }

            // properties for attributes
            foreach (var item in element.Attributes)
            {
                GeneratePropertyForAttribute(xsd, memberNames, item, members);
            }
            
            string baseInterface = GetBaseInterface(xsd, element, interfaceName);

            var baseTypes = new List<BaseTypeSyntax> { SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseInterface)) };

            if (extraInterface != null)
            {
                baseTypes.Add(SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(extraInterface)));
            }

            InterfaceDeclarationSyntax declaration = SyntaxFactory.InterfaceDeclaration(interfaceName)
                .WithMembers(SyntaxFactory.List(members))
                .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(baseTypes)))
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                    SyntaxFactory.Token(SyntaxKind.PartialKeyword)));

            if (!String.IsNullOrWhiteSpace(element.Documentation))
            {
                SyntaxTrivia docTrivia = Tools.CreateDocumentationTrivia(element.Documentation);
                declaration = declaration.WithLeadingTrivia(SyntaxFactory.TriviaList(docTrivia));
            }

            return declaration;
        }

        private static string GetBaseInterface(ProtocolXsd xsd, ElementNode element, string interfaceName)
        {
            string baseInterface;
            if (element.IsCollection)
            {
                baseInterface = GetBaseInterfaceAsCollection(xsd, element, interfaceName);
            }
            else
            {
                if (xsd.KnownTypes.TryGetValue(element.SchemaType.QualifiedName.ToString(), out var kt) && kt != element && GenerateKnownType(kt))
                {
                    baseInterface = "IValueTag<" + GetInterfaceName(kt) + ">";
                }
                else if (!element.HasMixedElementContent && TryDetermineValueType(xsd, element.SchemaType, out string valueType))
                {
                    baseInterface = "IValueTag<" + valueType + ">";
                }
                else if (element.SchemaType.IsMixed)
                {
                    baseInterface = "IValueTag<string>";
                }
                else
                {
                    baseInterface = "IReadable";
                }
            }

            return baseInterface;
        }

        private static string GetBaseInterfaceAsCollection(ProtocolXsd xsd, ElementNode element, string interfaceName)
        {
            string baseInterface;
            var collectionItemElements = element.GetCollectionItemElements().ToList();
            if (collectionItemElements.Count == 1)
            {
                var first = collectionItemElements.First();

                if (xsd.KnownTypes.TryGetValue(first.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
                {
                    baseInterface = "IReadableList<" + GetInterfaceName(kt) + ">";
                }
                else
                {
                    baseInterface = "IReadableList<" + GetInterfaceName(first) + ">";
                }
            }
            else
            {
                // multiple child element types, so we need to link them with the in-between interface
                baseInterface = "IReadableList<" + interfaceName + "Item>";
            }

            return baseInterface;
        }

        private static void GeneratePropertyForAttribute(ProtocolXsd xsd, Dictionary<INode, string> memberNames, Attribute item, List<MemberDeclarationSyntax> members)
        {
            string propName = memberNames[item];
            string typeName;

            if (xsd.KnownTypes.TryGetValue(item.Definition.AttributeSchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
            {
                typeName = GetInterfaceName(kt);
            }
            else if (TryDetermineValueType(xsd, item.Definition.AttributeSchemaType, out string valueType))
            {
                typeName = "IValueTag<" + valueType + ">";
            }
            else
            {
                typeName = "IValueTag<string>";
            }

            members.Add(GenerateProperty(propName, typeName, item.Documentation));
        }

        private static void GeneratePropertyForElement(ProtocolXsd xsd, Dictionary<INode, string> memberNames, Element item, List<MemberDeclarationSyntax> members)
        {
            string propName = memberNames[item];
            string typeName;

            if (CreateInterfaceOrClass(xsd, item))
            {
                typeName = GetInterfaceName(item);
            }
            else if (xsd.KnownTypes.TryGetValue(item.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
            {
                typeName = GetInterfaceName(kt);
            }
            else if (!item.HasMixedContent && TryDetermineValueType(xsd, item.SchemaType, out string valueType))
            {
                typeName = "IValueTag<" + valueType + ">";
            }
            else
            {
                typeName = GetInterfaceName(item);
            }

            members.Add(GenerateProperty(propName, typeName, item.Documentation));
        }

        private static InterfaceDeclarationSyntax GenerateInterfaceForCollectionItems(ProtocolXsd xsd, ElementNode element)
        {
            string interfaceName = GetInterfaceName(element) + "Item";
            string baseType;

            HashSet<string> valueTypes = new HashSet<string>();
            foreach (var e in element.Elements)
            {
                if (TryDetermineValueType(xsd, e.SchemaType, out string valueType, out bool _))
                {
                    valueTypes.Add(valueType);
                }
            }

            if (valueTypes.Count == 1)
            {
                baseType = "IValueTag<" + valueTypes.First() + ">";
            }
            else
            {
                baseType = "IReadable";
            }

            BaseTypeSyntax baseTypeSyntax = SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseType));

            InterfaceDeclarationSyntax declaration = SyntaxFactory.InterfaceDeclaration(interfaceName)
                .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(new[] { baseTypeSyntax })))
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                    SyntaxFactory.Token(SyntaxKind.PartialKeyword)));

            return declaration;
        }

        private static PropertyDeclarationSyntax GenerateProperty(string identifier, string typeName, string documentation)
        {
            TypeSyntax typeSyntax = SyntaxFactory.ParseTypeName(typeName);

            var declaration = SyntaxFactory.PropertyDeclaration(typeSyntax, identifier)
                .AddAccessorListAccessors(SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));

            if (!String.IsNullOrWhiteSpace(documentation))
            {
                SyntaxTrivia docTrivia = Tools.CreateDocumentationTrivia(documentation);
                declaration = declaration.WithLeadingTrivia(SyntaxFactory.TriviaList(docTrivia));
            }

            return declaration;
        }
    }
}
