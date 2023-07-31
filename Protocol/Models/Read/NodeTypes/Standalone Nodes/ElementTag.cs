namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal abstract class ElementTag : ProtocolTag
    {

        internal ElementTag(ProtocolModel model, ProtocolTag parent, string tagName)
            : base(model, parent, tagName)
        {
        }

        protected override void Parse(string notifyPropertyName)
        {

        }

    }
}
