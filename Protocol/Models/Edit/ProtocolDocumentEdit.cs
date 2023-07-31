namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using ReadXml = Skyline.DataMiner.CICD.Parsers.Common.Xml;
    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    using Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces;

    public class ProtocolDocumentEdit
    {

        #region Private fields

        private readonly IProtocolModel protocolModel;
        private readonly XmlDocument document;

        private Protocol protocol;

        #endregion

        #region Constructors

        public ProtocolDocumentEdit(IProtocolModel protocolModel, XmlDocument document)
        {
            this.protocolModel = protocolModel;
            this.document = document;

            Initialize();
        }

        public ProtocolDocumentEdit(ReadXml.XmlDocument document, IProtocolModel model) : this(model, new XmlDocument(document)) { }

        #endregion

        #region Properties

        public XmlDocument Document => document;

        public Protocol Protocol
        {
            get
            {
                return protocol;
            }

            set
            {
                AssignProtocol(value);
            }
        }

        #endregion

        private void Initialize()
        {
            if (protocolModel.Protocol != null)
            {
                XmlElement editNode = document.TryFindNode(protocolModel.Protocol.ReadNode);
                if (editNode != null)
                {
                    protocol = new Protocol(protocolModel.Protocol, editNode);
                }
            }
        }

        private void AssignProtocol(Protocol protocol)
        {
            if (protocol == null)
            {
                if (Protocol != null)
                {
                    document.Children.Remove(Protocol.EditNode);
                }
            }
            else
            {
                // Override link
                if (Protocol?.EditNode != null)
                {
                    int index = document.Children.IndexOf(Protocol.EditNode);
                    document.Children[index] = protocol.EditNode;
                }
                else
                {
                    document.Children.Add(protocol.EditNode);
                }
            }

            this.protocol = protocol;
        }
    }
}
