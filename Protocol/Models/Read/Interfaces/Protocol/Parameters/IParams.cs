namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;

    public partial interface IParams
    {
        /// <summary>
        /// Returns all parameters that are exported for the given table PID.
        /// </summary>
        IEnumerable<IParamsParam> GetExportedParamsForTable(int tablePid);
    }
}
