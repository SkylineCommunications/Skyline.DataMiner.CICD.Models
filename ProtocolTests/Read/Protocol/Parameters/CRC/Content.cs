namespace Models.ProtocolTests.Read.Protocol.Parameters.CRC
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Content : ProtocolTestBase
    {
        #region Param

        [TestMethod]
        public void Param_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <CRC>
                                        <Content>
                                            <Param>10</Param>
                                        </Content>
                                    </CRC>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var param = parameter.CRC.Content[0];

            // Assert
            Assert.AreEqual((uint?)10, param.Value);
        }
        
        [TestMethod]
        public void Param_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <CRC>
                                        <Content>
                                            <Param>0.5</Param>
                                        </Content>
                                    </CRC>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var param = parameter.CRC.Content[0];

            // Assert
            Assert.IsNull(param.Value);
        }
               
        [TestMethod]
        public void Param_MinusOne_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <CRC>
                                        <Content>
                                            <Param>-1</Param>
                                        </Content>
                                    </CRC>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var param = parameter.CRC.Content[0];

            // Assert
            Assert.IsNull(param.Value);
        }

        [TestMethod]
        public void Param_EmptyValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <CRC>
                                        <Content>
                                            <Param></Param>
                                        </Content>
                                    </CRC>
                                </Param>
                            </Params>
                           </Protocol>";
            
            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var param = parameter.CRC.Content[0];

            // Assert
            Assert.IsNull(param.Value);
        }

        [TestMethod]
        public void GetEnumerator_ParamTagAvailable_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <CRC>
                                        <Content>
                                            <Param>
                                            </Param>
                                            <Param>
                                            </Param>
                                        </Content>
                                    </CRC>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNotNull(parameter.CRC.Content.GetEnumerator());
        }

        #endregion

        [TestMethod]
        public void Content_ParamTagAvailable_ReturnsListOfParams()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <CRC>
                                        <Content>
                                            <Param>
                                            </Param>
                                            <Param>
                                            </Param>
                                        </Content>
                                    </CRC>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.HasCount(2, parameter.CRC.Content);
        }
    }
}