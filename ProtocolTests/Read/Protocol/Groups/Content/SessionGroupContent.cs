namespace Models.ProtocolTests.Read.Protocol.Groups.Content
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class SessionGroupContent : ProtocolTestBase
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
                                        <Session>1</Session>
                                    </Content>
                                </Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var contents = group.Content;
            var content = contents[0] as GroupsGroupContentSession;

            // Assert
            Assert.AreEqual((uint)1, content.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group>
                                    <Content>
                                        <Session></Session>
                                    </Content>
                                </Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var contents = group.Content;
            var content = contents[0] as GroupsGroupContentSession;

            // Assert
            Assert.AreEqual(null, content.Value);
        }

        #endregion

    }
}
