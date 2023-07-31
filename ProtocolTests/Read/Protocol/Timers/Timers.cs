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
            Assert.AreEqual(0, protocol.Timers.Count);
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
            Assert.AreEqual(2, protocol.Timers.Count);
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
            Assert.AreNotEqual(null, protocol.Timers.GetEnumerator());
        }
    }
}
