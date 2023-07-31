namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Skyline.DataMiner.CICD.Common.Extensions;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    public static class IReadableExtensions
    {
        // Used by DIS (SubText)
        /// <summary>
        /// Check if the node has a CData tag in the XML.
        /// </summary>
        /// <param name="node">Node to check.</param>
        /// <returns>True when node has a CData tag.</returns>
        public static bool HasCData(this IReadable node)
        {
            return node?.ReadNode?.Children?.OfType<XmlCDATA>().Any() ?? false;
        }

        // Used by DIS for Comparer
        /// <summary>
        /// Gets the identifier/path for the specified node.
        /// Example of result: Protocol/Params/Param[@id:123]/id
        /// </summary>
        /// <param name="node">Node to check.</param>
        /// <returns>String that represents the path for the specified node.</returns>
        /// <example>
        /// Protocol/Params/Param[@id:123]/id
        /// </example>
        public static string GetIdentifier(this IReadable node)
        {
            List<string> parts = new List<string>();

            IReadable tempNode = node;
            while (tempNode != null)
            {
                string name = tempNode.TagName;

                if (HasIdentifier(tempNode, out string identifier))
                {
                    name += $"[{identifier}]";
                }
                else if (HasPositionInList(tempNode, out int position))
                {
                    name += $"[{position}]";
                }

                parts.Add(name);
                tempNode = tempNode.Parent;
            }

            parts.Reverse();
            return String.Join("/", parts);
        }

        private static bool HasIdentifier(IReadable node, out string identifier)
        {
            identifier = null;

            string identifierKey = null;
            string identifierValue = null;
            switch (node)
            {
                case IParamsParam param:
                    identifierKey = param.Id?.TagName;
                    identifierValue = param.Id?.RawValue;
                    break;
                case IGroupsGroup group:
                    identifierKey = group.Id?.TagName;
                    identifierValue = group.Id?.RawValue;
                    break;
                case IQActionsQAction qAction:
                    identifierKey = qAction.Id?.TagName;
                    identifierValue = qAction.Id?.RawValue;
                    break;
                case ITriggersTrigger trigger:
                    identifierKey = trigger.Id?.TagName;
                    identifierValue = trigger.Id?.RawValue;
                    break;
                case IActionsAction action:
                    identifierKey = action.Id?.TagName;
                    identifierValue = action.Id?.RawValue;
                    break;
                case ITimersTimer timer:
                    identifierKey = timer.Id?.TagName;
                    identifierValue = timer.Id?.RawValue;
                    break;
                case ICommandsCommand command:
                    identifierKey = command.Id?.TagName;
                    identifierValue = command.Id?.RawValue;
                    break;
                case IResponsesResponse response:
                    identifierKey = response.Id?.TagName;
                    identifierValue = response.Id?.RawValue;
                    break;
                case IPairsPair pair:
                    identifierKey = pair.Id?.TagName;
                    identifierValue = pair.Id?.RawValue;
                    break;
                case IHTTPSession session:
                    identifierKey = session.Id?.TagName;
                    identifierValue = session.Id?.RawValue;
                    break;
                case IHTTPSessionConnection connection:
                    identifierKey = connection.Id?.TagName;
                    identifierValue = connection.Id?.RawValue;
                    break;
                case IAlarmLevelLinksAlarmLevelLink alarmLevelLink:
                    identifierKey = alarmLevelLink.Id?.TagName;
                    identifierValue = alarmLevelLink.Id?.RawValue;
                    break;

                case IPortSettings portSettings:
                    identifierKey = portSettings.Name?.TagName;
                    identifierValue = portSettings.Name?.Value;
                    break;
                case IChainsChain chain:
                    identifierKey = chain.Name?.TagName;
                    identifierValue = chain.Name?.Value;
                    break;
                case ITypeChainsChainField field:
                    identifierKey = field.Name?.TagName;
                    identifierValue = field.Name?.Value;
                    break;
                case IDVEsDVEProtocolsDVEProtocol dveProtocol:
                    identifierKey = dveProtocol.Name?.TagName;
                    identifierValue = dveProtocol.Name?.Value;
                    break;
                case IExportRulesExportRule exportRule:
                    identifierKey = exportRule.Name?.TagName;
                    identifierValue = exportRule.Name?.Value;
                    break;
                case IRelationsRelation relation:
                    identifierKey = relation.Name?.TagName;
                    identifierValue = relation.Name?.Value;
                    break;
                case ITopologiesTopology topology:
                    identifierKey = topology.Name?.TagName;
                    identifierValue = topology.Name?.Value;
                    break;
                case ITopology topology2:
                    identifierKey = topology2.Name?.TagName;
                    identifierValue = topology2.Name?.Value;
                    break;

                case IParameterGroupsGroup paramGroup:
                    identifierKey = paramGroup.Id?.TagName;
                    identifierValue = paramGroup.Id?.RawValue;

                    if (identifierValue == null)
                    {
                        identifierKey = paramGroup.Name?.TagName;
                        identifierValue = paramGroup.Name?.Value;
                    }

                    break;
            }

            if (identifierKey == null || identifierValue == null)
            {
                return false;
            }

            identifier = $"@{identifierKey}:{identifierValue}";
            return true;
        }

        private static bool HasPositionInList<T>(T node, out int position) where T : IReadable
        {
            position = default;

            if (!(node.Parent is IReadableList<T> list))
            {
                // No parent tag or parent isn't a list
                return false;
            }

            int index = list.IndexOf(node);

            if (index != -1)
            {
                position = index;
                return true;
            }

            return false;
        }
    }
}