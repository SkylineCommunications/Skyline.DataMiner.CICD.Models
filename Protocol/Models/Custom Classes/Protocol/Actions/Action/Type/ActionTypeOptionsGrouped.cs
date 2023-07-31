namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public class ActionTypeOptionsGrouped
    {
        public ActionTypeOptionsGrouped(ActionTypeOptions options)
        {
            if (options == null)
            {
                return;
            }

            Merge = new MergeClass(options);
            Aggregate = new AggregateClass(options);
            Wmi = new WmiClass(options);
            Swap = new SwapClass(options);
            Append = new AppendClass(options);
        }

        public AggregateClass Aggregate { get; }

        public MergeClass Merge { get; }

        public WmiClass Wmi { get; }

        public SwapClass Swap { get; }

        public AppendClass Append { get; }

        public class AggregateClass
        {
            public AggregateClass(ActionTypeOptions options)
            {
                AllowValues = options.AllowValues;
                IgnoreValues = options.IgnoreValues;
                HasAvoidZeroInResult = options.HasAvoidZeroInResult;
                DefaultIf = options.DefaultIf;
                DefaultValue = options.DefaultValue;
                Equation = options.Equation;
                EquationValue = options.EquationValue;
                ////Filter = options.Filter;
                GroupBy = options.GroupBy;
                GroupByTable = options.GroupByTable;
                Join = options.Join;
                Return = options.Return;
                Status = options.Status;
                HasThreaded = options.HasThreaded;
                Type = options.Type;
                Weight = options.Weight;
            }

            public ActionTypeOptions.AllowValuesClass AllowValues { get; }

            public ActionTypeOptions.IgnoreValuesClass IgnoreValues { get; }

            public bool HasAvoidZeroInResult { get; }

            public ActionTypeOptions.DefaultIfClass DefaultIf { get; }

            public ActionTypeOptions.DefaultValueClass DefaultValue { get; }

            public ActionTypeOptions.EquationClass Equation { get; }

            public ActionTypeOptions.EquationValueClass EquationValue { get; }

            // TODO: Filter?

            public ActionTypeOptions.GroupByClass  GroupBy { get; }

            public ActionTypeOptions.GroupByTableClass GroupByTable { get; }

            public ActionTypeOptions.JoinClass Join { get; }

            public ActionTypeOptions.ReturnClass Return { get; }

            public ActionTypeOptions.StatusClass Status { get; }

            public bool HasThreaded { get; }

            public ActionTypeOptions.TypeClass Type { get; }

            public ActionTypeOptions.WeightClass Weight { get; }
        }

        public class MergeClass
        {
            public MergeClass(ActionTypeOptions options)
            {
                Destination = options.Destination;
                DefaultIf = options.DefaultIf;
                DefaultValue = options.DefaultValue;
                HasDeleteHistory = options.HasDeleteHistory;
                DestinationFindPk = options.DestinationFindPk;
                LimitResult = options.LimitResult;
                HasMergeResult = options.HasMergeResult;
                RemoteElements = options.RemoteElements;
                Resolve = options.Resolve;
                Trigger = options.Trigger;
                Type = options.Type;
            }

            public ActionTypeOptions.DestinationClass Destination { get; }

            public ActionTypeOptions.DefaultIfClass DefaultIf { get; }

            public ActionTypeOptions.DefaultValueClass DefaultValue { get; }

            public bool HasDeleteHistory { get; }

            public ActionTypeOptions.DestinationFindPkClass DestinationFindPk { get; }

            public ActionTypeOptions.LimitResultClass LimitResult { get; }

            public bool HasMergeResult { get; }

            public ActionTypeOptions.RemoteElementsClass RemoteElements { get; }

            public ActionTypeOptions.ResolveClass Resolve { get; }

            public ActionTypeOptions.TriggerClass Trigger { get; }

            public ActionTypeOptions.TypeClass Type { get; }
        }

        public class WmiClass
        {
            public WmiClass(ActionTypeOptions options)
            {
                Connection = options.Connection;
                Pwd = options.Pwd;
                Server = options.Server;
                Table = options.Table;
                UName = options.UName;
                Where = options.Where;
            }

            public ActionTypeOptions.ConnectionClass Connection { get; }

            public ActionTypeOptions.PwdClass Pwd { get; }

            public ActionTypeOptions.ServerClass Server { get; }

            public ActionTypeOptions.TableClass Table { get; }

            public ActionTypeOptions.UNameClass UName { get; }

            public ActionTypeOptions.WhereClass Where { get; }
        }

        public class SwapClass
        {
            public SwapClass(ActionTypeOptions options)
            {
                Swap = options.Swap;
            }

            public ActionTypeOptions.SwapClass Swap { get; }
        }

        public class AppendClass
        {
            public AppendClass(ActionTypeOptions options)
            {
                Hex = options.Hex;
            }

            public ActionTypeOptions.HexClass Hex { get; }
        }
    }
}