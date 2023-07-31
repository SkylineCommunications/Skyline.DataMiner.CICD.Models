namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal class ElementValueTag<T> : ValueTag<T>
    {

        protected ElementValueTag(ProtocolModel model, ProtocolTag parent, string tagName)
            : base(model, parent, tagName)
        {
        }

        protected override void Parse(string notifyPropertyName)
        {
            string value = ReadNode?.InnerText;
            SetValue(value, notifyPropertyName);
        }

        public override void Accept(ProtocolVisitor visitor)
        {
            visitor.VisitValueTag<T>(this);
        }
    }
}
