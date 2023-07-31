namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;

    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal abstract class ProtocolListNode<T> : ElementTag, INotifyCollectionChanged, IList<T> where T : class, IProtocolTag
    {

        private readonly ObservableCollection<T> children = new ObservableCollection<T>();

        protected ProtocolListNode(ProtocolModel model, ProtocolTag parent, string tagName, IEnumerable<string> childTagNames)
            : base(model, parent, tagName)
        {
            ChildTagNames = childTagNames;
            children.CollectionChanged += ForwardEvent;
        }

        protected IEnumerable<string> ChildTagNames
        {
            get; private set;
        }


        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!initialLoad)
            {
                var handler = CollectionChanged;
                if (handler != null)
                {
                    CollectionChanged(this, e);
                }
            }
        }

        #region IList implementation

        public T this[int index]
        {
            get
            {
                return children[index];
            }
            set
            {
                children[index] = value;
            }
        }

        public int Count { get { return children.Count; } }

        public bool IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            children.Add(item);
        }

        public void Clear()
        {
            children.Clear();
        }

        public bool Contains(T item)
        {
            return children.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            children.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return children.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return children.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            children.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return children.Remove(item);
        }

        public void RemoveAt(int index)
        {
            children.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return children.GetEnumerator();
        }

        #endregion

        #region Protected Methods

        protected void ParseChildren()
        {
            var availableXmlNodes = new List<XmlElement>();
            foreach (string childTagName in ChildTagNames)
            {
                availableXmlNodes.AddRange(ReadNode.Elements[childTagName]);
            }

            if (availableXmlNodes.Count != 0)
            {

                int i = 0, j = 0;
                while (i < children.Count || j < availableXmlNodes.Count)
                {
                    T currentChild = i < children.Count ? children[i] : null;
                    var availableChild = j < availableXmlNodes.Count ? availableXmlNodes[i] : null;

                    // The read node is exactly the same
                    if (currentChild != null && currentChild.ReadNode == availableChild)
                    {
                        i++;
                        j++;
                    }
                    else if (currentChild != null && ElementWasDeleted(currentChild, j, availableXmlNodes))
                    {
                        Remove(currentChild);
                        protocolModel.NotifyRemoved(currentChild);
                    }
                    // Check if we need to update or create a new element
                    else if (availableChild != null)
                    {
                        var currentChildNode = currentChild?.ReadNode;

                        if (NodesHaveEqualTokens(currentChildNode, availableChild) || NodesAreSelfContainedWithSameName(currentChildNode, availableChild))
                        {
                            // this element itself has not changed, but something in its subtree has (or one of its attributes)
                            if (currentChild?.Update(availableChild, availableChild?.Name) == true)
                            {
                                protocolModel.NotifyUpdated(currentChild);
                            }
                        }
                        else
                        {
                            T newElement = TryCreateElement(availableChild);
                            if (newElement != null)
                            {
                                if (i >= children.Count)
                                {
                                    Add(newElement);
                                }
                                else
                                {
                                    Insert(i, newElement);
                                }
                                protocolModel.NotifyAdded(newElement);
                            }
                        }
                        i++;
                        j++;

                    }
                }
            }
            else
            {
                if (children.Count != 0)
                {
                    var copy = children.ToList();
                    Clear();
                    foreach (var c in copy)
                    {
                        protocolModel.NotifyRemoved(c);
                    }
                }
            }
        }

        protected abstract T TryCreateElement(XmlElement element);

        protected override void Parse(string notifyPropertyName)
        {
            ParseChildren();
        }

        #endregion

        #region Private Methods

        private static bool NodesHaveEqualTokens(XmlNode a, XmlNode b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            // check opening token
            if (a.Token == b.Token)
            {
                return true;
            }

            var ea = a as XmlElement;
            var eb = b as XmlElement;

            if (ea == null || eb == null || ea.TokenClose == null || eb.TokenClose == null)
            {
                return false;
            }

            // check closing token
            return (ea.Name == eb.Name && ea.TokenClose == eb.TokenClose);
        }

        private static bool NodesAreSelfContainedWithSameName(XmlNode a, XmlNode b)
        {
            if (a?.Token == null || b?.Token == null)
            {
                return false;
            }

            if (a.Token.TagType != ElementTagType.SelfContained || b.Token.TagType != ElementTagType.SelfContained)
            {
                return false;
            }

            return a.Token.ElementName == b.Token.ElementName;
        }

        private bool ElementWasDeleted(T element, int currentIndex, IList<XmlElement> availableElements)
        {
            for (int i = currentIndex; i < availableElements.Count; i++)
            {
                var availableElement = availableElements.ElementAt(i);
                var test = element.ReadNode;

                if (availableElement == test || NodesHaveEqualTokens(test, availableElement) || NodesAreSelfContainedWithSameName(test, availableElement))
                {
                    return false;
                }
            }

            return true;
        }

        private void ForwardEvent(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnCollectionChanged(e);
        }

        #endregion

    }
}
