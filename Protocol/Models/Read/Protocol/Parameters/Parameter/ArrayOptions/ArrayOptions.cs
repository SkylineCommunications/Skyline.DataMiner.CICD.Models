namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;

    internal partial class ParamsParamArrayOptions : IParamsParamArrayOptions
    {
        public ArrayOptionsOptions GetOptions()
        {
            string options = Options?.Value;
            if (options == null)
            {
                return null;
            }

            return new ArrayOptionsOptions(options);
        }
        
        public bool TryGetColumnOption(int index, out ITypeColumnOption columnOption)
        {
            columnOption = null;

            if (index >= Count)
            {
                return false;
            }

            columnOption = this[index];
            return true;
        }
    }
}