namespace Protocol.Generator.Generators
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using Protocol.Generator.XSD;

    internal class ReadProtocolVisitorGenerator : GeneratorBase
    {
        public static NamespaceDeclarationSyntax GenerateRootNamespace(ProtocolXsd xsd)
        {
            NameSyntax nameSyntax = SyntaxFactory.IdentifierName("Skyline.DataMiner.CICD.Models.Protocol.Read");

            var members = new List<MemberDeclarationSyntax> { GenerateClass(xsd) };

            NamespaceDeclarationSyntax declaration = SyntaxFactory.NamespaceDeclaration(nameSyntax)
                                                                  .WithMembers(SyntaxFactory.List(members));

            return declaration;
        }

        private static ClassDeclarationSyntax GenerateClass(ProtocolXsd xsd)
        {
            List<MemberDeclarationSyntax> members = new List<MemberDeclarationSyntax>();

            var root = xsd.Node;
            members.AddRange(GenerateVisitMethodsRecursive(xsd, root));

            // create for known types
            foreach (var type in xsd.KnownTypes.Values)
            {
                if (GenerateKnownType(type))
                {
                    members.AddRange(GenerateVisitMethodsRecursive(xsd, type));
                }
            }

            var declaration = SyntaxFactory.ClassDeclaration("ProtocolVisitor")
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                    SyntaxFactory.Token(SyntaxKind.AbstractKeyword),
                    SyntaxFactory.Token(SyntaxKind.PartialKeyword)))
                .WithMembers(SyntaxFactory.List(members));

            return declaration;
        }

        private static IEnumerable<MethodDeclarationSyntax> GenerateVisitMethodsRecursive(ProtocolXsd xsd, ElementNode element)
        {
            string className = GetClassName(element);

            yield return GenerateVisitMethod(element, className);

            if (element.IsCollection && element.GetCollectionItemElements().Skip(1).Any())
            {
                // generate extra method for (in between) interface for collection items, because there are multiple types
                yield return GenerateVisitMethod(element, className + "Item", onlyDefaultVisit: true);
            }

            foreach (var child in element.Elements)
            {
                if (CreateInterfaceOrClass(xsd, child))
                {
                    foreach (var e in GenerateVisitMethodsRecursive(xsd, child))
                    {
                        yield return e;
                    }
                }
            }
        }

        private static MethodDeclarationSyntax GenerateVisitMethod(ElementNode element, string className, bool onlyDefaultVisit = false)
        {
            string interfaceName = "I" + className;

            List<StatementSyntax> statements = new List<StatementSyntax> { GenerateDefaultVisitCall() };

            if (!onlyDefaultVisit)
            {
                var memberNames = GenerateMemberNames(element);
                statements.AddRange(GenerateVisitMethodParts(element, memberNames));
            }

            return SyntaxFactory.MethodDeclaration(
                SyntaxFactory.PredefinedType(
                    SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                SyntaxFactory.Identifier("Visit" + className))
                    .WithModifiers(
                        SyntaxFactory.TokenList(
                            new[]{
                                SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                                SyntaxFactory.Token(SyntaxKind.VirtualKeyword)}))
                    .WithParameterList(
                        SyntaxFactory.ParameterList(
                            SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("obj"))
                                .WithType(
                                    SyntaxFactory.IdentifierName(interfaceName)))))
                    .WithBody(
                        SyntaxFactory.Block(SyntaxFactory.List(statements)));
        }

        private static IEnumerable<StatementSyntax> GenerateVisitMethodParts(ElementNode element, Dictionary<INode, string> memberNames)
        {
            // for child elements
            if (element.GetCollectionItemElements().Skip(1).Any())
            {
                // this case is covered by the foreach loop
            }
            else
            {
                foreach (var e in element.Elements.Where(e => !e.IsCollectionItem))
                {
                    var propName = memberNames[e];
                    yield return GenerateVisitMethodPart(propName);
                }
            }

            // for attributes
            foreach (var a in element.Attributes)
            {
                string propName = memberNames[a];
                yield return GenerateVisitMethodPart(propName);
            }

            // collections
            if (element.IsCollection)
            {
                // foreach (var x in obj) x.Accept(this);
                var foreachStatement = SyntaxFactory.ForEachStatement(
                    SyntaxFactory.IdentifierName("var"),
                    SyntaxFactory.Identifier("x"),
                    SyntaxFactory.IdentifierName("obj"),
                    SyntaxFactory.ExpressionStatement(
                        SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName("x"),
                                SyntaxFactory.IdentifierName("Accept")))
                        .WithArgumentList(
                            SyntaxFactory.ArgumentList(
                                SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                    SyntaxFactory.Argument(SyntaxFactory.ThisExpression()))))));

                yield return foreachStatement;
            }
        }

        private static StatementSyntax GenerateVisitMethodPart(string propertyName)
        {
            // obj.Measurement?.Accept(this);

            return SyntaxFactory.ExpressionStatement(
                SyntaxFactory.ConditionalAccessExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("obj"),
                        SyntaxFactory.IdentifierName(propertyName)),
                    SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberBindingExpression(
                            SyntaxFactory.IdentifierName("Accept")))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                SyntaxFactory.Argument(
                                    SyntaxFactory.ThisExpression()))))));
        }

        private static StatementSyntax GenerateDefaultVisitCall()
        {
            // this.DefaultVisit(obj);

            return SyntaxFactory.ExpressionStatement(
                SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.ThisExpression(),
                            SyntaxFactory.IdentifierName("DefaultVisit")))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                SyntaxFactory.Argument(
                                    SyntaxFactory.IdentifierName("obj"))))));
        }
    }
}
