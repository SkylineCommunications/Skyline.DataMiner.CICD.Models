namespace Skyline.DataMiner.CICD.Models.Protocol.Read.Export
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal class ProtocolExportHandler
    {
        private readonly IProtocolModel model;
        private readonly int tablePid;
        private readonly string name;

        // list provided by DEV
        private static readonly string[] skipCopyTags = {
                "Commands"    ,
                "Responses"   ,
                "Pairs"       ,
                "HTTP"        , // Not part of core code but we can ignore anyway
                "Groups"      ,
                "Triggers"    ,
                "Actions"     ,
                "QActions"    ,
                "Timers"      ,
                "Relations"   ,
                "Chains"      ,
                "RCA"         ,
                "Topology"    ,
                "ExportRules" ,
                "PortSettings",
                "Ports"       ,
                "DVEs"
            };

        public ProtocolExportHandler(IProtocolModel model, int tablePid, string name)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (tablePid <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tablePid));
            }

            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            this.model = model;
            this.tablePid = tablePid;
            this.name = name;
        }

        public ProtocolModelExport CreateExportedProtocol()
        {
            var mainProtocol = model.Protocol;
            if (mainProtocol == null) return default;

            var exportXml = CopyProtocol(mainProtocol.ReadNode);

            ClearCache();

            ApplyExportRules(exportXml);
            
            var newDocument = new XmlDocumentExportOverride(exportXml);
            
            var newModel = new ProtocolModel(newDocument);
            newModel.SetMainProtocolModel(model);

            return new ProtocolModelExport(tablePid, name, newDocument, newModel);
        }

        private void ClearCache()
        {
            var exportRules = model.Protocol.ExportRules;
            if (exportRules == null)
            {
                return;
            }

            foreach (IExportRulesExportRule exportRule in exportRules)
            {
                exportRule.ClearCache();
            }
        }

        private XmlElementExportOverride CopyProtocol(XmlElement xml)
        {
            var xmlProtocol = new XmlElementExportOverride(xml.ParentNode, xml, copyChildren: false);

            foreach (var child in xml.Children)
            {
                if (child is XmlElement xe)
                {
                    if (skipCopyTags.Contains(xe.Name, StringComparer.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    XmlElementExportOverride newChild;

                    if (String.Equals(xe.Name, "params", StringComparison.OrdinalIgnoreCase))
                    {
                        newChild = new XmlElementExportOverride(xmlProtocol, xe, copyChildren: false);

                        foreach (var param in GetExportedParams())
                        {
                            var newParam = new XmlElementExportOverride(newChild, param.ReadNode);
                            HandleParamExport(newParam);
                            newChild.AddChild(newParam);
                        }
                    }
                    else if (String.Equals(xe.Name, "name", StringComparison.OrdinalIgnoreCase))
                    {
                        newChild = new XmlElementExportOverride(xmlProtocol, xe);
                        newChild.OverrideInnerText(name, exportRule: null);
                        newChild.AddAttribute(new XmlAttributeExportOverride("parentProtocol", xe.InnerText));
                    }
                    else if (String.Equals(xe.Name, "type", StringComparison.OrdinalIgnoreCase))
                    {
                        newChild = GenerateNewTypeTag(xmlProtocol, xe);
                    }
                    else if (String.Equals(xe.Name, "display", StringComparison.OrdinalIgnoreCase))
                    {
                        newChild = GenerateNewDisplayTag(xmlProtocol, xe);
                    }
                    else
                    {
                        newChild = new XmlElementExportOverride(xmlProtocol, xe);
                    }

                    xmlProtocol.AddChild(newChild);
                }
                else
                {
                    xmlProtocol.AddChild(child);
                }
            }

            return xmlProtocol;
        }
        
        private static XmlElementExportOverride GenerateNewTypeTag(XmlElementExportOverride xmlProtocol, XmlElement oldType)
        {
            var newType = new XmlElementExportOverride(xmlProtocol, oldType);
            newType.OverrideInnerText("virtual", exportRule: null);

            var options = newType.Attribute["options"];
            if (options is XmlAttributeExportOverride optionsOverride)
            {
                var parts = optionsOverride.Value.Split(new[] { ';' }).ToList();
                parts.RemoveAll(x => x.Trim().StartsWith("exportProtocol:", StringComparison.OrdinalIgnoreCase));

                if (parts.Count > 0)
                    optionsOverride.OverrideValue(String.Join(";", parts), exportRule: null);
                else
                    newType.RemoveAttribute(optionsOverride);
            }

            var advanced = newType.Attribute["advanced"];
            if (advanced != null)
            {
                newType.RemoveAttribute(advanced);
            }

            return newType;
        }

        private static XmlElementExportOverride GenerateNewDisplayTag(XmlElementExportOverride xmlProtocol, XmlElement oldDisplay)
        {
            var newDisplay = new XmlElementExportOverride(xmlProtocol, oldDisplay);

            var pageOrder = newDisplay.Attribute["pageOrder"];
            if (pageOrder is XmlAttributeExportOverride pageOrderOverride)
            {
                pageOrderOverride.OverrideValue("", exportRule: null);
            }

            var defaultPage = newDisplay.Attribute["defaultPage"];
            if (defaultPage is XmlAttributeExportOverride defaultPageOverride)
            {
                defaultPageOverride.OverrideValue("", exportRule: null);
            }

            return newDisplay;
        }

        private void HandleParamExport(XmlElementExportOverride param)
        {
            // remove discreet values that don't need to be exported
            var discreets = param.Element["Measurement"]?.Element["Discreets"];

            if (!(discreets is XmlElementExportOverride discreetsOverride))
            {
                return;
            }

            foreach (var discreet in discreetsOverride.Elements["Discreet"].ToList())
            {
                var export = discreet.Attribute["export"]?.Value;
                if (String.IsNullOrWhiteSpace(export))
                {
                    continue;
                }

                bool found = false;

                var exportParts = export.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string exportPart in exportParts)
                {
                    if (Int32.TryParse(exportPart, out var x) && x == tablePid)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    discreetsOverride.RemoveChild(discreet);
                }
            }
        }
        
        private IEnumerable<IParamsParam> GetExportedParams()
        {
            var parameters = model.Protocol.Params;
            if (parameters == null)
            {
                return Enumerable.Empty<IParamsParam>();
            }

            return parameters.GetExportedParamsForTable(tablePid);
        }

        private void ApplyExportRules(XmlElementExportOverride exportXml)
        {
            var exportRules = model.Protocol.ExportRules;
            if (exportRules == null)
            {
                return;
            }

            foreach (var rule in exportRules.GetExportRulesForTable(tablePid))
            {
                var attribute = rule.Attribute?.Value;
                
                IEnumerable<XmlElement> matchingElements = rule.FindMatchingElements(exportXml);

                foreach (var me in matchingElements)
                {
                    if (!String.IsNullOrWhiteSpace(attribute))
                    {
                        if (me.Attribute[attribute] is XmlAttributeExportOverride attr)
                        {
                            var newValue = rule.GetNewValueAfterExportRule(attr.Value);
                            attr.OverrideValue(newValue, rule);
                        }
                    }
                    else
                    {
                        var newValue = rule.GetNewValueAfterExportRule(me.InnerText);
                        (me as XmlElementExportOverride)?.OverrideInnerText(newValue, rule);
                    }
                }
            }
        }
    }
}
