namespace Models.ProtocolTests.Read.Protocol.PortSettings.Elements
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class GetCommunity : ProtocolTestBase
    {

        #region DefaultValue

        [TestMethod]
        public void DefaultValue_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <GetCommunity>
                                        <DefaultValue>Test</DefaultValue>   
                                    </GetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var GetCommunity = portSettings.GetCommunity;

            // Assert
            Assert.AreEqual("Test", GetCommunity.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <GetCommunity>
                                        <DefaultValue></DefaultValue>   
                                    </GetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var GetCommunity = portSettings.GetCommunity;

            // Assert
            Assert.AreEqual(String.Empty, GetCommunity.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <GetCommunity>  
                                    </GetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var GetCommunity = portSettings.GetCommunity;

            // Assert
            Assert.IsNull(GetCommunity.DefaultValue);
        }

        #endregion

        #region Disabled

        [TestMethod]
        public void Disabled_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <GetCommunity>
                                        <Disabled>true</Disabled>   
                                    </GetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var GetCommunity = portSettings.GetCommunity;

            // Assert
            Assert.IsTrue(GetCommunity.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <GetCommunity>
                                        <Disabled>tr</Disabled>   
                                    </GetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var GetCommunity = portSettings.GetCommunity;

            // Assert
            Assert.IsNull(GetCommunity.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <GetCommunity>
                                        <Disabled></Disabled>   
                                    </GetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var GetCommunity = portSettings.GetCommunity;

            // Assert
            Assert.IsNull(GetCommunity.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <GetCommunity>  
                                    </GetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var GetCommunity = portSettings.GetCommunity;

            // Assert
            Assert.IsNull(GetCommunity.Disabled);
        }

        #endregion

    }
}
