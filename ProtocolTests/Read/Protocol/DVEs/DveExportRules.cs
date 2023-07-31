namespace Models.ProtocolTests.Read.Protocol.DVEs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class DveExportRules : ProtocolTestBase
    {
        [TestMethod]
        public void ExportRules_NoAvailableExportRules_ReturnsEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>

                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(0, protocol.DVEs.ExportRules.Count);
        }

        [TestMethod]
        public void ExportRules_AvailableExportRules_ReturnsExportRulesList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule></ExportRule>
                                    <ExportRule></ExportRule>
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(2, protocol.DVEs.ExportRules.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableExportRules_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule></ExportRule>
                                    <ExportRule></ExportRule>
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.DVEs.ExportRules.GetEnumerator());
        }
    }
}