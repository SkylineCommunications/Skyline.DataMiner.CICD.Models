using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Parameters.Interprete.Exceptions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ExceptionDisplay : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void Value_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception id='1'>
                                                <Display>Test</Display>
                                            </Exception>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var exception = parameter.Interprete.Exceptions[0];

            // Assert
            Assert.AreEqual("Test", exception.Display.Value);
        }

        [TestMethod]
        public void Value_EmptyValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception id='1'>
                                                <Display></Display>
                                            </Exception>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var exception = parameter.Interprete.Exceptions[0];

            // Assert
            Assert.AreEqual(String.Empty, exception.Display.Value);
        }

        [TestMethod]
        public void Value_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception id='1'>
                                            </Exception>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var exception = parameter.Interprete.Exceptions[0];

            // Assert
            Assert.IsNull(exception.Display);
        }

        #endregion

        #region State

        [TestMethod]
        public void Value_Enabled_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception id='1'>
                                                <Display state='enabled'>Test</Display>
                                            </Exception>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var exception = parameter.Interprete.Exceptions[0];

            // Assert
            Assert.AreEqual(Enums.EnumDisplayState.Enabled, exception.Display.State.Value);
        }

        [TestMethod]
        public void Value_Disabled_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception id='1'>
                                                <Display state='disabled'>Test</Display>
                                            </Exception>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var exception = parameter.Interprete.Exceptions[0];

            // Assert
            Assert.AreEqual(Enums.EnumDisplayState.Disabled, exception.Display.State.Value);
        }

        [TestMethod]
        public void Value_InvalidStateValue_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception id='1'>
                                                <Display state='enled'>Test</Display>
                                            </Exception>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var exception = parameter.Interprete.Exceptions[0];

            // Assert
            Assert.IsNull(exception.Display.State.Value);
        }

        [TestMethod]
        public void Value_EmptyStateValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception id='1'>
                                                <Display state=''>Test</Display>
                                            </Exception>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var exception = parameter.Interprete.Exceptions[0];

            // Assert
            Assert.IsNull(exception.Display.State.Value);
        }

        [TestMethod]
        public void Value_MissingStateTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception id='1'>
                                                <Display>Test</Display>
                                            </Exception>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var exception = parameter.Interprete.Exceptions[0];

            // Assert
            Assert.IsNull(exception.Display.State);
        }

        #endregion

    }
}
