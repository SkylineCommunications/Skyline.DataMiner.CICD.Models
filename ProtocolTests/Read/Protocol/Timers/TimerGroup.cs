namespace Models.ProtocolTests.Read.Protocol.Timers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TimerGroup : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Content>
                                        <Group>10</Group>
                                    </Content>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var group = timer.Content[0];

            // Assert
            Assert.AreEqual("10", group.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Content>
                                        <Group></Group>
                                    </Content>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var group = timer.Content[0];

            // Assert
            Assert.AreEqual("", group.Value);
        }

        #endregion

    }
}
