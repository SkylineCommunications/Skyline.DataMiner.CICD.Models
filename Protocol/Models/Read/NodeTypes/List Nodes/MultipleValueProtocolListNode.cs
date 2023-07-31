namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Skyline.DataMiner.CICD.Models.Protocol.Models.Custom_Classes;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal abstract class MultipleValueProtocolListNode<T> : SimpleProtocolListNode<T> where T : class, IProtocolTag
    {
        private readonly Dictionary<string, Type> typeDictionary;

        protected MultipleValueProtocolListNode(ProtocolModel model, ProtocolTag parent, string tagName, Dictionary<string, Type> typeDictionary)
            : base(model, parent, tagName, typeDictionary.Keys)
        {
            this.typeDictionary = typeDictionary;
        }

        protected override T TryCreateElement(XmlElement element)
        {
            string name = element.Name;

            if (typeDictionary.TryGetValue(name, out Type type))
            {
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
            else
            {
                return null;
            }
        }

    }
}
