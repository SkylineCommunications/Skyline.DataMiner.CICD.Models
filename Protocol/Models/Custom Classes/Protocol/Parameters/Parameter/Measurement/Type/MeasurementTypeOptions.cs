namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;

    public class MeasurementTypeOptions : OptionsBase
    {
        public MeasurementTypeOptions(string optionsAttribute) : base(optionsAttribute)
        {
            if (!String.IsNullOrWhiteSpace(optionsAttribute) && optionsAttribute.Length > 0)
            {
                char separator = ';';

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

                    // TODO option: Number (when using String as Type) => unclear on syntax.

                    if (!found)
                    {
                        // Add to list of unknown options?
                    }
                }
            }
        }

        public bool HasHScroll { get; private set; }

        public CustomDisableWriteClass CustomDisableWrite { get; private set; }

        public MatrixClass Matrix { get; private set; }

        public bool HasTimeOfDay { get; private set; }

        public TimeClass Time { get; private set; }

        public bool HasDate { get; private set; }

        public bool HasFixedFont { get; private set; }

        public bool HasPassword { get; private set; }

        public DateTimeClass DateTime { get; private set; }

        public uint? Tab { get; private set; }

        public TableClass Table { get; private set; }

        public bool HasBegin { get; private set; }

        public bool HasConnect { get; private set; }

        public bool HasEnd { get; private set; }

        private bool DoublePointSignOptions(string option)
        {
            string[] optionSplit = option.Split(':');
            
            string optionCommand = optionSplit[0].ToLower();

            switch (optionCommand)
            {
                case "custom=disablewrite":
                    if (optionSplit.Length < 2)
                    {
                        // TODO: Change the classes as to only accept the entire option and maybe the splitted already.
                        // So that the class is made, but the internal data is null
                        return false;
                    }
                    CustomDisableWrite = new CustomDisableWriteClass(option, optionSplit[1]);
                    break;

                case "time":
                    Time = new TimeClass(option);
                    break;

                case "datetime":
                    DateTime = new DateTimeClass(option);
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
                case "matrix":
                    Matrix = new MatrixClass(option, optionSplit[1]);
                    break;

                case "tab":
                    if (UInt32.TryParse(optionSplit[1], out uint t))
                    {
                        // String tab : The tab distance (the starting position of the text in the box).
                        Tab = t;
                    }
                    else
                    {
                        Table = new TableClass(option, optionSplit[1]);
                    }

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
                case "hscroll":
                    HasHScroll = true;
                    break;

                case "timeofday":
                    HasTimeOfDay = true;
                    break;

                case "date":
                    HasDate = true;
                    break;

                case "fixedfont":
                    HasFixedFont = true;
                    break;

                case "password":
                    HasPassword = true;
                    break;

                case "begin":
                    HasBegin = true;
                    break;

                case "end":
                    HasEnd = true;
                    break;

                case "connect":
                    HasConnect = true;
                    break;

                default:
                    return false;
            }

            return true;
        }

        public class CustomDisableWriteClass : OptionsBase
        {
            public uint? Column { get; }

            public string Value { get; }

            public bool IsValid { get; }

            public CustomDisableWriteClass(string fullOption, string value) : base(fullOption)
            {
                string[] splitted = value.Split('=');

                if (UInt32.TryParse(splitted[0], out uint c))
                {
                    Column = c;
                }

                if (splitted.Length > 1)
                {
                    Value = splitted[1];
                }

                if (splitted.Length == 2)
                {
                    IsValid = true;
                }
            }
        }

        public class MatrixClass : OptionsBase
        {
            public bool IsValid { get; } = true;

            public uint? Inputs { get; }

            public uint? Outputs { get; }

            public uint? COMin { get; }

            public uint? COMax { get; }

            public uint? CIMin { get; }

            public uint? CIMax { get; }

            public bool HasPages { get; }

            public bool HasNoDisconnectsInBackup { get; }

            public bool HasEvenSmallPages { get; }

            public MatrixClass(string fullOption, string value) : base(fullOption)
            {
                string[] splitted = value.Split(',');

                if (UInt32.TryParse(splitted[0], out uint i))
                {
                    Inputs = i;
                }
                else
                {
                    IsValid = false;
                }

                if (splitted.Length > 1 && UInt32.TryParse(splitted[1], out uint o))
                {
                    Outputs = o;
                }
                else
                {
                    IsValid = false;
                }

                if (splitted.Length > 2 && UInt32.TryParse(splitted[2], out uint coMin))
                {
                    COMin = coMin;
                }
                else
                {
                    IsValid = false;
                }

                if (splitted.Length > 3 && UInt32.TryParse(splitted[3], out uint coMax))
                {
                    COMax = coMax;
                }
                else
                {
                    IsValid = false;
                }

                if (splitted.Length > 4 && UInt32.TryParse(splitted[4], out uint ciMin))
                {
                    CIMin = ciMin;
                }
                else
                {
                    IsValid = false;
                }

                if (splitted.Length > 5 && UInt32.TryParse(splitted[5], out uint ciMax))
                {
                    CIMax = ciMax;
                }
                else
                {
                    IsValid = false;
                }

                if (splitted.Length > 6)
                {
                    if (String.Equals(splitted[6], "pages", StringComparison.OrdinalIgnoreCase))
                    {
                        HasPages = true;
                    }
                    else if (String.Equals(splitted[6], "evenSmallPages", StringComparison.OrdinalIgnoreCase))
                    {
                        HasEvenSmallPages = true;
                    }
                    else
                    {
                        // Unknown option?
                        IsValid = false;
                    }
                }

                if (splitted.Length > 7)
                {
                    if (String.Equals(splitted[7], "noDisconnectsInBackup", StringComparison.OrdinalIgnoreCase))
                    {
                        HasNoDisconnectsInBackup = true;
                    }
                    else
                    {
                        IsValid = false;
                    }
                }
            }
        }

        public class TimeClass : OptionsBase
        {
            public enum Options
            {
                Minute,
                Hour,
            }

            public Options? ExtraOption { get; }

            public bool IsValid { get; }

            public TimeClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');

                IsValid = true;

                if (splitted.Length > 1)
                {
                    if (String.Equals(splitted[1], "minute", StringComparison.OrdinalIgnoreCase))
                    {
                        ExtraOption = Options.Minute;
                    }
                    else if (String.Equals(splitted[1], "hour", StringComparison.OrdinalIgnoreCase))
                    {
                        ExtraOption = Options.Hour;
                    }
                    else
                    {
                        // Unknown option...
                        IsValid = false;
                    }
                }

                if (splitted.Length > 2)
                {
                    IsValid = false;
                }
            }
        }

        public class DateTimeClass : OptionsBase
        {
            public enum Options
            {
                Minute,
            }

            public Options? ExtraOption { get; }

            public bool IsValid { get; }

            public DateTimeClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');

                IsValid = true;

                if (splitted.Length > 1)
                {
                    if (String.Equals(splitted[1], "minute", StringComparison.OrdinalIgnoreCase))
                    {
                        ExtraOption = Options.Minute;
                    }
                    else
                    {
                        // Unknown option...
                        IsValid = false;
                    }
                }

                if (splitted.Length > 2)
                {
                    IsValid = false;
                }
            }
        }

        public class TableClass : OptionsBase
        {
            public ICollection<Column> ColumnsFull { get; private set; }

            public ColumnsClass Columns { get; }

            public uint? Lines { get; }

            public bool? Filter { get; }

            public WidthClass Width { get; }

            public SortClass Sort { get; }

            public TableClass(string fullOption, string value) : base(fullOption)
            {
                string[] splitted = value.Split(',');

                foreach (string tableOption in splitted)
                {
                    string[] splittedOption = tableOption.Split(':');

                    if (splittedOption.Length < 2)
                    {
                        continue;
                    }

                    string optionsCommand = splittedOption[0];
                    if (String.Equals(optionsCommand, "columns", StringComparison.OrdinalIgnoreCase))
                    {
                        Columns = new ColumnsClass(tableOption, splittedOption[1]);
                    }
                    else if (String.Equals(optionsCommand, "lines", StringComparison.OrdinalIgnoreCase))
                    {
                        if (UInt32.TryParse(splittedOption[1], out uint l))
                        {
                            Lines = l;
                        }
                    }
                    else if (String.Equals(optionsCommand, "width", StringComparison.OrdinalIgnoreCase))
                    {
                        Width = new WidthClass(tableOption, splittedOption[1]);
                    }
                    else if (String.Equals(optionsCommand, "sort", StringComparison.OrdinalIgnoreCase))
                    {
                        Sort = new SortClass(tableOption, splittedOption[1]);
                    }
                    else if (String.Equals(optionsCommand, "filter", StringComparison.OrdinalIgnoreCase))
                    {
                        if (String.Equals(splittedOption[1], "true", StringComparison.OrdinalIgnoreCase))
                        {
                            Filter = true;
                        }
                        else if (String.Equals(splittedOption[1], "false", StringComparison.OrdinalIgnoreCase))
                        {
                            Filter = false;
                        }
                    }
                    else
                    {
                        // Unknown Options?
                    }
                }

                BuildColumnFull();
            }

            private void BuildColumnFull()
            {
                Dictionary<uint, Column> tempColumns = new Dictionary<uint, Column>();

                if (Width?.Columns != null)
                {
                    foreach ((uint displayedIndex, uint? width) in Width.Columns)
                    {
                        if (!tempColumns.TryGetValue(displayedIndex, out Column c))
                        {
                            c = new Column
                            {
                                DisplayedIndex = displayedIndex,
                            };
                            tempColumns.Add(displayedIndex, c);
                        }

                        c.Width = width;
                    }
                }

                if (Sort?.Columns != null)
                {
                    foreach ((uint displayedIndex, SortType? type, SortDirection? direction, uint? priority) in Sort.Columns)
                    {
                        if (!tempColumns.TryGetValue(displayedIndex, out Column c))
                        {
                            c = new Column
                            {
                                DisplayedIndex = displayedIndex,
                            };
                            tempColumns.Add(displayedIndex, c);
                        }

                        c.SortDirection = direction;
                        c.SortPriority = priority;
                        c.SortType = type;
                    }
                }

                if (Columns?.Columns != null)
                {
                    foreach ((uint displayedIndex, uint? columnPid, uint? columnIdx) in Columns.Columns)
                    {
                        if (!tempColumns.TryGetValue(displayedIndex, out Column c))
                        {
                            c = new Column
                            {
                                DisplayedIndex = displayedIndex,
                            };
                            tempColumns.Add(displayedIndex, c);
                        }

                        c.Pid = columnPid;
                        c.Idx = columnIdx;
                    }
                }

                ColumnsFull = tempColumns.Values;
            }

            public class Column
            {
                public uint DisplayedIndex { get; internal set; }

                public uint? Pid { get; internal set; }

                public uint? Idx { get; internal set; }

                public SortDirection? SortDirection { get; internal set; }

                public SortType? SortType { get; internal set; }

                public uint? SortPriority { get; internal set; }

                public uint? Width { get; internal set; }
            }

            public class ColumnsClass : OptionsBase
            {
                public ICollection<(uint displayedIndex, uint? columnPid, uint? columnIdx)> Columns { get; }

                public ColumnsClass(string fullOption, string value) : base(fullOption)
                {
                    string[] splitted = value.Split('-');

                    // PID|Index-PID|Index

                    Columns = new List<(uint, uint?, uint?)>();
                    for (uint i = 0; i < splitted.Length; i++)
                    {
                        string[] columnSplit = splitted[i].Split('|');

                        uint? pid = null;
                        uint? idx = null;

                        if (UInt32.TryParse(columnSplit[0], out uint p))
                        {
                            pid = p;
                        }

                        if (columnSplit.Length == 1)
                        {
                            idx = i;
                        }
                        else if (columnSplit.Length > 1 && UInt32.TryParse(columnSplit[1], out uint index))
                        {
                            idx = index;
                        }

                        Columns.Add((i, pid, idx));
                    }
                }
            }

            public class WidthClass : OptionsBase
            {
                public ICollection<(uint displayedIndex, uint? width)> Columns { get; }

                public WidthClass(string fullOption, string value) : base(fullOption)
                {
                    string[] splitted = value.Split('-');

                    // Width-Width

                    Columns = new List<(uint, uint?)>();
                    for (uint i = 0; i < splitted.Length; i++)
                    {
                        uint? width = null;

                        if (UInt32.TryParse(splitted[i], out uint w))
                        {
                            width = w;
                        }

                        Columns.Add((i, width));
                    }
                }
            }

            public class SortClass : OptionsBase
            {
                public ICollection<(uint displayedIndex, SortType? type, SortDirection? direction, uint? priority)> Columns { get; }

                public SortClass(string fullOption, string value) : base(fullOption)
                {
                    string[] splitted = value.Split('-');

                    // PID|Index-PID|Index

                    Columns = new List<(uint, SortType?, SortDirection?, uint?)>();
                    for (uint i = 0; i < splitted.Length; i++)
                    {
                        string[] columnSplit = splitted[i].Split('|');

                        SortType? type = null;
                        SortDirection? direction = null;
                        uint? priority = null;

                        if (String.Equals(columnSplit[0], "STRING", StringComparison.OrdinalIgnoreCase))
                        {
                            type = SortType.String;
                        }
                        else if (String.Equals(columnSplit[0], "INT", StringComparison.OrdinalIgnoreCase))
                        {
                            type = SortType.Integer;
                        }

                        if (columnSplit.Length > 1)
                        {
                            if (String.Equals(columnSplit[1], "ASC", StringComparison.OrdinalIgnoreCase))
                            {
                                direction = SortDirection.Ascending;
                            }
                            else if (String.Equals(columnSplit[1], "DESC", StringComparison.OrdinalIgnoreCase))
                            {
                                direction = SortDirection.Descending;
                            }

                            if (columnSplit.Length > 2 && UInt32.TryParse(columnSplit[2], out uint p))
                            {
                                priority = p;
                            }
                        }

                        Columns.Add((i, type, direction, priority));
                    }
                }
            }

            public enum SortType
            {
                String,
                Integer,
            }

            public enum SortDirection
            {
                Ascending,
                Descending,
            }

        }
    }
}