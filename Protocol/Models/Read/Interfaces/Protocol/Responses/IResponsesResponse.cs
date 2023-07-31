using System.Collections.Generic;
using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public partial interface IResponsesResponse
    {
        #region Get

        /// <summary>
        /// Tries to get the parameters that make up this response.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The parameters that make up this response.</returns>
        IEnumerable<IParamsParam> GetParameters(RelationManager relationManager);

        #endregion
    }
}