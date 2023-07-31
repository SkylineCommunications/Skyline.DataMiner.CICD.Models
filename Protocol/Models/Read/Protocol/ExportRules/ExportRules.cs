namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;

    internal partial class ExportRules
    {
        public IEnumerable<IExportRulesExportRule> GetExportRulesForTable(int tablePid)
        {
            foreach (var rule in this)
            {
                var table = rule.Table?.Value;
                var tag = rule.Tag?.Value;

                if (table == null || String.IsNullOrWhiteSpace(tag))
                {
                    continue;
                }

                if (String.Equals(table, "*", StringComparison.OrdinalIgnoreCase))
                {
                    yield return rule;
                    continue;
                }

                var parts = table.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in parts)
                {
                    if (Int32.TryParse(part, out var exportPid) && exportPid == tablePid)
                    {
                        yield return rule;
                        break;
                    }
                }
            }
        }
    }
}
