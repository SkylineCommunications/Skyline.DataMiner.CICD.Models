namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public abstract partial class ProtocolVisitor
    {
        public virtual void DefaultVisit(IEditable obj)
        {

        }

        public virtual void VisitValueTag<T>(ValueTag<T> obj)
        {
            this.DefaultVisit(obj);
        }
    }
}
