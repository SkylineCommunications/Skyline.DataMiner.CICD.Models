namespace Protocol.Generator.XSD
{
    using System.Xml.Schema;

    internal interface INode
	{
		ElementNode Parent { get;  }

		XmlSchemaType SchemaType { get; }

		string Name { get;  }

		string Path { get; }

		string Documentation { get; }
	}
}
