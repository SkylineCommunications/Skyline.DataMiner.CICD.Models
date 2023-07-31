namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;

    public class PairOptions : OptionsBase
    {
        public CommBreakClass CommBreak { get; private set; }

        public ConnectionClass Connection { get; private set; }

        public bool HasIgnoreTimeout { get; private set; }

        public OneByteClass OneByte { get; private set; }

        public ReceiveIntervalClass ReceiveInterval { get; private set; }

        public RetriesClass Retries { get; private set; }

        public PairOptions(string optionsAttribute) : base(optionsAttribute)
        {
            if (String.IsNullOrWhiteSpace(optionsAttribute) || optionsAttribute.Length <= 0)
            {
                return;
            }

            char separator = optionsAttribute[0];
            if (Char.IsLetterOrDigit(separator))
            {
                separator = ';';
            }

            string[] options = optionsAttribute.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string option in options)
            {
                bool found = NoSignOptions(option);

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

            string optionCommand = optionSplit[0].ToLowerInvariant();

            switch (optionCommand)
            {
                case "onebyte":
                    OneByte = new OneByteClass(option);
                    break;

                case "commbreak":
                    CommBreak = new CommBreakClass(option);
                    break;

                case "connection":
                    Connection = new ConnectionClass(option);
                    break;

                case "retries":
                    Retries = new RetriesClass(option);
                    break;

                case "receiveinterval":
                    ReceiveInterval = new ReceiveIntervalClass(option);
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
                case "ignoretimeout":
                    HasIgnoreTimeout = true;
                    break;

                default:
                    return false;
            }

            return true;
        }

        public class OneByteClass : OptionsBase
        {
            public uint? Interval { get; }

            public OneByteClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');

                if (splitted.Length == 2 && UInt32.TryParse(splitted[1], out uint value))
                {
                    Interval = value;
                }
            }
        }

        public class CommBreakClass : OptionsBase
        {
            public uint? Interval { get; }

            public CommBreakClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');

                if (splitted.Length == 2 && UInt32.TryParse(splitted[1], out uint value))
                {
                    Interval = value;
                }
            }
        }

        public class ConnectionClass : OptionsBase
        {
            public uint? Id { get; }

            public ConnectionClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');

                if (splitted.Length == 2 && UInt32.TryParse(splitted[1], out uint value))
                {
                    Id = value;
                }
            }
        }

        public class ReceiveIntervalClass : OptionsBase
        {
            public uint? Interval { get; }

            public ReceiveIntervalClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');

                if (splitted.Length == 2 && UInt32.TryParse(splitted[1], out uint value))
                {
                    Interval = value;
                }
            }
        }

        public class RetriesClass : OptionsBase
        {
            public uint? Value { get; }

            public RetriesClass(string fullOption) : base(fullOption)
            {
                string[] splitted = fullOption.Split(':');

                if (splitted.Length == 2 && UInt32.TryParse(splitted[1], out uint value))
                {
                    Value = value;
                }
            }
        }
    }
}