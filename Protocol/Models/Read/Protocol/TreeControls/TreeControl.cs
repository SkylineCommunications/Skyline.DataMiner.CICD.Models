using Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces;
using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class TreeControlsTreeControl : IRelationEvaluator, ITreeControlsTreeControl
    {
        #region Get

        public ICollection<uint> GetDisplayedTablesPids(IProtocolModel model)
        {
            HashSet<uint> tablePids = new HashSet<uint>();

            // Hierarchy@path
            string[] pathIds = this.Hierarchy?.Path?.Value?.Split(',');
            if (pathIds != null)
            {
                foreach (var pathId in pathIds)
                {
                    if (!UInt32.TryParse(pathId, out uint id))
                    {
                        continue;
                    }

                    tablePids.Add(id);
                }
            }

            // Hierarchy\Table@id
            if (this.Hierarchy?.Count > 0)
            {
                foreach (var table in this.Hierarchy)
                {
                    if (table.Id?.Value == null)
                    {
                        continue;
                    }

                    tablePids.Add(table.Id.Value.Value);
                }
            }

            // ExtraTabs\Tab@tableId
            if (this.ExtraTabs != null)
            {
                foreach (var tab in this.ExtraTabs)
                {
                    if (tab.Parameter?.Value == null || !UInt32.TryParse(tab.Parameter.Value, out uint pid))
                    {
                        continue;
                    }

                    if (!model.TryGetObjectByKey(Mappings.ParamsById, tab.Parameter.Value, out IParamsParam param))
                    {
                        continue;
                    }

                    if (param.IsTable())
                    {
                        tablePids.Add(pid);
                    }
                    else if (param.TryGetTable(model.RelationManager, out IParamsParam table))
                    {
                        tablePids.Add(table.Id.Value.Value);
                    }
                }
            }

            // ExtraDetails\LinkedDetails@detailsTableId
            if (this.ExtraDetails != null)
            {
                foreach (var linkedDetails in this.ExtraDetails)
                {
                    if (linkedDetails.DetailsTableId?.Value == null)
                    {
                        continue;
                    }

                    uint detailsTableId = linkedDetails.DetailsTableId.Value.Value;

                    if (!model.TryGetObjectByKey(Mappings.ParamsById, Convert.ToString(detailsTableId), out IParamsParam param))
                    {
                        continue;
                    }

                    if (param.IsTable())
                    {
                        tablePids.Add(detailsTableId);
                    }
                    else if (param.TryGetTable(model.RelationManager, out IParamsParam table))
                    {
                        tablePids.Add(table.Id.Value.Value);
                    }
                }
            }

            return tablePids;
        }

        public bool MainParameterExists(IProtocolModel model)
        {
            var paramIdString = Convert.ToString(ParameterId?.Value);
            return model.TryGetObjectByKey(Mappings.ParamsById, paramIdString, out IParamsParam _);
        }

        #endregion

        #region IRelationEvaluator

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            if (ParameterId?.Value != null)
            {
                yield return new Reference(this, Mappings.ParamsById, Convert.ToString(ParameterId?.Value), this, isLogic: false);
            }

            var hierarchy = Hierarchy;
            if (hierarchy != null)
            {
                string p = hierarchy.Path?.Value;
                if (p != null)
                {
                    foreach (var ref_id in p.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        yield return new Reference(this, Mappings.ParamsById, ref_id, hierarchy, isLogic: false);
                    }
                }

                foreach (var t in hierarchy)
                {
                    var tid = t.Id?.Value;
                    if (tid != null)
                        yield return new Reference(this, Mappings.ParamsById, Convert.ToString(tid), t, isLogic: false);
                }
            }

            var extraDetails = ExtraDetails;
            if (extraDetails != null)
            {
                foreach (var ld in extraDetails)
                {
                    var ldid = ld.DetailsTableId?.Value;
                    if (ldid != null)
                        yield return new Reference(this, Mappings.ParamsById, Convert.ToString(ldid), ld, isLogic: false);
                }
            }

            var extraTabs = ExtraTabs;
            if (extraTabs != null)
            {
                foreach (var t in extraTabs)
                {
                    string p = t.Parameter?.Value;
                    if (p != null)
                    {
                        foreach (var ref_id in p.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, isLogic: false);
                        }
                    }
                }
            }

            var overrideDisplayColumns = OverrideDisplayColumns;
            if (overrideDisplayColumns != null)
            {
                string p = overrideDisplayColumns.Value;
                if (p != null)
                {
                    foreach (var ref_id in p.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        yield return new Reference(this, Mappings.ParamsById, ref_id, overrideDisplayColumns, isLogic: false);
                    }
                }
            }

            var overrideIconColumns = OverrideIconColumns;
            if (overrideIconColumns != null)
            {
                string p = overrideIconColumns.Value;
                if (p != null)
                {
                    foreach (var ref_id in p.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        yield return new Reference(this, Mappings.ParamsById, ref_id, overrideIconColumns, isLogic: false);
                    }
                }
            }

            var hiddenColumns = HiddenColumns;
            if (hiddenColumns != null)
            {
                string p = hiddenColumns.Value;
                if (p != null)
                {
                    foreach (var ref_id in p.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        yield return new Reference(this, Mappings.ParamsById, ref_id, hiddenColumns, isLogic: false);
                    }
                }
            }
        }

        #endregion
    }
}
