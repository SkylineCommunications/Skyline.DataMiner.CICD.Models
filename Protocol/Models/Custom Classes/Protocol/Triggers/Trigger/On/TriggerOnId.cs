namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;

    public class TriggerOnId : OptionsBase
    {
        public TriggerOnId(string value) : base(value)
        {
            Each = String.Equals("each", value, StringComparison.OrdinalIgnoreCase);

            if (UInt32.TryParse(value, out uint id))
            {
                Id = id;
            }
        }

        public bool Each { get; }

        public uint? Id { get; }
    }
}