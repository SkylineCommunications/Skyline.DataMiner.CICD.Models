namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal partial class PairsPair : IRelationEvaluator, IPairsPair
    {
        #region IRelationEvaluator

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            var c = Content;
            if (c != null)
            {
                foreach (var x in c)
                {
                    if (String.Equals(x.TagName, "command", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return new Reference(this, Mappings.CommandsById, Convert.ToString(x.Value), x);
                    }
                    if (String.Equals(x.TagName, "response", StringComparison.OrdinalIgnoreCase) ||
                        String.Equals(x.TagName, "responseOnBadCommand", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return new Reference(this, Mappings.ResponsesById, Convert.ToString(x.Value), x);
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

        public PairOptions GetOptions()
        {
            string options = Options?.RawValue;
            if (options == null)
            {
                return null;
            }

            return new PairOptions(options);
        }
    }
}