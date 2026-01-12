using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Parameters.Snmp
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Snmp : ProtocolTestBase
    {

        #region Options

        [TestMethod]
        public void Options_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP options='Test'>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual("Test", snmp.Options.Value);
        }  

        [TestMethod]
        public void Options_Empty_ReturnsIsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP options=''>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(String.Empty, snmp.Options.Value);
        }

        [TestMethod]
        public void Options_NoTagAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.Options);
        }

        #endregion

        #region Enabled

        [TestMethod]
        public void Enabled_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Enabled>true</Enabled>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsTrue(snmp.Enabled.Value);
        }

        [TestMethod]
        public void Enabled_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Enabled>tue</Enabled>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.Enabled.Value);
        }


        [TestMethod]
        public void Enabled_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Enabled></Enabled>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.Enabled.Value);
        }

        [TestMethod]
        public void Enabled_NoTagAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.Enabled);
        }

        #endregion

        #region Factor

        [TestMethod]
        public void Factor_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Factor>2</Factor>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual((uint?)2, snmp.Factor.Value);
        }

        [TestMethod]
        public void Factor_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Factor>tue</Factor>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.Factor.Value);
        }


        [TestMethod]
        public void Factor_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Factor></Factor>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.Factor.Value);
        }

        [TestMethod]
        public void Factor_NoTagAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.Factor);
        }

        #endregion

        #region OID

        [TestMethod]
        public void OID_TagAvailable_ReturnsInstance()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNotNull(snmp.OID);
        }

        [TestMethod]
        public void OID_NoTagAvailable_ReturnsInstance()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.OID);
        }

        #endregion

        #region TrapOID

        [TestMethod]
        public void TrapOID_TagAvailable_ReturnsInstance()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNotNull(snmp.TrapOID);
        }

        [TestMethod]
        public void TrapOID_NoTagAvailable_ReturnsInstance()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.TrapOID);
        }

        #endregion

        #region TrapMappings

        [TestMethod]
        public void TrapMappings_TagAvailable_ReturnsInstance()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings></TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNotNull(snmp.TrapMappings);
        }

        [TestMethod]
        public void TrapMappings_NoTagAvailable_ReturnsInstance()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.TrapMappings);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_Counter32_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>counter32</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Counter32, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_Counter64_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>counter64</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Counter64, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_Counter64String_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>counter64String</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Counter64String, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_Gauage32_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>gauge32</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Gauge32, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_Integer_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>integer</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Integer, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_Integer32_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>integer32</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Integer32, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_IpAddress_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>ipaddress</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Ipaddress, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_NSAPAddress_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>nsapaddress</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Nsapaddress, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_Null_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>null</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Null, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_ObjectId_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>objectid</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Objectid, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_OctetString_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>octetstring</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Octetstring, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_OctetStringASCII_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>octetstringascii</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Octetstringascii, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_OctetStringHex_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>octetstringhex</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Octetstringhex, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_OctetStringUTF8_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>octetstringutf8</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Octetstringutf8, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_OctetStringDecimal_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>octetstringdecimal</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Octetstringdecimal, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_OID_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>oid</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Oid, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_Opaque_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>opaque</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Opaque, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_Timeticks_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>timeticks</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Timeticks, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_UInteger32_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>uinteger32</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.AreEqual(Enums.EnumSNMPType.Uinteger32, snmp.Type.Value);
        }

        [TestMethod]
        public void Type_InvalidValue_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type>opue</Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.Type.Value);
        }

        [TestMethod]
        public void Type_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <Type></Type>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.Type.Value);
        }

        [TestMethod]
        public void Type_NoTagAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var snmp = param.SNMP;

            // Assert
            Assert.IsNull(snmp.Type);
        }
        #endregion

    }
}
