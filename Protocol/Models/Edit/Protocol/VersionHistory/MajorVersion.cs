namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public partial class VersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersion
    {
        public static readonly string[] attributesOrder = new[] { "id" };
        public static readonly string[] elementsOrder = new[] { "Changes", "MinorVersions" };

        public override string[] AttributesOrder => attributesOrder;
        public override string[] ElementOrder => elementsOrder;
    }
}
