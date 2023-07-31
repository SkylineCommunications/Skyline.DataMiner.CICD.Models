namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using System;
    using System.Linq;

    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public static class ElementHandler
    {

        /// <summary>
        /// Verifies if the attribute is available. When the container of the handler is null, the attribute will be removed.
        /// When the container is different from null and the attribute doesn't exists in xml yet, it will be created.
        /// </summary>
        internal static void Assign<T>(ElementValue<T> value, IEditableNode parent, string tagName)
        {

            XmlElement element = parent.EditNode.Element[tagName];
            if (value == null)
            {
                RemoveNode(element, parent);
            }
            else
            {
                value.TagName = tagName;
                value.Parent = parent;

                if (element == null)
                {
                    CreateNewValueNode(value.RawValue, parent, tagName, value.UseCDATA);
                }
                else
                {
                    SetNodeValue(element, value.RawValue, value.UseCDATA);
                }
            }

            parent.EditNode?.Format();
        }

        #region Private Methods
        /// <summary>
        /// Removes an XmlNode from the XmlElement.
        /// </summary>
        /// <param name="node">The node to be removed</param>
        /// <param name="parent">The item from which the <paramref name="node"/> should be removed.</param>
        private static void RemoveNode(XmlElement node, IEditableNode parent)
        {
            if (node != null)
            {
                parent.EditNode.Children.Remove(node, removeEmptyLineBefore: true);
            }
        }

        /// <summary>
        /// Creates a new value node based.
        /// If the element order is specified, the node will be put in the correct position.
        /// Otherwise, it's appended to the back of the children list on that level.
        /// </summary>
        /// <param name="value">The value of the new node.</param>
        /// <param name="parent">The item on which the new node should be added.</param>
        /// <param name="tagName">The name of the new node.</param>
        /// <param name="useCDATA">true if the <paramref name="value"/> should be surrounded by a CDATA tag.</param>
        private static void CreateNewValueNode(string value, IEditableNode parent, string tagName, bool useCDATA)
        {
            var node = new XmlElement(tagName);
            if (useCDATA)
            {
                node.Children.Add(new XmlCDATA(value));
            }
            else
            {
                node.InnerText = value;
            }

            var order = parent.ElementOrder;

            if (order == null)
            {
                parent.EditNode.Children.Add(node);
            }
            else
            {
                int insertPosition = GetNodeInsertPosition(parent, tagName, order);
                parent.EditNode.Children.Insert(insertPosition, node);
            }

            parent.EditNode?.Format();
        }

        /// <summary>
        /// Retrieves the position where we should insert the node.
        /// </summary>
        /// <param name="parent">The item on which adding a node is planned.</param>
        /// <param name="name">the name of the tag to be added.</param>
        /// <param name="order">The order that the elements should occur in according to the XSD.</param>
        /// <returns></returns>
        internal static int GetNodeInsertPosition(IEditableNode parent, string name, string[] order)
        {
            var children = parent.EditNode.Children;
            int index = children.Count;

            int nameIndex = Array.IndexOf(order, name);
            if (nameIndex == -1)
            {
                // add after other children
                return index;
            }

            for (int i = 0; i < children.Count; i++)
            {
                if (children[i] is XmlElement element &&
                    Array.IndexOf(order, element.Name) > nameIndex)
                {
                    // insert before item with higher order index
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Assigns the value to the element.
        /// </summary>
        /// <param name="element">The XmlElement.</param>
        /// <param name="value">The value to be assigned.</param>
        private static void SetNodeValue(XmlElement element, string value, bool useCDATA)
        {
            if (useCDATA && !element.Children.Any(c => c is XmlCDATA))
            {
                element.Children.Clear();
                element.Children.Add(new XmlCDATA(value));
            }
            else
            {
                element.InnerText = value;
            }

        }

        #endregion
    }
}
