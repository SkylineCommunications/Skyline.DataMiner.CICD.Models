namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;

    internal partial class Params
    {
        public IEnumerable<IParamsParam> GetExportedParamsForTable(int tablePid)
        {
            foreach (var p in this)
            {
                var export = p.Export?.Value;

                if (export == null)
                {
                    continue;
                }

                if (String.Equals(export, "true", StringComparison.OrdinalIgnoreCase))
                {
                    yield return p;
                    continue;
                }

                var parts = export.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in parts)
                {
                    if (Int32.TryParse(part, out var exportPid) && exportPid == tablePid)
                    {
                        yield return p;
                        break;
                    }
                }
            }
        }
    }
}
