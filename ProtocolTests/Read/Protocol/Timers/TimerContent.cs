namespace Models.ProtocolTests.Read.Protocol.Timers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TimerContent : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void TimerContent_NoGroupsAvailable_ReturnsEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Content>
                                    </Content>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreEqual(0, timer.Content.Count);
        }

        [TestMethod]
        public void TimerContent_GroupsAvailable_ReturnsCorrectList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Content>
                                        <Group>1</Group>
                                        <Group>2</Group>
                                    </Content>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreEqual(2, timer.Content.Count);
        }

        [TestMethod]
        public void GetEnumerator_GroupsAvailable_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Content>
                                        <Group>1</Group>
                                        <Group>2</Group>
                                    </Content>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreNotEqual(null, timer.Content.GetEnumerator());
        }

        [TestMethod]
        public void Indexer_GroupsAvailable_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Content>
                                        <Group>1</Group>
                                        <Group>2</Group>
                                    </Content>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreNotEqual(null, timer.Content[0]);
        }


        #endregion

    }
}
