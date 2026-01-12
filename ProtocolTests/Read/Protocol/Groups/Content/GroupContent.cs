namespace Models.ProtocolTests.Read.Protocol.Groups.Content
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class GroupContent : ProtocolTestBase
    {

        #region Contents

        [TestMethod]
        public void GroupContent_NoContent_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Content></Content></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var contents = group.Content;

            // Assert
            Assert.IsEmpty(contents);
        }

        [TestMethod]
        public void GroupContent_Content_NoEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group>
                                    <Content>
                                        <Action></Action>
                                        <Pair></Pair>
                                        <Param></Param>
                                        <Session></Session>
                                        <Trigger></Trigger>
                                        <Fake></Fake>
                                    </Content>
                                </Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var contents = group.Content;

            // Assert
            Assert.HasCount(5, contents);
        }

        [TestMethod]
        public void GetEnumerator_Valid_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group>
                                    <Content>
                                        <Action></Action>
                                        <Pair></Pair>
                                        <Param></Param>
                                        <Session></Session>
                                        <Trigger></Trigger>
                                        <Fake></Fake>
                                    </Content>
                                </Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var contents = group.Content;

            // Assert
            Assert.IsNotNull(contents.GetEnumerator());
        }


        #endregion

    }
}
