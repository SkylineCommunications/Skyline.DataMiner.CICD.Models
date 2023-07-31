namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public static class CombinedTagHandler
    {
        /// <summary>
        /// Verifies if the attribute is available. When the container of the handler is null, the attribute will be removed.
        /// When the container is different from null and the attribute doesn't exists in xml yet, it will be created.
        /// </summary>
        internal static void Assign(IEditableNode value, IEditableNode parent, string tagName)
        {
            if (value == null)
            {
                RemoveNode(tagName, parent);
            }
            else
            {
                XmlElement node = parent.EditNode.Element[tagName];
                if (node == null)
                {
                    CreateNewCombinedNode(value, parent);
                }
                else
                {
                    int position = parent.EditNode.Children.IndexOf(node);
                    parent.EditNode.Children[position] = value.EditNode;
                }

                // Creates white spaces in the subtree of the new edit node.
                value.EditNode.Format();
            }
        }

        #region Private methods

        /// <summary>
        /// Creates a new combined node based on the writable element.
        /// If the element order is specified, the node will be put in the correct position.
        /// Otherwise, it's appended to the back of the children list on that level.
        /// </summary>
        /// <param name="element">The writable element.</param>
        private static void CreateNewCombinedNode(IEditableNode element, IEditableNode parent)
        {
            var node = element.EditNode;

            var order = parent.ElementOrder;

            if (order == null)
            {
                parent.EditNode.Children.Add(node);
            }
            else
            {
                int insertPosition = ElementHandler.GetNodeInsertPosition(parent, element.TagName, order);
                parent.EditNode.Children.Insert(insertPosition, node);
            }

            node.Format();
        }

        /// <summary>
        /// Removes an XmlNode from the xml.
        /// </summary>
        /// <typeparam name="T">The type of values used in the entry.</typeparam>
        /// <param name="tagName">The name of the node to remove.</param>
        private static void RemoveNode(string tagName, IEditableNode parent)
        {
            XmlElement node = parent.EditNode.Element[tagName];
            if (node != null)
            {
                parent.EditNode.Children.Remove(node, removeEmptyLineBefore: true);
            }
        }

        #endregion
    }
}