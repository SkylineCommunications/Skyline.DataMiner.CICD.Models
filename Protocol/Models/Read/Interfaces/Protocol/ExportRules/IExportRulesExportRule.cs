namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Skyline.DataMiner.CICD.Parsers.Common.Xml;
    using XmlEdit = Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public partial interface IExportRulesExportRule
    {
        /// <summary>
        /// Clears the internal cache of the regex.
        /// </summary>
        void ClearCache();

        /// <summary>
        /// Returns a regex object when defined on the export rule.
        /// </summary>
        bool TryGetRegex(out Regex regex);

        /// <summary>
        /// Checks if this export rule matches the given XML element.
        /// </summary>
        bool MatchesElement(XmlElement element);

        /// <summary>
        /// Checks if this export rule matches the given XML element.
        /// </summary>
        bool MatchesElement(XmlEdit.XmlElement element);

        /// <summary>
        /// Checks if this export rule matches the given XML element and attribute.
        /// </summary>
        bool MatchesAttribute(XmlElement element, string attributeName);

        /// <summary>
        /// Checks if this export rule matches the given XML element and attribute.
        /// </summary>
        bool MatchesAttribute(XmlEdit.XmlElement element, string attributeName);

        /// <summary>
        /// Returns the child elements that match the tag that is defined in the export rule.
        /// </summary>
        IEnumerable<XmlElement> FindMatchingElements(XmlElement root);

        /// <summary>
        /// Gets the new value after applying the regex and value that is defined on the export rule.
        /// </summary>
        string GetNewValueAfterExportRule(string originalValue);
    }
}