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
            Assert.AreEqual(0, protocol.Params.Count);
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
            Assert.AreEqual(2, protocol.Params.Count);
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
            Assert.AreNotEqual(null, protocol.Params.GetEnumerator());
        }

    }
}
