namespace Skyline.DataMiner.CICD.Models.Protocol.Read.Export
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    using Skyline.DataMiner.CICD.Parsers.Common.Xml;
    
    internal class XmlElementExportOverride : XmlElement
    {
        private readonly XmlContainer _parentNode;

        public XmlElement OriginalElement { get; }

        public XmlElementExportOverride(XmlContainer parent, XmlElement originalElement, bool copyChildren = true)
        {
            _parentNode = parent ?? throw new ArgumentNullException(nameof(parent));
            OriginalElement = originalElement ?? throw new ArgumentNullException(nameof(originalElement));

            // New XmlElement that does not have a token.
            if (originalElement.Token != null)
            {
                var newAttributes = originalElement.GetAttributes()
                                                   .Select(a => new XmlAttributeExportOverride(a));

                _attributes.AddRange(newAttributes);
            }

            if (!copyChildren)
            {
                return;
            }

            foreach (var c in originalElement.Children)
            {
                if (c is XmlElement ce)
                {
                    _children.Add(new XmlElementExportOverride(this, ce));
                    continue;
                }

                _children.Add(c);
            }
        }

        public override XmlContainer ParentNode => _parentNode;

        private readonly List<XmlAttribute> _attributes = new List<XmlAttribute>();

        public override string Name => OriginalElement.Name;

        private string _overrideInnerText;
        public override string InnerText => _overrideInnerText ?? OriginalElement.InnerText;

        /// <summary>
        /// The export rule that has produced the overridden value.
        /// </summary>
        public IExportRulesExportRule ExportRule { get; private set; }

        public override IEnumerable<XmlAttribute> GetAttributes()
        {
            return _attributes;
        }

        internal void AddChild(XmlNode child)
        {
            _children.Add(child);
        }

        internal void RemoveChild(XmlNode child)
        {
            _children.Remove(child);
        }

        internal void AddAttribute(XmlAttribute attribute)
        {
            _attributes.Add(attribute);
        }

        internal void RemoveAttribute(XmlAttribute attribute)
        {
            _attributes.Remove(attribute);
        }

        internal void OverrideInnerText(string text, IExportRulesExportRule exportRule)
        {
            _overrideInnerText = text;
            ExportRule = exportRule;
        }

        public override string GetXml()
        {
            if (_overrideInnerText != null)
            {
                var sb = new StringBuilder();

                sb.Append("<");
                sb.Append(Name);

                foreach (var a in GetAttributes())
                {
                    sb.Append(" ");
                    sb.Append(a.GetXml());
                }

                sb.Append(">");
                sb.Append(WebUtility.HtmlEncode(_overrideInnerText));
                sb.Append("</");
                sb.Append(Name);
                sb.Append(">");

                return sb.ToString();
            }

            return base.GetXml();
        }

        // Returns the positions in the original XML
        public override int FirstCharOffset => OriginalElement.Token == null ? GetExistingOriginalParent().FirstCharOffset : OriginalElement.FirstCharOffset;

        public override int LastCharOffset => OriginalElement.Token == null ? GetExistingOriginalParent().LastCharOffset : OriginalElement.LastCharOffset;

        private XmlElement GetExistingOriginalParent()
        {
            var element = OriginalElement;

            while(element != null && element.Token == null)
            {
                var parentNode = element.ParentNode as XmlElementExportOverride;

                if (parentNode != null)
                {
                    element = parentNode.OriginalElement;
                }
            }

            return element;
        }
    }
}
