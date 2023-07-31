namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;

    public class AdvancedConnection : OptionsBase
    {
        public uint ConnectionId { get; }

        public EnumProtocolType? Type { get; }

        public string TypeString { get; }

        public string Name { get; }

        public AdvancedConnection(uint id, string advancedProperty) : base(advancedProperty)
        {
            ConnectionId = id;
            string[] splitAdvancedProperty = advancedProperty.Split(':');
            TypeString = splitAdvancedProperty[0];
            Type = EnumProtocolTypeConverter.Convert(TypeString.Trim().ToLower());
            if (splitAdvancedProperty.Length > 1)
            {
                Name = splitAdvancedProperty[1];
            }
        }
    }
}

namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using System;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    public class AdvancedConnection : OptionsBase
    {
        public uint ConnectionId { get; }

        public EnumProtocolType? Type { get; set; }
        
        public string Name { get; set; }

        public AdvancedConnection(uint id, string advancedProperty) : base(advancedProperty)
        {
            ConnectionId = id;
            string[] splitAdvancedProperty = advancedProperty.Split(':');
            Type = EnumProtocolTypeConverter.Convert(splitAdvancedProperty[0].Trim().ToLower());
            if (splitAdvancedProperty.Length > 1)
            {
                Name = splitAdvancedProperty[1];
            }
        }

        public override string ToString()
        {
            if (Type.HasValue)
            {
                if (Name == null)
                {
                    return EnumProtocolTypeConverter.ConvertBack(Type.Value);
                }
                else
                {
                    return String.Format("{0}:{1}", EnumProtocolTypeConverter.ConvertBack(Type.Value), Name);
                }
            }

            return String.Empty;
        }
    }
}