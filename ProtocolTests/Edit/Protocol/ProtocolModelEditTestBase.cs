namespace Models.ProtocolTests.Edit.Protocol
{
    using System;
    using Skyline.DataMiner.CICD.Models.Protocol.Edit;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;
    using EditXml = Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public abstract class ProtocolModelEditTestBase
    {
        protected static void DoTest(string input, Action<ProtocolDocumentEdit> action, Action<ProtocolDocumentEdit, EditXml.XmlDocument, string> checks)
        {
            CreateEditModel(input,
                out EditXml.XmlDocument xmlEdit,
                out ProtocolDocumentEdit protocolEdit);

            action(protocolEdit);

            var output = xmlEdit.GetXml();

            checks(protocolEdit, xmlEdit, output);
        }

        private static void CreateEditModel(string xml, out EditXml.XmlDocument xmlEdit, out ProtocolDocumentEdit protocolEdit)
        {
            Parser parser = new Parser(xml);

            var model = new ProtocolModel(parser.Document);

            xmlEdit = new EditXml.XmlDocument(parser.Document);
            protocolEdit = new ProtocolDocumentEdit(model, xmlEdit);
        }

    }
}
