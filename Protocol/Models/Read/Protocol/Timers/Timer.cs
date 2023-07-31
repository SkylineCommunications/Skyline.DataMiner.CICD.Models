namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal partial class TimersTimer : IRelationEvaluator, ITimersTimer
    {
        #region Get

        public TimerOptions GetOptions()
        {
            string options = Options?.RawValue;
            if (options == null)
            {
                return null;
            }

            return new TimerOptions(options);
        }

        public IEnumerable<IGroupsGroup> GetTimerContentGroups(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetForwardLinks(this))
            {
                if (link?.Target is IGroupsGroup group && link?.Reference?.ReferencingObject is ITimersTimerContentGroup)
                {
                    yield return group;
                }
            }
        }

        #endregion

        #region IRelationEvaluator

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            if (Options?.Value != null)
            {
                var options = Options.Value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var option in options)
                {
                    var parts = option.Split(':');
                    if (parts.Length == 2)
                    {
                        string optionTitle = parts[0];
                        string optionValue = parts[1];

                        if (String.Equals(optionTitle, "ip", StringComparison.InvariantCultureIgnoreCase))
                        {
                            yield return new Reference(this, Mappings.ParamsById, optionValue.Split(',')[0], this);
                        }
                        else if (String.Equals(optionTitle, "qaction", StringComparison.InvariantCultureIgnoreCase) ||
                            String.Equals(optionTitle, "qactionBefore", StringComparison.InvariantCultureIgnoreCase) ||
                            String.Equals(optionTitle, "qactionAfter", StringComparison.InvariantCultureIgnoreCase))
                        {
                            yield return new Reference(this, Mappings.QActionsById, optionValue.Split(',')[0], this);
                        }
                    }
                }
            }

            if (Content != null)
            {
                foreach (ITimersTimerContentGroup c in Content)
                {
                    yield return new Reference(this, Mappings.GroupsById, Convert.ToString(c.Value), c);
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
