namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class ParamsParamMeasurementDiscreetsDiscreet : IParamsParamMeasurementDiscreetsDiscreet
    {
        public DiscreetsDiscreetOptions GetOptions()
        {
            string optionValue = Options?.RawValue;
            if (optionValue == null)
            {
                return null;
            }

            return new DiscreetsDiscreetOptions(optionValue);
        }
    }
}