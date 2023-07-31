namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class TriggersTriggerOn : ITriggersTriggerOn
    {
        public TriggerOnId GetId()
        {
            if (Id?.Value == null)
            {
                return null;
            }

            return new TriggerOnId(Id.Value);
        }
    }
}