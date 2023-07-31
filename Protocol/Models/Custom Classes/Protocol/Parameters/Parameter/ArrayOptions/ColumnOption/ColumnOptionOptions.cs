namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Globalization;

    public class ColumnOptionOptions : OptionsBase
    {
        public char Separator { get; }

        public Cpe CPE { get; }

        public Dve DVE { get; }

        public VisioClass Visio { get; }

        public ServiceOverviewManager SOM { get; }

        public bool IsDelete { get; private set; }

        public bool IsSaved { get; private set; }

        public bool IsDisplayIcon { get; private set; }

        /// <summary>
        /// DataMiner 9.5.2
        /// </summary>
        public bool IsDisplayElementAlarm { get; private set; }

        public ForeignKeyClass ForeignKey { get; private set; }

        public ViewTableClass ViewTable { get; private set; }

        public DeltaClass Delta { get; private set; }

        public bool IsDisableHeaderAvg { get; private set; }

        public bool IsDisplayViewAlarm { get; private set; }

        public bool IsDisplayServiceAlarm { get; private set; }

        public GroupByClass GroupBy { get; private set; }

        public bool IsIndexColumn { get; private set; }

        public bool IsLinkElement { get; private set; }

        public bool IsRowTextColoring { get; private set; }

        public bool IsSetOnTable { get; private set; }

        public bool IsVolatile { get; private set; }

        public ColumnOptionOptions(string columnOptionOptions) : base(columnOptionOptions)
        {
            DVE = new Dve();
            CPE = new Cpe();
            Visio = new VisioClass();
            SOM = new ServiceOverviewManager();

            if (String.IsNullOrWhiteSpace(columnOptionOptions))
            {
                Separator = ';';
                return;
            }

            Separator = Char.IsLetterOrDigit(columnOptionOptions[0]) ? ';' : columnOptionOptions[0];

            string[] options = columnOptionOptions.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
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

        private bool DoublePointSignOptions(string option)
        {
            string[] optionSplit = option.Split(':');

            if (optionSplit.Length < 2)
            {
                // TODO: Change the classes as to only accept the entire option and maybe the splitted already.
                // So that the class is made, but the internal data is null
                return false;
            }

            string optionCommand = optionSplit[0].ToLowerInvariant();

            switch (optionCommand)
            {
                case "selectionsetvar":
                    Visio.SelectionSetVar = new SelectionSetVarClass(option, optionSplit[1]);
                    break;

                case "selectionsetcardvar":
                    Visio.SelectionSetCardVar = new SelectionSetVarClass(option, optionSplit[1]);
                    break;

                case "selectionsetpagevar":
                    Visio.SelectionSetPageVar = new SelectionSetVarClass(option, optionSplit[1]);
                    break;

                case "selectionsetworkspacevar":
                    Visio.SelectionSetWorkspaceVar = new SelectionSetVarClass(option, optionSplit[1]);
                    break;

                case "showreadaskpi":
                    // TODO, not sure how to represent (as user needs to add false)
                    break;

                case "subtitle":
                    CPE.SubTitle = new SubTitleClass(option, optionSplit[1]);
                    break;

                default:
                    return false;
            }

            return true;
        }

        private bool EqualSignOptions(string option)
        {
            string[] optionSplit = option.Split('=');

            string optionCommand = optionSplit[0].ToLowerInvariant();

            switch (optionCommand)
            {
                case "delta":

                    if (optionSplit.Length < 2)
                    {
                        // TODO: Change the classes as to only accept the entire option and maybe the splitted already.
                        // So that the class is made, but the internal data is null
                        return false;
                    }
                    Delta = new DeltaClass(option, optionSplit[1]);
                    break;

                case "foreignkey":

                    if (optionSplit.Length < 2)
                    {
                        // TODO: Change the classes as to only accept the entire option and maybe the splitted already.
                        // So that the class is made, but the internal data is null
                        return false;
                    }
                    ForeignKey = new ForeignKeyClass(option, optionSplit[1]);
                    break;

                case "groupby":

                    if (optionSplit.Length < 2)
                    {
                        // TODO: Change the classes as to only accept the entire option and maybe the splitted already.
                        // So that the class is made, but the internal data is null
                        return false;
                    }
                    GroupBy = new GroupByClass(option, optionSplit[1]);
                    break;

                case "showreadaskpi":
                    // TODO, not sure how to represent (as user needs to add false)
                    break;

                case "view":
                    if (optionSplit.Length > 1)
                    {
                        // View tables
                        ViewTable = new ViewTableClass(option);
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
                case "cpedummycolumn":
                    CPE.IsCPEDummyColumn = true;
                    break;

                case "delete":
                    IsDelete = true;
                    break;

                case "displayicon":
                    IsDisplayIcon = true;
                    break;

                case "displayelementalarm":
                    IsDisplayElementAlarm = true;
                    break;

                case "displayservicealarm":
                    IsDisplayServiceAlarm = true;
                    break;

                case "displayviewalarm":
                    IsDisplayViewAlarm = true;
                    break;

                case "disabledheaderavg":
                    // TODO: Maybe Nullable enum (Enabled/Disabled)? for header, heatmap, histogram
                    IsDisableHeaderAvg = true;
                    break;

                case "dynamicdata":
                    Visio.IsDynamicData = true;
                    break;

                case "element":
                    DVE.IsElement = true;
                    break;

                case "hidden":
                    DVE.IsHidden = true;
                    break;

                case "hidekpi":
                    CPE.IsHideKPI = true;
                    break;

                case "hidesummarycolumn":
                    SOM.IsHideSummaryColumn = true;
                    break;

                case "indexcolumn":
                    IsIndexColumn = true;
                    break;

                case "kpihidewrite":
                    CPE.IsKPIHideWrite = true;
                    break;

                case "linkelement":
                    IsLinkElement = true;
                    break;

                case "rowtextcoloring":
                    IsRowTextColoring = true;
                    break;

                case "save":
                    IsSaved = true;
                    break;

                case "setontable":
                    IsSetOnTable = true;
                    break;

                case "severity":
                    DVE.IsSeverity = true;
                    break;

                case "severitycolumn":
                    SOM.IsSeverityColumn = true;
                    break;

                case "severitycolumnindex":
                    SOM.IsSeverityColumnIndex = true;
                    break;

                case "space":
                    CPE.IsSpace = true;
                    break;

                case "volatile":
                    IsVolatile = true;
                    break;

                case "view":
                    DVE.IsDveViewColumn = true;
                    break;

                // Not in documentation anymore...
                ////case "xpos":
                ////    IsXPos = true;
                ////    break;

                ////case "ypos":
                ////    IsYPos = true;
                ////    break;

                default:
                    return false;
            }

            return true;
        }

        public class Cpe
        {
            /// <summary>
            /// DataMiner 9.6.4
            /// </summary>
            public bool IsCPEDummyColumn { get; internal set; }

            public bool IsHideKPI { get; internal set; }

            public bool IsKPIHideWrite { get; internal set; }

            public bool IsSpace { get; internal set; }

            public SubTitleClass SubTitle { get; internal set; }
        }

        public class VisioClass
        {
            public bool IsDynamicData { get; internal set; }

            public SelectionSetVarClass SelectionSetVar { get; internal set; }

            public SelectionSetVarClass SelectionSetWorkspaceVar { get; internal set; }

            public SelectionSetVarClass SelectionSetPageVar { get; internal set; }

            public SelectionSetVarClass SelectionSetCardVar { get; internal set; }
        }

        public class Dve
        {
            public bool IsDveViewColumn { get; internal set; }

            public bool IsElement { get; internal set; }

            public bool IsHidden { get; internal set; }

            public bool IsSeverity { get; internal set; }
        }

        public class ServiceOverviewManager
        {
            public bool IsHideSummaryColumn { get; internal set; }

            public bool IsSeverityColumn { get; internal set; }

            public bool IsSeverityColumnIndex { get; internal set; }
        }

        public class GroupByClass : OptionsBase
        {
            public uint? Idx { get; }

            public GroupByClass(string fullOption, string value) : base(fullOption)
            {
                if (UInt32.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out uint idx))
                {
                    Idx = idx;
                }
            }
        }

        public class SelectionSetVarClass : OptionsBase
        {
            public string Variable { get; }

            public SelectionSetVarClass(string fullOption, string value) : base(fullOption)
            {
                Variable = value;
            }
        }

        public class SubTitleClass : OptionsBase
        {
            public string Value { get; }

            public SubTitleClass(string fullOption, string value) : base(fullOption)
            {
                Value = value;
            }
        }

        public class ForeignKeyClass : OptionsBase
        {
            public uint? Pid { get; }

            public ForeignKeyClass(string fullOption, string value) : base(fullOption)
            {
                if (UInt32.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out uint pid))
                {
                    Pid = pid;
                }
            }
        }

        public class DeltaClass : OptionsBase
        {
            public uint? Index { get; }

            public uint? Pid { get; }

            public DeltaClass(string fullOption, string value) : base(fullOption)
            {
                string[] splittedValue = value.Split(':');

                if (UInt32.TryParse(splittedValue[0], NumberStyles.None, CultureInfo.InvariantCulture, out uint idx))
                {
                    Index = idx;
                }

                if (splittedValue.Length > 1 && UInt32.TryParse(splittedValue[1], NumberStyles.None, CultureInfo.InvariantCulture, out uint pid))
                {
                    Pid = pid;
                }
            }
        }

        public class ViewTableClass : OptionsBase
        {
            public uint? Id { get; }

            public uint? Id2 { get; }

            public uint? Id3 { get; }

            public bool IsRemote { get; }

            public string OptionValue { get; }

            public ViewTableClass(string fullOption) : base(fullOption)
            {
                string[] optionSplit = fullOption.Split('=');

                if (String.Equals(optionSplit[0], "view", StringComparison.OrdinalIgnoreCase) &&
                    optionSplit.Length == 2 && !String.IsNullOrWhiteSpace(optionSplit[1]))
                {
                    string value = optionSplit[1];
                    OptionValue = value;

                    // Check with Regex

                    // Option 1 => view=1201
                    if (ParsingHelper.TryMatchRegex(value, @"^(?<id1>\d+)$", out var match1))
                    {
                        string id1 = match1.Groups["id1"].Value;

                        if (UInt32.TryParse(id1, out uint parsedId))
                        {
                            Id = parsedId;
                        }
                    }
                    // Option 2 => view=1204:2004
                    else if (ParsingHelper.TryMatchRegex(value, @"^(?<id1>\d+):(?<id2>\d+)$", out var match2))
                    {
                        string id1 = match2.Groups["id1"].Value;
                        string id2 = match2.Groups["id2"].Value;

                        if (UInt32.TryParse(id1, out uint parsedId))
                        {
                            Id = parsedId;
                        }

                        if (UInt32.TryParse(id2, out uint parsedId2))
                        {
                            Id2 = parsedId2;
                        }
                    }
                    // Option 3 => view=:2802:1000:1 -> first ':' is not a typo!
                    else if (ParsingHelper.TryMatchRegex(value, @"^:(?<id1>\d+):(?<id2>\d+):(?<id3>\d+)$", out var match3))
                    {
                        string id1 = match3.Groups["id1"].Value;
                        string id2 = match3.Groups["id2"].Value;
                        string id3 = match3.Groups["id3"].Value;

                        if (UInt32.TryParse(id1, out uint parsedId))
                        {
                            Id = parsedId;
                        }

                        if (UInt32.TryParse(id2, out uint parsedId2))
                        {
                            Id2 = parsedId2;
                        }

                        if (UInt32.TryParse(id3, out uint parsedId3))
                        {
                            Id3 = parsedId3;
                        }

                        IsRemote = true;
                    }
                }
            }
        }
    }
}