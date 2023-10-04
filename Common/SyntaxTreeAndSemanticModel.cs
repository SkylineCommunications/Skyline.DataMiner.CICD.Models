namespace Skyline.DataMiner.CICD.Models.Common
{
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Represents a semantic model with its syntax tree.
    /// </summary>
    public class SyntaxTreeAndSemanticModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxTreeAndSemanticModel"/> class.
        /// </summary>
        /// <param name="syntaxTree">The syntax tree.</param>
        /// <param name="semanticModel">The semantic model.</param>
        public SyntaxTreeAndSemanticModel(SyntaxTree syntaxTree, SemanticModel semanticModel)
        {
            SyntaxTree = syntaxTree;
            SemanticModel = semanticModel;
        }

        /// <summary>
        /// Gets the syntax tree.
        /// </summary>
        /// <value>The syntax tree.</value>
        public SyntaxTree SyntaxTree { get; }

        /// <summary>
        /// Gets the semantic model.
        /// </summary>
        /// <value>The semantic model.</value>
        public SemanticModel SemanticModel { get; }
    }
}
