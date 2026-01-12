namespace Models.ProtocolTests.Read.Protocol.Http
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Connection : ProtocolTestBase
    {

        #region Id

        [TestMethod]
        public void Id_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection id='10'></Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.AreEqual((uint?) 10, connection.Id.Value);
        }

        [TestMethod]
        public void Id_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection id='ten'></Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.IsNull(connection.Id.Value);
        }

        [TestMethod]
        public void Id_EmptyValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection id=''></Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.IsNull(connection.Id.Value);
        }

        [TestMethod]
        public void Id_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection></Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.IsNull(connection.Id);

        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection name='Name'></Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.AreEqual("Name", connection.Name.Value);
        }

        [TestMethod]
        public void Name_EmptyValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection name=''></Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.AreEqual(String.Empty, connection.Name.Value);
        }

        [TestMethod]
        public void Name_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection></Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.IsNull(connection.Name);
        }

        #endregion

        #region Request

        [TestMethod]
        public void Request_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request></Request>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.IsNotNull(connection.Request);
        }

        [TestMethod]
        public void Request_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.IsNull(connection.Request);
        }

        #endregion

        #region Response

        [TestMethod]
        public void Response_AvailableTag_IsNotNull()
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

            // Assert
            Assert.IsNotNull(connection.Response);
        }

        [TestMethod]
        public void Response_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                    </Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.IsNull(connection.Response);
        }

        #endregion

    }
}
