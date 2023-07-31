namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public interface IPortSettingsPortTypeSerialBase : IReadable
    {
        ///<summary>
        /// Specifies whether the port type serial can be selected in the DataMiner user interface.
        ///</summary>
        IValueTag<bool?> Disabled { get; }
    }
}