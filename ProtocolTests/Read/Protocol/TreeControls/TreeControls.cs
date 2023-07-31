namespace Models.ProtocolTests.Read.Protocol.TreeControls
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TreeControls : ProtocolTestBase
    {

        [TestMethod]
        public void TreeControls_NoAvailableTreeControls_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                            </TreeControls>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(0, protocol.TreeControls.Count);
        }

        [TestMethod]
        public void TreeControls_AvailableTreeControls_ReturnCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl></TreeControl>
                                <TreeControl></TreeControl>
                            </TreeControls>
                           </Protocol>";


            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(2, protocol.TreeControls.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableTreeControls_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl></TreeControl>
                                <TreeControl></TreeControl>
                            </TreeControls>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.TreeControls.GetEnumerator());
        }

    }
}
