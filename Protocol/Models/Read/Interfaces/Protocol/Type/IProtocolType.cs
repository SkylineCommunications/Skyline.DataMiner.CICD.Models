namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public partial interface IProtocolType
    {
        /// <summary>
        /// Extracts the Options from the protocol.Type@Options.
        /// </summary>
        /// <returns>A <see cref="ProtocolTypeOptions"/> instance that will contain the parsed options.</returns>
        ProtocolTypeOptions GetOptions();

        /// <summary>
        /// Extracts the connections from the protocol.Type@advanced.
        /// </summary>
        /// <returns>A <see cref="ProtocolTypeAdvanced"/> instance that will contain the parsed connections.</returns>
        ProtocolTypeAdvanced GetAdvanced();
    }
}