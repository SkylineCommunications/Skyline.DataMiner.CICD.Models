namespace Models.ProtocolTests.Edit.Protocol
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Edit;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;

    [TestClass]
    public class ProtocolSnmp : ProtocolModelEditTestBase
    {
        #region SNMP

        [TestMethod]
        public void SNMP_ChangeValue_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><SNMP>auto</SNMP></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(EnumSNMP.Auto, m.Protocol.SNMP.Value);
                    Assert.AreEqual("auto", m.Protocol.SNMP.RawValue);
                    m.Protocol.SNMP.Value = EnumSNMP.False;
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(EnumSNMP.False, m.Protocol.SNMP.Value);
                    Assert.AreEqual("false", m.Protocol.SNMP.RawValue);
                    Assert.AreEqual("<Protocol><SNMP>false</SNMP></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void SNMP_AssignNull_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><SNMP>auto</SNMP></Protocol>",
                action:
                    m =>
                    {
                        m.Protocol.SNMP = null;
                        m.Protocol.Cleanup(cleanupSelf: false);
                    },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.SNMP);
                    Assert.AreEqual("<Protocol />", o);
                }
            );
        }

        [TestMethod]
        public void SNMP_AssignValue_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol></Protocol>",
                action:
                    m => m.Protocol.SNMP = new SNMP(EnumSNMP.Auto),
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(EnumSNMP.Auto, m.Protocol.SNMP.Value);
                    Assert.AreEqual("auto", m.Protocol.SNMP.RawValue);
                    Assert.AreEqual("<Protocol>\r\n\t<SNMP>auto</SNMP>\r\n</Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void SNMP_ChangeRawValue1_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><SNMP>auto</SNMP></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(EnumSNMP.Auto, m.Protocol.SNMP.Value);
                    Assert.AreEqual("auto", m.Protocol.SNMP.RawValue);
                    m.Protocol.SNMP.RawValue = "false";
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(EnumSNMP.False, m.Protocol.SNMP.Value);
                    Assert.AreEqual("false", m.Protocol.SNMP.RawValue);
                    Assert.AreEqual("<Protocol><SNMP>false</SNMP></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void SNMP_ChangeRawValue2_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><SNMP>auto</SNMP></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(EnumSNMP.Auto, m.Protocol.SNMP.Value);
                    Assert.AreEqual("auto", m.Protocol.SNMP.RawValue);
                    m.Protocol.SNMP.RawValue = "test";
                },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.SNMP.Value);
                    Assert.AreEqual("test", m.Protocol.SNMP.RawValue);
                    Assert.AreEqual("<Protocol><SNMP>test</SNMP></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void SNMP_AssignRawValue_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol></Protocol>",
                action:
                    m =>
                    {
                        var x = new SNMP();
                        x.RawValue = "test";
                        m.Protocol.SNMP = x;
                    },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.SNMP.Value);
                    Assert.AreEqual("test", m.Protocol.SNMP.RawValue);
                    Assert.AreEqual("<Protocol>\r\n\t<SNMP>test</SNMP>\r\n</Protocol>", o);
                }
            );
        }

        #endregion
    }
}
