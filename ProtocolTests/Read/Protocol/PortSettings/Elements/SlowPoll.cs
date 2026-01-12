namespace Models.ProtocolTests.Read.Protocol.PortSettings.Elements
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class SlowPoll : ProtocolTestBase
    {

        #region DefaultValue

        [TestMethod]
        public void DefaultValue_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPoll>
                                        <DefaultValue>20</DefaultValue>   
                                    </SlowPoll>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPoll SlowPoll = portSettings.SlowPoll;

            // Assert
            Assert.AreEqual(20u, SlowPoll.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPoll>
                                        <DefaultValue>ten</DefaultValue>   
                                    </SlowPoll>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPoll SlowPoll = portSettings.SlowPoll;

            // Assert
            Assert.IsNull(SlowPoll.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPoll>  
                                    </SlowPoll>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPoll SlowPoll = portSettings.SlowPoll;

            // Assert
            Assert.IsNull(SlowPoll.DefaultValue);
        }

        #endregion

        #region Disabled

        [TestMethod]
        public void Disabled_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPoll>
                                        <Disabled>true</Disabled>   
                                    </SlowPoll>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPoll SlowPoll = portSettings.SlowPoll;

            // Assert
            Assert.IsTrue(SlowPoll.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPoll>
                                        <Disabled>tr</Disabled>   
                                    </SlowPoll>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPoll SlowPoll = portSettings.SlowPoll;

            // Assert
            Assert.IsNull(SlowPoll.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPoll>
                                        <Disabled></Disabled>   
                                    </SlowPoll>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPoll SlowPoll = portSettings.SlowPoll;

            // Assert
            Assert.IsNull(SlowPoll.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPoll>  
                                    </SlowPoll>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPoll SlowPoll = portSettings.SlowPoll;

            // Assert
            Assert.IsNull(SlowPoll.Disabled);
        }

        #endregion

    }
}
