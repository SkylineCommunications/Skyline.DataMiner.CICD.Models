namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public interface IPortSettingsTypeBase : IReadable
    {
        ///<summary>
        /// Specifies the default port type.
        ///</summary>
        IValueTag<Enums.EnumPortTypes?> DefaultValue { get; }
    }
}
