namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public interface IPortSettingsPortTypeUDPBase : IReadable
    {
        ///<summary>
        /// Specifies whether the port type UDP/IP can be selected in the DataMiner user interface.
        ///</summary>
        IValueTag<bool?> Disabled { get; }
    }
}