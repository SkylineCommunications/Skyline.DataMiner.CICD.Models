namespace Models.ProtocolTests.Read.Protocol.Responses
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ResponseContent : ProtocolTestBase
    {

        [TestMethod]
        public void ResponseContent_NoAvailableContent_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Content>
                                    </Content>
                                </Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var content = protocol.Responses[0].Content;

            // Assert
            Assert.AreEqual(0, content.Count);
        }

        [TestMethod]
        public void ResponseContent_AvailableContent_ReturnsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Content>
                                        <Param></Param>
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
            Assert.AreEqual(2, content.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableContent_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Content>
                                        <Param></Param>
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
            Assert.AreNotEqual(null, content.GetEnumerator());
        }

        [TestMethod]
        public void Indexer_AvailableContent_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Content>
                                        <Param></Param>
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
            Assert.AreNotEqual(null, content[0]);
        }



    }
}
