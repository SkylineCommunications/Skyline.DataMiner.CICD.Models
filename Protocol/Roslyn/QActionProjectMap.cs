namespace Skyline.DataMiner.CICD.Models.Protocol
{
    using System.Collections.Generic;

    using Microsoft.CodeAnalysis;

    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    /// <summary>
    /// Groups the created solution and contains the mapping between the projects in the solution and the corresponding IQActionsQAction objects.
    /// </summary>
    internal class QActionProjectMap
    {
        private readonly IDictionary<int, (ProjectId project, IQActionsQAction qa)> map;
        private readonly IDictionary<ProjectId, IQActionsQAction> projectMap;

        public QActionProjectMap(Solution solution, IDictionary<int, (ProjectId project, IQActionsQAction qa)> qactions)
        {
            Solution = solution;
            map = qactions;

            projectMap = new Dictionary<ProjectId, IQActionsQAction>();

            foreach (var item in map)
            {
                projectMap.Add(item.Value.project, item.Value.qa);
            }
        }
        public Solution Solution { get; private set; }

        public IQActionsQAction GetQAction(int id)
        {
            if (map.TryGetValue(id, out (ProjectId Project, IQActionsQAction QAction) item))
            {
                return item.QAction;
            }

            return null;
        }

        public IQActionsQAction GetQAction(ProjectId projectId)
        {
            projectMap.TryGetValue(projectId, out IQActionsQAction result);
            return result;
        }

        public ProjectId GetProjectId(int id)
        {
            if (map.TryGetValue(id, out (ProjectId Project, IQActionsQAction QAction) item))
            {
                return item.Project;
            }

            return null;
        }
    }
}