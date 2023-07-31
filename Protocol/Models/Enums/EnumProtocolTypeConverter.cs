namespace Skyline.DataMiner.CICD.Models.Protocol.Enums
{
    public static partial class EnumProtocolTypeConverter
    {
        public static EnumProtocolType? ConvertFromTagName(string input, bool isSingle)
        {
            switch (input)
            {
                case "Gpib":
                    return EnumProtocolType.Gpib;
                case "Http":
                    return EnumProtocolType.Http;
                case "Opc":
                    return EnumProtocolType.Opc;
                case "Serial":
                    return isSingle ? EnumProtocolType.SerialSingle : EnumProtocolType.Serial;
                case "Service":
                    return EnumProtocolType.Service;
                case "Sla":
                    return EnumProtocolType.Sla;
                case "SmartSerial":
                    return isSingle ? EnumProtocolType.SmartSerialSingle : EnumProtocolType.SmartSerial;
                case "Snmp":
                    return EnumProtocolType.Snmp;
                case "SnmpV2":
                    return EnumProtocolType.Snmpv2;
                case "SnmpV3":
                    return EnumProtocolType.Snmpv3;
                case "Virtual":
                    return EnumProtocolType.Virtual;
                default:
                    return null;
            }
        }
    }
}
