namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using System;
    using System.Collections.Generic;

    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    public abstract class ComplexEditableListNode<TReadList, VReadChild, UEditable> : EditableListNode<TReadList, VReadChild, UEditable>
        where TReadList : IReadableList<VReadChild>
        where VReadChild : IReadable
        where UEditable : class, IEditableNode
    {

        private readonly Dictionary<string, Type> typeDictionary;

        #region Constructors

        protected ComplexEditableListNode(TReadList readableElement, IEditableNode parent, XmlElement editNode, Dictionary<string, Type> typeDictionary)
           : base(readableElement, parent, editNode)
        {
            this.typeDictionary = typeDictionary;
        }

        protected ComplexEditableListNode(string name, Dictionary<string, Type> typeDictionary)
            : base(name)
        {
            this.typeDictionary = typeDictionary;
        }

        #endregion

        protected override UEditable CreateChild(XmlElement edit, VReadChild read)
        {
            UEditable editable = null;

            if (typeDictionary.TryGetValue(read.TagName, out Type type)
                || typeDictionary.TryGetValue("", out type))
            {
                editable = CreateChild(type, edit, read);
            }

            return editable;
        }
    }
}
