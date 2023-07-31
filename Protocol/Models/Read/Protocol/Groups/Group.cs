namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{

    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;
    using System.Collections.Generic;
    using System;
    using System.Text.RegularExpressions;

    internal partial class GroupsGroup : IRelationEvaluator, IGroupsGroup
    {
        #region Get

        public IEnumerable<IActionsAction> GetContentActions(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetForwardLinks(this))
            {
                if (link.Target is IActionsAction action)
                {
                    yield return action;
                }
            }
        }

        public IEnumerable<IPairsPair> GetContentPairs(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetForwardLinks(this))
            {
                if (link.Target is IPairsPair pair)
                {
                    yield return pair;
                }
            }
        }

        public IEnumerable<IParamsParam> GetContentParameters(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetForwardLinks(this))
            {
                if (link.Target is IParamsParam param)
                {
                    yield return param;
                }
            }
        }

        public IEnumerable<IHTTPSession> GetContentSessions(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetForwardLinks(this))
            {
                if (link.Target is IHTTPSession session)
                {
                    yield return session;
                }
            }
        }

        public IEnumerable<ITriggersTrigger> GetContentTriggers(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetForwardLinks(this))
            {
                if (link.Target is ITriggersTrigger trigger)
                {
                    yield return trigger;
                }
            }
        }

        #endregion

        #region IRelationManager

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            if (ConnectionPID?.Value != null)
            {
                yield return new Reference(this, Mappings.ParamsById, ConnectionPID.Value.ToString(), this, groupForward: "Incoming", groupReverse: "Outgoing", isLogic: false);
            }

            var c = Content;
            if (c != null)
            {
                foreach (var d in c)
                {
                    if (d is IGroupsGroupContentPair pair)
                    {
                        string ref_id = Convert.ToString(pair.Value);
                        yield return new Reference(this, Mappings.PairsById, ref_id, d);
                    }
                    else if (d is IGroupsGroupContentAction action)
                    {
                        string ref_id = Convert.ToString(action.Value);
                        yield return new Reference(this, Mappings.ActionsById, ref_id, d);
                    }
                    else if (d is IGroupsGroupContentTrigger trigger)
                    {
                        string ref_id = Convert.ToString(trigger.Value);
                        yield return new Reference(this, Mappings.TriggersById, ref_id, d);
                    }
                    else if (d is IGroupsGroupContentParam param)
                    {
                        string ref_id = Convert.ToString(param.Value);
                        yield return new Reference(this, Mappings.ParamsById, ref_id, d);
                    }
                    else if (d is IGroupsGroupContentSession session)
                    {
                        string ref_id = Convert.ToString(session.Value);
                        yield return new Reference(this, Mappings.SessionsById, ref_id, d);
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
