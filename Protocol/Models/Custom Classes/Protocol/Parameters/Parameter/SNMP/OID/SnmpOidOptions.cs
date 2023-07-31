namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;

    public class SnmpOidOptions : OptionsBase
    {
        public SnmpOidOptions(string optionsAttribute) : base(optionsAttribute)
        {
            if (!String.IsNullOrWhiteSpace(optionsAttribute) && optionsAttribute.Length > 0)
            {
                char separator = ';';

                string[] options = optionsAttribute.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var option in options)
                {
                    bool found = NoSignOptions(option);

                    ////if (!found)
                    ////{
                    ////    found = EqualSignOptions(option);
                    ////}

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

        public BulkClass Bulk { get; private set; }

        public bool HasColumn { get; private set; }

        public bool HasInstance { get; private set; }

        public bool HasMultipleGetNext { get; private set; }

        public MultipleGetBulkClass MultipleGetBulk { get; private set; }

        public MultipleGetBulkClass PartialSnmp { get; private set; }

        public bool HasSubtable { get; private set; }

        private bool DoublePointSignOptions(string option)
        {
            string[] optionSplit = option.Split(':');

            string optionCommand = optionSplit[0].ToLower();

            switch (optionCommand)
            {
                case "bulk":
                    Bulk = new BulkClass(option);
                    break;

                case "multiplegetbulk":
                    MultipleGetBulk = new MultipleGetBulkClass(option);
                    break;

                case "partialsnmp":
                    PartialSnmp = new MultipleGetBulkClass(option);
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
                case "column":
                    HasColumn = true;
                    break;

                case "instance":
                    HasInstance = true;
                    break;

                case "multiplegetnext":
                    HasMultipleGetNext = true;
                    break;

                case "subtable":
                    HasSubtable = true;
                    break;

                default:
                    return false;
            }

            return true;
        }

        public class BulkClass : OptionsBase
        {
            public uint? Amount { get; }

            public BulkClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');
                if (splitted.Length > 1 && UInt32.TryParse(splitted[1], out uint amount))
                {
                    Amount = amount;
                }
            }
        }

        public class MultipleGetBulkClass : OptionsBase
        {
            public uint? Amount { get; }

            public MultipleGetBulkClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');
                if (splitted.Length > 1 && UInt32.TryParse(splitted[1], out uint amount))
                {
                    Amount = amount;
                }
            }
        }

        public class PartialSnmpClass : OptionsBase
        {
            public uint? Amount { get; }

            public PartialSnmpClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');
                if (splitted.Length > 1 && UInt32.TryParse(splitted[1], out uint amount))
                {
                    Amount = amount;
                }
            }
        }
    }
}