namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DiscreetsDiscreetOptions : OptionsBase
    {
        public DiscreetsDiscreetOptions(string optionsAttribute) : base(optionsAttribute)
        {
            if (!String.IsNullOrWhiteSpace(optionsAttribute) && optionsAttribute.Length > 0)
            {
                char separator = ';';

                string[] options = optionsAttribute.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string option in options)
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

        public bool HasSeparator { get; private set; }

        public ConfirmClass Confirm { get; private set; }

        public DisabledClass Disabled { get; private set; }

        public EnabledClass Enabled { get; private set; }

        public LevelClass Level { get; private set; }

        public SeverityClass Severity { get; private set; }

        public RowTextColorClass RowTextColor { get; private set; }

        public ScriptClass Script { get; private set; }

        public TableClass Table { get; private set; }

        private bool DoublePointSignOptions(string option)
        {
            string[] optionSplit = option.Split(':');
            switch (optionSplit[0].ToLower())
            {
                case "confirm":
                    Confirm = new ConfirmClass(option);
                    break;

                case "script":
                    Script = new ScriptClass(option);
                    break;

                case "table":
                    Table = new TableClass(option);
                    break;

                default:
                    return false;
            }

            return true;
        }

        private bool EqualSignOptions(string option)
        {
            string[] optionSplit = option.Split('=');
            switch (optionSplit[0].ToLowerInvariant())
            {
                case "disabled":
                    Disabled = new DisabledClass(option);
                    break;

                case "enabled":
                    Enabled = new EnabledClass(option);
                    break;

                case "level":
                    Level = new LevelClass(option);
                    break;

                case "rowtextcolor":
                    RowTextColor = new RowTextColorClass(option);
                    break;

                case "severity":
                    Severity = new SeverityClass(option);
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
                case "separator":
                    HasSeparator = true;
                    break;

                default:
                    return false;
            }

            return true;
        }

        public class ConfirmClass : OptionsBase
        {
            public string Message { get; }

            public ConfirmClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');
                if (splitted.Length > 1)
                {
                    Message = splitted[1];
                }
            }
        }

        public class DisabledClass : OptionsBase
        {
            public uint? ColumnPid { get; }

            public IReadOnlyList<string> Values { get; }

            public DisabledClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split('=');

                if (splitted.Length == 1)
                {
                    Values = new List<string>(0);
                    return;
                }

                string[] items = splitted[1].Split(',');

                if (UInt32.TryParse(items[0], out uint columnPid))
                {
                    ColumnPid = columnPid;
                }

                if (items.Length > 1)
                {
                    Values = items.Skip(1).ToList();
                }
            }
        }

        public class EnabledClass : OptionsBase
        {
            public uint? ColumnPid { get; }

            public IReadOnlyList<string> Values { get; }

            public EnabledClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split('=');

                if (splitted.Length == 1)
                {
                    Values = new List<string>(0);
                    return;
                }

                string[] items = splitted[1].Split(',');

                if (UInt32.TryParse(items[0], out uint columnPid))
                {
                    ColumnPid = columnPid;
                }

                if (items.Length > 1)
                {
                    Values = items.Skip(1).ToList();
                }
            }
        }

        public class LevelClass : OptionsBase
        {
            public uint? Level { get; }

            public LevelClass(string option) : base(option)
            {
                string[] splitted = option.Split('=');
                if (splitted.Length > 1 && UInt32.TryParse(option, out uint level))
                {
                    Level = level;
                }
            }
        }

        public class SeverityClass : OptionsBase
        {
            public uint? Severity { get; }

            public SeverityClass(string option) : base(option)
            {
                string[] splitted = option.Split('=');
                if (splitted.Length > 1 && UInt32.TryParse(option, out uint severity))
                {
                    Severity = severity;
                }
            }
        }

        public class RowTextColorClass : OptionsBase
        {
            public string Value { get; }

            public RowTextColorClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');
                if (splitted.Length == 1)
                {
                    return;
                }

                Value = splitted[1];
            }
        }

        public class ScriptClass : OptionsBase
        {
            public string Value { get; }

            public ScriptClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');
                if (splitted.Length == 1)
                {
                    return;
                }

                Value = splitted[1];
            }
        }

        public class TableClass : OptionsBase
        {
            public SelectionType? Type { get; }

            public TableClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');
                if (splitted.Length == 1)
                {
                    return;
                }

                if (String.Equals("selection", splitted[1], StringComparison.OrdinalIgnoreCase))
                {
                    Type = SelectionType.Selection;
                }
                else if (String.Equals("singleselection", splitted[1], StringComparison.OrdinalIgnoreCase))
                {
                    Type = SelectionType.SingleSelection;
                }
            }

            public enum SelectionType
            {
                Selection,
                SingleSelection,
            }
        }
    }
}