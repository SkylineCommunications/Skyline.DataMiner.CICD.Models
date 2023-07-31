using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.PortSettings.Elements
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class SlowPollBase : ProtocolTestBase
    {

        #region DefaultValue

        [TestMethod]
        public void DefaultValue_Number_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPollBase>
                                        <DefaultValue>number</DefaultValue>   
                                    </SlowPollBase>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPollBase SlowPollBase = portSettings.SlowPollBase;

            // Assert
            Assert.AreEqual(Enums.EnumTypePortSlowPollBase.Number, SlowPollBase.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_Time_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPollBase>
                                        <DefaultValue>time</DefaultValue>   
                                    </SlowPollBase>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPollBase SlowPollBase = portSettings.SlowPollBase;

            // Assert
            Assert.AreEqual(Enums.EnumTypePortSlowPollBase.Time, SlowPollBase.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPollBase>
                                        <DefaultValue></DefaultValue>   
                                    </SlowPollBase>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPollBase SlowPollBase = portSettings.SlowPollBase;

            // Assert
            Assert.AreEqual(null, SlowPollBase.DefaultValue.Value);
        }

        [TestMethod]
        public void DefaultValue_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPollBase>  
                                    </SlowPollBase>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPollBase SlowPollBase = portSettings.SlowPollBase;

            // Assert
            Assert.AreEqual(null, SlowPollBase.DefaultValue);
        }

        #endregion

        #region Disabled

        [TestMethod]
        public void Disabled_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPollBase>
                                        <Disabled>true</Disabled>   
                                    </SlowPollBase>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPollBase SlowPollBase = portSettings.SlowPollBase;

            // Assert
            Assert.AreEqual(true, SlowPollBase.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPollBase>
                                        <Disabled>tr</Disabled>   
                                    </SlowPollBase>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPollBase SlowPollBase = portSettings.SlowPollBase;

            // Assert
            Assert.AreEqual(null, SlowPollBase.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPollBase>
                                        <Disabled></Disabled>   
                                    </SlowPollBase>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPollBase SlowPollBase = portSettings.SlowPollBase;

            // Assert
            Assert.AreEqual(null, SlowPollBase.Disabled.Value);
        }

        [TestMethod]
        public void Disabled_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPollBase>  
                                    </SlowPollBase>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;
            ISlowPollBase SlowPollBase = portSettings.SlowPollBase;

            // Assert
            Assert.AreEqual(null, SlowPollBase.Disabled);
        }

        #endregion

    }
}
