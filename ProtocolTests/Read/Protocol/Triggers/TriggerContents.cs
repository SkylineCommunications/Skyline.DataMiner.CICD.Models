namespace Models.ProtocolTests.Read.Protocol.Triggers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TriggerContents : ProtocolTestBase
    {

        [TestMethod]
        public void Contents_NoAvailableContent_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <Triggers>
                                     <Trigger>
                                          <Content>
                                          </Content>
                                     </Trigger>
                                </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITriggers triggers = protocol.Triggers;
            var trigger = triggers[0];
            var contents = trigger.Content;

            // Assert
            Assert.IsEmpty(contents);
        }

        [TestMethod]
        public void Contents_AvailableContent_ReturnActionCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <Triggers>
                                     <Trigger>
                                          <Content>
                                            <Id/>
                                            <Id/>
                                          </Content>
                                     </Trigger>
                                </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITriggers triggers = protocol.Triggers;
            var trigger = triggers[0];
            var contents = trigger.Content;

            // Assert
            Assert.HasCount(2, contents);
        }

        [TestMethod]
        public void GetEnumerator_AvailableContent_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <Triggers>
                                     <Trigger>
                                          <Content>
                                          </Content>
                                     </Trigger>
                                </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITriggers triggers = protocol.Triggers;
            var trigger = triggers[0];
            var contents = trigger.Content;

            // Assert
            Assert.IsNotNull(contents.GetEnumerator());
        }

    }
}
