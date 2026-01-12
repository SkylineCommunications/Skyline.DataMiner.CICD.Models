namespace Models.ProtocolTests.Read.Protocol.DVEs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class DveProtocols : ProtocolTestBase
    {
        [TestMethod]
        public void DVEProtocols_NoAvailableDVEProtocols_ReturnsEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>

                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsEmpty(protocol.DVEs.DVEProtocols);
        }

        [TestMethod]
        public void DVEProtocols_AvailableDVEProtocols_ReturnsDVEProtocolsList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol></DVEProtocol>
                                    <DVEProtocol></DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.HasCount(2, protocol.DVEs.DVEProtocols);
        }

        [TestMethod]
        public void GetEnumerator_AvailableDVEProtocols_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol></DVEProtocol>
                                    <DVEProtocol></DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNotNull(protocol.DVEs.DVEProtocols.GetEnumerator());
        }
    }
}