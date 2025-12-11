namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    internal partial class ActionsAction : IRelationEvaluator, IActionsAction
    {
        #region Get

        public IEnumerable<IGroupsGroup> GetGroups(RelationManager relationManager)
        {
            return relationManager.GetForwardLinks(this)
                .Where(l => l.Source == this && l.Target is IGroupsGroup)
                .Select(l => (IGroupsGroup)l.Target);
        }

        public IEnumerable<ITriggersTrigger> GetTriggeringTriggers(RelationManager relationManager)
        {
            return relationManager.GetReverseLinks(this)
                .Where(l => l.Target == this && l.Source is ITriggersTrigger)
                .Select(l => (ITriggersTrigger)l.Source);
        }

        #endregion

        #region IRelationManager

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            var o = On;
            if (o?.Id != null)
            {
                string ref_ids = Convert.ToString(o.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_ids))
                {
                    foreach (var ref_id in ref_ids.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        switch (o.Value)
                        {
                            case EnumActionOn.Parameter:
                                yield return new Reference(this, Mappings.ParamsById, ref_id, o);
                                break;
                            case EnumActionOn.Group:
                                yield return new Reference(this, Mappings.GroupsById, ref_id, o);
                                break;
                            case EnumActionOn.Pair:
                                yield return new Reference(this, Mappings.PairsById, ref_id, o);
                                break;
                            case EnumActionOn.Command:
                                yield return new Reference(this, Mappings.CommandsById, ref_id, o);
                                break;
                            case EnumActionOn.Response:
                                yield return new Reference(this, Mappings.ResponsesById, ref_id, o);
                                break;
                            case EnumActionOn.Timer:
                                yield return new Reference(this, Mappings.TimersById, ref_id, o);
                                break;
                        }
                    }
                }
            }

            if (o?.Value != null)
            {
                switch (o.Value)
                {
                    case EnumActionOn.Parameter:
                        foreach (var reference in ProcessParameterActionReferences())
                        {
                            yield return reference;
                        }
                        break;
                    case EnumActionOn.Protocol:
                        foreach (var reference in ProcessProtocolActionReferences())
                        {
                            yield return reference;
                        }
                        break;
                    case EnumActionOn.Pair:
                        foreach (var reference in ProcessPairActionReferences())
                        {
                            yield return reference;
                        }
                        break;
                    case EnumActionOn.Command:
                        foreach (var reference in ProcessCommandActionReferences())
                        {
                            yield return reference;
                        }
                        break;
                    case EnumActionOn.Response:
                        foreach (var reference in ProcessResponseActionReferences())
                        {
                            yield return reference;
                        }
                        break;
                }
            }

            var condition = Condition;
            if (condition?.Value != null)
            {
                foreach (Match m in Regex.Matches(condition.Value, @"id:(?<id>\d+)"))
                {
                    string ref_id = m.Groups["id"].Value;
                    yield return new Reference(this, Mappings.ParamsById, ref_id, condition, "Conditions", "Conditions", isLogic: false);
                }
            }
        }

        private IEnumerable<Reference> ProcessParameterActionReferences()
        {
            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Append:
                        case EnumActionType.AppendData:
                        case EnumActionType.ChangeLength:
                        case EnumActionType.Copy:
                        case EnumActionType.CopyReverse:
                        case EnumActionType.Normalize:
                        case EnumActionType.SetAndGetWithWait:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }

                var optionsByType = t.GetOptionsByType();
                if (optionsByType != null)
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Aggregate:
                            var aggregateOptions = optionsByType.Aggregate;
                            if (aggregateOptions.DefaultValue?.ColumnPid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, aggregateOptions.DefaultValue.ColumnPid.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (aggregateOptions.Equation?.Pid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, aggregateOptions.Equation.Pid.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (aggregateOptions.EquationValue?.Pid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, aggregateOptions.EquationValue.Pid.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (aggregateOptions.GroupBy?.Values != null)
                            {
                                foreach ((_, uint? columnPid, _) in aggregateOptions.GroupBy.Values.Where(x => x.columnPid != null))
                                {
                                    yield return new Reference(this, Mappings.ParamsById, columnPid.ToString(), t, reverse: true, isLogic: false);
                                }
                            }

                            if (aggregateOptions.GroupByTable?.Pid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, aggregateOptions.GroupByTable.Pid.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (aggregateOptions.Join?.ColumnPids != null)
                            {
                                foreach (uint? columnPid in aggregateOptions.Join.ColumnPids.Where(pid => pid != null))
                                {
                                    yield return new Reference(this, Mappings.ParamsById, columnPid.ToString(), t, reverse: true, isLogic: false);
                                }
                            }

                            if (aggregateOptions.Return != null)
                            {
                                if (aggregateOptions.Return.Value1 != null)
                                {
                                    yield return new Reference(this, Mappings.ParamsById, aggregateOptions.Return.Value1.ToString(), t, reverse: true, isLogic: false);
                                }

                                if (aggregateOptions.Return.Value2 != null)
                                {
                                    yield return new Reference(this, Mappings.ParamsById, aggregateOptions.Return.Value2.ToString(), t, reverse: true, isLogic: false);
                                }

                                if (aggregateOptions.Return.Value3 != null)
                                {
                                    yield return new Reference(this, Mappings.ParamsById, aggregateOptions.Return.Value3.ToString(), t, reverse: true, isLogic: false);
                                }

                                if (aggregateOptions.Return.Value4 != null)
                                {
                                    yield return new Reference(this, Mappings.ParamsById, aggregateOptions.Return.Value4.ToString(), t, reverse: true, isLogic: false);
                                }
                            }

                            if (aggregateOptions.Status?.Value != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, aggregateOptions.Status.Value.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (aggregateOptions.Weight?.Value != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, aggregateOptions.Weight.Value.ToString(), t, reverse: true, isLogic: false);
                            }

                            break;
                    }
                }
            }
        }

        private IEnumerable<Reference> ProcessProtocolActionReferences()
        {
            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Close:
                        case EnumActionType.ReadFile:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }

            if (t?.Nr != null)
            {
                string nrValue_id = Convert.ToString(t.Nr?.Value);
                if (!String.IsNullOrWhiteSpace(nrValue_id) && Int32.TryParse(nrValue_id, out _))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.ReadFile:
                            yield return new Reference(this, Mappings.ParamsById, nrValue_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }

            if (t?.ReturnValue != null)
            {
                string returnValue_id = Convert.ToString(t.ReturnValue?.Value);
                if (!String.IsNullOrWhiteSpace(returnValue_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.ReadFile:
                            if (Int32.TryParse(returnValue_id, out _))
                            {
                                yield return new Reference(this, Mappings.ParamsById, returnValue_id, t, reverse: true, isLogic: false);
                            }
                            break;
                        case EnumActionType.Wmi:
                            {
                                string[] parts = returnValue_id.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                                for (int i = 0; i < parts.Length; i++)
                                {
                                    string paramId = parts[i];
                                    if (!String.IsNullOrWhiteSpace(paramId) && Int32.TryParse(paramId, out _))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, paramId, t, reverse: true, isLogic: false);
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            if (t?.Startoffset != null)
            {
                string startOffsetValue_id = Convert.ToString(t.Startoffset?.Value);
                if (!String.IsNullOrWhiteSpace(startOffsetValue_id) && Int32.TryParse(startOffsetValue_id, out _))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.ReadFile:
                            yield return new Reference(this, Mappings.ParamsById, startOffsetValue_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }

            var optionsByType = t?.GetOptionsByType();
            if (optionsByType != null)
            {
                switch (t.Value.Value)
                {
                    case EnumActionType.Merge:
                        {
                            var mergeOptions = optionsByType.Merge;
                            if (mergeOptions.Destination?.ColumnPids != null)
                            {
                                foreach (uint? columnPid in mergeOptions.Destination.ColumnPids.Where(pid => pid != null))
                                {
                                    yield return new Reference(this, Mappings.ParamsById, columnPid.ToString(), t, reverse: true, isLogic: false);
                                }
                            }

                            if (mergeOptions.DefaultValue?.ColumnPid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, mergeOptions.DefaultValue.ColumnPid.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (mergeOptions.DestinationFindPk?.ColumnPids != null)
                            {
                                foreach (uint? columnPid in mergeOptions.DestinationFindPk.ColumnPids.Where(pid => pid != null))
                                {
                                    yield return new Reference(this, Mappings.ParamsById, columnPid.ToString(), t, reverse: true, isLogic: false);
                                }
                            }

                            if (mergeOptions.LimitResult?.Pid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, mergeOptions.LimitResult.Pid.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (mergeOptions.RemoteElements?.ColumnPid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, mergeOptions.RemoteElements.ColumnPid.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (mergeOptions.Resolve?.ColumnPids != null)
                            {
                                foreach (uint? columnPid in mergeOptions.Resolve.ColumnPids.Where(pid => pid != null))
                                {
                                    yield return new Reference(this, Mappings.ParamsById, columnPid.ToString(), t, reverse: true, isLogic: false);
                                }
                            }

                            if (mergeOptions.Trigger?.Pid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, mergeOptions.Trigger.Pid.ToString(), t, reverse: true, isLogic: false);
                            }
                        }
                        break;
                    case EnumActionType.SwapColumn:
                        {
                            var swapOptions = optionsByType.Swap;
                            if (swapOptions.Swap != null)
                            {
                                if (swapOptions.Swap.TablePid != null)
                                {
                                    yield return new Reference(this, Mappings.ParamsById, swapOptions.Swap.TablePid.ToString(), t, reverse: true, isLogic: false);
                                }

                                if (swapOptions.Swap.SourceColumnPid != null)
                                {
                                    yield return new Reference(this, Mappings.ParamsById, swapOptions.Swap.SourceColumnPid.ToString(), t, reverse: true, isLogic: false);
                                }

                                if (swapOptions.Swap.DestinationColumnPid != null)
                                {
                                    yield return new Reference(this, Mappings.ParamsById, swapOptions.Swap.DestinationColumnPid.ToString(), t, reverse: true, isLogic: false);
                                }
                            }
                        }
                        break;
                    case EnumActionType.Wmi:
                        {
                            var wmiOptions = optionsByType.Wmi;
                            if (wmiOptions.Pwd?.Pid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, wmiOptions.Pwd.Pid.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (wmiOptions.Server?.Pid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, wmiOptions.Server.Pid.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (wmiOptions.UName?.Pid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, wmiOptions.UName.Pid.ToString(), t, reverse: true, isLogic: false);
                            }

                            if (wmiOptions.Where?.Pid != null)
                            {
                                yield return new Reference(this, Mappings.ParamsById, wmiOptions.Where.Pid.ToString(), t, reverse: true, isLogic: false);
                            }
                        }
                        break;
                }
            }
        }

        private IEnumerable<Reference> ProcessCommandActionReferences()
        {
            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Replace:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }
        }

        private IEnumerable<Reference> ProcessResponseActionReferences()
        {
            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Replace:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }
        }

        private IEnumerable<Reference> ProcessPairActionReferences()
        {
            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.SetNext:
                        case EnumActionType.Timeout:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }
        }
        #endregion
    }
}