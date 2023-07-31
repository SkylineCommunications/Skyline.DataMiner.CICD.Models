namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;

    public class ArrayOptionsOptions : OptionsBase
    {
        public bool HasAutoAdd { get; private set; }

        public DirectViewClass DirectView { get; private set; }

        public string DiscreetDestination { get; private set; }

        public bool HasInterruptTrend { get; private set; }

        public NamingClass Naming { get; private set; }

        public bool HasOnlyFilteredDirectView { get; private set; }

        public bool HasPreserveState { get; private set; }

        public uint? QueryTablePid { get; private set; }

        public ViewClass View { get; private set; }

        public bool HasVolatile { get; private set; }

        public DatabaseClass Database { get; private set; }

        public FilterChangeClass FilterChange { get; private set; }

        public PropertyTableClass PropertyTable { get; private set; }

        public ProcessingOrderClass ProcessingOrder { get; private set; }

        public ArrayOptionsOptions(string optionsAttribute) : base(optionsAttribute)
        {
            if (!String.IsNullOrWhiteSpace(optionsAttribute) && optionsAttribute.Length > 0)
            {
                char separator = optionsAttribute[0];
                if (Char.IsLetterOrDigit(separator))
                {
                    separator = ';';
                }

                string[] options = optionsAttribute.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var option in options)
                {
                    bool found = NoSignOptions(option);

                    if (!found)
                    {
                        found = EqualSignOptions(option);
                    }

                    if (!found)
                    {
                        found = DoublePointSignOptions(option);
                    }

                    if (!found)
                    {
                        // Add to list of unknown options?
                    }
                }
            }
        }

        private bool DoublePointSignOptions(string option)
        {
            string[] optionSplit = option.Split(':');

            string optionCommand = optionSplit[0].ToLowerInvariant();

            switch (optionCommand)
            {
                case "database":
                    Database = new DatabaseClass(option);
                    break;

                default:
                    return false;
            }

            return true;
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
                case "directview":
                    DirectView = new DirectViewClass(option, optionSplit[1]);
                    break;

                case "discreetdestination":
                    DiscreetDestination = optionSplit[1];
                    break;

                case "filterchange":
                    FilterChange = new FilterChangeClass(option, optionSplit[1]);
                    break;

                case "naming":
                    Naming = new NamingClass(option, optionSplit[1]);
                    break;

                case "propertytable":
                    PropertyTable = new PropertyTableClass(option, optionSplit[1]);
                    break;

                case "processingorder":
                    ProcessingOrder = new ProcessingOrderClass(option, optionSplit[1]);
                    break;

                case "querytablepid":
                    if (UInt32.TryParse(optionSplit[1], out uint queryTablePid))
                    {
                        QueryTablePid = queryTablePid;
                    }

                    break;

                case "view":
                    View = new ViewClass(option, optionSplit[1]);
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
                case "autoadd":
                    HasAutoAdd = true;
                    break;

                case "interrupttrend":
                    HasInterruptTrend = true;
                    break;

                case "onlyfiltereddirectview":
                    HasOnlyFilteredDirectView = true;
                    break;

                case "preserve state":
                    HasPreserveState = true;
                    break;

                case "volatile":
                    HasVolatile = true;
                    break;

                default:
                    return false;
            }

            return true;
        }

        public class ProcessingOrderClass : OptionsBase
        {
            public ICollection<uint> Columns { get; }

            public ProcessingOrderClass(string fullOption, string value) : base(fullOption)
            {
                string[] pids = value.Split(',');

                if (pids.Length > 0)
                {
                    Columns = new List<uint>();

                    foreach (string pidString in pids)
                    {
                        if (UInt32.TryParse(pidString, out uint pid))
                        {
                            Columns.Add(pid);
                        }
                    }
                }
            }
        }

        public class PropertyTableClass : OptionsBase
        {
            public ICollection<uint> Columns { get; }

            public PropertyTableClass(string fullOption, string value) : base(fullOption)
            {
                string[] pids = value.Split(',');

                if (pids.Length > 0)
                {
                    Columns = new List<uint>();

                    foreach (string pidString in pids)
                    {
                        if (UInt32.TryParse(pidString, out uint pid))
                        {
                            Columns.Add(pid);
                        }
                    }
                }
            }
        }

        public class ViewClass : OptionsBase
        {
            public uint? Pid { get; }

            public bool IsValid { get; }

            public bool HasRemoteId { get; }

            public ViewClass(string fullOption, string value) : base(fullOption)
            {
                // xxxx,remoteId

                // Split on ,
                string[] splitted = value.Split(',');

                if (UInt32.TryParse(splitted[0], out uint pid))
                {
                    Pid = pid;
                }

                if (splitted.Length <= 2)
                {
                    IsValid = true;
                }

                if (splitted.Length == 2)
                {
                    if (String.Equals(splitted[1], "remoteId", StringComparison.OrdinalIgnoreCase))
                    {
                        HasRemoteId = true;
                    }
                    else
                    {
                        IsValid = false;
                    }
                }
            }
        }

        public class DirectViewClass : OptionsBase
        {
            public uint? Pid { get; }

            public DirectViewClass(string fullOption, string value) : base(fullOption)
            {
                if (UInt32.TryParse(value, out uint pid))
                {
                    Pid = pid;
                }
            }
        }

        public class DatabaseClass : OptionsBase
        {
            public uint? Rows { get; }

            public DatabaseClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');

                if (splitted.Length == 2 && UInt32.TryParse(splitted[1], out uint rows))
                {
                    Rows = rows;
                }
            }
        }

        public class FilterChangeClass : OptionsBase
        {
            public List<(uint? LocalId, uint? RemoteId, bool IsValid)> Pairs { get; }

            public FilterChangeClass(string fullOption, string value) : base(fullOption)
            {
                string[] splitted = value.Split(',');

                if (splitted.Length > 0)
                {
                    Pairs = new List<(uint? LocalId, uint? RemoteId, bool IsValid)>(splitted.Length);
                }

                foreach (var split in splitted)
                {
                    string[] ids = split.Split('-');

                    uint? local = null;
                    uint? remote = null;
                    bool valid = ids.Length == 2;

                    if (UInt32.TryParse(ids[0], out uint l))
                    {
                        local = l;
                    }

                    if (ids.Length == 2 && UInt32.TryParse(ids[1], out uint r))
                    {
                        remote = r;
                    }

                    Pairs.Add((local, remote, valid));
                }
            }
        }

        public class NamingClass : OptionsBase
        {
            public char? Separator { get; }

            public ICollection<uint> Columns { get; }

            public NamingClass(string fullOption, string value) : base(fullOption)
            {
                // First char is separator inside PK
                // Double check if this is always needed??

                if (value.Length > 0)
                {
                    Separator = value[0];

                    // Remove separator
                    value = value.Remove(0, 1);

                    string[] pids = value.Split(',');

                    if (pids.Length > 0)
                    {
                        Columns = new List<uint>();

                        foreach (string pidString in pids)
                        {
                            if (UInt32.TryParse(pidString, out uint pid))
                            {
                                Columns.Add(pid);
                            }
                        }
                    }
                }
            }
        }
    }
}