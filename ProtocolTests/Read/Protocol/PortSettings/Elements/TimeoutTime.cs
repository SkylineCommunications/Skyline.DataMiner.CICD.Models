namespace Models.ProtocolTests.Read.Protocol.PortSettings.Elements
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TimeoutTime : ProtocolTestBase
    {

        #region DefaultValue

        [TestMethod]
        public void DefaultValue_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <TimeoutTime>
                                        <DefaultValue>0</DefaultValue>   
                                    </TimeoutTime>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var TimeoutTime = portSettings.TimeoutTime;

            // Assert
            Assert.AreEqual((uint?) 0, TimeoutTime.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <TimeoutTime>
                                        <DefaultValue>zero</DefaultValue>   
                                    </TimeoutTime>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var TimeoutTime = portSettings.TimeoutTime;

            // Assert
            Assert.IsNull(TimeoutTime.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <TimeoutTime>
                                        <DefaultValue></DefaultValue>   
                                    </TimeoutTime>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var TimeoutTime = portSettings.TimeoutTime;

            // Assert
            Assert.IsNull(TimeoutTime.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <TimeoutTime>  
                                    </TimeoutTime>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var TimeoutTime = portSettings.TimeoutTime;

            // Assert
            Assert.IsNull(TimeoutTime.DefaultValue);
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
                                    <TimeoutTime>
                                        <Disabled>true</Disabled>   
                                    </TimeoutTime>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var TimeoutTime = portSettings.TimeoutTime;

            // Assert
            Assert.IsTrue(TimeoutTime.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <TimeoutTime>
                                        <Disabled>tr</Disabled>   
                                    </TimeoutTime>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var TimeoutTime = portSettings.TimeoutTime;

            // Assert
            Assert.IsNull(TimeoutTime.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <TimeoutTime>
                                        <Disabled></Disabled>   
                                    </TimeoutTime>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var TimeoutTime = portSettings.TimeoutTime;

            // Assert
            Assert.IsNull(TimeoutTime.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <TimeoutTime>  
                                    </TimeoutTime>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];
            var TimeoutTime = portSettings.TimeoutTime;

            // Assert
            Assert.IsNull(TimeoutTime.Disabled);
        }

        #endregion

    }
}
