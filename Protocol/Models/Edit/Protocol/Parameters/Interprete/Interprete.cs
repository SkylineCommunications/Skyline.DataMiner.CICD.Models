namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public partial class ParamsParamInterprete
    {
        static readonly string[] elementOrder = new string[] { "RawType", "Type", "LengthType", "Length", "Value", "DefaultValue", "Decimals", "Endian", "Base",
            "Sequence", "Factor", "OffSet", "Rounding", "Scale", "StartPosition", "NbrOfBits", "Alignment", "Bits", "ByteOffset",
            "Range", "Exceptions", "Others" };

        public override string[] ElementOrder => elementOrder;
    }
}
