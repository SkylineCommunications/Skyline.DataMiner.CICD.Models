namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Skyline.DataMiner.CICD.Common.Extensions;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    internal partial class ParamsParam : IRelationEvaluator, IParamsParam
    {
        #region Is[Type]

        public bool IsRead()
        {
            return Type?.Value == EnumParamType.Read || Type?.Value == EnumParamType.ReadBit;
        }

        public bool IsWrite()
        {
            return Type?.Value == EnumParamType.Write || Type?.Value == EnumParamType.WriteBit;
        }

        #endregion

        #region Is[MeasurementType]

        public bool IsButton()
        {
            return Measurement?.Type?.Value == EnumParamMeasurementType.Button;
        }

        public bool IsContextMenu()
        {
            return Name?.Value?.EndsWith("_ContextMenu", StringComparison.OrdinalIgnoreCase) == true;
        }

        public bool IsQActionFeedback()
        {
            return Name?.Value?.EndsWith("_QActionFeedback", StringComparison.OrdinalIgnoreCase) == true;
        }

        public bool IsPageButton()
        {
            return Measurement?.Type?.Value == EnumParamMeasurementType.Pagebutton;
        }

        public bool IsTitle()
        {
            return Measurement?.Type?.Value == EnumParamMeasurementType.Title;
        }

        public bool IsTitleBegin()
        {
            if (!this.IsTitle())
            {
                return false;
            }

            var options = Measurement?.Type?.GetOptions();
            return options?.HasBegin == true;
        }

        public bool IsTitleEnd()
        {
            if (!this.IsTitle())
            {
                return false;
            }

            var options = Measurement?.Type?.GetOptions();
            return options?.HasEnd == true;
        }

        public bool IsNumber()
        {
            return Measurement?.Type?.Value == EnumParamMeasurementType.Number;
        }

        public bool IsDateTime()
        {
            //return Measurement?.Type?.Options?.Value?.Contains("date", StringComparer.OrdinalIgnoreCase) ?? false;
            //return Measurement?.Type?.Options?.Value?.IndexOf("date", StringComparison.InvariantCultureIgnoreCase) >= 0;
            return Measurement?.Type?.GetOptions()?.HasDate == true || Measurement?.Type?.GetOptions()?.DateTime?.IsValid == true;
        }

        public bool IsTime()
        {
            return Measurement?.Type?.Options?.Value?.Contains("time") ?? false;
        }

        public bool IsProgress()
        {
            return Measurement?.Type?.Value == EnumParamMeasurementType.Progress;
        }

        public bool IsAnalog()
        {
            return Measurement?.Type?.Value == EnumParamMeasurementType.Analog;
        }

        public bool IsString()
        {
            return Measurement?.Type?.Value == EnumParamMeasurementType.String;
        }

        #endregion

        #region TryGet

        public bool TryGetTableFromReadAndWrite(RelationManager relationManager, out IParamsParam table)
        {
            if (this.Id?.Value == null || !this.Id.Value.HasValue)
            {
                table = null;
                return false;
            }

            // Directly linked (read column + button column)
            if (TryGetTable(relationManager, out table))
            {
                return true;
            }

            // Indirectly linked (write column linked to read column)
            if (this.IsWrite() &&
                this.TryGetRead(relationManager, out var readColumn) &&
                readColumn.TryGetTable(relationManager, out table))
            {
                return true;
            }

            return false;
        }

        public bool TryGetTable(RelationManager relationManager, out IParamsParam table)
        {
            if (this.Id?.Value == null || !this.Id.Value.HasValue)
            {
                table = null;
                return false;
            }

            return TryGetTable(relationManager, this.Id.Value.Value, out table);
        }

        public bool TryGetTable(RelationManager relationManager, uint viewColumnPid, out IParamsParam table)
        {
            // Table <- Column
            IEnumerable<Link> links = relationManager.GetReverseLinks(this);

            foreach (Link link in links)
            {
                if (!(link.Source is IParamsParam tableParam) || link.Target != this || !(link.Target is IParamsParam))
                {
                    continue;
                }

                // Common table (ArrayOptions with ColumnOption tags)
                if (link.Reference.ReferencingObject is ITypeColumnOption columnOptionReference &&
                    columnOptionReference.Pid?.Value == viewColumnPid)
                {
                    table = tableParam;
                    return true;
                }

                // Old style table (id attribute on Param/Type tag)
                if (link.Reference.ReferencingObject is IParamsParamType paramTypeReference &&
                    paramTypeReference.Value == EnumParamType.Array &&
                    paramTypeReference.Id?.Value?.Split(';').Contains(viewColumnPid.ToString()) == true)
                {
                    table = tableParam;
                    return true;
                }
            }

            table = null;
            return false;
        }

        public IEnumerable<IParamsParam> GetTables(RelationManager relationManager)
        {
            if (this.Id?.Value == null || !this.Id.Value.HasValue)
            {
                yield break;
            }

            foreach (var table in GetTables(relationManager, this.Id.Value.Value))
            {
                yield return table;
            }
        }

        public IEnumerable<IParamsParam> GetTables(RelationManager relationManager, uint viewColumnPid)
        {
            // Table <- Column
            IEnumerable<Link> links = relationManager.GetReverseLinks(this);

            foreach (Link link in links)
            {
                if (!(link.Source is IParamsParam tableParam) || link.Target != this || !(link.Target is IParamsParam))
                {
                    continue;
                }

                // Common table (ArrayOptions with ColumnOption tags)
                if (link.Reference.ReferencingObject is ITypeColumnOption columnOptionReference &&
                    columnOptionReference.Pid?.Value == viewColumnPid)
                {
                    yield return tableParam;
                }

                // Old style table (id attribute on Param/Type tag)
                if (link.Reference.ReferencingObject is IParamsParamType paramTypeReference &&
                    paramTypeReference.Value == EnumParamType.Array &&
                    paramTypeReference.Id?.Value?.Split(';').Contains(viewColumnPid.ToString()) == true)
                {
                    yield return tableParam;
                }
            }
        }

        public bool TryGetColumn(IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> columns, uint idx, out IParamsParam columnParam)
        {
            columnParam = columns.FirstOrDefault(c => c.idx == idx).columnParam;
            return columnParam != null;
        }

        public bool TryGetColumn(IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> columns, string pid, out IParamsParam columnParam)
        {
            columnParam = columns.FirstOrDefault(c => c.pid == pid).columnParam;
            return columnParam != null;
        }

        public IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> GetColumns(RelationManager relationManager, bool returnBaseColumnsIfDuplicateAs)
        {
            // Get all linked columns
            Dictionary<string, IParamsParam> linkedColumnsByPid = new Dictionary<string, IParamsParam>();
            foreach (var link in relationManager.GetForwardLinks(this))
            {
                bool isLinkedViaColumnOption = link.Reference.ReferencingObject is ITypeColumnOption;
                bool isLinkedViaParamTypeId = link.Reference.ReferencingObject is IParamsParamType type
                    && type.Value == EnumParamType.Array;

                if ((isLinkedViaColumnOption || isLinkedViaParamTypeId) &&
                    link.Source == this &&
                    link.Target is IParamsParam columnParam &&
                    columnParam.Id.Value.HasValue)
                {
                    linkedColumnsByPid[Convert.ToString(columnParam.Id.Value.Value)] = columnParam;
                }
            }

            // Get columns included via Param.Type@id
            if (Type?.Id?.Value != null)
            {
                string[] columnPids = Type.Id.Value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (uint i = 0; i < columnPids.Length; i++)
                {
                    var column = GetColumn(linkedColumnsByPid, columnPids[i], returnBaseColumnsIfDuplicateAs);

                    yield return (i, columnPids[i], column);
                }
            }

            // Get columns included via ColumnOption tags
            foreach (var columnOption in ArrayOptions)
            {
                if (columnOption?.Pid?.Value == null)
                {
                    continue;
                }

                string columnPid = Convert.ToString(columnOption.Pid.Value.Value);
                var column = GetColumn(linkedColumnsByPid, columnPid, returnBaseColumnsIfDuplicateAs);

                yield return (columnOption?.Idx?.Value, columnPid, column);
            }
        }

        private static IParamsParam GetColumn(Dictionary<string, IParamsParam> columnsByPid, string columnPid, bool returnBaseColumnsIfDuplicateAs)
        {
            foreach (var kvp in columnsByPid)
            {
                string columnToCheckPid = kvp.Key;
                var columnToCheckParam = kvp.Value;

                if (columnToCheckPid == columnPid
                    || (returnBaseColumnsIfDuplicateAs && columnToCheckParam.GetDuplicateAsIds().Contains(columnPid, StringComparison.OrdinalIgnoreCase)))
                {
                    return columnToCheckParam;
                }
            }

            return null;
        }

        public bool TryGetWrite(RelationManager relationManager, out IParamsParam writeParameter)
        {
            IEnumerable<Link> links = relationManager.GetForwardLinks(this);

            foreach (Link link in links)
            {
                if (link.Source is IParamsParam readParam && readParam == this &&
                    link.Target is IParamsParam writeParam && writeParam.IsWrite() &&
                    String.Equals(writeParam?.Description?.Value, Description?.Value))
                {
                    writeParameter = writeParam;
                    return true;
                }
            }

            writeParameter = null;
            return false;
        }

        public bool TryGetRead(RelationManager relationManager, out IParamsParam readParameter)
        {
            IEnumerable<Link> links = relationManager.GetForwardLinks(this);

            foreach (Link link in links)
            {
                if (link.Source is IParamsParam writeParam && writeParam == this &&
                    link.Target is IParamsParam readParam && readParam.IsRead() &&
                    String.Equals(readParam?.Description?.Value, Description?.Value))
                {
                    readParameter = readParam;
                    return true;
                }
            }

            readParameter = null;
            return false;
        }

        public bool TryGetPrimaryKeyColumn(RelationManager relationManager, out IParamsParam primaryKeyColumn)
        {
            // Table -> Column
            IEnumerable<Link> links = relationManager.GetForwardLinks(this);

            uint? indexColumnIdx = ArrayOptions?.Index?.Value;

            foreach (Link link in links)
            {
                // Check if link source is this table param
                if (!(link.Source is IParamsParam source) || source != this)
                {
                    continue;
                }

                // Check if target is a param
                if (!(link.Target is IParamsParam target))
                {
                    continue;
                }

                // Look for column via ColumnOptions
                if (link.Reference.ReferencingObject is ITypeColumnOption columnOption
                    && columnOption.Idx?.Value == indexColumnIdx)
                {
                    primaryKeyColumn = target;
                    return true;
                }

                // Look for column via Param/Type@id
                string targetPid = Convert.ToString(target.Id?.Value);
                if (link.Reference.ReferencingObject is IParamsParamType paramType
                    && !String.IsNullOrEmpty(paramType.Id?.Value)
                    && !String.IsNullOrEmpty(targetPid)
                    && (paramType.Id.Value == targetPid || paramType.Id.Value.StartsWith(targetPid + ";")))
                {
                    primaryKeyColumn = target;
                    return true;
                }
            }

            primaryKeyColumn = null;
            return false;
        }

        public IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> GetIndexColumns(RelationManager relationManager)
        {
            // Table -> Column
            IEnumerable<Link> links = relationManager.GetForwardLinks(this);

            foreach (Link link in links)
            {
                if (link.Source is IParamsParam source && source == this &&
                    link.Reference.ReferencingObject is ITypeColumnOption columnOption &&
                    columnOption.Options?.Value?.Contains("indexColumn") == true && link.Target is IParamsParam target)
                {
                    yield return (columnOption.Idx.Value, columnOption.Pid.RawValue, target);
                }
            }
        }

        #endregion

        public bool IsTreeControl(RelationManager relationManager)
        {
            // TreeControl <- Table
            var reverseLinks = relationManager.GetReverseLinks(this);

            foreach (Link link in reverseLinks)
            {
                if (link.Reference.ReferencingObject is ITreeControlsTreeControl &&
                    link.Source is ITreeControlsTreeControl treeControl &&
                    link.Target == this)
                {
                    return true;
                }
            }

            return false;
        }

        public bool GetRTDisplay()
        {
            return Display?.RTDisplay?.Value ?? false;
        }

        public bool IsInSLElement(RelationManager relationManager)
        {
            // TODO: Check with viewTables
            if (WillBeExported())
            {
                return true;
            }

            if (TryGetTable(relationManager, out IParamsParam tableParam))
            {
                return tableParam.GetRTDisplay();
            }
            else
            {
                return GetRTDisplay();
            }
        }

        public bool IsInSLElementWhenExported(IProtocol protocol)
        {
            if (WillBeExported() && protocol.ExportRules != null)
            {
                foreach (var exportRule in protocol.ExportRules)
                {
                    if (String.Equals(exportRule.Tag?.Value, "Protocol/Params/Param/Display/RTDisplay", StringComparison.OrdinalIgnoreCase) &&
                        String.Equals(exportRule.ValueAttribute?.Value, "true", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] paramExports = Export.Value.Split(';');
                        if (paramExports.Contains("true", StringComparer.OrdinalIgnoreCase) ||
                            String.Equals(exportRule.Table?.Value, "*") ||
                            paramExports.Contains(exportRule.Table?.Value, StringComparer.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public ICollection<IParamsParam> GetDependencyIdParams(RelationManager relationManager)
        {
            // DependencyId Param <- DropDown
            IEnumerable<Link> links = relationManager.GetReverseLinks(this);

            List<IParamsParam> parameters = new List<IParamsParam>();

            foreach (Link link in links)
            {
                if (link.Reference.ReferencingObject is IParamsParamMeasurementDiscreets &&
                    link.Source is IParamsParam param &&
                    link.Target == this)
                {
                    parameters.Add(param);
                }
            }

            return parameters;
        }

        public bool IsDisplayed(RelationManager relationManager)
        {
            // TODO: Check with viewTables
            if (WillBeExported())
            {
                return true;
            }

            if (!IsInSLElement(relationManager))
            {
                return false;
            }

            if (TryGetTable(relationManager, out IParamsParam tableParam))
            {
                return tableParam.HasPosition();
            }
            else
            {
                ICollection<IParamsParam> referenceParams = GetDependencyReferenceParameters(relationManager);
                if (referenceParams.Count > 0)
                {
                    return referenceParams.Any(x => x.IsDisplayed(relationManager));
                }
                else
                {
                    return HasPosition();
                }
            }
        }

        public bool IsPositioned(RelationManager relationManager)
        {
            if (TryGetTable(relationManager, out IParamsParam tableParam))
            {
                // In case of a column, check the table
                return tableParam.HasPosition();
            }

            // Check if it has any dependencies (Dependencies Tag)
            ICollection<IParamsParam> referenceParams = GetDependencyReferenceParameters(relationManager);
            if (referenceParams.Count > 0)
            {
                // Only check 1 level deep. No need to check IsPositioned as that doesn't work in DataMiner and could even cause loops.
                return referenceParams.Any(x => x.HasPosition());
            }
            else
            {
                return HasPosition();
            }
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
            return !String.IsNullOrWhiteSpace(Export?.Value) && Export?.Value != "false";
        }

        public bool HasPosition()
        {
            return Display?.Positions?.Count > 0;
        }

        public bool IsLoggerTable()
        {
            var arrayOptions = ArrayOptions?.Options?.Value;
            if (arrayOptions == null)
            {
                return false;
            }

            return arrayOptions.Contains("database:");
        }

        public bool IsSubtable()
        {
            if (!IsTable())
            {
                return false;
            }

            var snmpOidOptions = SNMP?.OID?.GetOptions();
            if (snmpOidOptions == null)
            {
                return false;
            }

            return snmpOidOptions.HasSubtable;
        }

        public bool IsTable()
        {
            if (ArrayOptions == null)
            {
                return false;
            }

            return true;
        }

        public bool IsMatrix()
        {
            return Measurement?.Type?.Value == EnumParamMeasurementType.Matrix;
        }

        public bool IsDisplayedWhenExported(IProtocol protocol, RelationManager relationManager)
        {
            if (!IsInSLElementWhenExported(protocol))
            {
                return false;
            }

            if (TryGetTable(relationManager, out IParamsParam tableParam))
            {
                return tableParam.HasPosition();
            }
            else
            {
                ICollection<IParamsParam> referenceParams = GetDependencyReferenceParameters(relationManager);
                if (referenceParams.Count > 0)
                {
                    return referenceParams.Any(x => x.IsPositioned(relationManager));
                }
                else
                {
                    return HasPosition();
                }
            }
        }

        public ICollection<IParamsParam> GetDependencyReferenceParameters(RelationManager relationManager)
        {
            IEnumerable<Link> links = relationManager.GetReverseLinks(this);

            List<IParamsParam> parameters = new List<IParamsParam>();
            foreach (Link link in links)
            {
                if (link.Target is IParamsParam target && target == this &&
                    link.Reference.ReferencingObject is IParamsParamDependenciesId &&
                    link.Source is IParamsParam refParam)
                {
                    parameters.Add(refParam);
                }
            }

            return parameters;
        }

        public ICollection<IParamsParam> GetDependencyParameters(RelationManager relationManager)
        {
            IEnumerable<Link> links = relationManager.GetForwardLinks(this);

            List<IParamsParam> parameters = new List<IParamsParam>();
            foreach (Link link in links)
            {
                if (link.Source is IParamsParam source && source == this &&
                    link.Reference.ReferencingObject is IParamsParamDependenciesId &&
                    link.Target is IParamsParam dependencyParam)
                {
                    parameters.Add(dependencyParam);
                }
            }

            return parameters;
        }

        #region IRelationManager

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            var n = Name;
            if (!String.IsNullOrWhiteSpace(n?.Value))
            {
                yield return new Reference(this, Mappings.ParamsByName, n.Value, this, isLogic: false, allowLinkToSelf: false);
            }

            var t = Type;
            if (t != null)
            {
                switch (t.Value)
                {
                    case EnumParamType.Response:
                        string rid = t.Id?.Value;
                        if (!String.IsNullOrEmpty(rid))
                        {
                            yield return new Reference(this, Mappings.ResponsesById, rid, t, isLogic: false);
                        }

                        break;
                    case EnumParamType.ReadBit:
                    case EnumParamType.WriteBit:
                        string gid = t.Id?.Value;
                        if (!String.IsNullOrEmpty(gid))
                        {
                            yield return new Reference(this, Mappings.ParamsById, gid, t, "Group", "Bits", isLogic: false);
                        }

                        break;
                    case EnumParamType.Array:
                        string pids = t.Id?.Value;
                        if (!String.IsNullOrEmpty(pids))
                        {
                            foreach (var pid in pids.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                yield return new Reference(this, Mappings.ParamsById, pid, t, "Columns", "Table", isLogic: false);
                            }
                        }
                        break;
                }
            }

            var a = ArrayOptions;
            if (a != null)
            {
                foreach (var c in a)
                {
                    string pid = Convert.ToString(c.Pid?.Value);
                    if (!String.IsNullOrEmpty(pid))
                    {
                        yield return new Reference(this, Mappings.ParamsById, pid, c, "Columns", "Table", isLogic: false);
                    }
                }
            }

            var s = SNMP;
            if (s != null)
            {
                var o = s.OID;
                if (o != null)
                {
                    var id = o.Id?.Value;
                    if (id != null)
                    {
                        yield return new Reference(this, Mappings.ParamsById, Convert.ToString(id), o, "Incoming", "Outgoing");
                    }

                    var ipid = o.Ipid?.Value;
                    if (ipid != null)
                    {
                        yield return new Reference(this, Mappings.ParamsById, Convert.ToString(ipid), o, "Incoming", "Outgoing");
                    }
                }
            }

            var m = Measurement;
            if (m != null)
            {
                var d = m.Discreets;
                if (d != null)
                {
                    string id = Convert.ToString(d.DependencyId?.Value);
                    if (!String.IsNullOrEmpty(id))
                    {
                        yield return new Reference(this, Mappings.ParamsById, id, d, isLogic: false);
                    }
                }
            }

            var deps = Dependencies;
            if (deps != null)
            {
                foreach (var d in deps)
                {
                    string id = d.Value;
                    if (!String.IsNullOrEmpty(id))
                    {
                        yield return new Reference(this, Mappings.ParamsById, id, d, isLogic: false);
                    }
                }
            }

            if (!String.IsNullOrEmpty(Interprete?.LengthType?.Id?.RawValue))
            {
                yield return new Reference(this, Mappings.ParamsById, Interprete.LengthType.Id.RawValue, Interprete.LengthType, groupForward: "Incoming", groupReverse: "Outgoing");
            }
        }

        #endregion
    }
}