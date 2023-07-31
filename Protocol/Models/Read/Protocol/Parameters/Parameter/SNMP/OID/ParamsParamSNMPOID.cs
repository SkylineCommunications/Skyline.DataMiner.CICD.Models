namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class ParamsParamSNMPOID : IParamsParamSNMPOID
    {
        public SnmpOidOptions GetOptions()
        {
            if (Options == null)
            {
                return null;
            }

            return new SnmpOidOptions(Options.Value);
        }
    }
}