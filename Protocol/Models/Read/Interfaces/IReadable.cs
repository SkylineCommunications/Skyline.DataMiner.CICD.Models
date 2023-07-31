namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.ComponentModel;

    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    using Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces;

    public interface IReadable : INotifyPropertyChanged
    {
        string TagName { get; }

        XmlElement ReadNode { get; }

        XmlAttribute ReadAttribute { get; }

        IProtocolModel Model { get; }

        IReadable Parent { get; }

        T TryFindParent<T>() where T : IReadable;

        void Accept(ProtocolVisitor visitor);
    }
}