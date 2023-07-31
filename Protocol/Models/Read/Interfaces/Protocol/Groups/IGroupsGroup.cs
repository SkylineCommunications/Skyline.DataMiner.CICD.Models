namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    public partial interface IGroupsGroup
    {
        /// <summary>
        /// Tries to get the actions in this group.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The actions that are in the content of this group.</returns>
        IEnumerable<IActionsAction> GetContentActions(RelationManager relationManager);

        /// <summary>
        /// Tries to get the pairs in this group.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The pairs that are in the content of this group.</returns>
        IEnumerable<IPairsPair> GetContentPairs(RelationManager relationManager);

        /// <summary>
        /// Tries to get the parameters in this group.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The parameters that are in the content of this group.</returns>
        IEnumerable<IParamsParam> GetContentParameters(RelationManager relationManager);

        /// <summary>
        /// Tries to get the sessions in this group.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The sessions that are in the content of this group.</returns>
        IEnumerable<IHTTPSession> GetContentSessions(RelationManager relationManager);

        /// <summary>
        /// Tries to get the triggers in this group.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The triggers that are in the content of this group.</returns>
        IEnumerable<ITriggersTrigger> GetContentTriggers(RelationManager relationManager);
    }
}
