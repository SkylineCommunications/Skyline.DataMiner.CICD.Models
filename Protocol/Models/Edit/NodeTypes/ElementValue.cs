namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public class ElementValue<T> : ValueTag<T>
    {
        #region Constructors

        public ElementValue(bool useCDATA = false) : base()
        {
            UseCDATA = useCDATA;
        }
        public ElementValue(T value, bool useCDATA = false) : base(value)
        {
            UseCDATA = useCDATA;
        }
        public ElementValue(string rawValue, bool useCDATA = false) : base(rawValue)
        {
            UseCDATA = useCDATA;
        }

        internal ElementValue(Read.IValueTag<T> readNode, IEditableNode parent, bool useCDATA = false) : base(readNode, parent)
        {
            UseCDATA = useCDATA;
        }

        #endregion

        #region Properties

        internal bool UseCDATA { get; set; }

        public XmlElement EditNode => Parent?.EditNode?.Element[TagName];

        #endregion


        public static ElementValue<T> FromRead(Read.IValueTag<T> value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return new ElementValue<T>(value.Value);
            }
        }

        protected override void AssignRawValue()
        {
            XmlElement element = Parent?.EditNode.Element[TagName];
            if (element != null)
            {
                if (UseCDATA)
                {
                    element.Children.Clear();
                    element.Children.Add(new XmlCDATA(this.rawValue));
                }
                else
                {
                    element.InnerText = this.rawValue;
                }
            }
        }

        public static implicit operator ElementValue<T>(T value)
        {
            return new ElementValue<T>(value);
        }

        public static explicit operator T(ElementValue<T> value)
        {
            return value != null ? value.Value : default(T);
        }

    }
}
