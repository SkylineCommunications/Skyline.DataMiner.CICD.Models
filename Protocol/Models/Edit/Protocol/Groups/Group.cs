namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public partial class GroupsGroup
    {
        private static readonly string[] elementOrder = new[] { "Name", "Description", "Type", "Content" };

        public override string[] ElementOrder => elementOrder;
    }
}