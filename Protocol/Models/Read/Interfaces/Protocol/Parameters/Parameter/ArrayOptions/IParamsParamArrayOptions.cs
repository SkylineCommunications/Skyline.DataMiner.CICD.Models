namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;

    public partial interface IParamsParamArrayOptions
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        ArrayOptionsOptions GetOptions();
        
        /// <summary>
        /// Try to get the columnOption at the specified index.
        /// </summary>
        bool TryGetColumnOption(int index, out ITypeColumnOption columnOption);
    }
}