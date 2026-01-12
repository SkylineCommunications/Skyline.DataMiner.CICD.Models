namespace Models.ProtocolTests.Read.Protocol.Http.Request
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ConnectionRequestHeaders : ProtocolTestBase
    {

        [TestMethod]
        public void Headers_NoAvailableHeaderTags_ReturnsEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                            <Headers></Headers>                
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var headers = request.Headers;

            // Assert
            Assert.IsEmpty(headers);
        }

        [TestMethod]
        public void Headers_AvailableHeaderTags_ReturnsList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                             <Headers>
                                                <Header></Header>
                                                <Header></Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var headers = request.Headers;

            // Assert
            Assert.HasCount(2, headers);
        }

        [TestMethod]
        public void GetEnumerator_AvailableHeaderTags_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                             <Headers>
                                                <Header></Header>
                                                <Header></Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var headers = request.Headers;

            // Assert
            Assert.IsNotNull(headers.GetEnumerator());
        }
    }
}
