namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public partial class VersionHistoryBranchesBranch
    {
        public static readonly string[] attributesOrder = new[] { "id" };
        public static readonly string[] elementsOrder = new[] { "Comment", "Features", "SystemVersions" };

        public override string[] AttributesOrder => attributesOrder;
        public override string[] ElementOrder => elementsOrder;
    }

}
