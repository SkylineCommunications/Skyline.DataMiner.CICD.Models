namespace Models.ProtocolTests.Read.Protocol.PortSettings.Range
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class PortSettingsRange : ProtocolTestBase
    {

        #region From

        [TestMethod]
        public void From_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <Range><From>0</From></Range>       
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
            Assert.AreEqual((uint?) 0, range.From.Value);
        }

        [TestMethod]
        public void From_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <Range><From>zero</From></Range>       
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
            Assert.IsNull(range.From.Value);
        }

        [TestMethod]
        public void From_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <Range><From></From></Range>       
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
            Assert.IsNull(range.From.Value);
        }

        [TestMethod]
        public void From_MissingTag_IsNull()
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
            Assert.IsNull(range.From);
        }

        #endregion

        #region To

        [TestMethod]
        public void To_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <Range><To>0</To></Range>       
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
            Assert.AreEqual((uint?) 0, range.To.Value);
        }

        [TestMethod]
        public void To_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <Range><To>zero</To></Range>       
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
            Assert.IsNull(range.To.Value);
        }

        [TestMethod]
        public void To_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate>
                                        <Range><To></To></Range>       
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
            Assert.IsNull(range.To.Value);
        }

        [TestMethod]
        public void To_MissingTag_IsNull()
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
            Assert.IsNull(range.To);
        }


        #endregion

    }
}
