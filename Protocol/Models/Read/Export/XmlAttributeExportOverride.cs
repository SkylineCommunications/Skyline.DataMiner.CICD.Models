namespace Skyline.DataMiner.CICD.Models.Protocol.Read.Export
{
    using System;

    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal class XmlAttributeExportOverride : XmlAttribute
    {
        public XmlAttribute OriginalAttribute { get; }

        public XmlAttributeExportOverride(XmlAttribute originalAttribute)
        {
            OriginalAttribute = originalAttribute ?? throw new ArgumentNullException(nameof(originalAttribute));
            Name = originalAttribute.Name;
        }

        public XmlAttributeExportOverride(string name, string value)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            Name = name;
            _overrideValue = value;
        }

        public override string Name { get; }

        private string _overrideValue;
        public override string Value => _overrideValue ?? OriginalAttribute.Value;

        /// <summary>
        /// The export rule that has produced the overridden value.
        /// </summary>
        public IExportRulesExportRule ExportRule { get; private set; }

        internal void OverrideValue(string value, IExportRulesExportRule exportRule)
        {
            _overrideValue = value;
            ExportRule = exportRule;
        }
    }
}