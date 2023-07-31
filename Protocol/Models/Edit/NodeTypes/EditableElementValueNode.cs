namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    public abstract class EditableElementValueNode<T, TValue> : EditableElementNode<T>
    where T : IReadable, Read.IValueTag<TValue>
    {
        private TValue value;
        private string rawValue;

        #region Constructors

        protected EditableElementValueNode(T read, IEditableNode parent, XmlElement editNode, bool useCDATA = false)
            : base(read, parent, editNode)
        {
            UseCDATA = useCDATA;

            if (read != null)
            {
                value = read.Value;
                rawValue = read.RawValue;
            }
        }

        protected EditableElementValueNode(string name, TValue value, bool useCDATA = false)
            : base(name)
        {
            UseCDATA = useCDATA;

            this.value = value;
            UpdateRawValue();
            AssignRawValue();
        }

        protected EditableElementValueNode(string name, string rawValue, bool useCDATA = false)
            : base(name)
        {
            UseCDATA = useCDATA;

            this.rawValue = rawValue;
            AssignRawValue();
            UpdateConvertedValue();
        }

        protected EditableElementValueNode(string name, bool useCDATA = false)
            : base(name)
        {
            UseCDATA = useCDATA;
        }

        #endregion

        #region Properties

        public TValue Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
                UpdateRawValue();
                AssignRawValue();
            }
        }

        public string RawValue
        {
            get
            {
                return rawValue;
            }

            set
            {
                rawValue = value;
                AssignRawValue();
                UpdateConvertedValue();
            }
        }

        internal bool UseCDATA { get; set; }

        #endregion

        protected virtual string GetValueToWrite()
        {
            return Tools.GetValueToWrite(value);
        }

        public virtual TValue ConvertRawValue(string rawValue)
        {
            return ProtocolTag.ConvertRawValue<TValue>(rawValue);
        }

        private void AssignRawValue()
        {
            XmlElement element = this.EditNode;
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

        private void UpdateConvertedValue()
        {
            this.value = ConvertRawValue(rawValue);
        }

        private void UpdateRawValue()
        {
            this.rawValue = GetValueToWrite();
        }
    }
}
