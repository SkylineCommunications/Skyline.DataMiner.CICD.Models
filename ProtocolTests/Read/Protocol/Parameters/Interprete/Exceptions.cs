namespace Models.ProtocolTests.Read.Protocol.Parameters.Interprete
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ExceptionsTests : ProtocolTestBase
    {

        [TestMethod]
        public void Exceptions_NoAvailableExceptionTag_ReturnsEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsEmpty(parameter.Interprete.Exceptions);
        }

        [TestMethod]
        public void Exceptions_ExceptionTagsAvailabe_ReturnsExceptionList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception></Exception>
                                            <Exception></Exception>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.HasCount(2, parameter.Interprete.Exceptions);
        }

        [TestMethod]
        public void GetEnumerator_ExceptionTagsAvailabe_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions>
                                            <Exception></Exception>
                                            <Exception></Exception>
                                        </Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNotNull(parameter.Interprete.Exceptions.GetEnumerator());
        }


    }
}
