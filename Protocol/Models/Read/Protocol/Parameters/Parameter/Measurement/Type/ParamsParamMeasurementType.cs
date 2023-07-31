namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class ParamsParamMeasurementType : IParamsParamMeasurementType
    {
        public MeasurementTypeOptions GetOptions()
        {
            string optionValue = Options?.RawValue;
            if (optionValue == null)
            {
                return null;
            }

            return new MeasurementTypeOptions(optionValue);
        }
    }
}