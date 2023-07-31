namespace Models.ProtocolTests.Edit.Protocol.Groups
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Edit;

    [TestClass]
    public class Group : ProtocolModelEditTestBase
    {
        #region Group/Content/Param

        [TestMethod]
        public void ContentParam_ChangeValue_CorrectlySet()
        {
            DoTest(
                input:
                "<Protocol><Groups><Group><Content><Param>10:table</Param></Content></Group></Groups></Protocol>",
                action:
                m => ((GroupsGroupContentParam)m.Protocol.Groups[0].Content[0]).Value = "10:tablev2",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("10:tablev2", ((GroupsGroupContentParam)m.Protocol.Groups[0].Content[0]).Value);
                    Assert.AreEqual("<Protocol><Groups><Group><Content><Param>10:tablev2</Param></Content></Group></Groups></Protocol>", o);
                }
            );
        }

        #endregion
    }
}
