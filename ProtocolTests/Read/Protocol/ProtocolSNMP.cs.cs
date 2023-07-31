using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ProtocolSNMP : ProtocolTestBase
    {

        #region SNMP Value

        [TestMethod]
        public void SNMP_Auto_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><SNMP>auto</SNMP></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumSNMP.Auto, protocol.SNMP.Value);
            Assert.AreEqual("auto", protocol.SNMP.RawValue);
        }

        [TestMethod]
        public void SNMP_False_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><SNMP>false</SNMP></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumSNMP.False, protocol.SNMP.Value);
            Assert.AreEqual("false", protocol.SNMP.RawValue);
        }

        [TestMethod]
        public void SNMP_InvalidProtocolSNMP_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol><SNMP>au</SNMP></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.SNMP.Value);
            Assert.AreEqual("au", protocol.SNMP.RawValue);

        }

        [TestMethod]
        public void SNMP_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><SNMP></SNMP></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.SNMP.Value);
            Assert.AreEqual("", protocol.SNMP.RawValue);

        }

        #endregion

        #region Include Pages

        [TestMethod]
        public void IncludePages_ValidIncludePages_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><SNMP includepages='true'>auto</SNMP></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(true, protocol.SNMP.Includepages.Value);
        }

        [TestMethod]
        public void IncludePages_InvalidIncludePages_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><SNMP includepages='ue'>auto</SNMP></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.SNMP.Includepages.Value);
        }

        [TestMethod]
        public void IncludePages_EmptyIncludePages_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><SNMP includepages='ue'>auto</SNMP></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.SNMP.Includepages.Value);
        }

        [TestMethod]
        public void IncludePages_MissingIncludePages_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><SNMP>auto</SNMP></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.SNMP.Includepages);
        }


        #endregion

    }
}
