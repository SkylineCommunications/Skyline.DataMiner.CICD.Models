namespace Models.ProtocolTests.Read.Protocol.Timers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Timers : ProtocolTestBase
    {

        [TestMethod]
        public void Timers_NoAvailableTimers_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                            </Timers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsEmpty(protocol.Timers);
        }

        [TestMethod]
        public void Timers_AvailableTimers_ReturnTimerCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer></Timer>
                                <Timer></Timer>
                            </Timers>
                           </Protocol>";


            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.HasCount(2, protocol.Timers);
        }

        [TestMethod]
        public void GetEnumerators_AvailableTimers_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer></Timer>
                                <Timer></Timer>
                            </Timers>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNotNull(protocol.Timers.GetEnumerator());
        }
    }
}
