namespace Models.ProtocolTests.Read.Protocol
{
    using System.Text;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    public abstract class ProtocolTestBase
    {
        protected ProtocolModel CreateModelFromXML(string xml)
        {
            Parser parser = new Parser(new StringBuilder(xml));
            var model = new ProtocolModel(parser.Document);

            return model;
        }
    }
}