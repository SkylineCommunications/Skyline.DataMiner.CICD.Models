namespace Models.ProtocolTests.Read.Protocol.Http.Request
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ConnectionRequestParameter : ProtocolTestBase
    {

        #region Key

        [TestMethod]
        public void Key_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                            <Parameters>
                                                <Parameter key='test'></Parameter>
                                            </Parameters>                
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
            var parameters = request.Parameters;
            var parameter = parameters[0];

            // Assert
            Assert.AreEqual("test", parameter.Key.Value);
        }

        [TestMethod]
        public void Key_EmptyValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                            <Parameters>
                                                <Parameter key=''></Parameter>
                                            </Parameters>                
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
            var parameters = request.Parameters;
            var parameter = parameters[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Key.Value);
        }

        [TestMethod]
        public void Key_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                            <Parameters>
                                                <Parameter></Parameter>
                                            </Parameters>                
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
            var parameters = request.Parameters;
            var parameter = parameters[0];

            // Assert
            Assert.IsNull(parameter.Key);
        }

        #endregion

        #region Value

        [TestMethod]
        public void Value_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                            <Parameters>
                                                <Parameter>Test</Parameter>
                                            </Parameters>                
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
            var parameters = request.Parameters;
            var parameter = parameters[0];

            // Assert
            Assert.AreEqual("Test", parameter.Value);
        }

        [TestMethod]
        public void Value_EmptyValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                            <Parameters>
                                                <Parameter></Parameter>
                                            </Parameters>                
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
            var parameters = request.Parameters;
            var parameter = parameters[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Value);
        }

        #endregion

    }
}
