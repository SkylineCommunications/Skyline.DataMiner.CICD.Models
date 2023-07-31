namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;

    using Interfaces;

    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    public class ProtocolModelExport
    {
        public ProtocolModelExport(int tablePid, string name, XmlDocument document, IProtocolModel model)
        {
            TablePid = tablePid;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Document = document ?? throw new ArgumentNullException(nameof(document));
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public int TablePid { get; }
        public string Name { get; }
        public XmlDocument Document { get; }
        public IProtocolModel Model { get; }

        public IProtocol Protocol => Model.Protocol;
    }
}
