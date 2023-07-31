namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public interface IValueTag<T> : IReadable
    {
        T Value { get; }
        string RawValue { get; }

        T ConvertRawValue(string rawValue);


    }
}
