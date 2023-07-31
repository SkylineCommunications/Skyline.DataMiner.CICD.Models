namespace Models.ProtocolTests.Read.Protocol.Relations
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Relations : ProtocolTestBase
    {

        [TestMethod]
        public void Relations_NoAvailableRelation_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                            </Relations>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(0, protocol.Relations.Count);
        }

        [TestMethod]
        public void Relations_AvailableRelations_ReturnActionCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation></Relation>
                                <Relation></Relation>
                            </Relations>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(2, protocol.Relations.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableRelations_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation></Relation>
                                <Relation></Relation>
                            </Relations>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Relations.GetEnumerator());
        }
    }
}
