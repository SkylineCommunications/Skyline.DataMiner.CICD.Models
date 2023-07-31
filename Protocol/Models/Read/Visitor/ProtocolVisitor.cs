namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public abstract partial class ProtocolVisitor
    {
        public virtual void DefaultVisit(IReadable obj)
        {

        }

        public virtual void VisitValueTag<T>(IValueTag<T> obj)
        {
            this.DefaultVisit(obj);
        }
    }
}
