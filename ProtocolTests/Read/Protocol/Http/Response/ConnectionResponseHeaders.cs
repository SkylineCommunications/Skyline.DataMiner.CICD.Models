namespace Models.ProtocolTests.Read.Protocol.Http.Response
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ConnectionResponseHeaders : ProtocolTestBase
    {

        [TestMethod]
        public void Header_NoAvailableHeaderTags_ReturnsEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                            <Headers></Headers>                
                                        </Response>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var response = connection.Response;
            var headers = response.Headers;

            // Assert
            Assert.AreEqual(0, headers.Count);
        }

        [TestMethod]
        public void Headers_AvailableHeaderTags_ReturnsList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                             <Headers>
                                                <Header></Header>
                                                <Header></Header>
                                             </Headers>
                                        </Response>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var response = connection.Response;
            var headers = response.Headers;

            // Assert
            Assert.AreEqual(2, headers.Count);
        }
        [TestMethod]
        public void GetEnumerators_AvailableHeaderTags_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                             <Headers>
                                                <Header></Header>
                                                <Header></Header>
                                             </Headers>
                                        </Response>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var response = connection.Response;
            var headers = response.Headers;

            // Assert
            Assert.AreNotEqual(null, headers.GetEnumerator());
        }


    }
}
