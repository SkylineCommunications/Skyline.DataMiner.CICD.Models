namespace Models.ProtocolTests.Read.Protocol.Parameters.Interprete.Exceptions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Exception : ProtocolTestBase
    {

        #region Id

        [TestMethod]
        public void Id_ValidIdValue_ReturnsCorrectValue()
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
            Assert.AreEqual((uint)1, exception.Id.Value);
        }

        [TestMethod]
        public void Id_InvalidIdValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception id='one'>
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
            Assert.IsNull(exception.Id.Value);
        }

        [TestMethod]
        public void Id_EmptyIdValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception id=''>
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
            Assert.IsNull(exception.Id.Value);
        }

        [TestMethod]
        public void Id_MissingIdTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception>
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
            Assert.IsNull(exception.Id);
        }

        #endregion

        #region Value Attribute


        [TestMethod]
        public void ValuAttribute_ValidAttributeValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception value='test'>
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
            Assert.AreEqual("test", exception.ValueAttribute.Value);
        }

        [TestMethod]
        public void ValuAttribute_EmptyAttributeValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception value=''>
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
            Assert.AreEqual(String.Empty, exception.ValueAttribute.Value);
        }

        [TestMethod]
        public void ValuAttribute_MissingAttributeValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception>
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
            Assert.IsNull(exception.ValueAttribute);
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
                                    <Interprete>
                                        <Exceptions>
                                            <Exception>
                                                <Value>test</Value>
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
            Assert.AreEqual("test", exception.ValueElement.Value);
        }

        [TestMethod]
        public void Value_Emptyalue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception>
                                                 <Value></Value>
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
            Assert.AreEqual(String.Empty, exception.ValueElement.Value);
        }

        [TestMethod]
        public void ValueAttribute_MissingValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception>
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
            Assert.IsNull(exception.ValueAttribute);
        }

        #endregion

        #region Display

        [TestMethod]
        public void Display_NoAvailableDisplayTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception>
                                                <Value>test</Value>
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

        [TestMethod]
        public void Display_AvailableDisplayTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception>
                                                <Value>test</Value>
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
            Assert.IsNotNull(exception.Display);
        }

        #endregion

    }
}
