namespace Models.ProtocolTests.Read.Protocol.Triggers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Triggers : ProtocolTestBase
    {

        [TestMethod]
        public void Triggers_NoAvailableTriggers_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                            </Triggers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsEmpty(protocol.Triggers);
        }

        [TestMethod]
        public void Triggers_AvailableTriggers_ReturnTriggerCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger></Trigger>
                                <Trigger></Trigger>
                            </Triggers>
                           </Protocol>";


            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.HasCount(2, protocol.Triggers);
        }

        [TestMethod]
        public void GetEnumerator_AvailableTriggers_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger></Trigger>
                                <Trigger></Trigger>
                            </Triggers>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNotNull(protocol.Triggers.GetEnumerator());
        }

    }
}
