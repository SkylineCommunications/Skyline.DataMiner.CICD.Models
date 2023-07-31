namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal partial class Protocol : IProtocol
    {
        internal Protocol(ProtocolModel model) : this(model, null)
        {
        }

        public bool IsSpectrum()
        {
            return Display?.Type?.Value == EnumDisplayType.SpectrumAnalyzer;
        }

        public bool IsMediation()
        {
            return !String.IsNullOrWhiteSpace(BaseFor?.Value);
        }

        public bool IsEnhancedService()
        {
            return Type?.Value == EnumProtocolType.Service;
        }

        public bool IsSLA()
        {
            return Type?.Value == EnumProtocolType.Sla;
        }

        public IReadOnlyList<Page> GetPages(RelationManager relationManager)
        {
            if (Params == null)
            {
                return new List<Page>(0);
            }

            Dictionary<string, Page> pagesPerName = new Dictionary<string, Page>();
            foreach (var param in Params)
            {
                var positions = param.Display?.Positions;

                // Ignore non displayed parameters
                if (param.Display?.RTDisplay?.Value != true || positions == null)
                {
                    continue;
                }

                // Exclude read columns
                if (param.TryGetTable(relationManager, out _))
                {
                    continue;
                }

                // Exclude write columns
                if (param.TryGetRead(relationManager, out var readParam) && readParam.TryGetTable(relationManager, out _))
                {
                    continue;
                }

                foreach (var position in positions)
                {
                    string pageName = position?.Page?.Value?.Trim();
                    if (String.IsNullOrWhiteSpace(pageName))
                    {
                        continue;
                    }

                    if (!pagesPerName.TryGetValue(pageName, out Page page))
                    {
                        page = new Page(pageName);
                        pagesPerName.Add(pageName, page);
                    }

                    page.Params.Add(param);
                }

                CheckPagebutton(param);
            }

            return pagesPerName.Values.ToList();

            void CheckPagebutton(IParamsParam paramsParam)
            {
                if (!paramsParam.IsPageButton())
                {
                    return;
                }

                var discreteEntries = paramsParam.Measurement?.Discreets;
                if (discreteEntries == null)
                {
                    return;
                }

                foreach (var discrete in discreteEntries)
                {
                    string pageName = discrete?.ValueElement?.Value?.Trim();
                    if (String.IsNullOrWhiteSpace(pageName))
                    {
                        continue;
                    }

                    if (!pagesPerName.TryGetValue(pageName, out Page page))
                    {
                        page = new Page(pageName);
                        pagesPerName.Add(pageName, page);
                    }

                    page.IsPopup = true;
                }
            }
        }

        public IList<Connection> GetConnections()
        {
            Dictionary<uint, Connection> connections = new Dictionary<uint, Connection>();

            if (Type != null)   // Syntax 1
            {
                // Main Connection
                var mainConnection = new Connection(Type, (IPortSettingsBase)PortSettings);
                connections.Add(mainConnection.Number, mainConnection);

                // Check Extra Connections (Ports)
                Dictionary<uint, TempConnection> ports = new Dictionary<uint, TempConnection>();

                if (Ports != null)
                {
                    for (uint i = 0; i < Ports.Count; i++)
                    {
                        ports.Add(i + 1, new TempConnection { PortSettings = (IPortSettingsBase)Ports[(int)i] });
                    }
                }

                var advancedConnections = Type.GetAdvanced()?.Connections?.ToList();
                if (advancedConnections != null)
                {
                    for (uint i = 0; i < advancedConnections.Count; i++)
                    {
                        if (ports.TryGetValue(i + 1, out var port))
                        {
                            port.Advanced = advancedConnections[(int)i];
                        }
                        else
                        {
                            ports.Add(i + 1, new TempConnection { Advanced = advancedConnections[(int)i] });
                        }
                    }
                }

                foreach (var conn in ports)
                {
                    connections.Add(conn.Key, new Connection(conn.Key, conn.Value.Advanced, conn.Value.PortSettings));
                }
            }
            else // Syntax 2 & 3
            {
                var connectionXmlElements = ReadNode.Element["Connections"]?.Elements["Connection"];
                if (connectionXmlElements == null)
                {
                    return new List<Connection>(0);
                }

                foreach (XmlElement connectionXmlElement in connectionXmlElements)
                {
                    if (!UInt32.TryParse(connectionXmlElement.Attribute["id"]?.Value, out uint connectionId))
                    {
                        continue;
                    }

                    connections.Add(connectionId, new Connection(connectionId, connectionXmlElement));
                }
            }

            return connections.Values.ToList();
        }

        public bool TryGetBasedOnVersion(out Version version)
        {
            string sCurrentVersion = Version?.Value;

            if (sCurrentVersion != null && System.Version.TryParse(sCurrentVersion, out Version currentVersion))
            {
                var branch = VersionHistory?.Branches?.FirstOrDefault(x => x.Id?.Value == currentVersion.Major);
                var systemVersion = branch?.SystemVersions?.FirstOrDefault(x => x.Id?.Value == currentVersion.Minor);
                var majorVersion = systemVersion?.MajorVersions?.FirstOrDefault(x => x.Id?.Value == currentVersion.Build);
                var revision = majorVersion?.MinorVersions?.FirstOrDefault(x => x.Id?.Value == currentVersion.Revision);

                var basedOn = revision?.BasedOn?.Value;

                if (basedOn != null && System.Version.TryParse(basedOn, out Version basedOnVersion))
                {
                    version = basedOnVersion;
                    return true;
                }
            }

            version = null;
            return false;
        }
    }

    internal class TempConnection
    {
        public IPortSettingsBase PortSettings { get; set; }

        public AdvancedConnection Advanced { get; set; }
    }
}