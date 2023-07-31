namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using System;
    using System.Linq;

    using ReadXml = Skyline.DataMiner.CICD.Parsers.Common.Xml;
    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    public abstract class EditableElementNode<T> : IEditableNode
        where T : IReadable
    {
        protected EditableElementNode(T read, IEditableNode parent, XmlElement editNode)
        {
            EditNode = editNode ?? throw new ArgumentNullException(nameof(editNode));
            TagName = read.TagName;
            Parent = parent;

            Read = read;
            ReadNode = read.ReadNode;

            Initialize(read, editNode);
        }

        protected EditableElementNode(string name)
        {
            EditNode = new XmlElement(name);
            TagName = name;
        }

        #region Properties

        public ReadXml.XmlElement ReadNode
        {
            get; private set;
        }

        public T Read
        {
            get; private set;
        }

        public XmlElement EditNode { get; protected set; }

        public string TagName { get; internal set; }

        public IEditableNode Parent { get; internal set; }

        // will be overridden by derived classes
        public virtual string[] ElementOrder => Array.Empty<string>();
        public virtual string[] AttributesOrder => Array.Empty<string>();

        #endregion

        #region Public methods

        public void Cleanup(bool cleanupSelf = true)
        {
            if (cleanupSelf)
            {
                RecursiveCleanup(EditNode);
            }
            else
            {
                foreach (XmlElement e in EditNode.Children.OfType<XmlElement>().ToList())
                {
                    RecursiveCleanup(e);
                }
            }
        }

        #endregion

        #region Internal Methods

        internal XmlElement GetExistingEdit(ReadXml.XmlElement read)
        {
            return EditNode.TryFindNode(read);
        }

        #endregion

        #region Protected Methods

        protected virtual void OnCreated()
        {

        }

        #endregion

        #region Private Methods

        private void RecursiveCleanup(XmlElement node)
        {
            foreach (XmlElement e in node.Children.OfType<XmlElement>().ToList())
            {
                RecursiveCleanup(e);
            }

            if (IsCleanable(node) && node.ParentNode is IXmlContainer parentContainer)
            {
                parentContainer.Children.Remove(node, removeEmptyLineBefore: true);
            }
        }

        private bool IsCleanable(XmlElement element)
        {
            if (element.Attributes.Any(a => !String.IsNullOrWhiteSpace(a.Value)))
            {
                return false;
            }

            // If there is any element remaining at this point, don't clear.
            foreach (var child in element.Children)
            {
                switch (child)
                {
                    case XmlText t:
                        if (!String.IsNullOrWhiteSpace(t.Text))
                        {
                            return false;
                        }

                        break;
                    case XmlElement _:
                    case XmlCDATA _:
                    case XmlComment _:
                    case XmlSpecial _:
                        return false;
                }
            }

            return true;
        }

        #endregion

        #region Abstract Methods

        protected abstract void Initialize(T read, XmlElement editNode);

        public abstract void Accept(ProtocolVisitor visitor);

        #endregion

        public override string ToString()
        {
            if (ReadNode != null && ReadNode.TryGetAttribute("id", out var idAttr))
            {
                return TagName + " [" + idAttr.Value + "]";
            }
            else
            {
                return TagName;
            }
        }
    }
}
