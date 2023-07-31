namespace Skyline.DataMiner.CICD.Models.Protocol.Read.Export
{
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal class XmlDocumentExportOverride : XmlDocument
    {
        public XmlDocumentExportOverride(XmlNode root)
        {
            _children.Add(root);
        }
    }
}