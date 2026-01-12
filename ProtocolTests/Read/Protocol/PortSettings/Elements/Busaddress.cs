namespace Models.ProtocolTests.Read.Protocol.PortSettings.Elements
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Busaddress : ProtocolTestBase
    {

        #region DefaultValue

        [TestMethod]
        public void DefaultValue_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Busaddress>
                                        <DefaultValue>Test</DefaultValue>   
                                    </Busaddress>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Busaddress = portSettings.BusAddress;

            // Assert
            Assert.AreEqual("Test", Busaddress.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Busaddress>
                                        <DefaultValue></DefaultValue>   
                                    </Busaddress>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Busaddress = portSettings.BusAddress;

            // Assert
            Assert.AreEqual(String.Empty, Busaddress.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Busaddress>  
                                    </Busaddress>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Busaddress = portSettings.BusAddress;

            // Assert
            Assert.IsNull(Busaddress.DefaultValue);
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
                                    <Busaddress>
                                        <Disabled>true</Disabled>   
                                    </Busaddress>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Busaddress = portSettings.BusAddress;

            // Assert
            Assert.IsTrue(Busaddress.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Busaddress>
                                        <Disabled>tr</Disabled>   
                                    </Busaddress>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Busaddress = portSettings.BusAddress;

            // Assert
            Assert.IsNull(Busaddress.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Busaddress>
                                        <Disabled></Disabled>   
                                    </Busaddress>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Busaddress = portSettings.BusAddress;

            // Assert
            Assert.IsNull(Busaddress.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Busaddress>  
                                    </Busaddress>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Busaddress = portSettings.BusAddress;

            // Assert
            Assert.IsNull(Busaddress.Disabled);
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
                                    <Busaddress>
                                        <Range></Range>       
                                    </Busaddress>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Busaddress = portSettings.BusAddress;
            var range = Busaddress.Range;

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
                                    <Busaddress>     
                                    </Busaddress>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Busaddress = portSettings.BusAddress;
            var range = Busaddress.Range;

            // Assert
            Assert.IsNull(range);
        }

        #endregion

    }
}
