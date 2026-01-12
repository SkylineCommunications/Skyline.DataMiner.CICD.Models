namespace Models.ProtocolTests.Read.Protocol.Parameters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Parameters : ProtocolTestBase
    {

        [TestMethod]
        public void Parameters_NoAvailableParameters_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsEmpty(protocol.Params);
        }

        [TestMethod]
        public void Parameters_AvailableParameters_ReturnParamsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param></Param>
                                <Param></Param>
                            </Params>
                           </Protocol>";


            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.HasCount(2, protocol.Params);
        }

        [TestMethod]
        public void GetEnumerator_AvailableParameters_ReturnEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param></Param>
                                <Param></Param>
                            </Params>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNotNull(protocol.Params.GetEnumerator());
        }

    }
}
