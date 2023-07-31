namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public interface IEditable
    {
        void Accept(ProtocolVisitor visitor);
    }
}
