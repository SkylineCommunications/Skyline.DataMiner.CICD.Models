namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    public abstract class ValueTag<T> : IEditable
    {
        protected T value;
        protected string rawValue;

        #region Constructors

        protected ValueTag(Read.IValueTag<T> readNode, IEditableNode parent)
        {
            if (readNode != null)
            {
                TagName = readNode.TagName;
                Parent = parent;
                value = readNode.Value;
                rawValue = readNode.RawValue;
            }
        }

        protected ValueTag() { }

        protected ValueTag(T value)
        {
            this.value = value;
            UpdateRawValue();
            AssignRawValue();
        }

        protected ValueTag(string rawValue)
        {
            this.rawValue = rawValue;
            AssignRawValue();
            UpdateConvertedValue();
        }

        #endregion

        #region Properties

        public string TagName { get; set; }

        internal IEditableNode Parent { get; set; }

        public T Value
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

        #endregion

        protected virtual void OnCreated()
        {

        }

        protected virtual string GetValueToWrite()
        {
            return Tools.GetValueToWrite(value);
        }

        protected abstract void AssignRawValue();

        public virtual T ConvertRawValue(string rawValue)
        {
            return ProtocolTag.ConvertRawValue<T>(rawValue);
        }

        private void UpdateConvertedValue()
        {
            this.value = ConvertRawValue(rawValue);
        }

        private void UpdateRawValue()
        {
            this.rawValue = GetValueToWrite();
        }

        public virtual void Accept(ProtocolVisitor visitor)
        {
            visitor.VisitValueTag(this);
        }

        public override string ToString()
        {
            return TagName + ": " + Value;
        }

    }
}
