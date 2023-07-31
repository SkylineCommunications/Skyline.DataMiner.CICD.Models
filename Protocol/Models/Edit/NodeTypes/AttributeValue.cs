namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public class AttributeValue<T> : ValueTag<T>
    {
        #region Constructors

        public AttributeValue() : base()
        {
        }
        public AttributeValue(T value) : base(value)
        {
        }
        public AttributeValue(string rawValue) : base(rawValue)
        {
        }
        internal AttributeValue(Read.IValueTag<T> readNode, IEditableNode parent) : base(readNode, parent)
        {
        }

        #endregion

        public static AttributeValue<T> FromRead(Read.IValueTag<T> value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return new AttributeValue<T>(value.Value);
            }
        }

        protected override void AssignRawValue()
        {
            if (Parent != null)
            {
                XmlAttribute attribute = Parent.EditNode.Attribute[TagName];
                attribute.Value = this.rawValue;
            }
        }

        public static implicit operator AttributeValue<T>(T value)
        {
            return new AttributeValue<T>(value);
        }

        public static explicit operator T(AttributeValue<T> value)
        {
            return value != null ? value.Value : default(T);
        }

    }
}
