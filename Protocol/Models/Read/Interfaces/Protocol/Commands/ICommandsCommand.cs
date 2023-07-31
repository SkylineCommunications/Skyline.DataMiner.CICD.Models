namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    public partial interface ICommandsCommand
    {
        #region Get

        /// <summary>
        /// Tries to get the parameters that make up this command.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The parameters that make up this command.</returns>
        IEnumerable<IParamsParam> GetParameters(RelationManager relationManager);

        #endregion
    }
}