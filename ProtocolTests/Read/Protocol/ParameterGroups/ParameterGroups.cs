namespace Models.ProtocolTests.Read.Protocol.ParameterGroups
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ParameterGroups : ProtocolTestBase
    {

        [TestMethod]
        public void ParameterGroups_NoAvailableGroups_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsEmpty(protocol.ParameterGroups);
        }

        [TestMethod]
        public void ParameterGroups_AvailableGroups_ReturnTriggerCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group></Group>
                                <Group></Group>
                            </ParameterGroups>
                           </Protocol>";


            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.HasCount(2, protocol.ParameterGroups);
        }

        [TestMethod]
        public void GetEnumerator_AvailableGroups_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group></Group>
                                <Group></Group>
                            </ParameterGroups>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNotNull(protocol.ParameterGroups.GetEnumerator());
        }

    }
}
