namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    public partial interface IHTTPSession
    {
        /// <summary>
        /// Tries to get the parameters used by this session.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The parameters used by this session.</returns>
        IEnumerable<IParamsParam> GetLinkedParameters(RelationManager relationManager);
    }
}
