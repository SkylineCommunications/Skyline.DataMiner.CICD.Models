namespace Skyline.DataMiner.CICD.Models.Protocol
{
    using Microsoft.CodeAnalysis;

    using Skyline.DataMiner.CICD.Models.Common;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    /// <summary>
    /// Represents a compiled QAction project.
    /// </summary>
    public class CompiledQActionProject : CompiledProject
    {
        internal CompiledQActionProject(ProjectId projectId, IQActionsQAction qaction, Project project) : base(projectId, project)
        {
            QAction = qaction;
        }

        /// <summary>
        /// Gets the QAction protocol model object that corresponds with this project.
        /// </summary>
        /// <value>The QAction protocol model object that corresponds with this project.</value>
        public IQActionsQAction QAction { get; }
    }
}
