namespace Skyline.DataMiner.CICD.Models.Protocol
{
    using System.Collections.Generic;
    using System.Text;

    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    internal static class QuickActionExtractor
    {
        public static List<IQActionsQAction> Extract(IProtocolModel model)
        {
            List<IQActionsQAction> sourceCode = new List<IQActionsQAction>();

            var allQActions = model?.Protocol?.QActions;

            if (allQActions != null)
            {
                foreach (var qAction in allQActions)
                {
                    if (qAction.Encoding?.Value == EnumQActionEncoding.Csharp)
                    {
                        sourceCode.Add(qAction);
                    }
                }
            }

            return sourceCode;
        }

        //public static (ProtocolModel, XmlDocument) ParseProtocol(string protocolCode)
        //{
        //    Parser parser = new Parser(new StringBuilder(protocolCode));

        //    return (new ProtocolModel(parser.Document), parser.Document);
        //}
    }
}
