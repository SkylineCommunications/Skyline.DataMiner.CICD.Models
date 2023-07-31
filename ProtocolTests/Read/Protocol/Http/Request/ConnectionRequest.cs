using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Http.Request
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ConnectionRequest : ProtocolTestBase
    {

        #region Verb

        [TestMethod]
        public void Verb_Copy_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='COPY'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.COPY, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Delete_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='DELETE'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.DELETE, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Get_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='GET'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.GET, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Head_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='HEAD'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.HEAD, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Lock_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='LOCK'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.LOCK, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Mkcol_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='MKCOL'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.MKCOL, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Options_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='OPTIONS'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.OPTIONS, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Patch_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='PATCH'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.PATCH, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Post_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='POST'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.POST, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Propfind_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='PROPFIND'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.PROPFIND, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Proppatch_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='PROPPATCH'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.PROPPATCH, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Put_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='PUT'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.PUT, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Trace_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='TRACE'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.TRACE, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Track_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='TRACK'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.TRACK, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Unlock_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='UNLOCK'></Request>
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

            // Assert
            Assert.AreEqual(Enums.EnumHttpRequestVerb.UNLOCK, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Invalid_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='GT'></Request>
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

            // Assert
            Assert.AreEqual(null, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb=''></Request>
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

            // Assert
            Assert.AreEqual(null, request.Verb.Value);
        }

        [TestMethod]
        public void Verb_MissingTag_IsNull()
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
            var request = connection.Request;

            // Assert
            Assert.AreEqual(null, request.Verb);
        }

        #endregion

        #region Url

        [TestMethod]
        public void Url_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request url='localhost'></Request>
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

            // Assert
            Assert.AreEqual("localhost", request.Url.Value);
        }

        [TestMethod]
        public void Url_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request url=''></Request>
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

            // Assert
            Assert.AreEqual(String.Empty, request.Url.Value);
        }

        [TestMethod]
        public void Url_MissingTag_IsNull()
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
            var request = connection.Request;

            // Assert
            Assert.AreEqual(null, request.Url);
        }

        #endregion

        #region Headers

        [TestMethod]
        public void Headers_NoAvailableTag_IsNull()
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
            var request = connection.Request;

            // Assert
            Assert.AreEqual(null, request.Headers);
        }


        [TestMethod]
        public void Headers_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request><Headers></Headers></Request>
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

            // Assert
            Assert.AreNotEqual(null, request.Headers);
        }

        #endregion

        #region Data

        [TestMethod]
        public void Data_NoAvailableTag_IsNull()
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
            var request = connection.Request;

            // Assert
            Assert.AreEqual(null, request.Data);
        }


        [TestMethod]
        public void Data_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request><Data></Data></Request>
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

            // Assert
            Assert.AreNotEqual(null, request.Data);
        }

        #endregion

        #region Parameters

        [TestMethod]
        public void Parameters_NoAvailableTag_IsNull()
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
            var request = connection.Request;

            // Assert
            Assert.AreEqual(null, request.Parameters);
        }


        [TestMethod]
        public void Parameters_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request><Parameters></Parameters></Request>
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

            // Assert
            Assert.AreNotEqual(null, request.Parameters);
        }

        #endregion

    }
}
