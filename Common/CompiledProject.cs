namespace Skyline.DataMiner.CICD.Models.Common
{
    using System.Collections.Generic;

    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Represents a compiled project containing the syntax trees and semantic models.
    /// </summary>
    public class CompiledProject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompiledProject"/> using the project ID and the project.
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <param name="project">The project.</param>
        protected CompiledProject(ProjectId projectId, Project project)
        {
            ProjectId = projectId;
            Project = project;

            TreesAndModels = new List<SyntaxTreeAndSemanticModel>();
        }

        /// <summary>
        /// Adds the specified syntax tree and semantic model.
        /// </summary>
        /// <param name="syntaxTree">The syntax tree.</param>
        /// <param name="semanticModel">The semantic model.</param>
        public void AddSyntaxTreeAndModelPair(SyntaxTree syntaxTree, SemanticModel semanticModel)
        {
            TreesAndModels.Add(new SyntaxTreeAndSemanticModel(syntaxTree, semanticModel));
        }

        /// <summary>
        /// Gets the syntax tree and semantic model.
        /// </summary>
        /// <value>The syntax tree and semantic model.</value>
        public IList<SyntaxTreeAndSemanticModel> TreesAndModels { get; }

        /// <summary>
        /// Gets the project ID.
        /// </summary>
        /// <value>The project ID.</value>
        public ProjectId ProjectId { get; }

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <value>The project.</value>
        public Project Project { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the build of the project succeeded.
        /// </summary>
        /// <value><c>true</c> if the compilation succeeded; otherwise, <c>false</c>.</value>
        public bool BuildSucceeded { get; set; }

        /// <summary>
        /// Gets the compilation error messages.
        /// </summary>
        /// <value>The compilation error messages.</value>
        public IList<Diagnostic> CompilationErrors { get; set; }
    }
}
