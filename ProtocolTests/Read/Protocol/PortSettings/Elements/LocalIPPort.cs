namespace Models.ProtocolTests.Read.Protocol.PortSettings.Elements
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class LocalIPPort : ProtocolTestBase
    {

        #region DefaultValue

        [TestMethod]
        public void DefaultValue_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <LocalIPport>
                                        <DefaultValue>0</DefaultValue>   
                                    </LocalIPport>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var LocalIPPort = portSettings.LocalIPport;

            // Assert
            Assert.AreEqual( 0u, LocalIPPort.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_InvalidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <LocalIPport>
                                        <DefaultValue>zero</DefaultValue>   
                                    </LocalIPport>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var LocalIPPort = portSettings.LocalIPport;

            // Assert
            Assert.IsNull(LocalIPPort.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <LocalIPport>
                                        <DefaultValue></DefaultValue>   
                                    </LocalIPport>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var LocalIPPort = portSettings.LocalIPport;

            // Assert
            Assert.IsNull(LocalIPPort.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <LocalIPport>  
                                    </LocalIPport>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var LocalIPPort = portSettings.LocalIPport;

            // Assert
            Assert.IsNull(LocalIPPort.DefaultValue);
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
                                    <LocalIPport>
                                        <Disabled>true</Disabled>   
                                    </LocalIPport>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var LocalIPPort = portSettings.LocalIPport;

            // Assert
            Assert.IsTrue(LocalIPPort.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <LocalIPport>
                                        <Disabled>tr</Disabled>   
                                    </LocalIPport>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var LocalIPPort = portSettings.LocalIPport;

            // Assert
            Assert.IsNull(LocalIPPort.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <LocalIPport>
                                        <Disabled></Disabled>   
                                    </LocalIPport>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var LocalIPPort = portSettings.LocalIPport;

            // Assert
            Assert.IsNull(LocalIPPort.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <LocalIPport>  
                                    </LocalIPport>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var LocalIPPort = portSettings.LocalIPport;

            // Assert
            Assert.IsNull(LocalIPPort.Disabled);
        }

        #endregion

    }
}
