namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public partial interface IParamsParamType
    {
        /// <summary>
        /// Extracts the options.
        /// </summary>
        /// <returns>Options parsed into a class.</returns>
        ParamTypeOptions GetOptions();
    }
}