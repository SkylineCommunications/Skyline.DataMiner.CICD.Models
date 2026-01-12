namespace Models.ProtocolTests.Edit.Protocol.Parameters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Edit;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;

    [TestClass]
    public class Param : ProtocolModelEditTestBase
    {
        #region Id

        [TestMethod]
        public void Id_ChangeValue_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param id=""10"" /></Params></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(10u, m.Protocol.Params[0].Id.Value);
                    Assert.AreEqual("10", m.Protocol.Params[0].Id.RawValue);
                    m.Protocol.Params[0].Id.Value = 11;
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(11u, m.Protocol.Params[0].Id.Value);
                    Assert.AreEqual("11", m.Protocol.Params[0].Id.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param id=""11"" /></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Id_AssignNull_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param id=""10"" /></Params></Protocol>",
                action:
                    m =>
                    {
                        m.Protocol.Params[0].Id = null;
                    },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.Params[0].Id);
                    Assert.AreEqual(@"<Protocol><Params><Param /></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Id_AssignValue_CorrectlySet()
        {
            DoTest(
                input:
                @"<Protocol><Params><Param></Param></Params></Protocol>",
                action:
                m => m.Protocol.Params[0].Id = 10,
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(10u, m.Protocol.Params[0].Id.Value);
                    Assert.AreEqual("10", m.Protocol.Params[0].Id.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param id=""10"" /></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Id_AssignValue_CorrectlySetWithOrder()
        {
            // trending should be added between id and save

            DoTest(
                input:
                    @"<Protocol><Params><Param id=""10"" save=""true""></Param></Params></Protocol>",
                action:
                    m => m.Protocol.Params[0].Trending = true,
                checks: (m, x, o) =>
                {
                    Assert.IsTrue(m.Protocol.Params[0].Trending.Value);
                    Assert.AreEqual("true", m.Protocol.Params[0].Trending.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param id=""10"" trending=""true"" save=""true"" /></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Id_ChangeRawValue1_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param id=""10"" /></Params></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(10u, m.Protocol.Params[0].Id.Value);
                    Assert.AreEqual("10", m.Protocol.Params[0].Id.RawValue);
                    m.Protocol.Params[0].Id.RawValue = "11";
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(11u, m.Protocol.Params[0].Id.Value);
                    Assert.AreEqual("11", m.Protocol.Params[0].Id.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param id=""11"" /></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Id_ChangeRawValue2_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param id=""10"" /></Params></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(10u, m.Protocol.Params[0].Id.Value);
                    Assert.AreEqual("10", m.Protocol.Params[0].Id.RawValue);
                    m.Protocol.Params[0].Id.RawValue = "abc";
                },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.Params[0].Id.Value);
                    Assert.AreEqual("abc", m.Protocol.Params[0].Id.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param id=""abc"" /></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Id_AssignRawValue_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param /></Params></Protocol>",
                action:
                    m =>
                    {
                        m.Protocol.Params[0].Id = new AttributeValue<uint?>("abc");
                    },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.Params[0].Id.Value);
                    Assert.AreEqual("abc", m.Protocol.Params[0].Id.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param id=""abc"" /></Params></Protocol>", o);
                }
            );
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_AssignValue_CorrectlySet()
        {
            DoTest(
                input:
                @"<Protocol><Params><Param></Param></Params></Protocol>",
                action:
                m => m.Protocol.Params[0].Name = "Name1",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("Name1", m.Protocol.Params[0].Name.Value);
                    Assert.AreEqual("Name1", m.Protocol.Params[0].Name.RawValue);
                    Assert.AreEqual(@"<Protocol><Params>
		<Param>
			<Name>Name1</Name>
		</Param>
	</Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Name_AssignValue_CorrectlySetWithOrder()
        {
            // Description should be added between Name and Type

            DoTest(
                input:
                @"<Protocol><Params><Param><Name>MyName</Name><Type>read</Type></Param></Params></Protocol>",
                action:
                m => m.Protocol.Params[0].Description = "MyDescription",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("MyDescription", m.Protocol.Params[0].Description.Value);
                    Assert.AreEqual("MyDescription", m.Protocol.Params[0].Description.RawValue);
                    Assert.AreEqual(@"<Protocol><Params>
		<Param>
			<Name>MyName</Name>
			<Description>MyDescription</Description>
			<Type>read</Type>
		</Param>
	</Params></Protocol>", o);
                }
            );
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_ChangeValue_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param><Type>read</Type></Param></Params></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(EnumParamType.Read, m.Protocol.Params[0].Type.Value);
                    Assert.AreEqual("read", m.Protocol.Params[0].Type.RawValue);
                    m.Protocol.Params[0].Type.Value = EnumParamType.Write;
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(EnumParamType.Write, m.Protocol.Params[0].Type.Value);
                    Assert.AreEqual("write", m.Protocol.Params[0].Type.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param><Type>write</Type></Param></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Type_AssignNull_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param><Type>read</Type></Param></Params></Protocol>",
                action:
                    m =>
                    {
                        m.Protocol.Params[0].Type = null;
                    },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.Params[0].Type);
                    Assert.AreEqual(@"<Protocol><Params><Param /></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Type_AssignValue_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param></Param></Params></Protocol>",
                action:
                    m => m.Protocol.Params[0].Type = new ParamsParamType(EnumParamType.Read),
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(EnumParamType.Read, m.Protocol.Params[0].Type.Value);
                    Assert.AreEqual("read", m.Protocol.Params[0].Type.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param>
			<Type>read</Type>
		</Param></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Type_ChangeRawValue1_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param><Type>read</Type></Param></Params></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(EnumParamType.Read, m.Protocol.Params[0].Type.Value);
                    Assert.AreEqual("read", m.Protocol.Params[0].Type.RawValue);
                    m.Protocol.Params[0].Type.RawValue = "write";
                },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual(EnumParamType.Write, m.Protocol.Params[0].Type.Value);
                    Assert.AreEqual("write", m.Protocol.Params[0].Type.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param><Type>write</Type></Param></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Type_ChangeRawValue2_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param><Type>read</Type></Param></Params></Protocol>",
                action: m =>
                {
                    Assert.AreEqual(EnumParamType.Read, m.Protocol.Params[0].Type.Value);
                    Assert.AreEqual("read", m.Protocol.Params[0].Type.RawValue);
                    m.Protocol.Params[0].Type.RawValue = "test";
                },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.Params[0].Type.Value);
                    Assert.AreEqual("test", m.Protocol.Params[0].Type.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param><Type>test</Type></Param></Params></Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Type_AssignRawValue_CorrectlySet()
        {
            DoTest(
                input:
                    @"<Protocol><Params><Param></Param></Params></Protocol>",
                action:
                    m =>
                    {
                        var x = new ParamsParamType();
                        x.RawValue = "test";
                        m.Protocol.Params[0].Type = x;
                    },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.Params[0].Type.Value);
                    Assert.AreEqual("test", m.Protocol.Params[0].Type.RawValue);
                    Assert.AreEqual(@"<Protocol><Params><Param>
			<Type>test</Type>
		</Param></Params></Protocol>", o);
                }
            );
        }

        #endregion


    }
}
