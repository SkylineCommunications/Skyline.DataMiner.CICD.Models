using System;

namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal abstract class ValueTag<T> : ProtocolTag, IValueTag<T>
    {
        protected ValueTag(ProtocolModel model, ProtocolTag parent, string tagName)
            : base(model, parent, tagName)
        {

        }

        public T Value { get; private set; }
        public string RawValue { get; private set; }

        public virtual T ConvertRawValue(string rawValue)
        {
            if (rawValue != null)
            {
                rawValue = rawValue.Trim();
            }

            return ConvertRawValue<T>(rawValue);
        }

        internal void SetValue(string newValue, string notifyPropertyName)
        {
            if (!String.Equals(newValue, RawValue))
            {
                RawValue = newValue;

                var newValueConverted = ConvertRawValue(newValue);
                if (!Object.Equals(Value, newValueConverted))
                {
                    Value = newValueConverted;
                    NotifyPropertyChanged(notifyPropertyName);
                } 
            }
        }

        public static explicit operator T(ValueTag<T> value)
        {
            return value != null ? value.Value : default(T);
        }

        public override string ToString()
        {
            return TagName + ": " + Value;
        }
    }
}