namespace Protocol.Generator.XSD
{
    using System;

    internal class EnumValue
    {
        public string Name { get; private set; }

        public string Value { get; private set; }

        public string Documentation { get; set; }

        public EnumValue(string value)
        {
            string memberName = Tools.ToPascalCase(value).Trim();
            if (!String.IsNullOrWhiteSpace(memberName) && Char.IsNumber(memberName[0]))
            {
                memberName = "_" + memberName;
            }

            Name = memberName;
            Value = value;
        }
    }
}
