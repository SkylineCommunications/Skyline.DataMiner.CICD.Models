namespace Models.ProtocolTests.Edit.Protocol
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProtocolDisplay : ProtocolModelEditTestBase
    {
        #region DefaultPage

        [TestMethod]
        public void DefaultPage_ChangeValue_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><Display defaultPage=\"\" /></Protocol>",
                action:
                    m => m.Protocol.Display.DefaultPage = "Page1",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("Page1", m.Protocol.Display.DefaultPage.Value);
                    Assert.AreEqual("<Protocol><Display defaultPage=\"Page1\" /></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void DefaultPage_ChangeValueWithSpecialCharacters_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><Display defaultPage=\"\" /></Protocol>",
                action:
                    m => m.Protocol.Display.DefaultPage = "A & B",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("A & B", m.Protocol.Display.DefaultPage.Value);
                    Assert.AreEqual("<Protocol><Display defaultPage=\"A &amp; B\" /></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void DefaultPage_AssignNull_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><Display defaultPage=\"Page1\" /></Protocol>",
                action:
                    m =>
                    {
                        m.Protocol.Display.DefaultPage = null;
                        m.Protocol.Display.Cleanup(cleanupSelf: false);
                    },          
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.Display.DefaultPage);
                    Assert.AreEqual("<Protocol><Display /></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void DefaultPage_AssignValue_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><Display /></Protocol>",
                action:
                    m => m.Protocol.Display.DefaultPage = "Page1",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("Page1", m.Protocol.Display.DefaultPage.Value);
                    Assert.AreEqual("<Protocol><Display defaultPage=\"Page1\" /></Protocol>", o);
                }
            );
        }



        #endregion

    }
}
