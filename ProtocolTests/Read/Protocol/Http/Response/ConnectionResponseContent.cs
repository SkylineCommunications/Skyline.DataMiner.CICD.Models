namespace Models.ProtocolTests.Read.Protocol.Http.Response
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ConnectionResponseContent : ProtocolTestBase
    {

        #region PID

        [TestMethod]
        public void PID_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                            <Content pid='400'></Content>
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
            var content = response.Content;

            // Assert
            Assert.AreEqual((uint?) 400, content.Pid.Value);
        }

        [TestMethod]
        public void PID_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                            <Content pid='ten'></Content>
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
            var content = response.Content;

            // Assert
            Assert.IsNull(content.Pid.Value);
        }

        [TestMethod]
        public void PID_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                            <Content pid=''></Content>
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
            var content = response.Content;

            // Assert
            Assert.IsNull(content.Pid.Value);
        }

        [TestMethod]
        public void PID_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Response>
                                            <Content></Content>
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
            var content = response.Content;

            // Assert
            Assert.IsNull(content.Pid);
        }

        #endregion


    }
}
