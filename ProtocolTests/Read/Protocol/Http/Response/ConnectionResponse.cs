namespace Models.ProtocolTests.Read.Protocol.Http.Response
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ConnectionResponse : ProtocolTestBase
    {

        #region StatusCode

        [TestMethod]
        public void StatusCode_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response statusCode='400'></Response>
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

            // Assert
            Assert.AreEqual((uint?)400, response.StatusCode.Value);
        }

        [TestMethod]
        public void StatusCode_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response statusCode='ten'></Response>
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

            // Assert
            Assert.IsNull(response.StatusCode.Value);
        }

        [TestMethod]
        public void StatusCode_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response statusCode=''></Response>
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

            // Assert
            Assert.IsNull(response.StatusCode.Value);
        }

        [TestMethod]
        public void StatusCode_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response></Response>
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

            // Assert
            Assert.IsNull(response.StatusCode);
        }

        #endregion

        #region Content

        [TestMethod]
        public void Content_TagAvailable_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response><Content></Content></Response>
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

            // Assert
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Content_TagNotAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response></Response>
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

            // Assert
            Assert.IsNull(response.Content);
        }

        #endregion

        #region Headers

        [TestMethod]
        public void Headers_TagAvailable_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response><Headers></Headers></Response>
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

            // Assert
            Assert.IsNotNull(response.Headers);
        }

        [TestMethod]
        public void Headers_TagNotAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response></Response>
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

            // Assert
            Assert.IsNull(response.Headers);
        }

        #endregion

    }
}
