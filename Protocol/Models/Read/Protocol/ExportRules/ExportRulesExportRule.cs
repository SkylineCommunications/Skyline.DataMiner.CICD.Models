namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    using Skyline.DataMiner.CICD.Models.Protocol.Read.Export;

    using XmlEdit = Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    internal partial class ExportRulesExportRule
    {
        private Regex cachedRegex;

        /// <inheritdoc />
        public void ClearCache()
        {
            cachedRegex = null;
        }

        /// <inheritdoc />
        public bool TryGetRegex(out Regex regex)
        {
            if (cachedRegex == null)
            {
                try
                {
                    var regexString = Regex?.RawValue;

                    if (!String.IsNullOrEmpty(regexString))
                    {
                        cachedRegex = new Regex(regexString);
                    }
                }
                catch (ArgumentException)
                {
                    // ignore
                }
            }

            regex = cachedRegex;
            return cachedRegex != null;
        }

        /// <inheritdoc />
        public IEnumerable<XmlElement> FindMatchingElements(XmlElement root)
        {
            var foundElements = Enumerable.Empty<XmlElement>();

            var whereTag = WhereTag;
            if (String.IsNullOrWhiteSpace(WhereTag?.Value))
            {
                // If whereTag attribute is not available, the 'tag' attribute is being used.
                whereTag = Tag;
            }

            var tagParts = GetTagParts(whereTag);

            for (int i = 0; i < tagParts.Length; i++)
            {
                var tagPart = tagParts[i];

                if (i == 0)
                {
                    if (String.Equals(tagPart, root.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        foundElements = new[] { root };
                    }
                }
                else
                {
                    // ToList is needed here as otherwise it can end up in situations where it will complain about modified collection.
                    foundElements = foundElements.SelectMany(x => x.Elements[tagPart]).ToList();
                }
            }

            if (WhereValue != null)
            {
                if (WhereAttribute != null)
                {
                    // Check content of attribute
                    foundElements = foundElements.Where(x => x.GetAttributeValue(WhereAttribute.Value) == WhereValue.Value);
                }
                else
                {
                    // Check content of tag
                    foundElements = foundElements.Where(x => x.InnerText == WhereValue.Value);
                }
            }
            
            return foundElements.Select(CheckTagCondition).Where(x => x != null);
        }

        /// <inheritdoc />
        public bool MatchesElement(XmlElement element)
        {
            var path = element.GetPath().Select(x => x.Name);

            var tagParts = GetTagParts(Tag);

            if (!path.SequenceEqual(tagParts, StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            return CheckWhereTagCondition(element);
        }

        public bool MatchesElement(XmlEdit.XmlElement element)
        {
            var path = element.GetPath().Select(x => x.Name);

            var tagParts = GetTagParts(Tag);

            if (!path.SequenceEqual(tagParts, StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            return CheckWhereTagCondition(element);
        }

        /// <inheritdoc />
        public bool MatchesAttribute(XmlElement element, string attributeName)
        {
            if (!MatchesElement(element))
            {
                return false;
            }

            return String.Equals(Attribute?.Value, attributeName, StringComparison.OrdinalIgnoreCase);
        }

        public bool MatchesAttribute(XmlEdit.XmlElement element, string attributeName)
        {
            if (!MatchesElement(element))
            {
                return false;
            }

            return String.Equals(Attribute?.Value, attributeName, StringComparison.OrdinalIgnoreCase);
        }

        private bool CheckWhereTagCondition(XmlElement element)
        {
            var whereTag = WhereTag?.Value;
            var whereValue = WhereValue?.Value;

            if (!String.IsNullOrWhiteSpace(whereValue) && String.IsNullOrWhiteSpace(whereTag))
            {
                // If whereTag attribute is not available, the 'tag' attribute is being used.
                whereTag = Tag?.Value;
            }

            if (String.IsNullOrWhiteSpace(whereTag))
            {
                return true;
            }

            XmlElement tagToCheck = null;

            var tagParts = GetTagParts(WhereTag);
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

        private XmlElement CheckTagCondition(XmlElement element)
        {
            if (String.IsNullOrWhiteSpace(Tag?.Value))
            {
                return null;
            }

            XmlElement tagToCheck = null;

            var tagParts = GetTagParts(Tag);
            var queue = new Queue<XmlElement>(element.GetPath());

            foreach (string tagPart in tagParts)
            {
                if (queue.Count > 0 && String.Equals(queue.Peek().Name, tagPart, StringComparison.OrdinalIgnoreCase))
                {
                    tagToCheck = queue.Dequeue();
                }
                else
                {
                    var tempTag = tagToCheck?.Element[tagPart];
                    if (tagToCheck is XmlElementExportOverride temp && tempTag == null)
                    {
                        var newTag = new XmlElement { Name = tagPart, ParentNode = tagToCheck };
                        var newOverrideTag = new XmlElementExportOverride(tagToCheck, newTag, false);
                        temp.AddChild(newOverrideTag);
                        tagToCheck = newOverrideTag;
                    }
                    else
                    {
                        tagToCheck = tempTag;
                    }
                }
            }

            return tagToCheck;
        }

        private bool CheckWhereTagCondition(XmlEdit.XmlElement element)
        {
            var whereTag = WhereTag?.Value;
            var whereValue = WhereValue?.Value;

            if (String.IsNullOrWhiteSpace(whereTag))
            {
                return true;
            }

            XmlEdit.XmlElement tagToCheck = null;

            var tagParts = GetTagParts(WhereTag);
            var queue = new Queue<XmlEdit.XmlElement>(element.GetPath());

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

        public string GetNewValueAfterExportRule(string originalValue)
        {
            var regexString = Regex?.RawValue;
            var value = ValueAttribute?.RawValue;

            if (!String.IsNullOrWhiteSpace(regexString))
            {
                if (TryGetRegex(out var regex))
                {
                    return regex.Replace(originalValue, value ?? "");
                }
                else
                {
                    // don't replace anything when regex is invalid
                    return originalValue;
                }
            }

            // normal replacement without regex
            return value;
        }

        private static string[] GetTagParts(IValueTag<string> tag)
        {
            var tagValue = tag?.Value ?? "";
            var tagParts = tagValue.Split(new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);

            return tagParts;
        }
    }
}