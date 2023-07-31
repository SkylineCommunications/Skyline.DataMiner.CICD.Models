namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Skyline.DataMiner.CICD.Common.Events;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Export;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    public class ProtocolModel : IProtocolModel
    {
        private Protocol protocol;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolModel"/> class.
        /// </summary>
        public ProtocolModel()
        {
            Mappings = CreateMappings();
            RelationManager = new RelationManager(Mappings);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolModel"/> class with the <see cref="XmlDocument"/>.
        /// </summary>
        public ProtocolModel(XmlDocument xmlDocument) : this()
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException(nameof(xmlDocument));
            }

            Initialize(xmlDocument);
        }

        // Used by DIS.
        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolModel"/> class with the protocol XML.
        /// </summary>
        public ProtocolModel(string protocolXml) : this()
        {
            if (protocolXml == null)
            {
                throw new ArgumentNullException(nameof(protocolXml));
            }

            Parser parser = new Parser(protocolXml);
            var xmlDocument = parser.Document;

            Initialize(xmlDocument);
        }

        #endregion

        #region Public Properties

        /// <inheritdoc />
        public IProtocol Protocol => protocol;

        /// <inheritdoc />
        public IDictionary<Mappings, Mapping> Mappings { get; }

        public RelationManager RelationManager { get; }

        public IProtocolModel MainProtocolModel { get; private set; }

        public bool IsExportedProtocolModel => MainProtocolModel != null;

        #endregion

        #region Public Methods

        public void Initialize(XmlDocument doc)
        {
            using (new MultipleDeferEvents(Mappings.Values))
            {
                using (RelationManager.DeferEvents())
                {
                    Update(doc);
                }
            }
        }

        public void Update(XmlDocument doc)
        {
            var protocolNode = doc.Element["protocol"];
            if (protocolNode != null)
            {
                if (Protocol == null)
                {
                    protocol = new Protocol(this);
                    protocol.Update(protocolNode, nameof(Protocol));
                    NotifyAdded(protocol);
                    NotifyPropertyChanged(nameof(Protocol));
                }
                else
                {
                    if (protocol.Update(protocolNode, nameof(Protocol)))
                    {
                        NotifyUpdated(protocol);
                    }
                }
            }
            else if (Protocol != null)
            {
                var temp = protocol;
                protocol = null;
                NotifyRemoved(temp);
                NotifyPropertyChanged(nameof(Protocol));
            }
        }

        /// <summary>
        /// Tries to get an object from the model, by its mapping and key.
        /// </summary>
        /// <exception cref="InvalidOperationException">When the object that is found, it not of the given type.</exception>
        public bool TryGetObjectByKey<T>(Mappings mapping, string key, out T result) where T : IReadable
        {
            if (Mappings[mapping].TryGetValue(key, out IReadable obj) && obj != null)
            {
                if (obj is T readable)
                {
                    result = readable;
                    return true;
                }
                else
                {
                    throw new InvalidOperationException($"Found object is not an instance of type '{typeof(T).Name}'.");
                }
            }

            result = default(T);
            return false;
        }

        public IEnumerable<ProtocolModelExport> GetAllExportedProtocols()
        {
            return GetAllExportedProtocolsFromTypeTag().Concat(GetAllExportedProtocolsFromDvesTag());
        }

        public IEnumerable<ProtocolModelExport> GetAllExportedProtocolsFromTypeTag()
        {
            var exportProtocols = Protocol?.Type?.GetOptions()?.ExportProtocols;

            if (exportProtocols == null)
            {
                yield break;
            }

            foreach (var item in exportProtocols)
            {
                if (item.TablePid == null || item.Name == null)
                {
                    continue;
                }

                var tablePid = Convert.ToInt32(item.TablePid);
                var dveName = item.Name;

                if (tablePid == 0 || String.IsNullOrWhiteSpace(dveName))
                {
                    continue;
                }

                yield return GetExportedProtocol(tablePid, dveName);
            }
        }

        public IEnumerable<ProtocolModelExport> GetAllExportedProtocolsFromDvesTag()
        {
            var dveProtocols = Protocol?.DVEs?.DVEProtocols;

            if (dveProtocols == null)
            {
                yield break;
            }

            foreach (var item in dveProtocols)
            {
                if (item.TablePID == null || item.Name == null)
                {
                    continue;
                }

                var tablePid = Convert.ToInt32(item.TablePID?.Value);
                var dveName = item.Name?.Value;

                if (tablePid == 0 || String.IsNullOrWhiteSpace(dveName))
                {
                    continue;
                }

                yield return GetExportedProtocol(tablePid, dveName);
            }
        }

        public ProtocolModelExport GetExportedProtocol(int tablePid, string name)
        {
            var handler = new ProtocolExportHandler(this, tablePid, name);
            return handler.CreateExportedProtocol();
        }

        #endregion

        #region Internal Methods

        internal void NotifyAdded(IReadable obj)
        {
            // update mappings
            var type = obj.GetType();

            foreach (var m in Mappings.Values)
            {
                if (m.Type.IsAssignableFrom(type))
                {
                    m.TryAddObject(obj);
                }
            }

            // update relations
            RelationManager.NotifyAdded(obj);
        }

        internal void NotifyUpdated(IReadable obj)
        {
            // update mappings
            var type = obj.GetType();

            foreach (var m in Mappings.Values)
            {
                if (m.Type.IsAssignableFrom(type))
                {
                    m.TryUpdateObject(obj);
                }
            }

            // update relations
            RelationManager.NotifyUpdated(obj);
        }

        internal void NotifyRemoved(IReadable obj)
        {
            var visitor = new GetDescendantProtocolObjectsVisitor();
            obj.Accept(visitor);

            ICollection<IReadable> objects = visitor.Objects;

            foreach (var o in objects)
            {
                // update mappings
                foreach (var m in Mappings.Values)
                {
                    m.TryRemoveObject(o);
                }

                // update relations
                RelationManager.NotifyRemoved(o);
            }
        }

        internal void SetMainProtocolModel(IProtocolModel mainModel)
        {
            MainProtocolModel = mainModel ?? throw new ArgumentNullException(nameof(mainModel));
        }

        #endregion

        #region Static

        internal static Dictionary<Mappings, Mapping> CreateMappings()
        {
            var mappings = new Dictionary<Mappings, Mapping>
            {
                { Linking.Mappings.ParamsById, Mapping.Create<IParamsParam>(Linking.Mappings.ParamsById, GetParamIds) },
                { Linking.Mappings.ParamsByName, Mapping.Create<IParamsParam>(Linking.Mappings.ParamsByName, param => param.Name?.Value) },
                { Linking.Mappings.TriggersById, Mapping.Create<ITriggersTrigger>(Linking.Mappings.TriggersById, trigger => Convert.ToString(trigger.Id?.Value)) },
                { Linking.Mappings.ActionsById, Mapping.Create<IActionsAction>(Linking.Mappings.ActionsById, action => Convert.ToString(action.Id?.Value)) },
                { Linking.Mappings.GroupsById, Mapping.Create<IGroupsGroup>(Linking.Mappings.GroupsById, group => Convert.ToString(group.Id?.Value)) },
                { Linking.Mappings.TimersById, Mapping.Create<ITimersTimer>(Linking.Mappings.TimersById, timer => Convert.ToString(timer.Id?.Value)) },
                { Linking.Mappings.CommandsById, Mapping.Create<ICommandsCommand>(Linking.Mappings.CommandsById, command => Convert.ToString(command.Id?.Value)) },
                { Linking.Mappings.ResponsesById, Mapping.Create<IResponsesResponse>(Linking.Mappings.ResponsesById, response => Convert.ToString(response.Id?.Value)) },
                { Linking.Mappings.PairsById, Mapping.Create<IPairsPair>(Linking.Mappings.PairsById, pair => Convert.ToString(pair.Id?.Value)) },
                { Linking.Mappings.SessionsById, Mapping.Create<IHTTPSession>(Linking.Mappings.SessionsById, session => Convert.ToString(session.Id?.Value)) },
                { Linking.Mappings.QActionsById, Mapping.Create<IQActionsQAction>(Linking.Mappings.QActionsById, qAction => Convert.ToString(qAction.Id?.Value)) },
            };

            return mappings;

            IEnumerable<string> GetParamIds(IParamsParam param)
            {
                yield return Convert.ToString(param.Id?.Value);

                foreach (var id in param.GetDuplicateAsIds())
                {
                    yield return id;
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    /// <summary>
    /// Retrieve all descendant objects of the given <see cref="IReadable"/>.
    /// </summary>
    public class GetDescendantProtocolObjectsVisitor : ProtocolVisitor
    {
        public List<IReadable> Objects { get; } = new List<IReadable>();

        public override void DefaultVisit(IReadable obj)
        {
            Objects.Add(obj);
        }
    }
}
