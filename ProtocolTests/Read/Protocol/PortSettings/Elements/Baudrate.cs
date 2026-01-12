namespace Models.ProtocolTests.Read.Protocol.PortSettings.Elements
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Baudrate : ProtocolTestBase
    {

        #region DefaultValue

        [TestMethod]
        public void DefaultValue_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <DefaultValue>0</DefaultValue>   
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;

            // Assert
            Assert.AreEqual((uint?) 0, baudrate.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <DefaultValue>zero</DefaultValue>   
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;

            // Assert
            Assert.IsNull(baudrate.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <DefaultValue></DefaultValue>   
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;

            // Assert
            Assert.IsNull(baudrate.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>  
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;

            // Assert
            Assert.IsNull(baudrate.DefaultValue);
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
                                    <Baudrate>
                                        <Disabled>true</Disabled>   
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;

            // Assert
            Assert.IsTrue(baudrate.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <Disabled>tr</Disabled>   
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;

            // Assert
            Assert.IsNull(baudrate.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <Disabled></Disabled>   
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;

            // Assert
            Assert.IsNull(baudrate.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>  
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;

            // Assert
            Assert.IsNull(baudrate.Disabled);
        }

        #endregion

        #region Value

     
        [TestMethod]
        public void Value_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <Value></Value>   
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;

            // Assert
            Assert.IsNull(baudrate.DefaultValue);
        }

        [TestMethod]
        public void Value_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>  
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;

            // Assert
            Assert.IsNull(baudrate.DefaultValue);
        }

        #endregion

        #region Range

        [TestMethod]
        public void Range_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <Range></Range>       
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;
            var range = baudrate.Range;

            // Assert
            Assert.IsNotNull(range);
        }

        [TestMethod]
        public void Range_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>     
                                    </Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var baudrate = portSettings.Baudrate;
            var range = baudrate.Range;

            // Assert
            Assert.IsNull(range);
        }

        #endregion

    }
}
