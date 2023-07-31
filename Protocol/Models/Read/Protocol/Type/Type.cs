namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class ProtocolType : IProtocolType
    {
        public ProtocolTypeOptions GetOptions()
        {
            if (Options?.Value == null)
            {
                return null;
            }
            else
            {
                return new ProtocolTypeOptions(Options.RawValue);
            }
        }

        public ProtocolTypeAdvanced GetAdvanced()
        {
            if (Advanced?.Value == null)
            {
                return null;
            }
            else
            {
                return new ProtocolTypeAdvanced(Advanced.RawValue);
            }
        }
    }
}