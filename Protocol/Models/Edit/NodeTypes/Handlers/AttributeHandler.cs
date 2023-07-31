namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using System;

    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public static class AttributeHandler
    {
        /// <summary>
        /// Verifies if the attribute is available. When the container of the handler is null, the attribute will be removed.
        /// When the container is different from null and the attribute doesn't exists in xml yet, it will be created.
        /// </summary>
        internal static void Assign<T>(AttributeValue<T> value, IEditableNode parent, string tagName)
        {

            if (value == null)
            {
                RemoveAttribute(parent.EditNode, tagName);
            }
            else
            {
                value.TagName = tagName;
                value.Parent = parent;

                XmlAttribute attribute = parent.EditNode.Attribute[tagName];
                string valueToWrite = value.RawValue;

                if (attribute == null)
                {
                    CreateNewAttribute(valueToWrite, parent, tagName);
                }
                else
                {
                    SetAttribute(attribute, valueToWrite);
                }
            }
        }

        #region Private Methods
        /// <summary>
        /// Adds a new attribute to <paramref name="parent"/> at a specific position.
        /// </summary>
        /// <param name="value">Value of the new attribute.</param>
        /// <param name="parent">Node to which the new attribute needs to be added.</param>
        /// <param name="name">Name of the new attribute.</param>
        private static void CreateNewAttribute(string value, IEditableNode parent, string name)
        {
            var attribute = new XmlAttribute(name, value);

            var order = parent.AttributesOrder;

            if (order == null || order.Length == 0)
            {
                parent.EditNode.Attributes.Add(attribute);
            }
            else
            {
                int insertPosition = GetAttributeInsertPosition(parent, name, order);
                parent.EditNode.Attributes.Insert(insertPosition, attribute);
            }
        }

        /// <summary>
        /// Retrieves the position where we should insert the attribute.
        /// </summary>
        /// <param name="parent">The item on which adding an attribute is planned.</param>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="order">The order that the attributes should occur in according to the XSD.</param>
        /// <returns>The insert position of the attribute.</returns>
        private static int GetAttributeInsertPosition(IEditableNode parent, string name, string[] order)
        {
            var attributes = parent.EditNode.Attributes;
            int index = attributes.Count;

            int nameIndex = Array.IndexOf(order, name);
            if (nameIndex == -1)
            {
                // add after other attributes
                return index;
            }

            for (int i = 0; i < attributes.Count; i++)
            {
                if (Array.IndexOf(order, attributes[i].Name) > nameIndex)
                {
                    // insert before item with higher order index
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Removes an attribute from the xml.
        /// </summary>
        /// <param name="tagName">The name of attribute to remove.</param>
        /// <param name="editNode">The node on which an attribute should be removed.</param>
        private static void RemoveAttribute(XmlElement editNode, string tagName)
        {
            XmlAttribute attribute = editNode.Attribute[tagName];
            if (attribute != null)
            {
                editNode.Attributes.Remove(attribute);
            }
        }

        /// <summary>
        /// Assigns the value to the attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="value">The value to be assigned.</param>
        private static void SetAttribute(XmlAttribute attribute, string value)
        {
            attribute.Value = value;
        }

        #endregion
    }
}
