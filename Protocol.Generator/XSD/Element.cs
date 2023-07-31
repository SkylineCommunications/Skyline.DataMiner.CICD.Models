namespace Protocol.Generator.XSD
{
    using System.Xml.Schema;

    internal class Element : ElementNode
    {
        public XmlSchemaElement Definition { get; }

        public Element(ElementNode parent, XmlSchemaElement definition) : base(parent, definition.ElementSchemaType)
        {
            Definition = definition;
        }

        public bool IsCollectionItem
        {
            get
            {
                if (Definition.MaxOccurs > 1)
                {
                    return true;
                }

                return Definition.Parent is XmlSchemaGroupBase group && group.MaxOccurs > 1;
            }
        }
    }
}
