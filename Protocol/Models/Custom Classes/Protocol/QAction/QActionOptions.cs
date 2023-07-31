namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;

    public class QActionOptions : OptionsBase
    {
        public QActionOptions(string value) : base(value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return;
            }

            string[] options = value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var option in options)
            {
                var parts = option.Split(new[] { '=' }, 2);
                string optName = parts[0].Trim();

                if (String.Equals(optName, "precompile", StringComparison.OrdinalIgnoreCase))
                {
                    HasPrecompile = true;
                }
                else if (String.Equals(optName, "binary", StringComparison.OrdinalIgnoreCase))
                {
                    HasBinary = true;
                }
                else if (String.Equals(optName, "debug", StringComparison.OrdinalIgnoreCase))
                {
                    HasDebug = true;
                }
                else if (String.Equals(optName, "group", StringComparison.OrdinalIgnoreCase))
                {
                    HasGroup = true;
                }
                else if (String.Equals(optName, "queued", StringComparison.OrdinalIgnoreCase))
                {
                    HasQueued = true;
                }
                else if (String.Equals(optName, "dllname", StringComparison.OrdinalIgnoreCase) && parts.Length == 2)
                {
                    string dllName = parts[1].Trim();

                    if (!dllName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
                    {
                        dllName += ".dll";
                    }

                    CustomDllName = dllName;
                }
            }
        }

        public bool HasBinary { get; }

        public bool HasDebug { get; }

        public bool HasGroup { get; }

        public bool HasPrecompile { get; }

        public bool HasQueued { get; }

        public string CustomDllName { get; }
    }
}