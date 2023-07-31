namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public interface IEditableNode : IEditable
    {
        string TagName { get; }

        XmlElement EditNode { get; }

        string[] AttributesOrder { get; }

        string[] ElementOrder { get; }
    }
}
