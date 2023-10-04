namespace ProtocolTests.Roslyn
{
    using System.Text;

    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal static class Generic
    {
        public static (Skyline.DataMiner.CICD.Models.Protocol.Read.ProtocolModel, XmlDocument) ParseProtocol(string protocolCode)
        {
            Parser parser = new Parser(new StringBuilder(protocolCode));

            return (new Skyline.DataMiner.CICD.Models.Protocol.Read.ProtocolModel(parser.Document), parser.Document);
        }
    }
}
