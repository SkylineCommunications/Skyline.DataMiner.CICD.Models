namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ParamTypeOptions : OptionsBase
    {
        public DimensionsClass Dimensions { get; private set; }

        public ColumnTypesClass ColumnTypes { get; private set; }

        public HeaderTrailerLinkClass HeaderTrailerLink { get; private set; }

        public uint? Connection { get; private set; }

        public DynamicIpClass DynamicIp { get; private set; }

        [Obsolete("There is now a dedicated dynamicSnmpGet Attribute.")]
        public bool HasDynamicSnmpGet { get; private set; }

        public LinkAlarmValueClass LinkAlarmValue { get; private set; }

        public bool HasLoadOID { get; private set; }

        public bool HasSshPwd { get; private set; }

        public bool HasSshUsername { get; private set; }

        public bool HasSshOptions { get; private set; }

        public ParamTypeOptions(string optionsAttribute) : base(optionsAttribute)
        {
            string[] options = optionsAttribute.Split(';');

            foreach (var option in options)
            {
                bool found = NoSignOptions(option);

                if (!found)
                {
                    found = EqualSignOptions(option);
                }

                if (!found)
                {
                    // Add to list of unknown options?
                }
            }
        }

        private bool EqualSignOptions(string option)
        {
            string[] optionSplit = option.Split('=');
            
            if (optionSplit.Length < 2)
            {
                // TODO: Change the classes as to only accept the entire option and maybe the splitted already.
                // So that the class is made, but the internal data is null
                return false;
            }

            string optionCommand = optionSplit[0].ToLowerInvariant();

            switch (optionCommand)
            {
                case "columntypes":
                    ColumnTypes = new ColumnTypesClass(option, optionSplit[1]);
                    break;

                case "connection":
                    if (optionSplit.Length > 1 && UInt32.TryParse(optionSplit[1], out uint c))
                    {
                        Connection = c;
                    }

                    break;

                case "dimensions":
                    Dimensions = new DimensionsClass(option, optionSplit[1]);
                    break;

                case "headertrailerlink":
                    HeaderTrailerLink = new HeaderTrailerLinkClass(option, optionSplit[1]);
                    break;

                case "linkalarmvalue":
                    LinkAlarmValue = new LinkAlarmValueClass(option, optionSplit[1]);
                    break;

                default:
                    return false;
            }

            return true;
        }

        private bool NoSignOptions(string option)
        {
            switch (option.ToLowerInvariant())
            {
                case "dynamic snmp get":
                    HasDynamicSnmpGet = true;
                    break;

                case "loadoid":
                    HasLoadOID = true;
                    break;

                case "ssh pwd":
                    HasSshPwd = true;
                    break;

                case "ssh username":
                    HasSshUsername = true;
                    break;

                case "ssh options":
                    HasSshOptions = true;
                    break;

                default:
                    if (option.StartsWith("dynamic ip"))
                    {
                        DynamicIp = new DynamicIpClass(option);
                        break;
                    }
                    else
                    {
                        return false;
                    }
            }

            return true;
        }

        public class ColumnTypesClass : OptionsBase
        {
            public List<(uint? pid, uint? fromIdx, uint? toIndex, bool isValid)> ColumnTypes { get; }

            public ColumnTypesClass(string fullOption, string value) : base(fullOption)
            {
                // options="columnTypes=2:0-20,35|3:21-34,36"

                string[] splitted = value.Split('|');

                ColumnTypes = new List<(uint? pid, uint? fromIdx, uint? toIndex, bool isValid)>();
                foreach (var columnType in splitted)
                {
                    string[] splittedColumnType = columnType.Split(':');

                    uint? pid = null;
                    uint? fromIdx = null;
                    uint? toIdx = null;
                    bool isValid = false;

                    if (UInt32.TryParse(splittedColumnType[0], out uint p))
                    {
                        pid = p;
                    }

                    if (splittedColumnType.Length > 1)
                    {
                        Match m = Regex.Match(splittedColumnType[1], @"^(\d+)-(\d+)$");
                        if (m.Success)
                        {
                            isValid = true;

                            if (UInt32.TryParse(m.Groups[1].Value, out uint f))
                            {
                                fromIdx = f;
                            }

                            if (UInt32.TryParse(m.Groups[2].Value, out uint t))
                            {
                                toIdx = t;
                            }
                        }
                    }

                    // Only 1 syntax is allowed
                    ColumnTypes.Add((p, fromIdx, toIdx, isValid));
                }
            }
        }

        public class DimensionsClass : OptionsBase
        {
            public uint? Rows { get; }

            public uint? Columns { get; }

            public DimensionsClass(string fullOption, string value) : base(fullOption)
            {
                string[] splitted = value.Split(',');

                if (UInt32.TryParse(splitted[0], out uint r))
                {
                    Rows = r;
                }

                if (splitted.Length > 1 && UInt32.TryParse(splitted[1], out uint c))
                {
                    Columns = c;
                }
            }
        }

        public class DynamicIpClass : OptionsBase
        {
            public uint? Connection { get; }

            public DynamicIpClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(' ');

                if (splitted.Length == 3 && UInt32.TryParse(splitted[2], out uint c))
                {
                    Connection = c;
                }
            }
        }

        public class HeaderTrailerLinkClass : OptionsBase
        {
            public uint? Id { get; }

            public HeaderTrailerLinkClass(string fullOption, string value) : base(fullOption)
            {
                if (UInt32.TryParse(value, out uint i))
                {
                    Id = i;
                }
            }
        }

        public class LinkAlarmValueClass : OptionsBase
        {
            public bool IsValid { get; }

            public char? FirstChar { get; }

            public char? SecondChar { get; }

            public LinkAlarmValueClass(string fullOption, string value) : base(fullOption)
            {
                if (String.Equals(value, "true", StringComparison.OrdinalIgnoreCase))
                {
                    // Normal LinkAlarmValue
                    IsValid = true;
                }
                else if (value.Length == 2)
                {
                    FirstChar = value[0];
                    SecondChar = value[1];
                    IsValid = true;
                }
            }
        }
    }
}