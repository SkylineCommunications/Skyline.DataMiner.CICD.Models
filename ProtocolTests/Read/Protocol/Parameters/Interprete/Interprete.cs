using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Parameters.Interprete
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Interprete : ProtocolTestBase
    {

        #region RawType

        [TestMethod]
        public void RawType_Bcd_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <RawType>bcd</RawType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretRawType.Bcd, parameter.Interprete.RawType.Value);
        }

        [TestMethod]
        public void RawType_Double_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <RawType>double</RawType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretRawType.Double, parameter.Interprete.RawType.Value);
        }

        [TestMethod]
        public void RawType_NumericText_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <RawType>numeric text</RawType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretRawType.NumericText, parameter.Interprete.RawType.Value);
        }

        [TestMethod]
        public void RawType_OnlyOthers_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <RawType>only others</RawType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretRawType.OnlyOthers, parameter.Interprete.RawType.Value);
        }

        [TestMethod]
        public void RawType_Other_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <RawType>other</RawType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretRawType.Other, parameter.Interprete.RawType.Value);
        }

        [TestMethod]
        public void RawType_SignedNumber_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <RawType>signed number</RawType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretRawType.SignedNumber, parameter.Interprete.RawType.Value);
        }

        [TestMethod]
        public void RawType_Text_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <RawType>text</RawType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretRawType.Text, parameter.Interprete.RawType.Value);
        }

        [TestMethod]
        public void RawType_UnsignedNumber_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <RawType>unsigned number</RawType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretRawType.UnsignedNumber, parameter.Interprete.RawType.Value);
        }

        [TestMethod]
        public void RawType_InvalidRawTypeValue_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <RawType>stroble</RawType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.RawType.Value);
        }

        [TestMethod]
        public void RawType_EmptyRawTypeValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <RawType></RawType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.RawType.Value);
        }

        [TestMethod]
        public void RawType_MissingRawTypeTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.RawType);
        }

        #endregion

        #region LengthType

        [TestMethod]
        public void LengthType_Fixed_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <LengthType>fixed</LengthType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretLengthType.Fixed, parameter.Interprete.LengthType.Value);
        }


        [TestMethod]
        public void LengthType_LastNextParam_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <LengthType>last next param</LengthType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretLengthType.LastNextParam, parameter.Interprete.LengthType.Value);
        }


        [TestMethod]
        public void LengthType_NextParam_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <LengthType>next param</LengthType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretLengthType.NextParam, parameter.Interprete.LengthType.Value);
        }


        [TestMethod]
        public void LengthType_OtherParam_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <LengthType>other param</LengthType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretLengthType.OtherParam, parameter.Interprete.LengthType.Value);
        }

        [TestMethod]
        public void LengthType_InvalidLengthTypeValue_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <LengthType>stroble</LengthType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.LengthType.Value);
        }

        [TestMethod]
        public void LengthType_EmptyLengthTypeValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <LengthType></LengthType>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.LengthType.Value);
        }

        [TestMethod]
        public void LengthType_MissingLengthTypeTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.LengthType);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_String_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Type>string</Type>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretType.String, parameter.Interprete.Type.Value);
        }

        [TestMethod]
        public void Type_Double_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Type>double</Type>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretType.Double, parameter.Interprete.Type.Value);
        }

        [TestMethod]
        public void Type_HighNibble_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Type>high nibble</Type>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamInterpretType.HighNibble, parameter.Interprete.Type.Value);
        }

        [TestMethod]
        public void Type_InvalidTypeValue_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Type>strouble</Type>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.Type.Value);
        }

        [TestMethod]
        public void Type_EmptyTypeValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Type></Type>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.Type.Value);
        }

        [TestMethod]
        public void Type_MissingTypeTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.Type);
        }

        #endregion

        #region Default

        [TestMethod]
        public void Default_ValidDefaultValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <DefaultValue>Test</DefaultValue>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("Test", parameter.Interprete.DefaultValue.Value);
        }

        [TestMethod]
        public void Default_EmptyDefaultValue_ReturnsEmptyString()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <DefaultValue></DefaultValue>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Interprete.DefaultValue.Value);
        }

        [TestMethod]
        public void Default_MissingDefaultValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
   
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.DefaultValue);
        }

        #endregion

        #region Sequence

        [TestMethod]
        public void Sequence_ValidSequenceValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Sequence>Test</Sequence>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("Test", parameter.Interprete.Sequence.Value);
        }

        [TestMethod]
        public void Sequence_EmptySequenceValue_ReturnsEmptyString()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Sequence></Sequence>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Interprete.Sequence.Value);
        }

        [TestMethod]
        public void Sequence_MissingSequenceValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.Sequence);
        }

        #endregion

        #region Exceptions

        [TestMethod]
        public void Exceptions_AvailableExceptionsTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                        <Exceptions></Exceptions>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNotNull(parameter.Interprete.Exceptions);
        }

        [TestMethod]
        public void Exceptions_NoAvailableExceptionsTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Interprete>
                                    </Interprete>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Interprete.Exceptions);
        }

        #endregion

    }
}
