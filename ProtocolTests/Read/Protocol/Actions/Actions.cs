namespace Models.ProtocolTests.Read.Protocol.Actions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Actions : ProtocolTestBase
    {
        [TestMethod]
        public void Actions_NoAvailableActions_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                            </Actions>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(0, protocol.Actions.Count);
        }

        [TestMethod]
        public void Actions_AvailableActions_ReturnActionCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action></Action>
                                <Action></Action>
                            </Actions>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(2, protocol.Actions.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableActions_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action></Action>
                                <Action></Action>
                            </Actions>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Actions.GetEnumerator());
        }
    }
}