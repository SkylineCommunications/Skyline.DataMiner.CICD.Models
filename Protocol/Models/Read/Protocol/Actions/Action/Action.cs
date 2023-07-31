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

            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Copy:
                        case EnumActionType.CopyReverse:
                        case EnumActionType.Normalize:
                        case EnumActionType.ReadFile:
                        case EnumActionType.Append:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }

                var ref_ids = Convert.ToString(t.ReturnValue?.Value);
                if (!String.IsNullOrWhiteSpace(ref_ids))
                {
                    foreach (var r in ref_ids.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        switch (t.Value.Value)
                        {
                            case EnumActionType.ReadFile:
                            case EnumActionType.Wmi:
                                yield return new Reference(this, Mappings.ParamsById, r, t, reverse: true, isLogic: false);
                                break;
                        }
                    }
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

        #endregion
    }
}