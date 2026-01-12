namespace Models.ProtocolTests.Read.Protocol.Parameters.Display
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Display : ProtocolTestBase
    {
        #region RTDisplay

        [TestMethod]
        public void RTDisplay_ValidRTDisplayValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <RTDisplay>true</RTDisplay>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.Display.RTDisplay.Value);
        }

        [TestMethod]
        public void RTDisplay_InvalidRTDisplayValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <RTDisplay>tr</RTDisplay>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.RTDisplay.Value);
        }

        [TestMethod]
        public void RTDisplay_EmptyRTDisplayValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <RTDisplay></RTDisplay>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.RTDisplay.Value);
        }

        [TestMethod]
        public void RTDisplay_MissingRTDisplay_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.RTDisplay);
        }

        #endregion

        #region RTDisplay@onAppLevel

        [TestMethod]
        public void RTDisplay_onAppLevel_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <RTDisplay onAppLevel='true'></RTDisplay>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.Display.RTDisplay.OnAppLevel.Value);
        }

        [TestMethod]
        public void RTDisplay_onAppLevel_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <RTDisplay onAppLevel='tr'></RTDisplay>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.RTDisplay.OnAppLevel.Value);
        }

        [TestMethod]
        public void RTDisplay_onAppLevel_EmptyValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <RTDisplay onAppLevel=''></RTDisplay>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.RTDisplay.OnAppLevel.Value);
        }

        [TestMethod]
        public void RTDisplay_onAppLevel_MissingAttribute_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <RTDisplay></RTDisplay>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.RTDisplay.OnAppLevel);
        }

        #endregion

        #region Units

        [TestMethod]
        public void Units_ValidUnitsValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Units>s</Units>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("s", parameter.Display.Units.Value);
        }

        [TestMethod]
        public void Units_EmptyUnitsValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Units></Units>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Display.Units.Value);
        }

        [TestMethod]
        public void Units_MissingUnitsValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Units);
        }
        #endregion

        #region Decimals

        [TestMethod]
        public void Decimals_ValidDecialsValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Decimals>8</Decimals>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual((uint)8, parameter.Display.Decimals.Value);
        }

        [TestMethod]
        public void Decimals_InvalidDecialsValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Decimals>acht</Decimals>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Decimals.Value);
        }

        [TestMethod]
        public void Decimals_EmptyDecialsValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Decimals></Decimals>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Decimals.Value);
        }

        [TestMethod]
        public void Decimals_MissingDecialsTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Decimals);
        }

        #endregion

        #region Range

        [TestMethod]
        public void Range_AvailableRangeTag_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Range></Range>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNotNull(parameter.Display.Range);
        }

        [TestMethod]
        public void Range_NotAvailableRangeTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Range);
        }

        #endregion

        #region Positions

        [TestMethod]
        public void Positions_AvailablePositionsTag_ReturnsNotNull()
        {
            // ArPositions.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions></Positions>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNotNull(parameter.Display.Positions);
        }

        [TestMethod]
        public void Positions_NotAvailablePositionsTag_ReturnsNull()
        {
            // ArPositions.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Positions);
        }

        #endregion

        #region ParametersView

        [TestMethod]
        public void ParametersView_AvailableTag_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView></ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNotNull(parameter.Display.ParametersView);
        }

        [TestMethod]
        public void ParametersView_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.ParametersView);
        }

        #endregion

        #region Steps

        [TestMethod]
        public void Steps_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Steps>0.5</Steps>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual((decimal?)0.5, parameter.Display.Steps.Value);
        }

        [TestMethod]
        public void Steps_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Steps>acht</Steps>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Steps.Value);
        }

        [TestMethod]
        public void Steps_EmptyValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Steps></Steps>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Steps.Value);
        }

        [TestMethod]
        public void Steps_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Steps);
        }

        #endregion

        #region Trending

        [TestMethod]
        public void Trending_AvailableTag_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending></Trending>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNotNull(parameter.Display.Trending);
        }

        [TestMethod]
        public void Trending_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Trending);
        }

        #endregion
    }
}