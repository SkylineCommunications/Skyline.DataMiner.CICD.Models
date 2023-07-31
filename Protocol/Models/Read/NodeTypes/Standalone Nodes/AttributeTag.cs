namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal class AttributeTag<T> : ValueTag<T>
    {
        internal AttributeTag(ProtocolModel model, ProtocolTag parent, string tagName)
            : base(model, parent, tagName)
        {
        }

        private XmlAttribute _readAttribute;
        public override XmlAttribute ReadAttribute => _readAttribute;

        protected override void Parse(string notifyPropertyName)
        {
            _readAttribute = ReadNode.Attribute[TagName];

            string value = _readAttribute?.Value;
            SetValue(value, notifyPropertyName);
        }

        public override void Accept(ProtocolVisitor visitor)
        {
            visitor.VisitValueTag(this);
        }
    }
}
