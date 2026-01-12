namespace Models.ProtocolTests.Read.Protocol.Parameters.CRC
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class CRC : ProtocolTestBase
    {
        #region Content

        [TestMethod]
        public void Content_TagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Content></Content></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNotNull(parameter.CRC.Content);
        }

        [TestMethod]
        public void Content_TagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Content);
        }
        
        #endregion

        #region Type

        [TestMethod]
        public void Type_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <CRC>
                                        <Type>codan</Type>
                                    </CRC>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(EnumParamCRCType.Codan, parameter.CRC.Type.Value);
        }

        [TestMethod]
        public void Type_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <CRC>
                                        <Type>something</Type>
                                    </CRC>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Value);
        }

        [TestMethod]
        public void Type_EmptyValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <CRC>
                                        <Type></Type>
                                    </CRC>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Value);
        }

        [TestMethod]
        public void Type_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <CRC>                                      
                                    </CRC>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type);
        }

        #endregion
    }
}