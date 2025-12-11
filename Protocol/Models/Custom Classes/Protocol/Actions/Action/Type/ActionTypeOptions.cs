namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ActionTypeOptions : OptionsBase
    {
        public ActionTypeOptions(string optionsAttribute) : base(optionsAttribute)
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

                    if (!found)
                    {
                        found = DashSignOptions(option);
                    }

                    // TODO: 'filter' => Not documented in DDL

                    if (!found)
                    {
                        // Add to list of unknown options?
                    }
                }
            }
        }

        public GroupByClass GroupBy { get; private set; }

        public bool HasThreaded { get; private set; }

        public WeightClass Weight { get; private set; }

        public TypeClass Type { get; private set; }

        public ReturnClass Return { get; private set; }

        public DefaultValueClass DefaultValue { get; private set; }

        public bool HasAvoidZeroInResult { get; private set; }

        public AllowValuesClass AllowValues { get; private set; }

        public IgnoreValuesClass IgnoreValues { get; private set; }

        public EquationClass Equation { get; private set; }

        public EquationValueClass EquationValue { get; private set; }

        public JoinClass Join { get; private set; }

        public StatusClass Status { get; private set; }

        public HexClass Hex { get; private set; }

        public DestinationClass Destination { get; private set; }

        public bool HasDeleteHistory { get; private set; }

        public bool HasMergeResult { get; private set; }

        public RemoteElementsClass RemoteElements { get; private set; }

        public LimitResultClass LimitResult { get; private set; }

        public DestinationFindPkClass DestinationFindPk { get; private set; }

        public ResolveClass Resolve { get; private set; }

        public TriggerClass Trigger { get; private set; }

        public SwapClass Swap { get; private set; }

        public ConnectionClass Connection { get; private set; }

        public PwdClass Pwd { get; private set; }

        public ServerClass Server { get; private set; }

        public TableClass Table { get; private set; }

        public UNameClass UName { get; private set; }

        public WhereClass Where { get; private set; }

        public DefaultIfClass DefaultIf { get; private set; }

        public GroupByTableClass GroupByTable { get; private set; }

        private bool DoublePointSignOptions(string option)
        {
            string[] optionSplit = option.Split(':');

            string optionCommand = optionSplit[0].ToLower();

            switch (optionCommand)
            {
                case "groupby":
                    GroupBy = new GroupByClass(option);
                    break;

                case "groupbytable":
                    GroupByTable = new GroupByTableClass(option);
                    break;

                case "weight":
                    Weight = new WeightClass(option);
                    break;

                case "type":
                    Type = new TypeClass(option);
                    break;

                case "return":
                    Return = new ReturnClass(option);
                    break;

                case "defaultvalue":
                    DefaultValue = new DefaultValueClass(option);
                    break;

                case "defaultif":
                    DefaultIf = new DefaultIfClass(option);
                    break;

                case "allowvalues":
                    AllowValues = new AllowValuesClass(option);
                    break;

                case "ignorevalues":
                    IgnoreValues = new IgnoreValuesClass(option);
                    break;

                case "equation":
                    Equation = new EquationClass(option);
                    break;

                case "equationvalue":
                    EquationValue = new EquationValueClass(option);
                    break;

                case "join":
                    Join = new JoinClass(option);
                    break;

                case "status":
                    Status = new StatusClass(option);
                    break;

                case "destination":
                    Destination = new DestinationClass(option);
                    break;

                case "destinationfindpk":
                    DestinationFindPk = new DestinationFindPkClass(option);
                    break;

                case "limitresult":
                    LimitResult = new LimitResultClass(option);
                    break;

                case "remoteelements":
                    RemoteElements = new RemoteElementsClass(option);
                    break;

                case "resolve":
                    Resolve = new ResolveClass(option);
                    break;

                case "trigger":
                    Trigger = new TriggerClass(option);
                    break;

                case "swap":
                    Swap = new SwapClass(option);
                    break;

                case "connection":
                    Connection = new ConnectionClass(option);
                    break;

                case "pwd":
                    Pwd = new PwdClass(option);
                    break;

                case "server":
                    Server = new ServerClass(option);
                    break;

                case "table":
                    Table = new TableClass(option);
                    break;

                case "uname":
                    UName = new UNameClass(option);
                    break;

                case "where":
                    Where = new WhereClass(option);
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
                default:
                    return false;
            }

            ////return true;
        }

        private bool NoSignOptions(string option)
        {
            switch (option.ToLowerInvariant())
            {
                case "threaded":
                    HasThreaded = true;
                    break;

                case "avoidzeroinresult":
                    HasAvoidZeroInResult = true;
                    break;

                case "deletehistory":
                    HasDeleteHistory = true;
                    break;

                case "mergeresult":
                    HasMergeResult = true;
                    break;

                default:
                    return false;
            }

            return true;
        }

        private bool DashSignOptions(string option)
        {
            string[] optionSplit = option.Split('-');

            string optionCommand = optionSplit[0].ToLowerInvariant();

            switch (optionCommand)
            {
                case "hex":
                    Hex = new HexClass(option);
                    break;

                default:
                    return false;
            }

            return true;
        }

        public class GroupByClass : OptionsBase
        {
            public GroupByClass(string option) : base(option)
            {
                option = option.Remove(0, "groupby:".Length);

                string[] parts = option.Split(',');

                var values = new List<(uint? columnIdx, uint? columnPid, bool shouldHavePid)>();
                foreach (var part in parts)
                {
                    string[] secondParts = part.Split(':');

                    uint? idx = null;
                    uint? pid = null;

                    if (UInt32.TryParse(secondParts[0], out uint i))
                    {
                        idx = i;
                    }

                    if (secondParts.Length == 2)
                    {
                        if (UInt32.TryParse(secondParts[1], out uint p))
                        {
                            pid = p;
                        }

                        values.Add((idx, pid, true));
                    }
                    else
                    {
                        values.Add((idx, pid, false));
                    }
                }

                Values = values;
            }

            public IReadOnlyList<(uint? columnIdx, uint? columnPid, bool shouldHavePid)> Values { get; }
        }

        public class WeightClass : OptionsBase
        {
            public WeightClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint v))
                {
                    Value = v;
                }
            }

            public uint? Value { get; }
        }

        public class TypeClass : OptionsBase
        {
            public TypeClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                switch (parts[1].ToLower())
                {
                    case "pct": Value = Type.Pct; break;
                    case "avg": Value = Type.Avg; break;
                    case "avg extended": Value = Type.AvgExtended; break;
                    case "max": Value = Type.Max; break;
                    case "min": Value = Type.Min; break;
                    case "count": Value = Type.Count; break;
                    case "sum": Value = Type.Sum; break;
                    default: return;
                }
            }

            public enum Type
            {
                Pct,
                Avg,
                AvgExtended,
                Max,
                Min,
                Count,
                Sum,
            }

            public Type Value { get; }
        }

        public class ReturnClass : OptionsBase
        {
            public ReturnClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                if (UInt32.TryParse(secondParts[0], out uint v1))
                {
                    Value1 = v1;
                }

                if (secondParts.Length > 1 && UInt32.TryParse(secondParts[1], out uint v2))
                {
                    Value2 = v2;
                }

                if (secondParts.Length > 2 && UInt32.TryParse(secondParts[2], out uint v3))
                {
                    Value3 = v3;
                }

                if (secondParts.Length > 3 && UInt32.TryParse(secondParts[3], out uint v4))
                {
                    Value4 = v4;
                }
            }

            public uint? Value1 { get; }

            public uint? Value2 { get; }

            public uint? Value3 { get; }

            public uint? Value4 { get; }
        }

        public class DefaultValueClass : OptionsBase
        {
            public DefaultValueClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                if (secondParts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(secondParts[0], out uint pid))
                {
                    ColumnPid = pid;
                }

                if (UInt32.TryParse(secondParts[1], out uint v))
                {
                    Value = v;
                }
            }

            public uint? ColumnPid { get; }

            public uint? Value { get; }
        }

        public class DefaultIfClass : OptionsBase
        {
            public DefaultIfClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                if (secondParts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(secondParts[0], out uint pid))
                {
                    ColumnIdx = pid;
                }

                if (UInt32.TryParse(secondParts[1], out uint v))
                {
                    Value = v;
                }
            }

            public uint? ColumnIdx { get; }

            public uint? Value { get; }
        }

        public class AllowValuesClass : OptionsBase
        {
            public AllowValuesClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                List<string> values = new List<string>();
                List<(uint?, string)> tableValues = new List<(uint?, string)>();

                foreach (var part in secondParts)
                {
                    string[] pieces = part.Split('/');

                    if (pieces.Length == 1)
                    {
                        values.Add(pieces[0]);
                        continue;
                    }

                    if (pieces.Length == 2)
                    {
                        uint? temp = null;
                        if (UInt32.TryParse(pieces[0], out uint t))
                        {
                            temp = t;
                        }

                        tableValues.Add((temp, pieces[1]));
                    }
                }

                Values = values;
                TableValues = tableValues;
            }

            private IReadOnlyList<string> Values { get; }

            private IReadOnlyList<(uint? columnIdx, string value)> TableValues { get; }
        }

        public class IgnoreValuesClass : OptionsBase
        {
            public IgnoreValuesClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                List<string> values = new List<string>();
                List<(uint?, string)> tableValues = new List<(uint?, string)>();

                foreach (var part in secondParts)
                {
                    string[] pieces = part.Split('/');

                    if (pieces.Length == 1)
                    {
                        values.Add(pieces[0]);
                        continue;
                    }

                    if (pieces.Length == 2)
                    {
                        uint? temp = null;
                        if (UInt32.TryParse(pieces[0], out uint t))
                        {
                            temp = t;
                        }

                        tableValues.Add((temp, pieces[1]));
                    }
                }

                Values = values;
                TableValues = tableValues;
            }

            private IReadOnlyList<string> Values { get; }

            private IReadOnlyList<(uint? columnIdx, string value)> TableValues { get; }
        }

        public class EquationClass : OptionsBase
        {
            public EquationClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                if (secondParts.Length != 2)
                {
                    return;
                }

                Operator = secondParts[0];
                if (UInt32.TryParse(secondParts[1], out uint pid))
                {
                    Pid = pid;
                }
            }

            public string Operator { get; }

            public uint? Pid { get; }
        }

        public class EquationValueClass : OptionsBase
        {
            public EquationValueClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                if (secondParts.Length != 4)
                {
                    return;
                }

                EquationType = secondParts[0];
                CompareValue = secondParts[1];
                if (UInt32.TryParse(secondParts[2], out uint pid))
                {
                    Pid = pid;
                }

                PrimaryKey = secondParts[3];
            }

            public string EquationType { get; }

            public string CompareValue { get; }

            public uint? Pid { get; }

            public string PrimaryKey { get; }
        }

        public class GroupByTableClass : OptionsBase
        {
            public GroupByTableClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint v))
                {
                    Pid = v;
                }
            }

            public uint? Pid { get; }
        }

        public class JoinClass : OptionsBase
        {
            public JoinClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                List<uint?> pids = new List<uint?>();

                foreach (var part in secondParts)
                {
                    if (UInt32.TryParse(part, out uint v))
                    {
                        pids.Add(v);
                    }
                    else
                    {
                        pids.Add(null);
                    }
                }

                ColumnPids = pids;
            }

            public IReadOnlyList<uint?> ColumnPids { get; }
        }

        public class StatusClass : OptionsBase
        {
            public StatusClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint v))
                {
                    Value = v;
                }
            }

            public uint? Value { get; }
        }

        public class HexClass : OptionsBase
        {
            public HexClass(string option) : base(option)
            {
                string[] parts = option.Split('-');

                if (parts.Length == 2 && UInt32.TryParse(parts[1], out uint v))
                {
                    Bytes = v;
                }
            }

            public uint? Bytes { get; }
        }

        public class DestinationClass : OptionsBase
        {
            public DestinationClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                List<uint?> columnPids = new List<uint?>();

                foreach (var part in secondParts)
                {
                    if (UInt32.TryParse(part, out uint v))
                    {
                        columnPids.Add(v);
                    }
                    else
                    {
                        columnPids.Add(null);
                    }
                }

                ColumnPids = columnPids;
            }

            public IReadOnlyList<uint?> ColumnPids { get; }
        }

        public class DestinationFindPkClass : OptionsBase
        {
            public DestinationFindPkClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                List<uint?> columnPids = new List<uint?>();

                foreach (var part in secondParts)
                {
                    if (UInt32.TryParse(part, out uint v))
                    {
                        columnPids.Add(v);
                    }
                    else
                    {
                        columnPids.Add(null);
                    }
                }

                ColumnPids = columnPids;
            }

            public IReadOnlyList<uint?> ColumnPids { get; }
        }

        public class LimitResultClass : OptionsBase
        {
            public LimitResultClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint v))
                {
                    Pid = v;
                }
            }

            public uint? Pid { get; }
        }

        public class RemoteElementsClass : OptionsBase
        {
            public RemoteElementsClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint v))
                {
                    ColumnPid = v;
                }
            }

            public uint? ColumnPid { get; }
        }

        public class ResolveClass : OptionsBase
        {
            public ResolveClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                string[] secondParts = parts[1].Split(',');

                List<uint?> columnPids = new List<uint?>();

                foreach (var part in secondParts)
                {
                    if (UInt32.TryParse(part, out uint v))
                    {
                        columnPids.Add(v);
                    }
                    else
                    {
                        columnPids.Add(null);
                    }
                }

                ColumnPids = columnPids;
            }

            public IReadOnlyList<uint?> ColumnPids { get; }
        }

        public class TriggerClass : OptionsBase
        {
            public TriggerClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint v))
                {
                    Pid = v;
                }
            }

            public uint? Pid { get; }
        }

        public class SwapClass : OptionsBase
        {
            public SwapClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 4)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint tablePid))
                {
                    TablePid = tablePid;
                }

                if (UInt32.TryParse(parts[2], out uint sourceColumnPid))
                {
                    SourceColumnPid = sourceColumnPid;
                }

                if (UInt32.TryParse(parts[3], out uint destinationColumnPid))
                {
                    DestinationColumnPid = destinationColumnPid;
                }
            }

            public uint? TablePid { get; }

            public uint? SourceColumnPid { get; }

            public uint? DestinationColumnPid { get; }
        }

        public class ConnectionClass : OptionsBase
        {
            public ConnectionClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint id))
                {
                    Pid = id;
                }
            }

            public uint? Pid { get; }
        }

        public class PwdClass : OptionsBase
        {
            public PwdClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint id))
                {
                    Pid = id;
                }
            }

            public uint? Pid { get; }
        }

        public class ServerClass : OptionsBase
        {
            public ServerClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint id))
                {
                    Pid = id;
                }
                else if (String.Equals(parts[1], "pollingip", StringComparison.OrdinalIgnoreCase))
                {
                    HasPollingIp = true;
                }
            }

            public uint? Pid { get; }

            public bool HasPollingIp { get; }
        }

        public class TableClass : OptionsBase
        {
            public TableClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (Boolean.TryParse(parts[1], out bool v))
                {
                    Value = v;
                }
            }

            public bool? Value { get; }
        }

        public class UNameClass : OptionsBase
        {
            public UNameClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                if (parts.Length != 2)
                {
                    return;
                }

                if (UInt32.TryParse(parts[1], out uint id))
                {
                    Pid = id;
                }
            }

            public uint? Pid { get; }
        }

        public class WhereClass : OptionsBase
        {
            public WhereClass(string option) : base(option)
            {
                string[] parts = option.Split(':');

                switch (parts.Length)
                {
                    case 2:
                        Value = parts[1];
                        break;
                    case 3 when String.Equals(parts[1], "ID", StringComparison.OrdinalIgnoreCase) && UInt32.TryParse(parts[2], out uint id):
                        Pid = id;
                        break;
                }
            }

            public string Value { get; set; }

            public uint? Pid { get; set; }
        }
    }
}