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

    internal class EditClassesGenerator : GeneratorBase
    {
        public static NamespaceDeclarationSyntax GenerateRootNamespace(ProtocolXsd xsd)
        {
            NameSyntax nameSyntax = SyntaxFactory.IdentifierName("Skyline.DataMiner.CICD.Models.Protocol.Edit");
            var root = xsd.Node;

            var members = new List<MemberDeclarationSyntax>();
            members.AddRange(GenerateClassesRecursive(xsd, root));

            // create classes for known types
            foreach (var type in xsd.KnownTypes.Values)
            {
                if (GenerateKnownType(type))
                {
                    members.AddRange(GenerateClassesRecursive(xsd, type, withCustomTagNameParameter: true));
                }
            }

            NamespaceDeclarationSyntax declaration = SyntaxFactory.NamespaceDeclaration(nameSyntax)
                .WithMembers(SyntaxFactory.List(members))
                .WithUsings(SyntaxFactory.List(new[] { CreateUsing("System"), CreateUsing("System.Collections.Generic"), CreateUsing("Skyline.DataMiner.CICD.Parsers.Common.XmlEdit") }));

            return declaration;
        }

        private static IEnumerable<TypeDeclarationSyntax> GenerateClassesRecursive(ProtocolXsd xsd, ElementNode element, bool withCustomTagNameParameter = false)
        {
            yield return GenerateClass(xsd, element, withCustomTagNameParameter);

            if (element.IsCollection && element.GetCollectionItemElements().Skip(1).Any())
            {
                // generate extra interface and class for collection items
                yield return GenerateInterfaceForCollectionItems(element);
                yield return GenerateClassForCollectionItems(element);
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

        private static ClassDeclarationSyntax GenerateClass(ProtocolXsd xsd, ElementNode element, bool withCustomTagNameParameter)
        {
            string className = GetClassName(element);
            string intfName = GetInterfaceName(element);

            string baseClass;
            string extraInterface = null;
            string valueType = null;
            bool isComplexCollectionClass = false;
            bool isValueType = false;
            bool isEnumType = false;
            bool parentIsMixedCollection = false;
            bool withInitializeMethods = true;
            bool withTagNameParameter = true;

            var parent = element.Parent;
            if (parent != null && parent.GetCollectionItemElements().Skip(1).Any())
            {
                var parentInterfaceName = GetInterfaceName(parent);
                extraInterface = parentInterfaceName + "Item";
                parentIsMixedCollection = true;
            }

            if (element.IsCollection)
            {
                var collectionItemElements = element.GetCollectionItemElements().ToList();
                if (collectionItemElements.Count == 1)
                {
                    string childClassName;

                    var first = collectionItemElements.First();
                    if (xsd.KnownTypes.TryGetValue(first.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
                    {
                        childClassName = GetClassName(kt);
                    }
                    else
                    {
                        childClassName = GetClassName(first);
                    }

                    string childIntfName = "I" + childClassName;
                    baseClass = "EditableListNode<Read." + intfName + ", Read." + childIntfName + ", " + childClassName + ">";
                }
                else
                {
                    // multiple child element types, so we need to link them with the in-between class
                    string childClassName = className + "Item";

                    string childIntfName = "I" + childClassName;
                    baseClass = "ComplexEditableListNode<Read." + intfName + ", Read." + childIntfName + ", " + childIntfName + ">";
                    isComplexCollectionClass = true;
                }
            }
            else
            {
                if (xsd.KnownTypes.TryGetValue(element.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt) && kt != element)
                {
                    baseClass = "EditableElementNode<" + GetClassName(kt) + ">";
                }
                else if (!element.HasMixedElementContent && TryDetermineValueType(xsd, element.SchemaType, out valueType, out isEnumType))
                {
                    if (element.HasMixedContent || parentIsMixedCollection || (element is Element e && e.IsCollectionItem))
                    {
                        baseClass = "EditableElementValueNode<Read." + intfName + ", " + valueType + ">";
                    }
                    else
                    {
                        baseClass = "ElementValue<" + valueType + ">";
                        withTagNameParameter = false;
                        withInitializeMethods = false;
                    }

                    isValueType = true;
                }
                else if (element.SchemaType.IsMixed)
                {
                    baseClass = "EditableElementValueNode<Read." + intfName + ", string>";
                    isValueType = true;
                }
                else
                {
                    baseClass = "EditableElementNode<Read." + intfName + ">";
                }
            }

            List<MemberDeclarationSyntax> members = GenerateMembers(xsd, element, withCustomTagNameParameter, isValueType, valueType, className, withTagNameParameter, isComplexCollectionClass, withInitializeMethods, isEnumType);

            var baseTypes = new List<BaseTypeSyntax> { SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseClass)) };
            if (extraInterface != null)
            {
                baseTypes.Add(SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(extraInterface)));
            }

            ClassDeclarationSyntax declaration = SyntaxFactory.ClassDeclaration(className)
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

        private static List<MemberDeclarationSyntax> GenerateMembers(ProtocolXsd xsd, ElementNode element, bool withCustomTagNameParameter, bool isValueType, string valueType,
            string className, bool withTagNameParameter, bool isComplexCollectionClass, bool withInitializeMethods, bool isEnumType)
        {
            var memberNames = GenerateMemberNames(element);

            var members = new List<MemberDeclarationSyntax>();

            bool withUseCDataParameter = isValueType && valueType == "string";
            members.Add(GenerateInternalConstructor(element, className, withEditNodeParameter: withTagNameParameter,
                withTypeMappingParameter: isComplexCollectionClass, withUseCDataParameter: withUseCDataParameter));
            members.Add(GeneratePublicConstructor(element, className,
                withTagNameParameter: withTagNameParameter,
                withCustomTagNameParameter: withCustomTagNameParameter,
                withTypeMappingParameter: isComplexCollectionClass,
                withUseCDataParameter: withUseCDataParameter));

            if (isValueType && !String.IsNullOrWhiteSpace(valueType))
            {
                members.Add(GeneratePublicConstructorWithValue(element, className, valueType, withTagNameParameter: withTagNameParameter,
                    withCustomTagNameParameter: withCustomTagNameParameter, withUseCDataParameter: withUseCDataParameter));
            }

            members.AddRange(GenerateFields(xsd, element, memberNames));
            members.AddRange(GenerateProperties(xsd, element, memberNames));
            members.AddRange(GenerateGetOrCreateMethods(xsd, element, memberNames));

            if (withInitializeMethods)
            {
                members.Add(GenerateInitializeMethod(xsd, element, memberNames));
            }

            members.Add(GenerateFromReadMethod(xsd, element, isValueType, memberNames, withCustomTagNameParameter));
            members.Add(GenerateVisitorAcceptMethod(className));

            if (isEnumType)
            {
                members.Add(GenerateGetValueToWriteMethod(xsd, element));
                members.Add(GenerateConvertRawValueMethod(xsd, element));
            }

            return members;
        }

        private static InterfaceDeclarationSyntax GenerateInterfaceForCollectionItems(ElementNode element)
        {
            string interfaceName = GetInterfaceName(element) + "Item";

            InterfaceDeclarationSyntax declaration = SyntaxFactory.InterfaceDeclaration(interfaceName)
                .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(new[] {
                    (BaseTypeSyntax)SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName("IEditableNode"))
                })))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            return declaration;
        }

        private static ClassDeclarationSyntax GenerateClassForCollectionItems(ElementNode element)
        {
            string className = GetClassName(element) + "Item";
            string intfName = "I" + className;

            string baseClass = "EditableElementNode<Read." + intfName + ">";
            string baseInterface = intfName;

            var members = new List<MemberDeclarationSyntax>
            {
                GenerateProtectedConstructorForCollectionItem(className),
                GenerateInternalConstructor(element, className, withEditNodeParameter: true, withTypeMappingParameter: false,
                    withUseCDataParameter: false),
                GenerateInitializeMethodForItemClass(className),
                GenerateFromReadMethodForCollectionItem(element, className),
                GenerateVisitorAcceptMethod(className)
            };

            ClassDeclarationSyntax declaration = SyntaxFactory.ClassDeclaration(className)
                                                              .WithMembers(SyntaxFactory.List(members))
                                                              .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(new[] {
                                                                  (BaseTypeSyntax)SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseClass)),
                                                                  (BaseTypeSyntax)SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseInterface))
                                                              })))
                                                              .WithModifiers(SyntaxFactory.TokenList(
                                                                  SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                                                                  SyntaxFactory.Token(SyntaxKind.PartialKeyword)));

            return declaration;
        }

        private static ClassDeclarationSyntax GenerateClassForEnumType(ProtocolXsd xsd, INode node, string enumType)
        {
            string className = GetClassName(node.Parent) + Tools.ToPascalCase(node.Name);

            string baseClass;

            if (node is XSD.Attribute)
            {
                baseClass = "AttributeValue<" + enumType + ">";
            }
            else
            {
                baseClass = "ElementValue<" + enumType + ">";
            }

            var members = new List<MemberDeclarationSyntax>
            {
                GenerateConstructorForEnumClass(className, enumType),
                GeneratePublicConstructor(node, className, withTagNameParameter: false, withCustomTagNameParameter: false,
                    withTypeMappingParameter: false, withUseCDataParameter: false),
                GeneratePublicConstructorWithValue(node, className, enumType, withTagNameParameter: false, withCustomTagNameParameter: false, withUseCDataParameter: false),
                GenerateGetValueToWriteMethod(xsd, node),
                GenerateConvertRawValueMethod(xsd, node),
                GenerateFromReadMethodForEnumType(node, enumType)
            };

            ClassDeclarationSyntax declaration = SyntaxFactory.ClassDeclaration(className)
                                                              .WithMembers(SyntaxFactory.List(members))
                                                              .WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(new[] {
                                                                  (BaseTypeSyntax)SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(baseClass)),
                                                              })))
                                                              .WithModifiers(SyntaxFactory.TokenList(
                                                                  SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                                                                  SyntaxFactory.Token(SyntaxKind.PartialKeyword)));

            return declaration;
        }

        private static ConstructorDeclarationSyntax GenerateProtectedConstructorForCollectionItem(string className)
        {
            // parameters
            var tagNameParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("tagName"))
            .WithType(SyntaxFactory.IdentifierName("string"));

            var parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(new[] { tagNameParameter }));

            // arguments
            var tagNameArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("tagName"));

            var argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(new[] { tagNameArgument }));

            var declaration = SyntaxFactory.ConstructorDeclaration(className)
                .WithInitializer(SyntaxFactory.ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, argumentList))
                .WithParameterList(parameterList)
                .WithBody(SyntaxFactory.Block())
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword)));

            return declaration;
        }

        private static ConstructorDeclarationSyntax GeneratePublicConstructor(INode node, string className, bool withTagNameParameter, bool withCustomTagNameParameter, bool withTypeMappingParameter, bool withUseCDataParameter)
        {
            // arguments
            List<ArgumentSyntax> arguments = new List<ArgumentSyntax>();

            if (withTagNameParameter)
            {
                ArgumentSyntax tagNameArgument;
                if (withCustomTagNameParameter)
                {
                    tagNameArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("tagName"));
                }
                else
                {
                    tagNameArgument = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(node.Name)));
                }

                arguments.Add(tagNameArgument);
            }

            if (withTypeMappingParameter && node is Element e)
            {
                var typeDictionaryArgument = SyntaxFactory.Argument(GenerateTypeMappingDictionary(e));

                arguments.Add(typeDictionaryArgument);
            }

            if (withUseCDataParameter)
            {
                var useCDataArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("useCDATA"))
                    .WithNameColon(SyntaxFactory.NameColon(SyntaxFactory.IdentifierName("useCDATA")));
                arguments.Add(useCDataArgument);
            }

            var argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(arguments));

            // parameters
            List<ParameterSyntax> parameters = new List<ParameterSyntax>();

            if (withTagNameParameter && withCustomTagNameParameter)
            {
                var tagNameParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("tagName"))
                    .WithType(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.StringKeyword)));
                parameters.Add(tagNameParameter);
            }

            if (withUseCDataParameter)
            {
                var useCDataParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("useCDATA"))
                    .WithType(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.BoolKeyword)))
                    .WithDefault(SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)));
                parameters.Add(useCDataParameter);
            }

            // body
            var body = SyntaxFactory.Block(
                SyntaxFactory.SingletonList<StatementSyntax>(
                    SyntaxFactory.ExpressionStatement(
                        SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("OnCreated"))
                        )));

            var declaration = SyntaxFactory.ConstructorDeclaration(className)
                .WithInitializer(SyntaxFactory.ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, argumentList))
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(parameters)))
                .WithBody(body)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            string doc = $"Creates a new instance of this class, that represents a {node.Name} node. None of it's properties will be set.";
            SyntaxTrivia docTrivia = Tools.CreateDocumentationTrivia(doc);
            declaration = declaration.WithLeadingTrivia(SyntaxFactory.TriviaList(docTrivia));

            return declaration;
        }

        private static ConstructorDeclarationSyntax GeneratePublicConstructorWithValue(INode node, string className, string valueType, bool withTagNameParameter, bool withCustomTagNameParameter, bool withUseCDataParameter)
        {
            // arguments
            List<ArgumentSyntax> arguments = new List<ArgumentSyntax>();

            if (withTagNameParameter)
            {
                ArgumentSyntax tagNameArgument;
                if (withCustomTagNameParameter)
                {
                    tagNameArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("tagName"));
                }
                else
                {
                    tagNameArgument = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(node.Name)));
                }

                arguments.Add(tagNameArgument);
            }

            arguments.Add(SyntaxFactory.Argument(SyntaxFactory.IdentifierName("value")));

            if (withUseCDataParameter)
            {
                var useCDataArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("useCDATA"))
                    .WithNameColon(SyntaxFactory.NameColon(SyntaxFactory.IdentifierName("useCDATA")));
                arguments.Add(useCDataArgument);
            }

            var argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(arguments));

            // parameters
            List<ParameterSyntax> parameters = new List<ParameterSyntax>();

            if (withTagNameParameter && withCustomTagNameParameter)
            {
                var tagNameParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("tagName"))
                    .WithType(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.StringKeyword)));
                parameters.Add(tagNameParameter);
            }

            parameters.Add(SyntaxFactory.Parameter(SyntaxFactory.Identifier("value"))
                .WithType(SyntaxFactory.IdentifierName(valueType)));

            if (withUseCDataParameter)
            {
                var useCDataParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("useCDATA"))
                    .WithType(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.BoolKeyword)))
                    .WithDefault(SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)));
                parameters.Add(useCDataParameter);
            }

            var declaration = SyntaxFactory.ConstructorDeclaration(className)
                .WithInitializer(SyntaxFactory.ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, argumentList))
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(parameters)))
                .WithBody(SyntaxFactory.Block())
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            return declaration;
        }

        private static ConstructorDeclarationSyntax GenerateInternalConstructor(INode node, string className, bool withEditNodeParameter, bool withTypeMappingParameter, bool withUseCDataParameter)
        {
            string intfName = "I" + className;

            // parameters
            List<ParameterSyntax> parameters = new List<ParameterSyntax>
            {
                SyntaxFactory.Parameter(SyntaxFactory.Identifier("read"))
                             .WithType(SyntaxFactory.IdentifierName("Read." + intfName)),
                SyntaxFactory.Parameter(SyntaxFactory.Identifier("parent"))
                             .WithType(SyntaxFactory.IdentifierName("IEditableNode"))
            };

            if (withEditNodeParameter)
            {
                parameters.Add(SyntaxFactory.Parameter(SyntaxFactory.Identifier("editNode"))
                    .WithType(SyntaxFactory.IdentifierName("XmlElement")));
            }

            if (withUseCDataParameter)
            {
                var useCDataParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("useCDATA"))
                    .WithType(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.BoolKeyword)))
                    .WithDefault(SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)));
                parameters.Add(useCDataParameter);
            }

            var parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(parameters));

            // base initializer
            List<ArgumentSyntax> arguments = new List<ArgumentSyntax>
            {
                SyntaxFactory.Argument(SyntaxFactory.IdentifierName("read")),
                SyntaxFactory.Argument(SyntaxFactory.IdentifierName("parent"))
            };

            if (withEditNodeParameter)
            {
                arguments.Add(SyntaxFactory.Argument(SyntaxFactory.IdentifierName("editNode")));
            }

            if (withTypeMappingParameter && node is Element e)
            {
                var typeDictionaryArgument = SyntaxFactory.Argument(GenerateTypeMappingDictionary(e));

                arguments.Add(typeDictionaryArgument);
            }

            if (withUseCDataParameter)
            {
                var useCDataArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("useCDATA"))
                    .WithNameColon(SyntaxFactory.NameColon(SyntaxFactory.IdentifierName("useCDATA")));
                arguments.Add(useCDataArgument);
            }

            var argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(arguments));

            var declaration = SyntaxFactory.ConstructorDeclaration(className)
                .WithParameterList(parameterList)
                .WithInitializer(SyntaxFactory.ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, argumentList))
                .WithBody(SyntaxFactory.Block())
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.InternalKeyword)));

            return declaration;
        }

        private static ConstructorDeclarationSyntax GenerateConstructorForEnumClass(string className, string enumType)
        {
            // parameters
            var modelParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("readNode"))
                .WithType(SyntaxFactory.IdentifierName("Read.IValueTag<" + enumType + ">"));
            var parentParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("parent"))
                .WithType(SyntaxFactory.IdentifierName("IEditableNode"));

            ParameterListSyntax parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(new[] { modelParameter, parentParameter }));

            // base initializer
            ArgumentSyntax readNodeArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("readNode"));
            ArgumentSyntax parentArgument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("parent"));

            ArgumentListSyntax argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(new[] { readNodeArgument, parentArgument }));

            var declaration = SyntaxFactory.ConstructorDeclaration(className)
                .WithParameterList(parameterList)
                .WithInitializer(SyntaxFactory.ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, argumentList))
                .WithBody(SyntaxFactory.Block())
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.InternalKeyword)));

            return declaration;
        }

        private static MethodDeclarationSyntax GenerateFromReadMethod(ProtocolXsd xsd, ElementNode element, bool isValueType, Dictionary<INode, string> memberNames, bool withCustomTagNameArgument)
        {
            string className = GetClassName(element);
            string intfName = GetInterfaceName(element);

            List<StatementSyntax> statements = new List<StatementSyntax>();

            // if (read == null) return null;
            statements.Add(SyntaxFactory.IfStatement(
                SyntaxFactory.BinaryExpression(
                    SyntaxKind.EqualsExpression,
                    SyntaxFactory.IdentifierName("read"),
                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)),
                SyntaxFactory.ReturnStatement(
                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))));

            // var item = new ParamsParamDisplayPositions();
            {
                var arguments = new List<ArgumentSyntax>();

                if (withCustomTagNameArgument)
                {
                    var argument = SyntaxFactory.Argument(SyntaxFactory.IdentifierName("read.TagName"));
                    arguments.Add(argument);
                }

                statements.Add(SyntaxFactory.LocalDeclarationStatement(
                        SyntaxFactory.VariableDeclaration(
                            SyntaxFactory.IdentifierName("var"))
                        .WithVariables(
                            SyntaxFactory.SingletonSeparatedList(
                                SyntaxFactory.VariableDeclarator(
                                    SyntaxFactory.Identifier("item"))
                                .WithInitializer(
                                    SyntaxFactory.EqualsValueClause(
                                        SyntaxFactory.ObjectCreationExpression(
                                            SyntaxFactory.IdentifierName(className))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList<ArgumentSyntax>(arguments)))))))));
            }

            if (isValueType)
            {
                // item.Value = read.Value;
                var valueExpression = SyntaxFactory.ExpressionStatement(
                    SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("item"), SyntaxFactory.IdentifierName("Value")),
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("read"), SyntaxFactory.IdentifierName("Value"))));
                statements.Add(valueExpression);
            }

            // child elements and attributes
            statements.AddRange(GenerateFromReadMethodParts(xsd, element, memberNames));

            if (element.IsCollection)
            {
                var foreachContent = new List<StatementSyntax>();

                var collectionItemElements = element.GetCollectionItemElements().ToList();
                if (collectionItemElements.Count == 1)
                {
                    var first = collectionItemElements.First();

                    if (xsd.KnownTypes.TryGetValue(first.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
                    {
                        foreachContent.Add(GenerateFromReadMethodPartForCollection(GetClassName(kt)));
                    }
                    else
                    {
                        foreachContent.Add(GenerateFromReadMethodPartForCollection(GetClassName(first)));
                    }
                }
                else
                {
                    foreachContent.Add(GenerateFromReadMethodPartForCollection(GetClassName(element) + "Item", isItem: true));
                }

                var foreachStatement = SyntaxFactory.ForEachStatement(
                    SyntaxFactory.IdentifierName("var"),
                    SyntaxFactory.Identifier("x"),
                    SyntaxFactory.IdentifierName("read"),
                    SyntaxFactory.Block(SyntaxFactory.List(foreachContent)));
                statements.Add(foreachStatement);
            }


            // return item;
            statements.Add(SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("item")));

            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.IdentifierName(className),
                SyntaxFactory.Identifier("FromRead"))
            .WithModifiers(
                SyntaxFactory.TokenList(
                    new[]{ SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                           SyntaxFactory.Token(SyntaxKind.StaticKeyword)}))
            .WithParameterList(
                SyntaxFactory.ParameterList(
                    SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Parameter(SyntaxFactory.Identifier("read"))
                            .WithType(
                                SyntaxFactory.IdentifierName("Read." + intfName)))))
            .WithBody(
                SyntaxFactory.Block(SyntaxFactory.List(statements)));

            return declaration;
        }

        private static MemberDeclarationSyntax GenerateFromReadMethodForEnumType(INode node, string enumType)
        {
            string className = GetClassName(node.Parent) + Tools.ToPascalCase(node.Name);

            List<StatementSyntax> statements = new List<StatementSyntax>();

            statements.Add(SyntaxFactory.IfStatement(
                SyntaxFactory.BinaryExpression(
                    SyntaxKind.EqualsExpression,
                    SyntaxFactory.IdentifierName("read"),
                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)),
                SyntaxFactory.ReturnStatement(
                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))));

            statements.Add(SyntaxFactory.LocalDeclarationStatement(
                    SyntaxFactory.VariableDeclaration(
                        SyntaxFactory.IdentifierName("var"))
                    .WithVariables(
                        SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                            SyntaxFactory.VariableDeclarator(
                                SyntaxFactory.Identifier("item"))
                            .WithInitializer(
                                SyntaxFactory.EqualsValueClause(
                                    SyntaxFactory.ObjectCreationExpression(
                                        SyntaxFactory.IdentifierName(className))
                                    .WithArgumentList(
                                        SyntaxFactory.ArgumentList())))))));

            // item.Value = read.Value;
            statements.Add(SyntaxFactory.ExpressionStatement(
                SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("item"), SyntaxFactory.IdentifierName("Value")),
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("read"), SyntaxFactory.IdentifierName("Value")))));

            statements.Add(SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("item")));

            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.IdentifierName(className),
                SyntaxFactory.Identifier("FromRead"))
            .WithModifiers(
                SyntaxFactory.TokenList(
                    new[]{ SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                           SyntaxFactory.Token(SyntaxKind.NewKeyword),
                           SyntaxFactory.Token(SyntaxKind.StaticKeyword)}))
            .WithParameterList(
                SyntaxFactory.ParameterList(
                    SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Parameter(SyntaxFactory.Identifier("read"))
                            .WithType(
                                SyntaxFactory.IdentifierName("Read.IValueTag<" + enumType + ">")))))
            .WithBody(
                SyntaxFactory.Block(SyntaxFactory.List(statements)));

            return declaration;
        }

        private static MemberDeclarationSyntax GenerateFromReadMethodForCollectionItem(ElementNode element, string className)
        {
            string intfName = "I" + className;

            List<StatementSyntax> statements = new List<StatementSyntax>();

            // if (read == null) return null;
            statements.Add(SyntaxFactory.IfStatement(
                SyntaxFactory.BinaryExpression(
                    SyntaxKind.EqualsExpression,
                    SyntaxFactory.IdentifierName("read"),
                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)),
                SyntaxFactory.ReturnStatement(
                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))));

            // switch
            var switchSections = new List<SwitchSectionSyntax>();

            foreach (var e in element.Elements)
            {
                // case "Action":  return GroupsGroupContentAction.FromRead(read as Read.IGroupsGroupContentAction);

                string itemClassName = GetClassName(e);
                string itemIntfName = "I" + itemClassName;

                var label = SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(e.Name));
                var returnExpression = SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName(itemClassName),
                            SyntaxFactory.IdentifierName("FromRead")))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                SyntaxFactory.Argument(
                                    SyntaxFactory.BinaryExpression(
                                        SyntaxKind.AsExpression,
                                        SyntaxFactory.IdentifierName("read"),
                                        SyntaxFactory.QualifiedName(
                                            SyntaxFactory.IdentifierName("Read"),
                                            SyntaxFactory.IdentifierName(itemIntfName)))))));

                var section = SyntaxFactory.SwitchSection()
                   .WithLabels(SyntaxFactory.SingletonList<SwitchLabelSyntax>(SyntaxFactory.CaseSwitchLabel(label)))
                   .WithStatements(SyntaxFactory.SingletonList<StatementSyntax>(
                           SyntaxFactory.ReturnStatement(returnExpression)));
                switchSections.Add(section);
            }

            // default: return new GroupsGroupContentItem(read.TagName);
            var defaultSection = SyntaxFactory.SwitchSection()
                .WithLabels(SyntaxFactory.SingletonList<SwitchLabelSyntax>(SyntaxFactory.DefaultSwitchLabel()))
                .WithStatements(
                    SyntaxFactory.SingletonList<StatementSyntax>(
                        SyntaxFactory.ReturnStatement(
                            SyntaxFactory.ObjectCreationExpression(
                                SyntaxFactory.IdentifierName(className))
                            .WithArgumentList(
                                SyntaxFactory.ArgumentList(
                                    SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                        SyntaxFactory.Argument(SyntaxFactory.IdentifierName("read.TagName"))))))));
            switchSections.Add(defaultSection);

            var switchStatement = SyntaxFactory.SwitchStatement(SyntaxFactory.IdentifierName("read.TagName"))
                .WithSections(SyntaxFactory.List(switchSections));

            statements.Add(switchStatement);


            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.IdentifierName(intfName),
                SyntaxFactory.Identifier("ItemFromRead"))
            .WithModifiers(
                SyntaxFactory.TokenList(
                    new[]{ SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                           SyntaxFactory.Token(SyntaxKind.StaticKeyword)}))
            .WithParameterList(
                SyntaxFactory.ParameterList(
                    SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Parameter(SyntaxFactory.Identifier("read"))
                            .WithType(
                                SyntaxFactory.IdentifierName("Read." + intfName)))))
            .WithBody(
                SyntaxFactory.Block(SyntaxFactory.List(statements)));

            return declaration;
        }

        private static IEnumerable<StatementSyntax> GenerateFromReadMethodParts(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames)
        {
            // for child elements
            foreach (var e in element.Elements.Where(e => !e.IsCollectionItem))
            {
                yield return GenerateFromReadMethodPartForElement(xsd, element, memberNames, e);
            }

            // for attributes
            foreach (var a in element.Attributes)
            {
                yield return GenerateFromReadMethodPartForAttribute(xsd, element, memberNames, a);
            }
        }

        private static StatementSyntax GenerateFromReadMethodPartForElement(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames, Element e)
        {
            var propName = memberNames[e];
            string typeName;

            if (element.GetCollectionItemElements().Skip(1).Any())
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
                    typeName = "ElementValue<" + valueType + ">";
                }
            }
            else
            {
                typeName = GetClassName(e);
            }

            return GenerateFromReadMethodPart(typeName, propName);
        }

        private static StatementSyntax GenerateFromReadMethodPartForAttribute(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames, Attribute a)
        {
            string propName = memberNames[a];
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
                    typeName = "AttributeValue<" + valueType + ">";
                }
            }
            else
            {
                typeName = "AttributeValue<string>";
            }

            return GenerateFromReadMethodPart(typeName, propName);
        }

        private static StatementSyntax GenerateFromReadMethodPart(string typeName, string propertyName)
        {
            // item.Id = AttributeValue<uint?>.FromRead(read.Id);

            return SyntaxFactory.ExpressionStatement(
                SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("item"),
                        SyntaxFactory.IdentifierName(propertyName)),
                    SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName(typeName),
                            SyntaxFactory.IdentifierName("FromRead")))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                SyntaxFactory.Argument(
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.IdentifierName("read"),
                                        SyntaxFactory.IdentifierName(propertyName))))))));
        }

        private static ExpressionStatementSyntax GenerateFromReadMethodPartForCollection(string typeName, bool isItem = false)
        {
            return SyntaxFactory.ExpressionStatement(
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("item"),
                        SyntaxFactory.IdentifierName("Add")))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.InvocationExpression(
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.IdentifierName(typeName),
                                        SyntaxFactory.IdentifierName(isItem ? "ItemFromRead" : "FromRead")))
                                .WithArgumentList(
                                    SyntaxFactory.ArgumentList(
                                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                            SyntaxFactory.Argument(
                                                SyntaxFactory.IdentifierName("x"))))))))));
        }

        private static MethodDeclarationSyntax GenerateInitializeMethod(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames)
        {
            string intfName = GetInterfaceName(element);

            List<StatementSyntax> statements = new List<StatementSyntax>();

            statements.AddRange(GenerateInitializeMethodParts(xsd, element, memberNames));

            if (statements.Count > 0)
            {
                statements.Insert(0, SyntaxFactory.IfStatement(
                    SyntaxFactory.BinaryExpression(
                        SyntaxKind.EqualsExpression,
                        SyntaxFactory.IdentifierName("read"),
                        SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)),
                    SyntaxFactory.ReturnStatement()));
            }

            List<SyntaxToken> modifiers = new List<SyntaxToken>
            {
                SyntaxFactory.Token(SyntaxKind.ProtectedKeyword),
                SyntaxFactory.Token(SyntaxKind.OverrideKeyword)
            };

            var declaration = SyntaxFactory.MethodDeclaration(
                                               SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                                               SyntaxFactory.Identifier("Initialize"))
                                           .WithModifiers(SyntaxFactory.TokenList(modifiers))
                                           .WithParameterList(
                                               SyntaxFactory.ParameterList(
                                                   SyntaxFactory.SeparatedList<ParameterSyntax>(
                                                       new[]{
                                                           SyntaxFactory.Parameter(SyntaxFactory.Identifier("read"))
                                                                        .WithType(SyntaxFactory.IdentifierName("Read." + intfName)),
                                                           SyntaxFactory.Parameter(SyntaxFactory.Identifier("editNode"))
                                                                        .WithType(SyntaxFactory.IdentifierName("XmlElement"))
                                                       })))
                                           .WithBody(
                                               SyntaxFactory.Block(SyntaxFactory.List(statements)));

            return declaration;
        }

        private static MethodDeclarationSyntax GenerateInitializeMethodForItemClass(string className)
        {
            string intfName = "I" + className;

            var declaration = SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                    SyntaxFactory.Identifier("Initialize"))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        new[]{
                            SyntaxFactory.Token(SyntaxKind.ProtectedKeyword),
                            SyntaxFactory.Token(SyntaxKind.OverrideKeyword)}))
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                            new[]{
                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("read"))
                                    .WithType(SyntaxFactory.IdentifierName("Read." + intfName)),
                                SyntaxFactory.Parameter(SyntaxFactory.Identifier("editNode"))
                                    .WithType(SyntaxFactory.IdentifierName("XmlElement"))
                                })))
                .WithBody(
                    SyntaxFactory.Block());

            return declaration;
        }

        private static IEnumerable<StatementSyntax> GenerateInitializeMethodParts(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames)
        {
            // for child elements
            foreach (var e in element.Elements.Where(e => !e.IsCollectionItem))
            {
                yield return GenerateInitializeMethodPartForElement(xsd, element, memberNames, e);
            }

            // for attributes
            foreach (var a in element.Attributes)
            {
                yield return GenerateInitializeMethodPartForAttribute(xsd, element, memberNames, a);
            }
        }

        private static StatementSyntax GenerateInitializeMethodPartForElement(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames, Element e)
        {
            string propName = memberNames[e];
            string fieldName = "_" + Tools.WithLowercaseFirstLetter(propName);
            string typeName;
            bool isValueType = false;

            if (element.GetCollectionItemElements().Skip(1).Any())
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
                    typeName = "ElementValue<" + valueType + ">";
                }

                isValueType = true;
            }
            else
            {
                typeName = GetClassName(e);
            }

            return GenerateInitializeMethodPart(typeName, e.Name, fieldName, propName, withEditNodeArgument: !isValueType);
        }

        private static StatementSyntax GenerateInitializeMethodPartForAttribute(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames, Attribute a)
        {
            string propName = memberNames[a];
            string fieldName = "_" + Tools.WithLowercaseFirstLetter(propName);
            string typeName;
            bool isValueType = false;

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
                    typeName = "AttributeValue<" + valueType + ">";
                }

                isValueType = true;
            }
            else
            {
                typeName = "AttributeValue<string>";
                isValueType = true;
            }

            return GenerateInitializeMethodPart(typeName, a.Name, fieldName, propName, withEditNodeArgument: !isValueType);
        }

        private static StatementSyntax GenerateInitializeMethodPart(string typeName, string tagName, string fieldName, string propertyName, bool withEditNodeArgument)
        {
            // _id = Read.Id != null ? new AttributeValue<uint?>(read.Id, this) : null;

            var arguments = new List<ArgumentSyntax>();

            arguments.Add(SyntaxFactory.Argument(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("read"),
                        SyntaxFactory.IdentifierName(propertyName))));

            arguments.Add(SyntaxFactory.Argument(SyntaxFactory.ThisExpression()));

            if (withEditNodeArgument)
            {
                arguments.Add(SyntaxFactory.Argument(
                SyntaxFactory.ElementAccessExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("editNode"),
                        SyntaxFactory.IdentifierName("Element")))
                .WithArgumentList(
                    SyntaxFactory.BracketedArgumentList(
                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                            SyntaxFactory.Argument(
                                SyntaxFactory.LiteralExpression(
                                    SyntaxKind.StringLiteralExpression,
                                    SyntaxFactory.Literal(tagName))))))));
            }

            return SyntaxFactory.ExpressionStatement(
                SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.IdentifierName(fieldName),
                    SyntaxFactory.ConditionalExpression(
                        SyntaxFactory.BinaryExpression(
                            SyntaxKind.NotEqualsExpression,
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName("read"),
                                SyntaxFactory.IdentifierName(propertyName)),
                            SyntaxFactory.LiteralExpression(
                                SyntaxKind.NullLiteralExpression)),
                        SyntaxFactory.ObjectCreationExpression(
                            SyntaxFactory.IdentifierName(typeName))
                        .WithArgumentList(SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(arguments))),
                        SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))));
        }

        private static MethodDeclarationSyntax GenerateGetValueToWriteMethod(ProtocolXsd xsd, INode element)
        {
            var ifNullStatement = SyntaxFactory.IfStatement(
                    SyntaxFactory.BinaryExpression(
                        SyntaxKind.EqualsExpression,
                        SyntaxFactory.IdentifierName("Value"),
                        SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)),
                    SyntaxFactory.ReturnStatement(
                        SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)));

            // expression
            StatementSyntax returnStatement;
            if (TryGetEnum(xsd, element.SchemaType, out var e))
            {
                // return Enums.EnumCpeAlignmentConverter.ConvertBack(Value);
                returnStatement = SyntaxFactory.ReturnStatement(
                                SyntaxFactory.InvocationExpression(
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.MemberAccessExpression(
                                            SyntaxKind.SimpleMemberAccessExpression,
                                            SyntaxFactory.IdentifierName("Enums"),
                                            SyntaxFactory.IdentifierName(e.Name + "Converter")),
                                        SyntaxFactory.IdentifierName("ConvertBack")))
                                .WithArgumentList(
                                    SyntaxFactory.ArgumentList(
                                        SyntaxFactory.SingletonSeparatedList(
                                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName("Value.Value"))))));
            }
            else
            {
                // return Value;
                returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("Value.Value"));
            }

            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.StringKeyword)),
                SyntaxFactory.Identifier("GetValueToWrite"))
                    .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword)))
                    .WithBody(SyntaxFactory.Block(SyntaxFactory.List(new[] { ifNullStatement, returnStatement })));

            return declaration;
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

        private static IEnumerable<FieldDeclarationSyntax> GenerateFields(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames)
        {
            var members = new List<FieldDeclarationSyntax>();

            // fields for child elements
            foreach (var e in element.Elements.Where(e => !e.IsCollectionItem))
            {
                GenerateFieldForElement(xsd, element, memberNames, e, members);
            }

            // fields for attributes
            foreach (var a in element.Attributes)
            {
                GenerateFieldForAttribute(xsd, element, memberNames, a, members);
            }

            return members;
        }

        private static void GenerateFieldForElement(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames, Element e, List<FieldDeclarationSyntax> members)
        {
            var propName = memberNames[e];
            var fieldName = "_" + Tools.WithLowercaseFirstLetter(propName);
            string typeName;

            if (element.GetCollectionItemElements().Skip(1).Any())
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
                    typeName = "ElementValue<" + valueType + ">";
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
                    typeName = "AttributeValue<" + valueType + ">";
                }
            }
            else
            {
                typeName = "AttributeValue<string>";
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
                GeneratePropertyForElement(xsd, element, memberNames, e, members);
            }

            // properties for attributes
            foreach (var a in element.Attributes)
            {
                GeneratePropertyForAttribute(xsd, element, memberNames, a, members);
            }

            return members;
        }

        private static void GeneratePropertyForElement(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames, Element e, List<PropertyDeclarationSyntax> members)
        {
            var propName = memberNames[e];
            string typeName;
            StatementSyntax elementHandler;

            if (element.GetCollectionItemElements().Skip(1).Any())
            {
                typeName = GetClassName(e);
                elementHandler = GenerateCombinedTagHandler(e.Name);
            }
            else if (xsd.KnownTypes.TryGetValue(e.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
            {
                typeName = GetClassName(kt);
                elementHandler = GenerateCombinedTagHandler(e.Name);
            }
            else if (TryDetermineValueType(xsd, e.Definition.ElementSchemaType, out string valueType, out bool isEnum) && !e.HasMixedContent)
            {
                if (isEnum)
                {
                    typeName = GetClassName(e);
                }
                else
                {
                    typeName = "ElementValue<" + valueType + ">";
                }

                elementHandler = GenerateElementHandler(e.Name);
            }
            else
            {
                typeName = GetClassName(e);
                elementHandler = GenerateCombinedTagHandler(e.Name);
            }

            members.Add(GenerateProperty(propName, typeName, e.Documentation, elementHandler));
        }

        private static void GeneratePropertyForAttribute(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames, Attribute a, List<PropertyDeclarationSyntax> members)
        {
            string propName = memberNames[a];
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
                    typeName = "AttributeValue<" + valueType + ">";
                }
            }
            else
            {
                typeName = "AttributeValue<string>";
            }

            var attributeHandler = GenerateAttributeHandler(a.Name);

            members.Add(GenerateProperty(propName, typeName, a.Documentation, attributeHandler));
        }

        private static PropertyDeclarationSyntax GenerateProperty(string identifier, string typeName, string documentation, StatementSyntax handler)
        {
            TypeSyntax typeSyntax = SyntaxFactory.ParseTypeName(typeName);
            string fieldName = "_" + Tools.WithLowercaseFirstLetter(identifier);

            // GETTER
            var getter = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                .WithBody(SyntaxFactory.Block(
                    SyntaxFactory.SingletonList<StatementSyntax>(
                        SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(fieldName)))));

            // SETTER

            // if (_id != value)
            // {
            //     _id = value;
            //     AttributeHandler.Assign(value, this, "id");
            // }

            var assign = SyntaxFactory.ExpressionStatement(
                            SyntaxFactory.AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                SyntaxFactory.IdentifierName(fieldName),
                                SyntaxFactory.IdentifierName("value")));

            var ifStatement = SyntaxFactory.IfStatement(
                SyntaxFactory.BinaryExpression(
                    SyntaxKind.NotEqualsExpression,
                    SyntaxFactory.IdentifierName(fieldName),
                    SyntaxFactory.IdentifierName("value")),
                SyntaxFactory.Block(
                    SyntaxFactory.List(new[] { assign, handler })));

            var setter = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                .WithBody(SyntaxFactory.Block(ifStatement));

            var declaration = SyntaxFactory.PropertyDeclaration(typeSyntax, identifier)
                .WithAccessorList(SyntaxFactory.AccessorList(SyntaxFactory.List(new[] { getter, setter })))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            if (!String.IsNullOrWhiteSpace(documentation))
            {
                SyntaxTrivia docTrivia = Tools.CreateDocumentationTrivia(documentation);
                declaration = declaration.WithLeadingTrivia(SyntaxFactory.TriviaList(docTrivia));
            }

            return declaration;
        }

        private static StatementSyntax GenerateAttributeHandler(string name)
        {
            return SyntaxFactory.ExpressionStatement(
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("AttributeHandler"),
                        SyntaxFactory.IdentifierName("Assign")))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                            new SyntaxNodeOrToken[]{
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("value")),
                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                    SyntaxFactory.Argument(
                        SyntaxFactory.ThisExpression()),
                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                    SyntaxFactory.Argument(
                        SyntaxFactory.LiteralExpression(
                            SyntaxKind.StringLiteralExpression,
                            SyntaxFactory.Literal(name)))
                            }))));
        }

        private static StatementSyntax GenerateElementHandler(string tagName)
        {
            return SyntaxFactory.ExpressionStatement(
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("ElementHandler"),
                        SyntaxFactory.IdentifierName("Assign")))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                            new SyntaxNodeOrToken[]{
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("value")),
                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                    SyntaxFactory.Argument(
                        SyntaxFactory.ThisExpression()),
                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                    SyntaxFactory.Argument(
                        SyntaxFactory.LiteralExpression(
                            SyntaxKind.StringLiteralExpression,
                            SyntaxFactory.Literal(tagName)))
                            }))));
        }

        private static StatementSyntax GenerateCombinedTagHandler(string tagName)
        {
            return SyntaxFactory.ExpressionStatement(
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("CombinedTagHandler"),
                        SyntaxFactory.IdentifierName("Assign")))
                .WithArgumentList(
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                            new SyntaxNodeOrToken[]{
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("value")),
                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                    SyntaxFactory.Argument(
                        SyntaxFactory.ThisExpression()),
                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                    SyntaxFactory.Argument(
                        SyntaxFactory.LiteralExpression(
                            SyntaxKind.StringLiteralExpression,
                            SyntaxFactory.Literal(tagName)))
                            }))));
        }

        private static IEnumerable<MethodDeclarationSyntax> GenerateGetOrCreateMethods(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames)
        {
            var members = new List<MethodDeclarationSyntax>();

            // properties for child elements
            foreach (var e in element.Elements.Where(e => !e.IsCollectionItem))
            {
                GenerateGetOrCreateMethodForElement(xsd, element, memberNames, e, members);
            }

            // properties for attributes
            foreach (var a in element.Attributes)
            {
                GenerateGetOrCreateMethodForAttribute(xsd, element, memberNames, a, members);
            }

            return members;
        }

        private static void GenerateGetOrCreateMethodForElement(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames, Element e, List<MethodDeclarationSyntax> members)
        {
            var propName = memberNames[e];
            string typeName;
            string tagName = null;

            if (element.GetCollectionItemElements().Skip(1).Any())
            {
                return;
            }

            if (xsd.KnownTypes.TryGetValue(e.SchemaType.QualifiedName.ToString(), out var kt) && GenerateKnownType(kt))
            {
                typeName = GetClassName(kt);
                tagName = e.Name;
            }
            else if (TryDetermineValueType(xsd, e.Definition.ElementSchemaType, out string valueType, out bool isEnum) && !e.HasMixedContent)
            {
                if (isEnum)
                {
                    typeName = GetClassName(e);
                }
                else
                {
                    typeName = "ElementValue<" + valueType + ">";
                }
            }
            else
            {
                typeName = GetClassName(e);
            }

            members.Add(GenerateGetOrCreateMethod(propName, typeName, tagName));
        }

        private static void GenerateGetOrCreateMethodForAttribute(ProtocolXsd xsd, ElementNode element, Dictionary<INode, string> memberNames, Attribute a, List<MethodDeclarationSyntax> members)
        {
            string propName = memberNames[a];
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
                    typeName = "AttributeValue<" + valueType + ">";
                }
            }
            else
            {
                typeName = "AttributeValue<string>";
            }

            members.Add(GenerateGetOrCreateMethod(propName, typeName));
        }

        private static MethodDeclarationSyntax GenerateGetOrCreateMethod(string identifier, string typeName, string tagName = null)
        {
            SeparatedSyntaxList<ArgumentSyntax> constructorArguments = default(SeparatedSyntaxList<ArgumentSyntax>);

            if (!String.IsNullOrWhiteSpace(tagName))
            {
                constructorArguments = SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                    SyntaxFactory.Argument(
                        SyntaxFactory.LiteralExpression(
                            SyntaxKind.StringLiteralExpression,
                            SyntaxFactory.Literal(tagName))));
            }

            var method = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.IdentifierName(typeName),
                SyntaxFactory.Identifier("GetOrCreate" + identifier))
            .WithModifiers(
                SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
            .WithBody(
                SyntaxFactory.Block(
                    SyntaxFactory.IfStatement(
                        SyntaxFactory.BinaryExpression(
                            SyntaxKind.EqualsExpression,
                            SyntaxFactory.IdentifierName(identifier),
                            SyntaxFactory.LiteralExpression(
                                SyntaxKind.NullLiteralExpression)),
                        SyntaxFactory.ExpressionStatement(
                            SyntaxFactory.AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                SyntaxFactory.IdentifierName(identifier),
                                SyntaxFactory.ObjectCreationExpression(
                                    SyntaxFactory.IdentifierName(typeName))
                                .WithArgumentList(
                                    SyntaxFactory.ArgumentList(constructorArguments))))),
                    SyntaxFactory.ReturnStatement(
                        SyntaxFactory.IdentifierName(identifier))));

            return method;
        }
    }
}
