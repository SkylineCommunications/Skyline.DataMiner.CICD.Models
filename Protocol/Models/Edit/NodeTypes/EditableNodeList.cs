namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Skyline.DataMiner.CICD.Models.Protocol.Models.Custom_Classes;
    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    public abstract class EditableListNode<TReadList, VReadChild, UEditable> : EditableElementNode<TReadList>, IList<UEditable>
        where TReadList : IReadableList<VReadChild>
        where VReadChild : IReadable
        where UEditable : class, IEditableNode
    {

        private readonly TReadList readList;
        private readonly Lazy<List<UEditable>> children;

        #region Constructors

        protected EditableListNode(TReadList readableElement, IEditableNode parent, XmlElement editNode)
           : base(readableElement, parent, editNode)
        {
            this.readList = readableElement;
            children = new Lazy<List<UEditable>>(() => CreateChildInstances());
        }

        protected EditableListNode(string name)
            : base(name)
        {
            children = new Lazy<List<UEditable>>();
        }

        #endregion

        #region Public Methods

        public UEditable Get(VReadChild item)
        {
            XmlElement edit = GetExistingEdit(item.ReadNode);
            return children.Value.FirstOrDefault(e => e.EditNode == edit);
        }

        public void Remove(VReadChild item)
        {
            XmlElement edit = GetExistingEdit(item.ReadNode);
            UEditable editableNode = children.Value.First(e => e.EditNode == edit);

            if (editableNode != null)
            {
                Remove(editableNode);
            }
        }

        public void Clear()
        {
            children.Value.Clear();
            EditNode.Children.Clear();
        }

        public void InsertBefore(UEditable before, UEditable newItem)
        {
            int index = IndexOf(before);
            if (index >= 0)
            {
                Insert(index, newItem);
            }
        }

        public void InsertAfter(UEditable before, UEditable newItem)
        {
            int index = IndexOf(before) + 1;
            if (index >= 0)
            {
                Insert(index, newItem);
            }
        }

        public void Swap(UEditable itemOne, UEditable itemTwo)
        {
            PerformSwap(itemOne, itemTwo);
        }

        #endregion

        #region Private Methods

        private void PerformSwap(UEditable itemOne, UEditable itemTwo)
        {
            if (itemOne == null)
            {
                throw new ArgumentNullException("itemOne");
            }

            if (itemTwo == null)
            {
                throw new ArgumentNullException("itemOne");
            }

            int indexOne = children.Value.IndexOf(itemOne);
            if (indexOne == -1)
            {
                throw new ArgumentException("'ItemOne' is not present is not a child of the current node", "itemOne");
            }

            int indexTwo = children.Value.IndexOf(itemTwo);
            if (indexTwo == -1)
            {
                throw new ArgumentException("'ItemTwo' is not present is not a child of the current node", "itemTwo");
            }

            children.Value[indexOne] = itemTwo;
            children.Value[indexTwo] = itemOne;

            PerformEditSwap(itemOne.EditNode, itemTwo.EditNode);
        }

        private void PerformEditSwap(XmlElement itemOne, XmlElement itemTwo)
        {
            if (itemOne == null)
            {
                throw new ArgumentNullException("itemOne");
            }

            if (itemTwo == null)
            {
                throw new ArgumentNullException("itemTwo");
            }

            int indexOne = EditNode.Children.IndexOf(itemOne);
            int indexTwo = EditNode.Children.IndexOf(itemTwo);

            if (indexOne != -1 && indexTwo != -1)
            {
                XmlNode temp = EditNode.Children[indexOne];
                EditNode.Children[indexOne] = EditNode.Children[indexTwo];
                EditNode.Children[indexTwo] = temp;
            }

        }

        #endregion

        #region Protected Method

        protected List<UEditable> CreateChildInstances()
        {
            List<UEditable> children = new List<UEditable>();
            foreach (VReadChild child in readList)
            {
                XmlElement edit = GetExistingEdit(child.ReadNode);
                children.Add(CreateChild(edit, child));
            }
            return children;
        }

        protected virtual UEditable CreateChild(XmlElement edit, VReadChild read)
        {
            UEditable editable;

            editable = CreateChild(typeof(UEditable), edit, read);

            return editable;
        }

        protected UEditable CreateChild(Type type, XmlElement edit, VReadChild read)
        {
            UEditable editable;

            if (!ModelObjectActivator<VReadChild, IEditableNode, XmlElement, UEditable>.TryCreate(type, read, this, edit, out editable))
            {
                var availableConstructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                throw new InvalidOperationException("No matching constructor found in type '" + type + "'. Available constructors:\n"
                                                    + String.Join("\n", availableConstructors.Select(x => " - " + x)));
            }

            return editable;
        }

        #endregion

        #region List Methods

        public UEditable this[int index]
        {
            get
            {
                return children.Value[index];
            }
            set
            {
                UEditable current = children.Value[index];
                children.Value[index] = value;
                if (current != null)
                {
                    int currentIndex = EditNode.Children.IndexOf(current.EditNode);
                    EditNode.Children[currentIndex] = value.EditNode;
                }

            }
        }

        public int Count { get => children.Value.Count; }

        public bool IsReadOnly { get => false; }

        public int IndexOf(UEditable item)
        {
            return children.Value.IndexOf(item);
        }

        public void Insert(int index, UEditable item)
        {
            children.Value.Insert(index, item);

            // Insert at beginning
            if (index == 0)
            {
                EditNode.Children.Insert(0, item.EditNode);
            }
            // Insert at the end
            else if (index == children.Value.Count - 1)
            {
                EditNode.Children.Add(item.EditNode);
            }
            else
            {
                UEditable before = children.Value[index - 1];
                EditNode.Children.InsertAfter(before.EditNode, item.EditNode);
            }

            EditNode.Format();
        }

        public void RemoveAt(int index)
        {
            UEditable item = children.Value[index];
            children.Value.RemoveAt(index);

            if (item != null && EditNode.Children.Contains(item.EditNode))
            {
                EditNode.Children.Remove(item.EditNode);
                EditNode.Format();
            }
        }

        public bool Contains(UEditable item)
        {
            return children.Value.Contains(item);
        }

        public void CopyTo(UEditable[] array, int arrayIndex)
        {
            children.Value.CopyTo(array, arrayIndex);
        }

        public void Add(UEditable item)
        {

            EditNode.Children.Add(item.EditNode);
            EditNode.Format();

            children.Value.Add(item);
        }

        public bool Remove(UEditable item)
        {
            if (EditNode.Children.Contains(item.EditNode))
            {
                EditNode.Children.Remove(item.EditNode);
                EditNode.Format();
            }

            return children.Value.Remove(item);
        }

        public IEnumerator<UEditable> GetEnumerator()
        {
            return children.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return children.Value.GetEnumerator();
        }

        #endregion
    }
}
