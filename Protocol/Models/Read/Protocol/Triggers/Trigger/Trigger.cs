namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    internal partial class TriggersTrigger : IRelationEvaluator, ITriggersTrigger
    {
        #region Get

        public IEnumerable<IActionsAction> GetActions(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetForwardLinks(this))
            {
                if (link.Source == this && link.Target is IActionsAction action)
                {
                    yield return action;
                }
            }
        }

        #endregion

        #region IRelationManager

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            var o = On;
            if (o?.Value != null && o?.Id != null)
            {
                string ref_id = Convert.ToString(o.Id?.Value);

                switch (o.Value.Value)
                {
                    case EnumTriggerOn.Parameter:
                        yield return new Reference(this, Mappings.ParamsById, ref_id, o, reverse: true);
                        break;
                    case EnumTriggerOn.Group:
                        yield return new Reference(this, Mappings.GroupsById, ref_id, o, reverse: true);
                        break;
                    case EnumTriggerOn.Pair:
                        yield return new Reference(this, Mappings.PairsById, ref_id, o, reverse: true);
                        break;
                    case EnumTriggerOn.Command:
                        yield return new Reference(this, Mappings.CommandsById, ref_id, o, reverse: true);
                        break;
                    case EnumTriggerOn.Response:
                        yield return new Reference(this, Mappings.ResponsesById, ref_id, o, reverse: true);
                        break;
                    case EnumTriggerOn.Timer:
                        yield return new Reference(this, Mappings.TimersById, ref_id, o, reverse: true);
                        break;
                    case EnumTriggerOn.Session:
                        yield return new Reference(this, Mappings.SessionsById, ref_id, o, reverse: true);
                        break;
                }
            }

            var ref_type = Type?.Value;

            var c = Content;
            if (c != null)
            {
                foreach (var d in c)
                {
                    string ref_id = Convert.ToString(d.Value);

                    switch (ref_type)
                    {
                        case EnumTriggerType.Action:
                            yield return new Reference(this, Mappings.ActionsById, ref_id, d);
                            break;
                        case EnumTriggerType.Trigger:
                            yield return new Reference(this, Mappings.TriggersById, ref_id, d);
                            break;
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