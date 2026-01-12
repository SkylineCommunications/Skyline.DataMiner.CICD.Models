namespace Models.ProtocolTests.Read.Protocol.Parameters.Information
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Includes : ProtocolTestBase
    {

        [TestMethod]
        public void Includes_NoIncludesAvailable_ReturnsEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Information>
                                        <Includes>
                                        </Includes>
                                    </Information>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsEmpty(parameter.Information.Includes);
        }

        [TestMethod]
        public void Includes_IncludeTagAvailable_ReturnsIncludeList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Information>
                                        <Includes>
                                            <Include></Include>
                                            <Include></Include>
                                        </Includes>
                                    </Information>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.HasCount(2, parameter.Information.Includes);
        }

        [TestMethod]
        public void GetEnumerator_IncludeTagAvailable_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Information>
                                        <Includes>
                                            <Include></Include>
                                            <Include></Include>
                                        </Includes>
                                    </Information>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNotNull(parameter.Information.Includes.GetEnumerator());
        }

    }
}
