namespace Models.ProtocolTests.Custom_Classes.Protocol.Type
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class AdvancedConnectionTests
    {
        [TestMethod]
        public void AdvancedConnection_ValidValue_CorrectData()
        {
            // Arrange.
            string connection = "snmp:SNMP Connection";

            // Act.
            var result = new AdvancedConnection(1, connection);

            // Assert
            Assert.AreEqual("SNMP Connection", result.Name);
            Assert.AreEqual(EnumProtocolType.Snmp, result.Type);
            Assert.AreEqual((uint)1, result.ConnectionId);
        }

        [TestMethod]
        public void AdvancedConnection_EmptyName_EmptyName()
        {
            // Arrange.
            string connection = "snmp:";

            // Act.
            var result = new AdvancedConnection(1, connection);

            // Assert
            Assert.AreEqual(String.Empty, result.Name);
            Assert.AreEqual(EnumProtocolType.Snmp, result.Type);
            Assert.AreEqual((uint)1, result.ConnectionId);
        }

        [TestMethod]
        public void AdvancedConnection_EmptyTypeEmptyName_EmptyNameNullType()
        {
            // Arrange.
            string connection = ":";

            // Act.
            var result = new AdvancedConnection(1, connection);

            // Assert
            Assert.AreEqual(String.Empty, result.Name);
            Assert.IsNull(result.Type);
            Assert.AreEqual((uint)1, result.ConnectionId);
        }
    }
}