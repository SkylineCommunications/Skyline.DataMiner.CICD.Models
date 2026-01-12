namespace Models.ProtocolTests.Read.Protocol.Http
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class HTTP : ProtocolTestBase
    {

        [TestMethod]
        public void Http_NoAvailableSessions_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                            </HTTP>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsEmpty(protocol.HTTP);
        }

        [TestMethod]
        public void HTTP_AvailableSession_ReturnSessionCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session></Session>
                                <Session></Session>
                            </HTTP>
                           </Protocol>";


            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.HasCount(2, protocol.HTTP);
        }

        [TestMethod]
        public void GetEnumerator_AvailableSession_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session></Session>
                                <Session></Session>
                            </HTTP>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNotNull(protocol.HTTP.GetEnumerator());
        }
    }
}
