namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class TypeColumnOption : ITypeColumnOption
    {
        internal TypeColumnOption(ProtocolModel model, ProtocolTag parent, string tagName) : base(model, parent, tagName)
        {
        }

        public ColumnOptionOptions GetOptions()
        {
            string columnOptionOptions = Options?.RawValue;
            if (columnOptionOptions == null)
            {
                return null;
            }

            return new ColumnOptionOptions(columnOptionOptions);
        }
    }
}