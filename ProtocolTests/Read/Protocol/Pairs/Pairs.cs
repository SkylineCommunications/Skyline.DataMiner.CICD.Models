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
            Assert.IsEmpty(protocol.Pairs);
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
            Assert.HasCount(2, protocol.Pairs);
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
            Assert.IsNotNull(protocol.Pairs.GetEnumerator());
        }


    }
}
