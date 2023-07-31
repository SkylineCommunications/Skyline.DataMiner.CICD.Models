namespace Models.ProtocolTests.Read.Protocol.Responses
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ResponseParameter : ProtocolTestBase
    {

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Content>
                                        <Param>10</Param>
                                    </Content>
                                </Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var content = protocol.Responses[0].Content;

            // Assert
            Assert.AreEqual((uint?)10, content[0].Value);
        }

        [TestMethod]
        public void Value_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Content>
                                        <Param>ten</Param>
                                    </Content>
                                </Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var content = protocol.Responses[0].Content;

            // Assert
            Assert.AreEqual(null, content[0].Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Content>
                                        <Param></Param>
                                    </Content>
                                </Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var content = protocol.Responses[0].Content;

            // Assert
            Assert.AreEqual(null, content[0].Value);
        }
    }
}
