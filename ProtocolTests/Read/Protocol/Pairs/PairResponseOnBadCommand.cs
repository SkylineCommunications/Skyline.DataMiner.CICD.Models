namespace Models.ProtocolTests.Read.Protocol.Pairs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ResponseOnBadCommandContent : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content>
                                        <ResponseOnBadCommand>1</ResponseOnBadCommand>
                                    </Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];
            var command = pair.Content[0];

            // Assert
            Assert.AreEqual((uint?)1, command.Value);
        }

        [TestMethod]
        public void Value_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content>
                                        <ResponseOnBadCommand>ten</ResponseOnBadCommand>
                                    </Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];
            var command = pair.Content[0];

            // Assert
            Assert.IsNull(command.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content>
                                        <ResponseOnBadCommand></ResponseOnBadCommand>
                                    </Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];
            var command = pair.Content[0];

            // Assert
            Assert.IsNull(command.Value);
        }

        #endregion

    }
}
