namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;

    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    public partial interface IQActionsQAction
    {
        /// <summary>
        /// Gets the code of the QAction.
        /// </summary>
        /// <returns>The content of the first CDATA section of the QAction.</returns>
        string Code { get; }

        /// <summary>
        /// Gets the CDATA tag that contains the code of the QAction.
        /// </summary>
        /// <returns>The first CDATA section of the QAction.</returns>
        XmlCDATA CodeCDATA { get; }

        /// <summary>
        /// Tries to get the triggers of this QAction.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The parameters that are in the triggers attribute of this QAction.</returns>
        IEnumerable<IParamsParam> GetTriggerParameters(RelationManager relationManager);

        /// <summary>
        /// Tries to get the groups that trigger this QAction.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The groups that trigger this QAction.</returns>
        IEnumerable<IGroupsGroup> GetTriggerGroups(RelationManager relationManager);

        /// <summary>
        /// Tries to get the timers that trigger this QAction.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The timers that trigger this QAction.</returns>
        IEnumerable<ITimersTimer> GetTriggerTimers(RelationManager relationManager);
        
        IReadOnlyList<uint> GetTriggers();

        QActionOptions GetOptions();

        QActionEntryPoints GetEntryPoints();

        IEnumerable<string> GetDllImports();

        IEnumerable<IQActionsQAction> GetReferencedQActions();
    }
}