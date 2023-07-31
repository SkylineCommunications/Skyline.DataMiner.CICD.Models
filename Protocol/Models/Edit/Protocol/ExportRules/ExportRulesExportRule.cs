namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public partial class ExportRulesExportRule
    {
        static readonly string[] attributesOrder = new string[] { "table", "tag", "attribute", "regex", "value", "whereTag", "whereValue" };

        public override string[] AttributesOrder => attributesOrder;

        public bool MatchesElement(XmlElement element)
        {
            var path = element.GetPath().Select(x => x.Name);

            var tag = Tag?.Value ?? "";
            var tagParts = tag.Split(new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (!path.SequenceEqual(tagParts, StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            return CheckWhereTagCondition(element);
        }

        private bool CheckWhereTagCondition(XmlElement element)
        {
            var whereTag = WhereTag?.Value;
            var whereValue = WhereValue?.Value;

            if (String.IsNullOrWhiteSpace(whereTag))
            {
                return true;
            }

            XmlElement tagToCheck = null;

            var tagParts = whereTag.Split(new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);
            var queue = new Queue<XmlElement>(element.GetPath());

            foreach (string tagPart in tagParts)
            {
                if (queue.Count > 0 && String.Equals(queue.Peek().Name, tagPart, StringComparison.OrdinalIgnoreCase))
                {
                    tagToCheck = queue.Dequeue();
                }
                else
                {
                    tagToCheck = tagToCheck?.Element[tagPart];
                }

                if (tagToCheck == null)
                {
                    break;
                }
            }

            if (tagToCheck != null && String.Equals(tagToCheck.InnerText, whereValue))
            {
                return true;
            }

            return false;
        }
    }
}
