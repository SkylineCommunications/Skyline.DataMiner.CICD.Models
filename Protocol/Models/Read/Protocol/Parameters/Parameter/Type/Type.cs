namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class ParamsParamType : IParamsParamType
    {
        public ParamTypeOptions GetOptions()
        {
            string paramTypeOptions = Options?.RawValue;
            if (paramTypeOptions == null)
            {
                return null;
            }

            return new ParamTypeOptions(paramTypeOptions);
        }
    }
}