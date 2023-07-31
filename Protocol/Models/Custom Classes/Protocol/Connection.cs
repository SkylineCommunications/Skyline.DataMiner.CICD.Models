namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.ComponentModel;
    using System.Linq;

    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    public class Connection
    {
        private Connection(IPortSettingsBase portSettings)
        {
            PortSettings = portSettings;
            PortSettingsName = portSettings?.Name?.RawValue;
        }

        public Connection(uint connectionId, XmlElement connectionXmlElement)
        {
            ConnectionXmlElement = connectionXmlElement;
            Number = connectionId;

            if (connectionXmlElement.Element["Type"] != null)
            {
                // Syntax 2
                TypeRaw = connectionXmlElement.Element["Type"]?.InnerText;
                Type = EnumProtocolTypeConverter.Convert(TypeRaw);
            }
            else
            {
                // Syntax 3
                var typeTag = connectionXmlElement.GetElements().FirstOrDefault();
                bool isSingle = typeTag.Attribute["single"]?.Value == "true";

                TypeRaw = typeTag.Name;
                Type = EnumProtocolTypeConverter.ConvertFromTagName(TypeRaw, isSingle);
            }
        }

        public Connection(IProtocolType type, IPortSettingsBase portSettings) : this(portSettings)
        {
            Number = 0;
            Type = type?.Value;
            TypeRaw = type?.ReadNode?.InnerText;
        }

        public Connection(uint number, AdvancedConnection advanced, IPortSettingsBase portSettings) : this(portSettings)
        {
            Number = number;
            Type = advanced?.Type;
            TypeRaw = advanced?.TypeString;
            AdvancedName = advanced?.Name;
        }

        public EnumProtocolType? Type { get; }

        public string TypeRaw { get;}

        public uint Number { get; }

        public string AdvancedName { get; }

        public string PortSettingsName { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPortSettingsBase PortSettings { get; }

        public XmlElement ConnectionXmlElement { get; }
    }
}