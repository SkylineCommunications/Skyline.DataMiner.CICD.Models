namespace Models.ProtocolTests.Read.Protocol.PortSettings.Elements
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class SetCommunity : ProtocolTestBase
    {

        #region DefaultValue

        [TestMethod]
        public void DefaultValue_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <SetCommunity>
                                        <DefaultValue>Test</DefaultValue>   
                                    </SetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var SetCommunity = portSettings.SetCommunity;

            // Assert
            Assert.AreEqual("Test", SetCommunity.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <SetCommunity>
                                        <DefaultValue></DefaultValue>   
                                    </SetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var SetCommunity = portSettings.SetCommunity;

            // Assert
            Assert.AreEqual(String.Empty, SetCommunity.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <SetCommunity>  
                                    </SetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var SetCommunity = portSettings.SetCommunity;

            // Assert
            Assert.AreEqual(null, SetCommunity.DefaultValue);
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
                                    <SetCommunity>
                                        <Disabled>true</Disabled>   
                                    </SetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var SetCommunity = portSettings.SetCommunity;

            // Assert
            Assert.AreEqual(true, SetCommunity.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <SetCommunity>
                                        <Disabled>tr</Disabled>   
                                    </SetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var SetCommunity = portSettings.SetCommunity;

            // Assert
            Assert.AreEqual(null, SetCommunity.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <SetCommunity>
                                        <Disabled></Disabled>   
                                    </SetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var SetCommunity = portSettings.SetCommunity;

            // Assert
            Assert.AreEqual(null, SetCommunity.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <SetCommunity>  
                                    </SetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var SetCommunity = portSettings.SetCommunity;

            // Assert
            Assert.AreEqual(null, SetCommunity.Disabled);
        }

        #endregion

    }
}
