namespace Protocol.Generator.XSD
{
    using System.Xml.Schema;

    internal class SchemaType : ElementNode
    {
        public XmlSchemaType Definition { get; }

        public SchemaType(XmlSchemaType definition) : base(null, definition)
        {
            Definition = definition;
        }
    }
}
