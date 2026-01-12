namespace Models.ProtocolTests.Read.Protocol.Commands
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class CommandParameter : ProtocolTestBase
    {
        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Content>
                                        <Param>10</Param>
                                    </Content>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var content = protocol.Commands[0].Content;

            // Assert
            Assert.AreEqual((uint?)10, content[0].Value);
        }

        [TestMethod]
        public void Value_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Content>
                                        <Param>ten</Param>
                                    </Content>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var content = protocol.Commands[0].Content;

            // Assert
            Assert.IsNull(content[0].Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Content>
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
            Assert.IsNull(content[0].Value);
        }
    }
}