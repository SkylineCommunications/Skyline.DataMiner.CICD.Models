namespace Models.ProtocolTests.Read.Protocol.Pairs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class PairContent : ProtocolTestBase
    {

        #region Contents

        [TestMethod]
        public void Content_NoAvailableContent_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content>
                                    </Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(0, pair.Content.Count);
        }

        [TestMethod]
        public void Content_AvailableContent_ReturnActionCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content>
                                        <Command/>
                                        <Response/>
                                    </Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(2, pair.Content.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableContent_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content>
                                    </Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreNotEqual(null, pair.Content.GetEnumerator());
        }

        [TestMethod]
        public void Indexer_AvailableContent_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content>
                                        <Command/>
                                        <Response/>
                                    </Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreNotEqual(null, pair.Content[0]);
        }

        #endregion

    }
}
