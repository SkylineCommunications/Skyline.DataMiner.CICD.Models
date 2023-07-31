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
            Assert.AreEqual(0, parameter.Interprete.Exceptions.Count);
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
            Assert.AreEqual(2, parameter.Interprete.Exceptions.Count);
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
            Assert.AreNotEqual(null, parameter.Interprete.Exceptions.GetEnumerator());
        }


    }
}
