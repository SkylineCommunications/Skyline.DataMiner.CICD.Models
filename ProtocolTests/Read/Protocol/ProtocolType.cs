namespace Models.ProtocolTests.Read.Protocol
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

    [TestClass]
    public class ProtocolType : ProtocolTestBase
    {
        #region ProtocolType

        [TestMethod]
        public void Type_Gpib_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>gpib</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.Gpib, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_Http_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>http</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.Http, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_Opc_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.Opc, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_Serial_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>serial</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.Serial, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_SerialSingle_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>serial single</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.SerialSingle, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_Service_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>service</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.Service, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_Sla_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>sla</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.Sla, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_SmartSerial_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>smart-serial</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.SmartSerial, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_SmartSerialSingle_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>smart-serial single</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.SmartSerialSingle, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_Snmp_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>snmp</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.Snmp, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_Snmpv2_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>snmpv2</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.Snmpv2, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_Snmpv3_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>snmpv3</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.Snmpv3, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_Virtual_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type>virtual</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolType.Virtual, protocol.Type.Value);
        }

        [TestMethod]
        public void Type_InvalidProtocolType_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol><Type>op</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Type.Value);
        }

        [TestMethod]
        public void Type_EmptyProtocolType_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Type></Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Type.Value);
        }

        [TestMethod]
        public void Type_MissingProtocolType_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Type);
        }


        #endregion

        #region Attributes

        #region Relative Timers

        [TestMethod]
        public void RelativeTimers_True_ReturnsTrue()
        {
            // Arrange.
            string xml = @"<Protocol><Type relativeTimers='true'>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolTypeRelativeTimers.True, protocol.Type.RelativeTimers.Value);
        }

        [TestMethod]
        public void RelativeTimers_TrueWithReset_ReturnsTrue()
        {
            // Arrange.
            string xml = @"<Protocol><Type relativeTimers='true with reset'>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumProtocolTypeRelativeTimers.TrueWithReset, protocol.Type.RelativeTimers.Value);
        }

        [TestMethod]
        public void RelativeTimers_InvalidRelativeTimers_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol><Type relativeTimers='ue'>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Type.RelativeTimers.Value);
        }


        [TestMethod]
        public void RelativeTimers_EmptyRelativeTimers_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol><Type relativeTimers=''>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Type.RelativeTimers.Value);
        }
        [TestMethod]
        public void RelativeTimers_MissingRelativeTimers_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Type>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Type.RelativeTimers);
        }

        #endregion

        #region Override Timeout DVE

        [TestMethod]
        public void OverrideTimeoutDVE_ValidOverrideTimeoutDVE_ReturnsTrue()
        {
            // Arrange.
            string xml = @"<Protocol><Type overrideTimeoutDVE='true'>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsTrue(protocol.Type.OverrideTimeoutDVE.Value);
        }

        [TestMethod]
        public void OverrideTimeoutDVE_InvalidOverrideTimeoutDVE_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Type overrideTimeoutDVE='ue'>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Type.OverrideTimeoutDVE.Value);
        }

        [TestMethod]
        public void OverrideTimeoutDVE_EmptyOverrideTimeoutDVE_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Type overrideTimeoutDVE=''>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Type.OverrideTimeoutDVE.Value);
        }

        [TestMethod]
        public void OverrideTimeoutDVE_MissingOverrideTimeoutDVE_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Type>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Type.OverrideTimeoutDVE);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_ValidOptions_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Type options='unicode;disableViewRefresh'>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("unicode;disableViewRefresh", protocol.Type.Options.Value);
        }

        [TestMethod]
        public void Options_EmptyOptions_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Type options=''>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Type.Options.Value);
        }

        [TestMethod]
        public void Options_MissingOptions_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Type>opc</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Type.Options);
        }

        #endregion

        #endregion

        #region Methods

        #region GetOptions.ExportProtocols

        [TestMethod]
        public void ExportProtocols_TwoProtocols_TwoCorrectProtocols()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Type options='exportProtocol:MotherChildASlot:100:noElementPrefix;exportProtocol:MotherChildAOldName:150'>virtual</Type>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var result = protocol.Type.GetOptions().ExportProtocols.ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.HasCount(2, result);
            Assert.AreEqual("MotherChildASlot", result[0].Name);
            Assert.AreEqual((uint?)100, result[0].TablePid);
            Assert.IsTrue(result[0].NoElementPrefix);
            Assert.AreEqual("MotherChildAOldName", result[1].Name);
            Assert.AreEqual((uint?)150, result[1].TablePid);
            Assert.IsFalse(result[1].NoElementPrefix);
        }

        [TestMethod]
        public void ExportProtocols_InvalidProtocols_Something()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Type options='exportProtocol:MotherChildASlot::noElementPrefix;exportProtocol:MotherChildAOldName:'>virtual</Type>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var result = protocol.Type.GetOptions().ExportProtocols.ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.HasCount(2, result);
            Assert.AreEqual("MotherChildASlot", result[0].Name);
            Assert.IsNull(result[0].TablePid);
            Assert.IsTrue(result[0].NoElementPrefix);
            Assert.AreEqual("MotherChildAOldName", result[1].Name);
            Assert.IsNull(result[1].TablePid);
            Assert.IsFalse(result[1].NoElementPrefix);
        }

        #endregion

        #region GetOptions.Unicode

        [TestMethod]
        [DataRow("", false)]
        [DataRow("unicode", true)]
        public void Unicode_DifferentResults(string text, bool expectedResult)
        {
            // Arrange.
            string xml = "<Protocol><Type options='" + text + "'>virtual</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var result = protocol.Type.GetOptions().Unicode;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        #endregion

        #region GetAdvanced

        [TestMethod]
        public void GetAdvanced_ValidConnections_CorrectData()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Type advanced='smart-serial;http:HTTP Connection2'>virtual</Type>
    </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var result = protocol.Type.GetAdvanced();
            var connections = result?.Connections?.ToList();

            // Assert
            Assert.IsNotNull(connections);
            Assert.HasCount(2, connections);
            Assert.AreEqual(Enums.EnumProtocolType.SmartSerial, connections[0].Type.Value);
            Assert.IsNull(connections[0].Name);
            Assert.AreEqual(Enums.EnumProtocolType.Http, connections[1].Type.Value);
            Assert.AreEqual("HTTP Connection2", connections[1].Name);
        }

        [TestMethod]
        public void GetAdvanced_InvalidConnections_NullType()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Type advanced='smart-serial;:HTTP Connection2'>virtual</Type>
    </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var connections = protocol.Type.GetAdvanced()?.Connections?.ToList();

            // Assert
            Assert.IsNotNull(connections);
            Assert.HasCount(2, connections);
            Assert.AreEqual(Enums.EnumProtocolType.SmartSerial, connections[0].Type.Value);
            Assert.IsNull(connections[0].Name);
            Assert.IsNull(connections[1].Type);
            Assert.AreEqual("HTTP Connection2", connections[1].Name);
        }

        [TestMethod]
        public void GetAdvanced_EmptyAttribute_EmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Type advanced=''>virtual</Type>
    </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var result = protocol.Type.GetAdvanced()?.Connections?.ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [TestMethod]
        public void GetAdvanced_NoAttribute_EmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Type>virtual</Type>
    </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var result = protocol.Type.GetAdvanced();

            // Assert
            Assert.IsNull(result);
        }

        #endregion

        #endregion
    }
}

/*

        [TestMethod]
        public void METHOD_WHAT_OUTCOME()
        {
            // Arrange.
            string xml = @"";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
        }

     */
