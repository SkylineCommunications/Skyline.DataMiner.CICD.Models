namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    public partial interface ITriggersTrigger
    {
        #region Get

        /// <summary>
        /// Tries to get the actions executed from this trigger.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The actions that were found.</returns>
        IEnumerable<IActionsAction> GetActions(RelationManager relationManager);

        #endregion
    }
}
