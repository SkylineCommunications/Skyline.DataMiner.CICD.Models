namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public class EnabledDisabledDiscreets : ParamsParamMeasurementDiscreets
    {
        public EnabledDisabledDiscreets()
        {
            Add(new ParamsParamMeasurementDiscreetsDiscreet
            {
                Display = new ParamsParamMeasurementDiscreetsDiscreetDisplay("Disabled"),
                ValueElement = new ParamsParamMeasurementDiscreetsDiscreetValue("0")
            });
            Add(new ParamsParamMeasurementDiscreetsDiscreet
            {
                Display = new ParamsParamMeasurementDiscreetsDiscreetDisplay("Enabled"),
                ValueElement = new ParamsParamMeasurementDiscreetsDiscreetValue("1")
            });
        }
    }
}