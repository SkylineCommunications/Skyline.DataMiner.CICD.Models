namespace ProtocolTests.Roslyn
{
    using System;
    using System.Collections.Generic;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    internal class InvocationExpressionWalker : CSharpSyntaxWalker
    {
        private readonly ProtocolModel model;
        private readonly SemanticModel semanticModel;

        public InvocationExpressionWalker(ProtocolModel model, SemanticModel semanticModel, SyntaxWalkerDepth depth = SyntaxWalkerDepth.Node) : base(depth)
        {
            this.model = model;
            this.semanticModel = semanticModel;

            Results = new List<string>();
        }

        public List<string> Results { get; }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            if (node?.Expression is MemberAccessExpressionSyntax memberAccess)
            {
                var name = memberAccess.Name.Identifier.ValueText;
                var arguments = node.ArgumentList.Arguments;

                if (name == "CheckTrigger" && arguments.Count == 1)
                {
                    // Verify whether this is the CheckTrigger method of the SLProtocol class.
                    var symbol = semanticModel.GetSymbolInfo(node.Expression).Symbol as IMethodSymbol;

                    // This is a numeric literal expression.
                    if (arguments[0].Expression.Kind() == SyntaxKind.NumericLiteralExpression &&
                        arguments[0].Expression is LiteralExpressionSyntax firstArgument &&
                        symbol?.ContainingType?.ToString() == "Skyline.DataMiner.Scripting.SLProtocol")
                    {
                        string triggerId = firstArgument.Token.ValueText;

                        if (!model.Mappings[Mappings.TriggersById].TryGetValue(triggerId, out _))
                        {
                            Console.WriteLine("Detected invalid trigger ID.");

                            var location = node.GetLocation().GetLineSpan();
                            var lineNumber = location.StartLinePosition.Line + 1;
                            var column = location.Span.Start.Character + 1;
                            ////var length = location.Span.End.Character;

                            Results.Add("Detected invalid trigger ID on Ln " + lineNumber + ", Ch: " + column);
                        }
                    }
                }
            }

            base.VisitInvocationExpression(node);
        }
    }
}
