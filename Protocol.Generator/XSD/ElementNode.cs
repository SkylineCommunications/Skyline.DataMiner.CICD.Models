namespace Protocol.Generator.XSD
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Xml.Schema;

    internal abstract class ElementNode : INode
    {
        public ElementNode Parent { get; }

        public XmlSchemaType SchemaType { get; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string Documentation { get; set; }


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly List<Attribute> attributes = new List<Attribute>();
        public IList<Attribute> Attributes => attributes;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly List<Element> children = new List<Element>();
        public IList<Element> Elements => children;

        protected ElementNode(ElementNode parent, XmlSchemaType type)
        {
            Parent = parent;
            SchemaType = type;
        }

        public bool HasMixedContent => Attributes.Count > 0 || Elements.Count > 1;

        public bool HasMixedElementContent => Elements.Count > 1;

        public bool IsCollection
        {
            get { return Elements.Any(e => e.IsCollectionItem); }
        }

        public IEnumerable<ElementNode> Ancestors
        {
            get
            {
                Stack<ElementNode> stack = new Stack<ElementNode>();
                for (ElementNode node = this; node != null; node = node.Parent)
                {
                    stack.Push(node);
                }

                foreach (var node in stack)
                {
                    yield return node;
                }
            }
        }

        public IEnumerable<Element> GetCollectionItemElements()
        {
            foreach (var e in Elements)
            {
                if (e.IsCollectionItem)
                {
                    yield return e;
                }
            }
        }

        public override string ToString()
        {
            if (Attributes.Count > 0)
            {
                string attributeNames = String.Join("|", Attributes.Select(attribute => attribute.Name).ToArray());
                return $"{Name} [{attributeNames}]";
            }

            return $"{Name}";
        }
    }
}
