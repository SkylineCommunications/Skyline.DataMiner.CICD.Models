namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;

    public class ExportProtocol
    {
        public string Name { get; } = String.Empty;

        public bool NoElementPrefix { get; } = false;

        public uint? TablePid { get; }

        public ExportProtocol(string[] splitOption)
        {
            if (splitOption.Length > 1)
            {
                Name = splitOption[1];
            }

            if (splitOption.Length > 2)
            {
                if (UInt32.TryParse(splitOption[2], out uint tablePid))
                {
                    TablePid = tablePid;
                }
            }

            if (splitOption.Length > 3)
            {
                if (String.Equals(splitOption[3], "noelementprefix", StringComparison.OrdinalIgnoreCase))
                {
                    NoElementPrefix = true;
                }
            }
        }
    }
}