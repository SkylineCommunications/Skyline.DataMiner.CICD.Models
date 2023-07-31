namespace Models.ProtocolTests.Read.Protocol.Commands
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Commands : ProtocolTestBase
    {
        [TestMethod]
        public void Commands_NoAvailableCommands_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(0, protocol.Commands.Count);
        }

        [TestMethod]
        public void Commands_AvailableCommands_ReturnsCommandsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command></Command>
                                <Command></Command>
                            </Commands>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(2, protocol.Commands.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableCommands_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command></Command>
                                <Command></Command>
                            </Commands>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Commands.GetEnumerator());
        }
    }
}