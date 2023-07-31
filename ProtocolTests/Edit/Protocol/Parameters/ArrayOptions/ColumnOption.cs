namespace Models.ProtocolTests.Edit.Protocol.Parameters.ArrayOptions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Edit;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;

    [TestClass]
    public class ColumnOption : ProtocolModelEditTestBase
    {

        #region Type

        [TestMethod]
        public void Type_ChangeValue_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param><ArrayOptions><ColumnOption type=""retrieved"" /></ArrayOptions></Param></Params></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(EnumColumnOptionType.Retrieved, m.Protocol.Params[0].ArrayOptions[0].Type.Value);
                    Assert.AreEqual("retrieved", m.Protocol.Params[0].ArrayOptions[0].Type.RawValue);
                    m.Protocol.Params[0].ArrayOptions[0].Type.Value = EnumColumnOptionType.Custom;
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(EnumColumnOptionType.Custom, m.Protocol.Params[0].ArrayOptions[0].Type.Value);
                    Assert.AreEqual("custom", m.Protocol.Params[0].ArrayOptions[0].Type.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param><ArrayOptions><ColumnOption type=""custom"" /></ArrayOptions></Param></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Type_AssignNull_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param><ArrayOptions><ColumnOption type=""retrieved"" /></ArrayOptions></Param></Params></Protocol>",
                action:
                    m =>
                    {
                        m.Protocol.Params[0].ArrayOptions[0].Type = null;
                    },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(null, m.Protocol.Params[0].ArrayOptions[0].Type);
                    Assert.AreEqual(@"<Protocol><Params><Param><ArrayOptions><ColumnOption /></ArrayOptions></Param></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Type_AssignValue_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param><ArrayOptions><ColumnOption /></ArrayOptions></Param></Params></Protocol>",
                action:
                    m => m.Protocol.Params[0].ArrayOptions[0].Type = new TypeColumnOptionType(EnumColumnOptionType.Retrieved),
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(EnumColumnOptionType.Retrieved, m.Protocol.Params[0].ArrayOptions[0].Type.Value);
                    Assert.AreEqual("retrieved", m.Protocol.Params[0].ArrayOptions[0].Type.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param><ArrayOptions><ColumnOption type=""retrieved"" /></ArrayOptions></Param></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Type_ChangeRawValue1_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param><ArrayOptions><ColumnOption type=""retrieved"" /></ArrayOptions></Param></Params></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(EnumColumnOptionType.Retrieved, m.Protocol.Params[0].ArrayOptions[0].Type.Value);
                    Assert.AreEqual("retrieved", m.Protocol.Params[0].ArrayOptions[0].Type.RawValue);
                    m.Protocol.Params[0].ArrayOptions[0].Type.RawValue = "custom";
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(EnumColumnOptionType.Custom, m.Protocol.Params[0].ArrayOptions[0].Type.Value);
                    Assert.AreEqual("custom", m.Protocol.Params[0].ArrayOptions[0].Type.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param><ArrayOptions><ColumnOption type=""custom"" /></ArrayOptions></Param></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Type_ChangeRawValue2_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param><ArrayOptions><ColumnOption type=""retrieved"" /></ArrayOptions></Param></Params></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(EnumColumnOptionType.Retrieved, m.Protocol.Params[0].ArrayOptions[0].Type.Value);
                    Assert.AreEqual("retrieved", m.Protocol.Params[0].ArrayOptions[0].Type.RawValue);
                    m.Protocol.Params[0].ArrayOptions[0].Type.RawValue = "test";
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(null, m.Protocol.Params[0].ArrayOptions[0].Type.Value);
                    Assert.AreEqual("test", m.Protocol.Params[0].ArrayOptions[0].Type.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param><ArrayOptions><ColumnOption type=""test"" /></ArrayOptions></Param></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Type_AssignRawValue_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param><ArrayOptions><ColumnOption /></ArrayOptions></Param></Params></Protocol>",
                action:
                    m =>
                    {
                        var x = new TypeColumnOptionType();
                        x.RawValue = "test";
                        m.Protocol.Params[0].ArrayOptions[0].Type = x;
                    },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(null, m.Protocol.Params[0].ArrayOptions[0].Type.Value);
                    Assert.AreEqual("test", m.Protocol.Params[0].ArrayOptions[0].Type.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param><ArrayOptions><ColumnOption type=""test"" /></ArrayOptions></Param></Params></Protocol>", o);
                }
            );
        }

        #endregion



    }
}
