namespace Models.ProtocolTests.Read.Protocol.Http.Request
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ConnectionRequestData : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='GET'>
                                            <Data>Test</Data>
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
            var data = request.Data;

            // Assert
            Assert.AreEqual("Test", data.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='GET'>
                                            <Data></Data>
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
            var data = request.Data;

            // Assert
            Assert.AreEqual(String.Empty, data.Value);
        }

        [TestMethod]
        public void Value_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request verb='GET'>
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
            var data = request.Data;

            // Assert
            Assert.IsNull(data);
        }

        #endregion

    }
}
