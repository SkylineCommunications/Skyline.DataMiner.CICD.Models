namespace Models.ProtocolTests.Read.Protocol.Commands
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class CommandContent : ProtocolTestBase
    {
        [TestMethod]
        public void CommandContent_NoAvailableContent_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Content>
                                    </Content>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var content = protocol.Commands[0].Content;

            // Assert
            Assert.AreEqual(0, content.Count);
        }

        [TestMethod]
        public void CommandContent_AvailableContent_ReturnsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Content>
                                        <Param></Param>
                                        <Param></Param>
                                    </Content>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var content = protocol.Commands[0].Content;

            // Assert
            Assert.AreEqual(2, content.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableContent_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Content>
                                        <Param></Param>
                                        <Param></Param>
                                    </Content>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var content = protocol.Commands[0].Content;

            // Assert
            Assert.AreNotEqual(null, content.GetEnumerator());
        }

        [TestMethod]
        public void Indexer_AvailableContent_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Content>
                                        <Param></Param>
                                        <Param></Param>
                                    </Content>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var content = protocol.Commands[0].Content;

            // Assert
            Assert.AreNotEqual(null, content[0]);
        }
    }
}