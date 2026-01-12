namespace Models.ProtocolTests.Edit.Protocol.QActions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QAction : ProtocolModelEditTestBase
    {
        #region SNMP

        [TestMethod]
        public void Code_ChangeValue_CorrectlySet()
        {
            string input = @"<Protocol>
                            <QActions>
                              <QAction>
                                  <![CDATA[using System;]]>
                              </QAction>
                            </QActions>
                           </Protocol>";

            string expected = @"<Protocol>
                            <QActions>
                              <QAction>
                                  <![CDATA[using System.Threading;]]>
                              </QAction>
                            </QActions>
                           </Protocol>";

            DoTest(
                input: input,
                action: m =>
                {
                    Assert.AreEqual("using System;", m.Protocol.QActions[0].Code);
                    m.Protocol.QActions[0].Code = "using System.Threading;";
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("using System.Threading;", m.Protocol.QActions[0].Code);
                    Assert.AreEqual(expected, o);
                }
            );
        }

        [TestMethod]
        public void Code_AssignNull_CorrectlySet()
        {
            string input = @"<Protocol>
                            <QActions>
                              <QAction>
                                  <![CDATA[using System;]]>
                              </QAction>
                            </QActions>
                           </Protocol>";

            string expected = @"<Protocol>
                            <QActions>
                              <QAction>
                              </QAction>
                            </QActions>
                           </Protocol>";

            DoTest(
                input: input,
                action: m =>
                {
                    Assert.AreEqual("using System;", m.Protocol.QActions[0].Code);
                    m.Protocol.QActions[0].Code = null;
                },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.QActions[0].Code);
                    Assert.AreEqual(expected, o);
                }
            );
        }

        [TestMethod]
        public void Code_AssignValue_CorrectlySet()
        {
            string input = @"<Protocol>
                            <QActions>
                              <QAction>
                              </QAction>
                            </QActions>
                           </Protocol>";

            string expected = @"<Protocol>
                            <QActions>
                              <QAction>
                              <![CDATA[using System;]]></QAction>
                            </QActions>
                           </Protocol>";

            DoTest(
                input: input,
                action: m =>
                {
                    Assert.IsNull(m.Protocol.QActions[0].Code);
                    m.Protocol.QActions[0].Code = "using System;";
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("using System;", m.Protocol.QActions[0].Code);
                    Assert.AreEqual(expected, o);
                }
            );
        }

        #endregion

    }
}
