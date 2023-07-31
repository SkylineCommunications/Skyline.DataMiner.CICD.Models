namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    public partial interface IActionsAction
    {
        #region Get

        /// <summary>
        /// Tries to get the groups executed from this action.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The groups that were found.</returns>
        IEnumerable<IGroupsGroup> GetGroups(RelationManager relationManager);

        /// <summary>
        /// Tries to get the triggers triggering this action.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The triggers that were found.</returns>
        IEnumerable<ITriggersTrigger> GetTriggeringTriggers(RelationManager relationManager);

        #endregion
    }
}