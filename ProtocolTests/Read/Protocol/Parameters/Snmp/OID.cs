using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Parameters.Snmp
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class OID : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID>1.1.4.5.9</OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual("1.1.4.5.9", OID.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsEmpty()
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
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(String.Empty, OID.Value);
        }

        #endregion

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID id='1'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual((uint?)1, OID.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID id='test'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID id=''></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.Id.Value);
        }

        [TestMethod]
        public void Id_NoAvailableTag_ReturnsNull()
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
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.Id);
        }

        #endregion

        #region IPid

        [TestMethod]
        public void IPid_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID ipid='10'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual((uint?) 10, OID.Ipid.Value);
        }

        [TestMethod]
        public void IPid_Invalid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID ipid='ten'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.Ipid.Value);
        }

        [TestMethod]
        public void IPid_Empty_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID ipid=''></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.Ipid.Value);
        }

        [TestMethod]
        public void IPid_NoAvailableTag_ReturnsNull()
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
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.Ipid);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID options='Test'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual("Test", OID.Options.Value);
        }

        [TestMethod]
        public void Options_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID options=''></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(String.Empty, OID.Options.Value);
        }

        [TestMethod]
        public void Options_NoAvailableTag_ReturnsNull()
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
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.Options);
        }

        #endregion

        #region SkipDynamicSNMPGet

        [TestMethod]
        public void SkipDynamicSNMPGet_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID skipDynamicSNMPGet='true'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(true, OID.SkipDynamicSNMPGet.Value);
        }

        [TestMethod]
        public void SkipDynamicSNMPGet_Invalid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID skipDynamicSNMPGet='tue'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.SkipDynamicSNMPGet.Value);
        }

        [TestMethod]
        public void SkipDynamicSNMPGet_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID skipDynamicSNMPGet=''></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.SkipDynamicSNMPGet.Value);
        }

        [TestMethod]
        public void SkipDynamicSNMPGet_NoAvailableTag_ReturnsNull()
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
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.SkipDynamicSNMPGet);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_Auto_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID type='auto'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(Enums.EnumOIDType.Auto, OID.Type.Value);
        }

        [TestMethod]
        public void Type_Complete_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID type='complete'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(Enums.EnumOIDType.Complete, OID.Type.Value);
        }

        [TestMethod]
        public void Type_Wildcard_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID type='wildcard'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(Enums.EnumOIDType.Wildcard, OID.Type.Value);
        }

        [TestMethod]
        public void Type_Composed_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID type='composed'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(Enums.EnumOIDType.Composed, OID.Type.Value);
        }

        [TestMethod]
        public void Type_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID type=''></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.Type.Value);
        }

        [TestMethod]
        public void Type_InvalidValue_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <OID type='blabla'></OID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.Type.Value);
        }

        [TestMethod]
        public void Type_NoTagAvailable_ReturnsNull()
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
            var OID = param.SNMP.OID;

            // Assert
            Assert.AreEqual(null, OID.Type);
        }

        #endregion

    }
}
