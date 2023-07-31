namespace Models.ProtocolTests.Read.Protocol
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ProtocolTag : ProtocolTestBase
    {
        [TestMethod]
        public void TryFindParent_ValidParentType_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Name></Name></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IValueTag<string> name = protocol.Name;

            IProtocol parent = name.TryFindParent<IProtocol>();

            // Assert
            Assert.AreEqual(protocol, parent);
        }

        [TestMethod]
        public void TryFindParent_InvalidParentType_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Name></Name></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IValueTag<string> name = protocol.Name;

            IParamsParam parent = name.TryFindParent<IParamsParam>();

            // Assert
            Assert.AreEqual(null, parent);
        }
    }
}
