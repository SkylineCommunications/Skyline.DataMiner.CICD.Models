namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Skyline.DataMiner.CICD.Models.Protocol.Models.Custom_Classes;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal abstract class SimpleProtocolListNode<T> : ProtocolListNode<T> where T : class, IProtocolTag
    {

        protected SimpleProtocolListNode(ProtocolModel model, ProtocolTag parent, string tagName, IEnumerable<string> childTagNames)
            : base(model, parent, tagName, childTagNames)
        {
        }

        protected SimpleProtocolListNode(ProtocolModel model, ProtocolTag parent, string tagName, string childTagName)
            : this(model, parent, tagName, new string[] { childTagName })
        {
        }

        protected override T TryCreateElement(XmlElement element)
        {
            var type = typeof(T);

            if (!ModelObjectActivator<ProtocolModel, ProtocolTag, string, T>.TryCreate(type, protocolModel, this, element.Name, out var newElement)
                && !ModelObjectActivator<ProtocolModel, ProtocolTag, T>.TryCreate(type, protocolModel, this, out newElement))
            {
                var availableConstructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                throw new InvalidOperationException("No matching constructor found in type '" + type + "'. Available constructors:\n"
                                                    + String.Join("\n", availableConstructors.Select(x => " - " + x)));
            }

            newElement.Update(element, element?.Name);
            return newElement;
        }

    }
}
