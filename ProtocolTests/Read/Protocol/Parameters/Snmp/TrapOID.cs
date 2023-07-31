using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Parameters.Snmp
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TrapOID : ProtocolTestBase
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
                                        <TrapOID>1.1.4.5.9</TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual("1.1.4.5.9", trapOID.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsEmpty()
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
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(String.Empty, trapOID.Value);
        }

        #endregion

        #region CheckBindings

        [TestMethod]
        public void CheckBindings_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID checkBindings='Test'></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual("Test", trapOID.CheckBindings.Value);
        }

        [TestMethod]
        public void CheckBindings_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID checkBindings=''></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(String.Empty, trapOID.CheckBindings.Value);
        }

        [TestMethod]
        public void CheckBindings_NoTagAvailable_ReturnsNull()
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
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(null, trapOID.CheckBindings);
        }

        #endregion

        #region Ipid

        [TestMethod]
        public void Ipid_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID ipid='Test'></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual("Test", trapOID.Ipid.Value);
        }

        [TestMethod]
        public void Ipid_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID ipid=''></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(String.Empty, trapOID.Ipid.Value);
        }

        [TestMethod]
        public void Ipid_NoTagAvailable_ReturnsNull()
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
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(null, trapOID.Ipid);
        }

        #endregion

        #region MapAlarm

        [TestMethod]
        public void MapAlarm_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID mapAlarm='Test'></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual("Test", trapOID.MapAlarm.Value);
        }

        [TestMethod]
        public void MapAlarm_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID mapAlarm=''></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(String.Empty, trapOID.MapAlarm.Value);
        }

        [TestMethod]
        public void MapAlarm_NoTagAvailable_ReturnsNull()
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
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(null, trapOID.MapAlarm);
        }

        #endregion

        #region SetBindings

        [TestMethod]
        public void SetBindings_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID setBindings='Test'></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual("Test", trapOID.SetBindings.Value);
        }

        [TestMethod]
        public void SetBindings_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID setBindings=''></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(String.Empty, trapOID.SetBindings.Value);
        }

        [TestMethod]
        public void SetBindings_NoTagAvailable_ReturnsNull()
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
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(null, trapOID.SetBindings);
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
                                        <TrapOID type='auto'></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(Enums.EnumTrapOIDType.Auto, trapOID.Type.Value);
        }

        [TestMethod]
        public void Type_Complete_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID type='complete'></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(Enums.EnumTrapOIDType.Complete, trapOID.Type.Value);
        }

        [TestMethod]
        public void Type_Wildcard_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID type='wildcard'></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(Enums.EnumTrapOIDType.Wildcard, trapOID.Type.Value);
        }

        [TestMethod]
        public void Type_Composed_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID type='composed'></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(Enums.EnumTrapOIDType.Composed, trapOID.Type.Value);
        }

        [TestMethod]
        public void Type_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID type=''></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(null, trapOID.Type.Value);
        }

        [TestMethod]
        public void Type_InvalidValue_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapOID type='blabla'></TrapOID>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(null, trapOID.Type.Value);
        }

        [TestMethod]
        public void Type_NoTagAvailable_ReturnsNull()
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
            var trapOID = param.SNMP.TrapOID;

            // Assert
            Assert.AreEqual(null, trapOID.Type);
        }

        #endregion

    }
}
