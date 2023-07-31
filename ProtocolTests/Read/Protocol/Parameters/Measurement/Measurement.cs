namespace Models.ProtocolTests.Read.Protocol.Parameters.Measurement
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Measurement : ProtocolTestBase
    {

        #region Type

        [TestMethod]
        public void Type_AvailableTypeTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type></Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Measurement.Type);
        }

        [TestMethod]
        public void Type_NoAvailableTypeTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement.Type);
        }

        #endregion

        #region Discreets

        [TestMethod]
        public void Discreets_AvailableDiscreetsTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets></Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Measurement.Discreets);
        }

        [TestMethod]
        public void Type_NoAvailableDiscreetsTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement.Discreets);
        }

        #endregion

    }
}
