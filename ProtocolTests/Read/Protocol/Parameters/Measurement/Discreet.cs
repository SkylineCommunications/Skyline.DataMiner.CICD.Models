namespace Models.ProtocolTests.Read.Protocol.Parameters.Measurement
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Discreet : ProtocolTestBase
    {

        #region Display

        [TestMethod]
        public void Display_ValidDisplayValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='10'>
                                            <Discreet>
                                                <Value>Value</Value>
                                                <Display>Display</Display>
                                            </Discreet>
                                        </Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var discreet = parameter.Measurement.Discreets[0];

            // Assert
            Assert.AreEqual("Display", discreet.Display.Value);
        }

        [TestMethod]
        public void Display_EmptyDisplayValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='10'>
                                            <Discreet>
                                                <Value>Value</Value>
                                                <Display></Display>
                                            </Discreet>
                                        </Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var discreet = parameter.Measurement.Discreets[0];

            // Assert
            Assert.AreEqual(String.Empty, discreet.Display.Value);
        }

        [TestMethod]
        public void Display_MissingDisplayTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='10'>
                                            <Discreet>
                                                <Value>Value</Value>
                                            </Discreet>
                                        </Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var discreet = parameter.Measurement.Discreets[0];

            // Assert
            Assert.IsNull(discreet.Display);
        }

        #endregion

        #region Value

        [TestMethod]
        public void Value_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='10'>
                                            <Discreet>
                                                <Value>Value</Value>
                                                <Display>Display</Display>
                                            </Discreet>
                                        </Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var discreet = parameter.Measurement.Discreets[0];

            // Assert
            Assert.AreEqual("Value", discreet.ValueElement.Value);
        }

        [TestMethod]
        public void Value_EmptyValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='10'>
                                            <Discreet>
                                                <Value></Value>
                                                <Display>Display</Display>
                                            </Discreet>
                                        </Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var discreet = parameter.Measurement.Discreets[0];

            // Assert
            Assert.AreEqual(String.Empty, discreet.ValueElement.Value);
        }

        [TestMethod]
        public void Value_MissingValueTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='10'>
                                            <Discreet>
                                            </Discreet>
                                        </Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var discreet = parameter.Measurement.Discreets[0];

            // Assert
            Assert.IsNull(discreet.ValueElement);
        }

        #endregion


    }
}
