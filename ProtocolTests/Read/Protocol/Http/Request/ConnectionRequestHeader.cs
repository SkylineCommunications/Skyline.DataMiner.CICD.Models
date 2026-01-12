namespace Models.ProtocolTests.Read.Protocol.Http.Request
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ConnectionRequestHeader : ProtocolTestBase
    {

        #region Verb

        [TestMethod]
        public void Verb_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                             <Headers>
                                                <Header>Test</Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var header = request.Headers[0];

            // Assert
            Assert.AreEqual("Test", header.Value);
        }

        [TestMethod]
        public void Verb_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                             <Headers>
                                                <Header></Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var header = request.Headers[0];

            // Assert
            Assert.AreEqual(String.Empty, header.Value);
        }

        #endregion

        #region Key

        [TestMethod]
        public void Key_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                             <Headers>
                                                <Header key='X-Wap-Profile'></Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var header = request.Headers[0];

            // Assert
            Assert.AreEqual("X-Wap-Profile", header.Key.Value);
        }

        [TestMethod]
        public void Key_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                             <Headers>
                                                <Header key=''></Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var header = request.Headers[0];

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
                                        <Request>
                                             <Headers>
                                                <Header></Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var header = request.Headers[0];

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
                                        <Request>
                                             <Headers>
                                                <Header pid='10'>Test</Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var header = request.Headers[0];

            // Assert
            Assert.AreEqual((uint?) 10, header.Pid.Value);
        }

        [TestMethod]
        public void Pid_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                             <Headers>
                                                <Header pid='ten'>Test</Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var header = request.Headers[0];

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
                                        <Request>
                                             <Headers>
                                                <Header pid=''>Test</Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var header = request.Headers[0];

            // Assert
            Assert.IsNull(header.Pid.Value);
        }

        [TestMethod]
        public void Pid_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                             <Headers>
                                                <Header>Test</Header>
                                             </Headers>
                                        </Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];
            var request = connection.Request;
            var header = request.Headers[0];

            // Assert
            Assert.IsNull(header.Pid);
        }
        #endregion

    }
}
