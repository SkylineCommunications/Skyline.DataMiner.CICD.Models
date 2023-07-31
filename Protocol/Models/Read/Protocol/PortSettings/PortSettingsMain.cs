namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class PortSettingsMain : IPortSettingsBase
    {
        IPortSettingsTypeBase IPortSettingsBase.Type => (IPortSettingsTypeBase)Type;

        IPortSettingsPortTypeIPBase IPortSettingsBase.PortTypeIP => (IPortSettingsPortTypeIPBase)PortTypeIP;

        IPortSettingsPortTypeSerialBase IPortSettingsBase.PortTypeSerial => (IPortSettingsPortTypeSerialBase)PortTypeSerial;

        IPortSettingsPortTypeUDPBase IPortSettingsBase.PortTypeUDP => (IPortSettingsPortTypeUDPBase)PortTypeUDP;
    }
}
