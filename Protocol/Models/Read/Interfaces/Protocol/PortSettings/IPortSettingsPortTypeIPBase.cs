namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public interface IPortSettingsPortTypeIPBase : IReadable
    {
        ///<summary>
        /// Specifies whether the port type TCP/IP can be selected in the DataMiner user interface.
        ///</summary>
        IValueTag<bool?> Disabled { get; }
    }
}