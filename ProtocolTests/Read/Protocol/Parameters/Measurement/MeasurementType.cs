using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Parameters.Measurement
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class MeasurementType : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void Value_Analog_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>analog</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Analog, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_Button_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>button</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Button, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_Chart_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>chart</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Chart, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_DigitalThreshold_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>digital threshold</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.DigitalThreshold, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_Discreet_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>discreet</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Discreet, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_InvalidValue_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>diseet</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_Matrix_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>matrix</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Matrix, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_Number_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>number</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Number, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_PageButton_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>pagebutton</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Pagebutton, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_Progress_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>progress</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Progress, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_String_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>string</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.String, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_Table_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>table</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Table, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_Title_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>title</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Title, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_ToggleButton_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>togglebutton</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamMeasurementType.Togglebutton, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_EmptyValue_ReturnsNull()
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
            Assert.AreEqual(null, parameter.Measurement.Type.Value);
        }

        [TestMethod]
        public void Value_MissingValue_ReturnsNull()
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

        #region Width

        [TestMethod]
        public void Width_ValidWidthValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type width='100'>discreet</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual((uint?)100, parameter.Measurement.Type.Width.Value);
        }

        [TestMethod]
        public void Width_InvalidWidthValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type width='hi'>discreet</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement.Type.Width.Value);
        }

        [TestMethod]
        public void Width_EmptyWidthValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type width=''>discreet</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement.Type.Width.Value);
        }

        [TestMethod]
        public void Width_MissingWidthTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>discreet</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement.Type.Width);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_ValidOptionsValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type options='custom=disableWrite:102=Moxa serial port 01'>discreet</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("custom=disableWrite:102=Moxa serial port 01", parameter.Measurement.Type.Options.Value);
        }

        [TestMethod]
        public void Options_EmptyOptionsValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type options=''>discreet</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Measurement.Type.Options.Value);
        }

        [TestMethod]
        public void Options_MissingOptionsTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Type>discreet</Type>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement.Type.Options);
        }

        #endregion

    }
}
