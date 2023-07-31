namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Text.RegularExpressions;

    public class TableCondition : OptionsBase
    {
        public TableCondition(string conditionValue) : base(conditionValue)
        {
            if (conditionValue == null)
            {
                throw new ArgumentNullException(nameof(conditionValue));
            }
            
            const char Separator = ';';
            string[] parts = conditionValue.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0)
            {
                string conditionPart = parts[0];

                string[] conditionParts = conditionPart.Split(':');

                ColumnPidString = conditionParts[0];

                if (UInt32.TryParse(conditionParts[0], out uint c))
                {
                    ColumnPid = c;
                }

                if (conditionParts.Length > 1)
                {
                    ConditionValue = conditionParts[1];
                }
            }

            // Filter part
            if (parts.Length > 1)
            {
                Filter = new FilterClass(parts[1]);
            }
        }

        public uint? ColumnPid { get; }

        public string ColumnPidString { get; }

        public string ConditionValue { get; }

        public FilterClass Filter{ get; }
    
        public class FilterClass : OptionsBase
        {
            public FilterClass(string filterValue) : base(filterValue)
            {
                if (filterValue == null)
                {
                    throw new ArgumentNullException(nameof(filterValue));
                }

                Regex regex = new Regex(@"filter:fk=(.+)");

                Match m = regex.Match(filterValue);

                if (m.Success)
                {
                    ColumnId = m.Groups[1].Value;
                }
            }

            public string ColumnId { get; }
        }
    }
}