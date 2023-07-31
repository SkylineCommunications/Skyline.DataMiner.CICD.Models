namespace Models.ProtocolTests.Read.Protocol.Http.Request
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ConnectionRequestParameters : ProtocolTestBase
    {

        [TestMethod]
        public void Parameters_NoAvailableHeaderTags_ReturnsEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                            <Parameters></Parameters>                
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
            var Parameters = request.Parameters;

            // Assert
            Assert.AreEqual(0, Parameters.Count);
        }

        [TestMethod]
        public void Parameters_AvailableHeaderTags_ReturnsList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection>
                                        <Request>
                                             <Parameters>
                                                <Parameter></Parameter>
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
            var Parameters = request.Parameters;

            // Assert
            Assert.AreEqual(2, Parameters.Count);
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
                                             <Parameters>
                                                <Parameter></Parameter>
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

            // Assert
            Assert.AreNotEqual(null, parameters.GetEnumerator());
        }

    }
}
