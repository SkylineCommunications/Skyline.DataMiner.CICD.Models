namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;

    public partial interface IExportRules
    {
        /// <summary>
        /// Returns all export rules that are applicable for the given table PID
        /// </summary>
        IEnumerable<IExportRulesExportRule> GetExportRulesForTable(int tablePid);
    }
}