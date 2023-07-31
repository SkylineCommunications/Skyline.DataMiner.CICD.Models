namespace Protocol.Generator.XSD
{
    using System.Collections.Generic;

    internal class EnumList : List<EnumValue>
	{
		public string QualifiedName { get; set; }

		public string Name { get; set; }

		public string Documentation { get; set; }
    }
}
