namespace Skyline.DataMiner.CICD.Models.Protocol.Read.Linking
{
    public class Reference
    {
        public IReadable Source { get; private set; }
        public Mappings TargetMapping { get; private set; }
        public string TargetId { get; private set; }
        public IReadable ReferencingObject { get; private set; }

        public string GroupForward { get; private set; }
        public string GroupReverse { get; private set; }

        public bool AllowLinkToSelf { get; private set; }
        public bool IsLogic { get; private set; }
        public bool IsReverse { get; private set; }

        public Reference(IReadable source, Mappings targetMapping, string targetId, IReadable reference, string groupForward = "Outgoing", string groupReverse = "Incoming", bool allowLinkToSelf = true, bool isLogic = true, bool reverse = false)
        {
            Source = source;
            TargetMapping = targetMapping;
            TargetId = targetId;
            ReferencingObject = reference;
            GroupForward = groupForward;
            GroupReverse = groupReverse;
            AllowLinkToSelf = allowLinkToSelf;
            IsLogic = isLogic;
            IsReverse = reverse;
        }

        public override bool Equals(object obj)
        {
            var r = obj as Reference;

            if (r == null) return false;

            if (Source != r.Source) return false;
            if (TargetMapping != r.TargetMapping) return false;
            if (TargetId != r.TargetId) return false;
            if (ReferencingObject != r.ReferencingObject) return false;
            if (GroupForward != r.GroupForward) return false;
            if (GroupReverse != r.GroupReverse) return false;

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 31;

                hash = hash * 41 + (Source != null ? Source.GetHashCode() : 0);
                hash = hash * 41 + TargetMapping.GetHashCode();
                hash = hash * 41 + (TargetId != null ? TargetId.GetHashCode() : 0);
                hash = hash * 41 + (ReferencingObject != null ? ReferencingObject.GetHashCode() : 0);
                hash = hash * 41 + (GroupForward != null ? GroupForward.GetHashCode() : 0);
                hash = hash * 41 + (GroupReverse != null ? GroupReverse.GetHashCode() : 0);

                return hash;
            }
        }
    }
}
