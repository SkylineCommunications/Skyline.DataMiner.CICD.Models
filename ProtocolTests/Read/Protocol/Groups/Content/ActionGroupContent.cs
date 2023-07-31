namespace Models.ProtocolTests.Read.Protocol.Groups.Content
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ActionGroupContent : ProtocolTestBase
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
                                        <Action>1</Action>
                                    </Content>
                                </Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var contents = group.Content;
            var content = contents[0] as GroupsGroupContentAction;

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
                                        <Action></Action>
                                    </Content>
                                </Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var contents = group.Content;
            var content = contents[0] as GroupsGroupContentAction;

            // Assert
            Assert.AreEqual("", content.Value);
        }

        #endregion

    }
}
