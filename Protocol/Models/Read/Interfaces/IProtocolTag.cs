namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal interface IProtocolTag : IReadable
    {
        bool Update(XmlElement readNode, string notifyPropertyName);
    }
}
