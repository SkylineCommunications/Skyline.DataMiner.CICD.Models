namespace Models.ProtocolTests.Read.Protocol.PortSettings.Elements
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class PortTypeUDP : ProtocolTestBase
    {

        #region Disabled

        [TestMethod]
        public void Disabled_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <PortTypeUDP>
                                        <Disabled>true</Disabled>   
                                    </PortTypeUDP>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var PortTypeUDP = portSettings.PortTypeUDP;

            // Assert
            Assert.IsTrue(PortTypeUDP.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <PortTypeUDP>
                                        <Disabled>tr</Disabled>   
                                    </PortTypeUDP>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var PortTypeUDP = portSettings.PortTypeUDP;

            // Assert
            Assert.IsNull(PortTypeUDP.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <PortTypeUDP>
                                        <Disabled></Disabled>   
                                    </PortTypeUDP>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var PortTypeUDP = portSettings.PortTypeUDP;

            // Assert
            Assert.IsNull(PortTypeUDP.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <PortTypeUDP>  
                                    </PortTypeUDP>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var PortTypeUDP = portSettings.PortTypeUDP;

            // Assert
            Assert.IsNull(PortTypeUDP.Disabled);
        }

        #endregion

    }
}
