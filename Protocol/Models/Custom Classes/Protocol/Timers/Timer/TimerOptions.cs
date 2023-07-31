namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;

    public class TimerOptionsBase : OptionsBase
    {
        public ISet<string> UnknownOptions { get; }

        public ISet<string> DuplicateOptions { get; }

        protected IDictionary<string, int> KnownOptionCounts { get; set; }

        protected TimerOptionsBase(string optionsAttribute) : base(optionsAttribute)
        {
            KnownOptionCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            UnknownOptions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            DuplicateOptions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        protected void AddToKnownOptionsCount(string optionName)
        {
            if (KnownOptionCounts.TryGetValue(optionName, out int count))
            {
                KnownOptionCounts[optionName] = ++count;
            }
            else
            {
                KnownOptionCounts.Add(optionName, 1);
            }
        }

        protected void AddToUnknownOptions(string optionName)
        {
            if (!UnknownOptions.Contains(optionName))
            {
                UnknownOptions.Add(optionName);
            }
        }
    }

    public class TimerOptions : TimerOptionsBase
    {
        public EachTimerOption Each { get; private set; }

        public DynamicThreadPoolTimerOption DynamicThreadPool { get; private set; }

        public IgnoreIfTimerOption IgnoreIf { get; private set; }

        public InstanceTimerOption Instance { get; private set; }

        public IpTimerOption IPAddress { get; private set; }

        public PingTimerOption Ping { get; private set; }

        public PollingRateTimerOption PollingRate { get; private set; }

        public QActionTimerOption QAction { get; private set; }

        public QActionTimerOption QActionAfter { get; private set; }

        public QActionTimerOption QActionBefore { get; private set; }

        public ThreadPoolTimerOption ThreadPool { get; private set; }

        public TimerOptions(string optionsAttribute) : base(optionsAttribute)
        {
            if (!String.IsNullOrWhiteSpace(optionsAttribute) && optionsAttribute.Length > 0)
            {
                char separator = ';';

                string[] options = optionsAttribute.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var option in options)
                {
                    ProcessOption(option);
                }

                foreach (var option in KnownOptionCounts)
                {
                    if (option.Value > 1)
                    {
                        DuplicateOptions.Add(option.Key);
                    }
                }
            }
        }

        private void ProcessOption(string option)
        {
            string[] optionSplit = option.Split(':');

            string optionNameUpperCase = optionSplit[0].ToUpperInvariant();

            string optionValue = "";
            if (optionSplit.Length > 1)
            {
                optionValue = optionSplit[1];

                if (optionSplit.Length > 2)
                {
                    optionValue = String.Join(":", optionSplit, 1, optionSplit.Length - 1);
                }
            }

            switch (optionNameUpperCase)
            {
                case "EACH":
                    AddToKnownOptionsCount("each");
                    Each = new EachTimerOption(option, optionValue);
                    break;
                case "DYNAMICTHREADPOOL":
                    AddToKnownOptionsCount("dynamicThreadPool");
                    DynamicThreadPool = new DynamicThreadPoolTimerOption(option, optionValue);
                    break;
                case "IGNOREIF":
                    AddToKnownOptionsCount("ignoreIf");
                    IgnoreIf = new IgnoreIfTimerOption(option, optionValue);
                    break;
                case "INSTANCE":
                    AddToKnownOptionsCount("instance");
                    Instance = new InstanceTimerOption(option, optionValue);
                    break;
                case "IP":
                    AddToKnownOptionsCount("ip");
                    IPAddress = new IpTimerOption(option, optionValue);
                    break;
                case "PING":
                    AddToKnownOptionsCount("ping");
                    Ping = new PingTimerOption(option, optionValue);
                    break;
                case "POLLINGRATE":
                    AddToKnownOptionsCount("pollingRate");
                    PollingRate = new PollingRateTimerOption(option, optionValue);
                    break;
                case "QACTION":
                    AddToKnownOptionsCount("qaction");
                    QAction = new QActionTimerOption(option, optionValue);
                    break;
                case "QACTIONAFTER":
                    AddToKnownOptionsCount("qactionAfter");
                    QActionAfter = new QActionTimerOption(option, optionValue);
                    break;
                case "QACTIONBEFORE":
                    AddToKnownOptionsCount("qactionBefore");
                    QActionBefore = new QActionTimerOption(option, optionValue);
                    break;
                case "THREADPOOL":
                    AddToKnownOptionsCount("threadPool");
                    ThreadPool = new ThreadPoolTimerOption(option, optionValue);
                    break;
                default:
                    AddToUnknownOptions(option);
                    break;
            }
        }

        public class EachTimerOption : OptionsBase
        {
            /// <summary>
            /// Gets the period (in ms) that each row should be executed in the table.
            /// </summary>
            public uint? Period { get; }

            public string OptionValue { get; }

            public EachTimerOption(string fullOption, string value) : base(fullOption)
            {
                OptionValue = value;

                if (UInt32.TryParse(value, out uint period))
                {
                    Period = period;
                }
            }
        }

        public class DynamicThreadPoolTimerOption : OptionsBase
        {
            /// <summary>
            /// Gets the ID of the parameter that will show the number of thread pool threads currently used .
            /// </summary>
            public uint? ParameterId { get; }

            public string OptionValue { get; }

            public DynamicThreadPoolTimerOption(string fullOption, string value) : base(fullOption)
            {
                OptionValue = value;

                if (UInt32.TryParse(value, out uint period))
                {
                    ParameterId = period;
                }
            }
        }

        public class IgnoreIfTimerOption : OptionsBase
        {
            /// <summary>
            /// Gets the 0-based column idx of the column that should have the value in order for the group to be ignored.
            /// </summary>
            public WrappedNullableUInt32 ColumnIdx { get; }

            /// <summary>
            /// The value the specified column should have in order for the group to be ignored.
            /// </summary>
            public string Value { get; }

            public string OptionValue { get; }

            public IgnoreIfTimerOption(string fullOption, string value) : base(fullOption)
            {
                OptionValue = value;

                string[] parts = value.Split(',');

                if (parts.Length > 0)
                {
                    ColumnIdx = new WrappedNullableUInt32(parts[0]);
                }

                if (parts.Length > 1)
                {
                    Value = parts[1];
                }
            }
        }

        public class InstanceTimerOption : OptionsBase
        {
            /// <summary>
            /// Gets the ID of the table parameter.
            /// </summary>
            public WrappedNullableUInt32 TableParameterId { get; }

            /// <summary>
            /// Gets the 0-based column idx of the column that holds the instance value.
            /// </summary>
            public WrappedNullableUInt32 ColumnIdx { get; }

            public string OptionValue { get; }

            public InstanceTimerOption(string fullOption, string value) : base(fullOption)
            {
                OptionValue = value;

                string[] parts = value.Split(',');

                if (parts.Length > 0)
                {
                    TableParameterId = new WrappedNullableUInt32(parts[0]);
                }

                if (parts.Length > 1)
                {
                    ColumnIdx = new WrappedNullableUInt32(parts[1]);
                }
            }
        }

        public class IpTimerOption : OptionsBase
        {
            /// <summary>
            /// Gets the ID of the table parameter.
            /// </summary>
            public WrappedNullableUInt32 TableParameterId { get; }

            /// <summary>
            /// Gets the 0-based column idx of the column that holds the IP address.
            /// </summary>
            public WrappedNullableUInt32 ColumnIdx { get; }

            public string OptionValue { get; }

            public IpTimerOption(string fullOption, string value) : base(fullOption)
            {
                OptionValue = value;

                string[] parts = value.Split(',');

                if (parts.Length > 0)
                {
                    TableParameterId = new WrappedNullableUInt32(parts[0]);
                }

                if (parts.Length > 1)
                {
                    ColumnIdx = new WrappedNullableUInt32(parts[1]);
                }
            }
        }

        public class PingTimerOption : TimerOptionsBase
        {
            /// <summary>
            /// Gets the 1-based column position where the result in ms of the RTT (round trip time) will be placed; if the ping fails, this value will be -1.
            /// </summary>
            public WrappedNullableUInt32 RttColumnPosition { get; }

            /// <summary>
            /// Gets the ID of the table parameter.
            /// </summary>
            public WrappedNullableUInt32 TimeoutParameterId { get; }

            /// <summary>
            /// Gets the time to live (TTL) of the packet (maximum number of hops) (default 10).
            /// </summary>
            public WrappedNullableUInt32 TimeToLive { get; }

            /// <summary>
            /// Gets the maximum time (in ms) before the ping is flagged as timeout when no response is returned (default 500 ms).
            /// </summary>
            public WrappedNullableUInt32 Timeout { get; }

            /// <summary>
            /// The 1-based column position where the time stamp should be placed when the ping has been executed.
            /// </summary>
            public WrappedNullableUInt32 TimeStampColumnPosition { get; }

            /// <summary>
            /// Gets the type of ping that is used: ICMP or Winsock (default ICMP).
            /// </summary>
            public string PingType { get; }

            /// <summary>
            /// Gets the payload size of the packet that is used to execute the ping (default 0).
            /// </summary>
            public WrappedNullableUInt32 PayloadSize { get; }

            /// <summary>
            /// Gets a value indicating whether the group should be executed when the ping is in timeout.
            /// </summary>
            public string ContinueSnmpOnTimeout { get; }

            /// <summary>
            /// Gets the 1-based column position of the column that will contain the jitter (ms).
            /// </summary>
            public WrappedNullableUInt32 JitterColumnPosition { get; }

            /// <summary>
            /// Gets the 1-based column position of the column that will contain the latency (ms).
            /// </summary>
            public WrappedNullableUInt32 LatencyColumnPosition { get; }

            /// <summary>
            /// Gets the 1-based column position of the column that will contain the packet loss rates (decimal value ranging from 0.01 to 1).
            /// </summary>
            public WrappedNullableUInt32 PacketLossRateColumnPosition { get; }

            /// <summary>
            /// Gets the number of packets to be sent to the device to calculate the jitter, latency and packet loss rate.
            /// </summary>
            public WrappedNullableUInt32 AmountPacketsMeasurements { get; }

            /// <summary>
            /// Gets the ID of the parameter that holds the number of packets to be sent to the device to calculate the jitter, latency and packet loss rate.
            /// </summary>
            public WrappedNullableUInt32 AmountPacketsMeasurementsPid { get; }

            /// <summary>
            /// Gets the number of packets to be sent to the device.
            /// </summary>
            public WrappedNullableUInt32 AmountPackets { get; }

            /// <summary>
            /// Gets the ID of the parameter that holds the number of packets to be sent to the device.
            /// </summary>
            public WrappedNullableUInt32 AmountPacketsPid { get; }

            /// <summary>
            /// Gets a value specifying the percentage of packets that will be fil­tered out is an integer number that is rounded down, with a minimum of 1.
            /// </summary>
            public WrappedNullableUInt32 ExcludeWorstResults { get; }

            /// <summary>
            /// Gets the ID of the parameter that holds a value specifying the percentage of packets that will be fil­tered out is an integer number that is rounded down, with a minimum of 1.
            /// </summary>
            public WrappedNullableUInt32 ExcludeWorstResultsParameterId { get; }

            public string OptionValue { get; }

            public PingTimerOption(string fullOption, string value) : base(fullOption)
            {
                OptionValue = value;

                string[] pingOptions = value.Split(',');

                foreach (var pingOption in pingOptions)
                {
                    string[] optionParts = pingOption.Split('=');

                    if (optionParts.Length > 1)
                    {
                        string optionName = optionParts[0].ToUpperInvariant();
                        string optionValue = optionParts[1];

                        switch (optionName)
                        {
                            case "RTTCOLUMN":
                                AddToKnownOptionsCount("rttColumn");
                                RttColumnPosition = new WrappedNullableUInt32(optionValue);
                                break;
                            case "TIMEOUTPID":
                                AddToKnownOptionsCount("timeoutPid");
                                TimeoutParameterId = new WrappedNullableUInt32(optionValue);
                                break;
                            case "TTL":
                                AddToKnownOptionsCount("ttl");
                                TimeToLive = new WrappedNullableUInt32(optionValue);
                                break;
                            case "TIMEOUT":
                                AddToKnownOptionsCount("timeout");
                                Timeout = new WrappedNullableUInt32(optionValue);
                                break;
                            case "TIMESTAMPCOLUMN":
                                AddToKnownOptionsCount("timestampColumn");
                                TimeStampColumnPosition = new WrappedNullableUInt32(optionValue);
                                break;
                            case "TYPE":
                                AddToKnownOptionsCount("type");
                                PingType = optionValue;
                                break;
                            case "SIZE":
                                AddToKnownOptionsCount("size");
                                PayloadSize = new WrappedNullableUInt32(optionValue);
                                break;
                            case "CONTINUESNMPONTIMEOUT":
                                AddToKnownOptionsCount("continueSnmpOnTimeout");
                                ContinueSnmpOnTimeout = optionValue;
                                break;
                            case "JITTERCOLUMN":
                                AddToKnownOptionsCount("jitterColumn");
                                JitterColumnPosition = new WrappedNullableUInt32(optionValue);
                                break;
                            case "LATENCYCOLUMN":
                                AddToKnownOptionsCount("latencyColumn");
                                LatencyColumnPosition = new WrappedNullableUInt32(optionValue);
                                break;
                            case "PACKETLOSSRATECOLUMN":
                                AddToKnownOptionsCount("packetLossRateColumn");
                                PacketLossRateColumnPosition = new WrappedNullableUInt32(optionValue);
                                break;
                            case "AMOUNTPACKETSMEASUREMENTS":
                                AddToKnownOptionsCount("amountPacketsMeasurements");
                                AmountPacketsMeasurements = new WrappedNullableUInt32(optionValue);
                                break;
                            case "AMOUNTPACKETSMEASUREMENTSPID":
                                AddToKnownOptionsCount("amountPacketsMeasurementsPid");
                                AmountPacketsMeasurementsPid = new WrappedNullableUInt32(optionValue);
                                break;
                            case "AMOUNTPACKETS":
                                AddToKnownOptionsCount("amountPackets");
                                AmountPackets = new WrappedNullableUInt32(optionValue);
                                break;
                            case "AMOUNTPACKETSPID":
                                AddToKnownOptionsCount("amountPacketsPid");
                                AmountPacketsPid = new WrappedNullableUInt32(optionValue);
                                break;
                            case "EXCLUDEWORSTRESULTS":
                                AddToKnownOptionsCount("excludeWorstResults");
                                ExcludeWorstResults = new WrappedNullableUInt32(optionValue);
                                break;
                            case "EXCLUDEWORSTRESULTSPID":
                                AddToKnownOptionsCount("excludeWorstResultsPid");
                                ExcludeWorstResultsParameterId = new WrappedNullableUInt32(optionValue);
                                break;
                            default:
                                AddToUnknownOptions(pingOption);
                                break;
                        }
                    }
                    else
                    {
                        AddToUnknownOptions(pingOption);
                    }
                }

                foreach (var option in KnownOptionCounts)
                {
                    if (option.Value > 1)
                    {
                        DuplicateOptions.Add(option.Key);
                    }
                }
            }
        }

        public class PollingRateTimerOption : OptionsBase
        {
            /// <summary>
            /// Gets the polling rate interval.
            /// </summary>
            public WrappedNullableUInt32 Interval { get; }

            /// <summary>
            /// Gets the max count.
            /// </summary>
            public WrappedNullableUInt32 MaxCount { get; }

            /// <summary>
            /// Gets the release count.
            /// </summary>
            public WrappedNullableUInt32 ReleaseCount { get; }

            public string OptionValue { get; }

            public PollingRateTimerOption(string fullOption, string value) : base(fullOption)
            {
                OptionValue = value;

                string[] parts = value.Split(',');

                if (parts.Length > 0)
                {
                    Interval = new WrappedNullableUInt32(parts[0]);
                }

                if (parts.Length > 1)
                {
                    MaxCount = new WrappedNullableUInt32(parts[1]);
                }

                if (parts.Length > 2)
                {
                    ReleaseCount = new WrappedNullableUInt32(parts[2]);
                }
            }
        }

        public class QActionTimerOption : OptionsBase
        {
            /// <summary>
            /// Gets the ID of the QAction.
            /// </summary>
            public WrappedNullableUInt32 Id { get; }

            public QActionTimerOption(string fullOption, string value) : base(fullOption)
            {
                Id = new WrappedNullableUInt32(value);
            }
        }

        public class ThreadPoolTimerOption : OptionsBase
        {
            /// <summary>
            /// Gets the maximum number of threads available in the thread pool.
            /// </summary>
            public WrappedNullableUInt32 Size { get; }

            /// <summary>
            /// Gets the number of seconds of the interval for refreshing the thread sta­tistics.
            /// </summary>
            public WrappedNullableUInt32 CalculationInteral { get; }

            /// <summary>
            /// Gets the parameter that will display the number of threads that are in use, refreshed at calculation interval.
            /// </summary>
            public WrappedNullableUInt32 UsageParameterId { get; }

            /// <summary>
            /// Gets the ID of the parameter that will display how many threads are waiting because all the threads in the thread pool are in use, refreshed at calculation interval.
            /// </summary>
            public WrappedNullableUInt32 WaitingParameterId { get; }

            /// <summary>
            /// Gets the ID of the parameter that will display how long it took to execute the slowest thread in ms during the last calculation interval.
            /// </summary>
            public WrappedNullableUInt32 MaxDurationParameterId { get; }

            /// <summary>
            /// Gets the ID of the parameter that will display how long it took by average to execute a thread in ms during the last calculation interval.
            /// </summary>
            public WrappedNullableUInt32 AverageDurationParameterId { get; }

            /// <summary>
            /// Gets the ID of the parameter that will display how many threads were finished executing during the last calculation interval.
            /// </summary>
            public WrappedNullableUInt32 CounterParameterId { get; }

            /// <summary>
            /// Gets the number of items that can be placed in waiting state. When the waiting thread pool has reached the stack size, a notice alarm is generated.
            /// </summary>
            public WrappedNullableUInt32 QueueSize { get; }

            public string OptionValue { get; }

            public ThreadPoolTimerOption(string fullOption, string value) : base(fullOption)
            {
                OptionValue = value;

                string[] parts = value.Split(',');

                if (parts.Length > 0)
                {
                    Size = new WrappedNullableUInt32(parts[0]);
                }

                if (parts.Length > 1)
                {
                    CalculationInteral = new WrappedNullableUInt32(parts[1]);
                }

                if (parts.Length > 2)
                {
                    UsageParameterId = new WrappedNullableUInt32(parts[2]);
                }

                if (parts.Length > 3)
                {
                    WaitingParameterId = new WrappedNullableUInt32(parts[3]);
                }

                if (parts.Length > 4)
                {
                    MaxDurationParameterId = new WrappedNullableUInt32(parts[4]);
                }

                if (parts.Length > 5)
                {
                    AverageDurationParameterId = new WrappedNullableUInt32(parts[5]);
                }

                if (parts.Length > 6)
                {
                    CounterParameterId = new WrappedNullableUInt32(parts[6]);
                }

                if (parts.Length > 7)
                {
                    QueueSize = new WrappedNullableUInt32(parts[7]);
                }
            }
        }

        /// <summary>
        /// Class for wrapping a nullable UInt32 with the provided value in the protocol.
        /// </summary>
        public class WrappedNullableUInt32
        {
            public uint? Value { get; }

            public string OriginalValue { get; }

            public WrappedNullableUInt32(string value)
            {
                OriginalValue = value;

                if (value != null && UInt32.TryParse(value, out uint numericValue))
                {
                    Value = numericValue;
                }
            }
        }

        /// <summary>
        /// Class for wrapping a nullable double with the provided value in the protocol.
        /// </summary>
        public class WrappedNullableDouble
        {
            public double? Value { get; }

            public string OriginalValue { get; }

            public WrappedNullableDouble(string value)
            {
                OriginalValue = value;

                if (value != null && Double.TryParse(value, out double numericValue))
                {
                    Value = numericValue;
                }
            }
        }

        /// <summary>
        /// Class for wrapping a nullable boolean.
        /// </summary>
        public class WrappedNullableBoolean
        {
            public bool? Value { get; }

            public string OriginalValue { get; }

            public WrappedNullableBoolean(string value)
            {
                OriginalValue = value;

                if (value != null && Boolean.TryParse(value, out bool booleanValue))
                {
                    Value = booleanValue;
                }
            }
        }
    }
}