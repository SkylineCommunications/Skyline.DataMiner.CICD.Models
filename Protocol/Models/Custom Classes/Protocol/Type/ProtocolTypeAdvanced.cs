namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;

    public class ProtocolTypeAdvanced : OptionsBase
    {
        public IReadOnlyList<AdvancedConnection> Connections { get; }

        public ProtocolTypeAdvanced(string protocolTypeAdvanced) : base(protocolTypeAdvanced)
        {
            if (String.IsNullOrWhiteSpace(protocolTypeAdvanced))
            {
                Connections = new List<AdvancedConnection>(0);
                return;
            }

            string[] connections = protocolTypeAdvanced.Split(';');
            List<AdvancedConnection> tempConnections = new List<AdvancedConnection>();
            for (uint i = 0; i < connections.Length; i++)
            {
                tempConnections.Add(new AdvancedConnection(i + 1, connections[i]));
            }

            Connections = tempConnections;
        }
    }
}