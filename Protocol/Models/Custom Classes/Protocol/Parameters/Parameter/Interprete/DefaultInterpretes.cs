namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;

    public class StringInterprete : ParamsParamInterprete
    {
        public StringInterprete()
        {
            Type = new ParamsParamInterpreteType(EnumParamInterpretType.String);
            RawType = new ParamsParamInterpreteRawType(EnumParamInterpretRawType.Other);
            LengthType = new ParamsParamInterpreteLengthType(EnumParamInterpretLengthType.NextParam);
        }
    }

    public class DoubleInterprete : ParamsParamInterprete
    {
        public DoubleInterprete()
        {
            Type = new ParamsParamInterpreteType(EnumParamInterpretType.Double);
            RawType = new ParamsParamInterpreteRawType(EnumParamInterpretRawType.NumericText);
            LengthType = new ParamsParamInterpreteLengthType(EnumParamInterpretLengthType.NextParam);
        }
    }
}