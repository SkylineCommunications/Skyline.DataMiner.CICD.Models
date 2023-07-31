namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public partial class TypeColumnOption
    {
        static readonly string[] attributesOrder = new[] { "idx", "pid", "type", "options" };

        public override string[] AttributesOrder => attributesOrder;
    }
}
