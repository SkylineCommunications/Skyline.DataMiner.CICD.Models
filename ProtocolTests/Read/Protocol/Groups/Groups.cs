namespace Models.ProtocolTests.Read.Protocol.Groups
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Groups : ProtocolTestBase
    {

        [TestMethod]
        public void Groups_NoAvailableGroups_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                            </Groups>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(0, protocol.Groups.Count);
        }

        [TestMethod]
        public void Groups_AvailableGroups_ReturnGroupCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group></Group>
                                <Group></Group>
                            </Groups>
                           </Protocol>";


            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(2, protocol.Groups.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableGroups_ReturnEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group></Group>
                                <Group></Group>
                            </Groups>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Groups.GetEnumerator());
        }


    }
}
