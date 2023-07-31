namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public partial class VersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersionMinorVersionsMinorVersion
    {
        public static readonly string[] attributesOrder = new[] { "id", "basedOn" };
        public static readonly string[] elementsOrder = new[] { "Date", "Provider", "Changes" };

        public override string[] AttributesOrder => attributesOrder;
        public override string[] ElementOrder => elementsOrder;
    }
}
