namespace Models.ProtocolTests.Read.Protocol.Pairs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Pairs : ProtocolTestBase
    {

        [TestMethod]
        public void Pairs_NoAvailablePairs_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(0, protocol.Pairs.Count);
        }

        [TestMethod]
        public void Pairs_AvailablePairs_ReturnsPairsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair></Pair>
                                <Pair></Pair>
                            </Pairs>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(2, protocol.Pairs.Count);
        }

        [TestMethod]
        public void GetEnumerators_AvailablePairs_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair></Pair>
                                <Pair></Pair>
                            </Pairs>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Pairs.GetEnumerator());
        }


    }
}
