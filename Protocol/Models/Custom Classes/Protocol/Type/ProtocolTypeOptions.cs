namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;

    public class ProtocolTypeOptions : OptionsBase
    {
        public ICollection<ExportProtocol> ExportProtocols { get; } = new List<ExportProtocol>();

        public bool Unicode { get; }

        public bool DisableViewRefresh { get; }

        public List<string> UnknownOptions { get; } = new List<string>();

        public ProtocolTypeOptions(string protocolTypeOptions) : base(protocolTypeOptions)
        {
            string[] options = protocolTypeOptions.Split(';');
            foreach (var option in options)
            {
                string[] typeValueSplit = option.Split(':');
                if (String.Equals(typeValueSplit[0], "exportProtocol", StringComparison.OrdinalIgnoreCase))
                {
                    ExportProtocols.Add(new ExportProtocol(typeValueSplit));
                }
                else if (String.Equals(typeValueSplit[0], "unicode", StringComparison.OrdinalIgnoreCase))
                {
                    Unicode = true;
                }
                else if (String.Equals(typeValueSplit[0], "disableViewRefresh", StringComparison.OrdinalIgnoreCase))
                {
                    DisableViewRefresh = true;
                }
                else
                {
                    UnknownOptions.Add(option);
                }
            }
        }
    }
}