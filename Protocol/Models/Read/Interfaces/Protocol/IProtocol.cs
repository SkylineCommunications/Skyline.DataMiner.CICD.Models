namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;

    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    public partial interface IProtocol
    {
        /// <summary>
        /// Determines whether this protocol is spectrum.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified protocol is spectrum; otherwise, <c>false</c>.
        /// </returns>
        bool IsSpectrum();

        /// <summary>
        /// Determines whether this protocol is mediation.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified protocol is mediation; otherwise, <c>false</c>.
        /// </returns>
        bool IsMediation();

        /// <summary>
        /// Determines whether this protocol is an enhanced service.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified protocol is an enhanced service ;otherwise, <c>false</c>.
        /// </returns>
        bool IsEnhancedService();

        /// <summary>
        /// Determines whether this protocol is SLA.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified protocol is SLA; otherwise, <c>false</c>.
        /// </returns>
        bool IsSLA();

        /// <summary>
        /// Retrieves the pages defined in this protocol.
        /// </summary>
        /// <returns>The pages defined in this protocol.</returns>
        /// <remarks>The method iterates over all parameters and detects all page names specified on parameter positions or page buttons. The page names will be uppercased.</remarks>
        IReadOnlyList<Page> GetPages(RelationManager relationManager);

        /// <summary>
        /// Gets the connections defined in this protocol.
        /// </summary>
        /// <returns>All the connections based on PortSettings and protocol/Type.</returns>
        IList<Connection> GetConnections();

        /// <summary>
        /// Tries to get the based-on version from the current version of the protocol.
        /// </summary>
        /// <param name="version">The based-on version.</param>
        /// <returns>True if the based on version was explicitly found, otherwise false.</returns>
        bool TryGetBasedOnVersion(out System.Version version);
    }
}