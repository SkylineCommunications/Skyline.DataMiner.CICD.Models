namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using ReadXml = Skyline.DataMiner.CICD.Parsers.Common.Xml;
    using EditXml = Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public partial class Protocol
    {
        static readonly string[] elementOrder = new string[] {
            "Name", "Description", "Version","Provider", "Vendor", "VendorOID", "DeviceOID", "ElementType", "Type", "Display", "SNMP",
            "DVEs", "ExportRules", "Params", "QActions", "Groups", "Triggers", "Actions", "Timers", "PortSettings"
        };
        
        internal Protocol(Read.IProtocol read, EditXml.XmlElement editNode) : base(read, null, editNode)
        {
        }
        
        public override string[] ElementOrder => elementOrder;

        protected override void OnCreated()
        {
            EditNode.Attributes.Add("xmlns", "http://www.skyline.be/protocol");
        }

        private static EditXml.XmlElement CreateEditNode(Read.IProtocol read)
        {
            var doc = read.ReadNode.ParentNode as ReadXml.XmlDocument;
            var editDocument = new EditXml.XmlDocument(doc);
            return editDocument.Element["protocol"];
        }
    }
}
