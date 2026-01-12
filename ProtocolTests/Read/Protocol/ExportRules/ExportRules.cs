namespace Models.ProtocolTests.Read.Protocol.ExportRules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ExportRules : ProtocolTestBase
    {

        [TestMethod]
        public void ExportRules_NoAvailableExportRules_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                            </ExportRules>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsEmpty(protocol.ExportRules);
        }

        [TestMethod]
        public void ExportRules_AvailableExportRules_ReturnParamsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule></ExportRule>
                                <ExportRule></ExportRule>
                            </ExportRules>
                           </Protocol>";


            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.HasCount(2, protocol.ExportRules);
        }

        [TestMethod]
        public void GetEnumerator_AvailableExportRules_ReturnEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule></ExportRule>
                                <ExportRule></ExportRule>
                            </ExportRules>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNotNull(protocol.ExportRules.GetEnumerator());
        }

    }
}
