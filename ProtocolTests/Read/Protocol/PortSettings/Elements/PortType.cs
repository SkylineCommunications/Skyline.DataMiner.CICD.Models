using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.PortSettings.Elements
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class PortType : ProtocolTestBase
    {

        #region DefaultValue

        [TestMethod]
        public void DefaultValue_IP_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Type>
                                        <DefaultValue>ip</DefaultValue>   
                                    </Type>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Type = portSettings.Type;

            // Assert
            Assert.AreEqual(Enums.EnumPortTypes.Ip, Type.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_UDP_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Type>
                                        <DefaultValue>udp</DefaultValue>   
                                    </Type>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Type = portSettings.Type;

            // Assert
            Assert.AreEqual(Enums.EnumPortTypes.Udp, Type.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_Rs232_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Type>
                                        <DefaultValue>rs232</DefaultValue>   
                                    </Type>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Type = portSettings.Type;

            // Assert
            Assert.AreEqual(Enums.EnumPortTypes.Rs232, Type.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_InvalidValue_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Type>
                                        <DefaultValue>eded</DefaultValue>   
                                    </Type>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Type = portSettings.Type;

            // Assert
            Assert.IsNull(Type.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Type>
                                        <DefaultValue></DefaultValue>   
                                    </Type>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Type = portSettings.Type;

            // Assert
            Assert.IsNull(Type.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Type>  
                                    </Type>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var Type = portSettings.Type;

            // Assert
            Assert.IsNull(Type.DefaultValue);
        }

        #endregion

    }
}
