namespace Models.ProtocolTests.Read.Protocol.Parameters.Display.Positions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Page : ProtocolTestBase
    {
        #region MeasType

        [TestMethod]
        public void MeasType_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Page measType='analog'></Page>
                                            </Position>
                                        </Positions>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(EnumParamMeasurementType.Analog, parameter.Display.Positions[0].Page.MeasType.Value);
        }

        [TestMethod]
        public void MeasType_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Page measType='something'></Page>
                                            </Position>
                                        </Positions>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Positions[0].Page.MeasType.Value);
        }

        [TestMethod]
        public void MeasType_EmptyValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Page measType=''></Page>
                                            </Position>
                                        </Positions>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Positions[0].Page.MeasType.Value);
        }

        [TestMethod]
        public void MeasType_MissingAttribute_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Page></Page>
                                            </Position>
                                        </Positions>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Positions[0].Page.MeasType);
        }

        #endregion
    }
}