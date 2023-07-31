namespace Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    public interface IProtocolModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Protocol object.
        /// </summary>
        IProtocol Protocol { get; }

        /// <summary>
        /// Mapping between the different components of the protocol.
        /// </summary>
        IDictionary<Mappings, Mapping> Mappings { get; }

        bool TryGetObjectByKey<T>(Mappings mapping, string key, out T result) where T : IReadable;

        RelationManager RelationManager { get; }

        IEnumerable<ProtocolModelExport> GetAllExportedProtocols();

        ProtocolModelExport GetExportedProtocol(int tablePid, string name);

        /// <summary>
        /// Gets the model of an exported protocol, this property contains the model of the main protocol that was used to create the export.
        /// </summary>
        IProtocolModel MainProtocolModel { get; }

        /// <summary>
        /// Gets a value indicating whether this is the model of an exported protocol.
        /// </summary>
       /// <value><c>true</c> if this is the model of an exported protocol; otherwise, <c>false</c>.</value>
        bool IsExportedProtocolModel { get; }
    }
}