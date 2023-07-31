namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public interface IPortSettingsBase : IReadable
    {
        ///<summary>
        /// Specifies the name of the additional protocol type as specified in the advanced attribute of the /Protocol/Type element.
        ///</summary>
        IValueTag<string> Name
        {
            get;
        }

        ///<summary>
        /// Specifies the port type settings.
        ///</summary>
        IPortSettingsTypeBase Type
        {
            get;
        }

        ///<summary>
        /// Specifies settings related to the TCP/IP port type.
        ///</summary>
        IPortSettingsPortTypeIPBase PortTypeIP
        {
            get;
        }

        ///<summary>
        /// Specifies settings related to the serial port type.
        ///</summary>
        IPortSettingsPortTypeSerialBase PortTypeSerial
        {
            get;
        }

        ///<summary>
        /// Specifies settings related to the UDP/IP port type.
        ///</summary>
        IPortSettingsPortTypeUDPBase PortTypeUDP
        {
            get;
        }
    }
}