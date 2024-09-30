namespace Models.ProtocolTests.Read.Linking
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    public abstract class DummyIReadable : IReadable, IRelationEvaluator
    {
        public string TagName => null;

        public XmlElement ReadNode => null;

        public XmlAttribute ReadAttribute => null;

        public IProtocolModel Model => null;

        public event PropertyChangedEventHandler PropertyChanged;

        private ICollection<Reference> References { get; set; }

        public IReadable Parent => null;

        public T TryFindParent<T>() where T : IReadable
        {
            throw new NotImplementedException();
        }

        protected DummyIReadable()
        {
            References = new List<Reference>();
        }

        public Reference AddReference(Mappings targetMapping, string targetId)
        {
            var r = new Reference(this, targetMapping, targetId, this);
            References.Add(r);
            return r;
        }

        public void ClearReferences()
        {
            References.Clear();
        }

        public abstract void Accept(ProtocolVisitor visitor);

        #region IRelationEvaluator

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            return References;
        }

        #endregion

    }

    public class DummyParameter : DummyIReadable, IParamsParam
    {
        public IValueTag<uint?> Id { get; set; }

        public IParamsParamAlarm Alarm => null;

        public IParamsParamArrayOptions ArrayOptions => null;

        public IParamsParamCRC CRC => null;

        public IParamsParamCrossDriverOptions CrossDriverOptions => null;

        public IParamsParamDashboard Dashboard => null;

        public IParamsParamDatabase Database => null;

        public IParamsParamDependencies Dependencies => null;

        public IValueTag<string> Description => null;

        public IParamsParamDisplay Display => null;

        public IParamsParamHyperLinks HyperLinks => null;

        public IIcon Icon => null;

        public IParamsParamInformation Information => null;

        public IParamsParamInterprete Interprete => null;

        public IParamsParamLength Length => null;

        public IParamsParamMatrix Matrix => null;

        public IParamsParamMeasurement Measurement => null;

        public IParamsParamMediation Mediation => null;

        public IValueTag<string> Message => null;

        public IValueTag<string> Name => null;

        public IParamsParamReplication Replication => null;

        public IParamsParamSNMP SNMP => null;

        public IParamsParamType Type => null;

        public IValueTag<bool?> Backup => null;

        public IValueTag<EnumParamConfirmPopup?> ConfirmPopup => null;

        public IValueTag<string> DuplicateAs { get; set; }

        public IValueTag<string> Export => null;

        public IValueTag<bool?> HistorySet => null;

        public IValueTag<uint?> Level => null;

        public IValueTag<string> Options => null;

        public IValueTag<uint?> PollingInterval => null;

        public IValueTag<bool?> Save => null;

        public IValueTag<TimeSpan?> SaveInterval => null;

        public IValueTag<bool?> Setter => null;

        public IValueTag<bool?> Snapshot => null;

        public IValueTag<string> SnmpSetAndGet => null;

        public IValueTag<bool?> Trending => null;

        public IValueTag<uint?> VerificationTimeout => null;

        public DummyParameter(string id)
        {
            var attrId = new AttributeTag<uint?>(null, null, "id");
            attrId.SetValue(id, nameof(Id));
            Id = attrId;
        }

        public DummyParameter(string id, string duplicateAs)
        {
            var attrId = new AttributeTag<uint?>(null, null, "id");
            attrId.SetValue(id, nameof(Id));
            Id = attrId;

            var attrDuplicateAs = new AttributeTag<string>(null, null, "duplicateAs");
            attrDuplicateAs.SetValue(duplicateAs, nameof(DuplicateAs));
            DuplicateAs = attrDuplicateAs;
        }

        public override void Accept(ProtocolVisitor visitor)
        {
            visitor.VisitParamsParam(this);
        }

        public bool IsRead()
        {
            throw new NotImplementedException();
        }

        public bool IsWrite()
        {
            throw new NotImplementedException();
        }

        public bool IsButton()
        {
            throw new NotImplementedException();
        }

        public bool IsContextMenu()
        {
            throw new NotImplementedException();
        }

        public bool IsQActionFeedback()
        {
            throw new NotImplementedException();
        }

        public bool IsPageButton()
        {
            throw new NotImplementedException();
        }

        public bool IsTreeControl(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public bool IsTitle()
        {
            throw new NotImplementedException();
        }

        public bool IsTitleBegin()
        {
            throw new NotImplementedException();
        }

        public bool IsTitleEnd()
        {
            throw new NotImplementedException();
        }

        public bool GetRTDisplay()
        {
            throw new NotImplementedException();
        }

        public bool IsInSLElement(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public bool TryGetTableFromReadAndWrite(RelationManager relationManager, out IParamsParam table)
        {
            throw new NotImplementedException();
        }

        public bool TryGetTable(RelationManager relationManager, out IParamsParam table)
        {
            throw new NotImplementedException();
        }

        public bool TryGetTable(RelationManager relationManager, uint viewColumnPid, out IParamsParam table)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IParamsParam> GetTables(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IParamsParam> GetTables(RelationManager relationManager, uint viewColumnPid)
        {
            throw new NotImplementedException();
        }

        public bool TryGetColumn(IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> columns, uint idx, out IParamsParam columnParam)
        {
            throw new NotImplementedException();
        }

        public bool TryGetColumn(IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> columns, string pid, out IParamsParam columnParam)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> GetColumns(RelationManager relationManager, bool returnBaseColumnsIfDuplicateAs)
        {
            throw new NotImplementedException();
        }

        public bool IsDisplayed(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetDuplicateAsIds()
        {
            string[] parts = DuplicateAs?.Value?.Split(',');
            if (parts != null)
            {
                foreach (var part in parts)
                {
                    string trimmed = part.Trim();
                    if (trimmed != "")
                    {
                        yield return trimmed;
                    }
                }
            }
        }

        public bool WillBeExported()
        {
            throw new NotImplementedException();
        }

        public bool HasPosition()
        {
            throw new NotImplementedException();
        }

        public bool IsTable()
        {
            throw new NotImplementedException();
        }

        public bool IsSubtable()
        {
            throw new NotImplementedException();
        }

        public bool IsLoggerTable()
        {
            throw new NotImplementedException();
        }

        public bool IsMatrix()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IParamsParam> GetDependencyIdParams(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public bool IsDisplayedWhenExported(IProtocol protocol, RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public bool TryGetWrite(RelationManager relationManager, out IParamsParam writeParameter)
        {
            throw new NotImplementedException();
        }

        public bool TryGetRead(RelationManager relationManager, out IParamsParam readParameter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> GetIndexColumns(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public bool TryGetPrimaryKeyColumn(RelationManager relationManager, out IParamsParam indexColumn)
        {
            throw new NotImplementedException();
        }

        public bool IsInSLElementWhenExported(IProtocol protocol)
        {
            throw new NotImplementedException();
        }

        public bool IsNumber()
        {
            throw new NotImplementedException();
        }

        public bool IsDateTime()
        {
            throw new NotImplementedException();
        }

        public bool IsTime()
        {
            throw new NotImplementedException();
        }

        public bool IsProgress()
        {
            throw new NotImplementedException();
        }

        public bool IsAnalog()
        {
            throw new NotImplementedException();
        }

        public bool IsString()
        {
            throw new NotImplementedException();
        }

        public ICollection<IParamsParam> GetDependencyReferenceParameters(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public ICollection<IParamsParam> GetDependencyParameters(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public bool IsPositioned(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        ICollection<IParamsParam> IParamsParam.GetDependencyIdParams(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }
    }

    public class DummyGroup : DummyIReadable, IGroupsGroup
    {
        public IValueTag<uint?> Id { get; set; }

        public IValueTag<string> Condition => null;

        public IGroupsGroupContent Content => null;

        public IValueTag<string> Description => null;

        public IValueTag<string> Name => null;

        public IValueTag<EnumGroupType?> Type => null;

        public IValueTag<uint?> Connection => null;

        public IValueTag<uint?> ConnectionPID => null;

        public IValueTag<bool?> Ping => null;

        public IValueTag<int?> ThreadId => null;

        public DummyGroup(string id)
        {
            var attrId = new AttributeTag<uint?>(null, null, "id");
            attrId.SetValue(id, nameof(Id));
            Id = attrId;
        }

        public override void Accept(ProtocolVisitor visitor)
        {
            visitor.VisitGroupsGroup(this);
        }

        public IEnumerable<IParamsParam> GetContentParameters(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IActionsAction> GetContentActions(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPairsPair> GetContentPairs(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHTTPSession> GetContentSessions(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITriggersTrigger> GetContentTriggers(RelationManager relationManager)
        {
            throw new NotImplementedException();
        }
    }
}
