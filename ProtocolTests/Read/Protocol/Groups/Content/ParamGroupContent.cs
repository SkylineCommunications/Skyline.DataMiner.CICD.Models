namespace Models.ProtocolTests.Read.Protocol.Groups.Content
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ParamGroupContent : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group>
                                    <Content>
                                        <Param>1</Param>
                                    </Content>
                                </Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var contents = group.Content;
            var content = contents[0] as GroupsGroupContentParam;

            // Assert
            Assert.AreEqual("1", content.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group>
                                    <Content>
                                        <Param></Param>
                                    </Content>
                                </Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var contents = group.Content;
            var content = contents[0] as GroupsGroupContentParam;

            // Assert
            Assert.AreEqual("", content.Value);
        }

        #endregion

    }
}
