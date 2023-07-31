namespace Protocol.Generator.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using Protocol.Generator.XSD;

    internal class EnumsGenerator : GeneratorBase
    {
        public static NamespaceDeclarationSyntax GenerateRootNamespace(ProtocolXsd xsd)
        {
            NameSyntax nameSyntax = SyntaxFactory.IdentifierName("Skyline.DataMiner.CICD.Models.Protocol.Enums");

            var members = GenerateEnums(xsd);

            NamespaceDeclarationSyntax declaration = SyntaxFactory.NamespaceDeclaration(nameSyntax)
                .WithMembers(SyntaxFactory.List(members))
                .WithUsings(SyntaxFactory.List(new[]
                {
                    CreateUsing("System"),
                }));

            return declaration;
        }

        private static IEnumerable<MemberDeclarationSyntax> GenerateEnums(ProtocolXsd xsd)
        {
            var members = new List<MemberDeclarationSyntax>();

            foreach (var item in xsd.Enums.Values)
            {
                if (item.Name.StartsWith("Enum") && item.Count > 0)
                {
                    members.Add(GenerateEnum(item));
                    members.Add(GenerateConverter(item));
                }
            }

            return members;
        }

        private static EnumDeclarationSyntax GenerateEnum(EnumList e)
        {
            var members = new List<EnumMemberDeclarationSyntax>();

            foreach (var v in e)
            {
                if (String.IsNullOrWhiteSpace(v.Name))
                {
                    continue;
                }

                EnumMemberDeclarationSyntax enumDeclaration = SyntaxFactory.EnumMemberDeclaration(v.Name);

                if (!String.IsNullOrWhiteSpace(v.Documentation))
                {
                    SyntaxTrivia docTrivia = Tools.CreateDocumentationTrivia(v.Documentation);
                    enumDeclaration = enumDeclaration.WithLeadingTrivia(SyntaxFactory.TriviaList(docTrivia));
                }

                members.Add(enumDeclaration);
            }

            EnumDeclarationSyntax declaration = SyntaxFactory.EnumDeclaration(e.Name)
                .WithMembers(SyntaxFactory.SeparatedList(members))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));

            if (!String.IsNullOrWhiteSpace(e.Documentation))
            {
                SyntaxTrivia docTrivia = Tools.CreateDocumentationTrivia(e.Documentation);
                declaration = declaration.WithLeadingTrivia(SyntaxFactory.TriviaList(docTrivia));
            }

            return declaration;
        }

        private static ClassDeclarationSyntax GenerateConverter(EnumList e)
        {
            ClassDeclarationSyntax declaration = SyntaxFactory.ClassDeclaration(e.Name + "Converter")
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                    SyntaxFactory.Token(SyntaxKind.StaticKeyword),
                    SyntaxFactory.Token(SyntaxKind.PartialKeyword)))
                .WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
                    GenerateConvertMethod(e),
                    GenerateConvertBackMethod(e)
                    }));

            return declaration;
        }

        private static MethodDeclarationSyntax GenerateConvertMethod(EnumList e)
        {
            var inputParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("input"))
                                              .WithType(SyntaxFactory.IdentifierName("string"));

            StatementSyntax ifElseStatement = null;

            foreach (var ev in Enumerable.Reverse(e))
            {
                var label = SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(ev.Value));
                var returnStatement = SyntaxFactory.ReturnStatement(
                    SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName(e.Name),
                        SyntaxFactory.IdentifierName(ev.Name)));

                var ifStatement = SyntaxFactory.IfStatement(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(
                                                                             SyntaxKind.SimpleMemberAccessExpression,
                                                                             SyntaxFactory.IdentifierName("String"),
                                                                             SyntaxFactory.IdentifierName("Equals")))
                                                                         .WithArgumentList(SyntaxFactory.ArgumentList(
                                                                             SyntaxFactory.SeparatedList<ArgumentSyntax>(new SyntaxNodeOrToken[]
                                                                             {
                                                                                 SyntaxFactory.Argument(SyntaxFactory.IdentifierName("input")),
                                                                                 SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                                                 SyntaxFactory.Argument(label),
                                                                                 SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                                                 SyntaxFactory.Argument(SyntaxFactory.MemberAccessExpression(
                                                                                     SyntaxKind.SimpleMemberAccessExpression,
                                                                                     SyntaxFactory.IdentifierName("StringComparison"),
                                                                                     SyntaxFactory.IdentifierName("OrdinalIgnoreCase")))
                                                                             }))),
                    returnStatement);

                if (ifElseStatement == null)
                {
                    ifElseStatement = ifStatement;
                }
                else
                {
                    ifElseStatement = ifStatement.WithElse(SyntaxFactory.ElseClause(ifElseStatement));
                }
            }

            var returnNullStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression));

            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.NullableType(SyntaxFactory.IdentifierName(e.Name)), SyntaxFactory.Identifier("Convert"))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword)))
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SingletonSeparatedList(inputParameter)))
                .WithBody(SyntaxFactory.Block(ifElseStatement, returnNullStatement));

            return declaration;
        }

        private static MethodDeclarationSyntax GenerateConvertBackMethod(EnumList e)
        {
            var inputParameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier("input"))
                .WithType(SyntaxFactory.NullableType(SyntaxFactory.IdentifierName(e.Name)));

            StatementSyntax sanityChecksSection = SyntaxFactory.IfStatement(
                // Condition
                SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression,
                    SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("input"), SyntaxFactory.IdentifierName("HasValue"))),
                // Statement
                SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal("UNDEFINED"))));

            var switchSections = new List<SwitchSectionSyntax>();
            foreach (var ev in e)
            {
                var label = SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.IdentifierName(e.Name),
                    SyntaxFactory.IdentifierName(ev.Name));

                var returnExpression = SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(ev.Value));

                var section = SyntaxFactory.SwitchSection()
                   .WithLabels(SyntaxFactory.SingletonList<SwitchLabelSyntax>(SyntaxFactory.CaseSwitchLabel(label)))
                   .WithStatements(SyntaxFactory.SingletonList<StatementSyntax>(
                           SyntaxFactory.ReturnStatement(returnExpression)));
                switchSections.Add(section);
            }

            var defaultSection = SyntaxFactory.SwitchSection()
                           .WithLabels(SyntaxFactory.SingletonList<SwitchLabelSyntax>(SyntaxFactory.DefaultSwitchLabel()))
                           .WithStatements(SyntaxFactory.SingletonList<StatementSyntax>(
                                   SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))));
            switchSections.Add(defaultSection);

            var switchStatement = SyntaxFactory.SwitchStatement(SyntaxFactory.IdentifierName("input"))
                .WithSections(SyntaxFactory.List(switchSections));
            SyntaxList<StatementSyntax> body = new SyntaxList<StatementSyntax>(sanityChecksSection).AddRange(SyntaxFactory.SingletonList(switchStatement));

            var declaration = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.IdentifierName("string"), SyntaxFactory.Identifier("ConvertBack"))
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword)))
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SingletonSeparatedList(inputParameter)))
                .WithBody(SyntaxFactory.Block(body));

            return declaration;
        }
    }
}
