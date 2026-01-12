namespace Models.ProtocolTests.Read.Protocol.Http.Response
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ConnectionResponseHeader : ProtocolTestBase
    {

        #region Key

        [TestMethod]
        public void Key_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                             <Headers>
                                                <Header key='A-IM'></Header>
                                             </Headers>
                                        </Response>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var Response = connection.Response;
            var header = Response.Headers[0];

            // Assert
            Assert.AreEqual("A-IM", header.Key.Value);
        }

        [TestMethod]
        public void Key_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                             <Headers>
                                                <Header key=''></Header>
                                             </Headers>
                                        </Response>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var Response = connection.Response;
            var header = Response.Headers[0];

            // Assert
            Assert.AreEqual("", header.Key.Value);
        }

        [TestMethod]
        public void Key_Missing_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                             <Headers>
                                                <Header></Header>
                                             </Headers>
                                        </Response>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var Response = connection.Response;
            var header = Response.Headers[0];

            // Assert
            Assert.IsNull(header.Key);
        }
        #endregion

        #region Pid

        [TestMethod]
        public void Pid_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                             <Headers>
                                                <Header pid='1'>Test</Header>
                                             </Headers>
                                        </Response>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var Response = connection.Response;
            var header = Response.Headers[0];

            // Assert
            Assert.AreEqual((uint?) 1, header.Pid.Value);
        }

        [TestMethod]
        public void Pid_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                             <Headers>
                                                <Header pid='one'></Header>
                                             </Headers>
                                        </Response>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var Response = connection.Response;
            var header = Response.Headers[0];

            // Assert
            Assert.IsNull(header.Pid.Value);
        }

        [TestMethod]
        public void Pid_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                             <Headers>
                                                <Header pid=''></Header>
                                             </Headers>
                                        </Response>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var Response = connection.Response;
            var header = Response.Headers[0];

            // Assert
            Assert.IsNull(header.Pid.Value);
        }

        [TestMethod]
        public void Pid_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                             <Headers>
                                                <Header></Header>
                                             </Headers>
                                        </Response>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var Response = connection.Response;
            var header = Response.Headers[0];

            // Assert
            Assert.IsNull(header.Pid);
        }

        #endregion
    }
}
