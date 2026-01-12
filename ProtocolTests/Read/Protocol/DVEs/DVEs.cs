namespace Models.ProtocolTests.Read.Protocol.DVEs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Dves : ProtocolTestBase
    {
        [TestMethod]
        public void DVEs_DVEProtocols_TagAvailable()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols></DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNotNull(protocol.DVEs.DVEProtocols);
        }

        [TestMethod]
        public void DVEs_DVEProtocols_NoTagAvailable()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.DVEs.DVEProtocols);
        }

        [TestMethod]
        public void DVEs_ExportRules_TagAvailable()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules></ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNotNull(protocol.DVEs.ExportRules);
        }

        [TestMethod]
        public void DVEs_ExportRules_NoTagAvailable()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.DVEs.ExportRules);
        }
    }
}