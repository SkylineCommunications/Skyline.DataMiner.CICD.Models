namespace Protocol.Generator.XSD
{
    using System.Xml.Schema;

    internal class Attribute : INode
    {
        public ElementNode Parent { get; }

        public XmlSchemaAttribute Definition { get; }

        public XmlSchemaType SchemaType => Definition.AttributeSchemaType;

        public string Name { get; set; }

        public string Path { get; set; }

        public string Documentation { get; set; }

        public Attribute(ElementNode parent, XmlSchemaAttribute definition)
        {
            Parent = parent;
            Definition = definition;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
