namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public partial class VersionHistoryBranchesBranchSystemVersionsSystemVersion
    {
        public static readonly string[] attributesOrder = new[] { "id" };
        public static readonly string[] elementsOrder = new[] { "Comment", "SupportedVersions", "MajorVersions" };

        public override string[] AttributesOrder => attributesOrder;
        public override string[] ElementOrder => elementsOrder;
    }
}
