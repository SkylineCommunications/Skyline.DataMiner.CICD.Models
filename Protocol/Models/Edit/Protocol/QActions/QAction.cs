namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using System.Linq;

    using Skyline.DataMiner.CICD.Parsers.Common.XmlEdit;

    public partial class QActionsQAction
    {
        public string Code
        {
            get
            {
                var firstCData = EditNode?.Children.OfType<XmlCDATA>().FirstOrDefault();
                return firstCData?.InnerText;
            }
            set
            {
                if (value == null)
                {
                    foreach (var c in EditNode?.Children.OfType<XmlCDATA>().ToList())
                    {
                        EditNode?.Children.Remove(c);
                    }
                }
                else
                {
                    var firstCData = EditNode?.Children.OfType<XmlCDATA>().FirstOrDefault();
                    if (firstCData != null)
                    {
                        firstCData.InnerText = value;
                    }
                    else
                    {
                        firstCData = new XmlCDATA(value);
                        EditNode.Children.Add(firstCData);
                    }
                }
            }
        }
    }
}
