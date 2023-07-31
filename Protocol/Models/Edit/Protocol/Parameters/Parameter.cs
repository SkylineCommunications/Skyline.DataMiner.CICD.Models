namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public partial class ParamsParam
    {
        static readonly string[] attributesOrder = new string[] { "id", "trending", "save", "export", "snmpSetAndGet" };
        static readonly string[] elementOrder = new string[] { "Name", "Description", "Type", "ArrayOptions", "Information", "Interprete", "SNMP", "Alarm", "Display", "Measurement" };

        public override string[] AttributesOrder => attributesOrder;
        public override string[] ElementOrder => elementOrder;
    }
}
