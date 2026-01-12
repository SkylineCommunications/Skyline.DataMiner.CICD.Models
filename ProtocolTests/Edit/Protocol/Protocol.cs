namespace Models.ProtocolTests.Edit.Protocol
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Edit = Skyline.DataMiner.CICD.Models.Protocol.Edit;

    [TestClass]
    public class Protocol : ProtocolModelEditTestBase
    {
        [TestMethod]
        public void Protocol_CreateNew_HasNamespace()
        {
            DoTest(
                input:
                    "",
                action:
                    m => m.Protocol = new Edit.Protocol(),
                checks: (m, x, o) =>
                {
                    Assert.IsInstanceOfType(m.Protocol, typeof(Edit.Protocol));
                    Assert.AreEqual(@"<Protocol xmlns=""http://www.skyline.be/protocol"" />", o);
                }
            );
        }

        #region Name

        [TestMethod]
        public void Name_ChangeValue_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><Name>Name1</Name></Protocol>",
                action:
                    m => m.Protocol.Name = "Name2",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("Name2", m.Protocol.Name.Value);
                    Assert.AreEqual("<Protocol>\r\n\t<Name>Name2</Name>\r\n</Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Name_AssignNull_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><Name>Name1</Name></Protocol>",
                action:
                    m =>
                    {
                        m.Protocol.Name = null;
                        m.Protocol.Cleanup(cleanupSelf: false);
                    },          
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.Name);
                    Assert.AreEqual("<Protocol />", o);
                }
            );
        }

        [TestMethod]
        public void Name_AssignEmptyString_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><Name>Name1</Name></Protocol>",
                action:
                    m =>
                    {
                        m.Protocol.Name = "";
                    },
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("", m.Protocol.Name.Value);
                    Assert.AreEqual("<Protocol>\r\n\t<Name></Name>\r\n</Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Name_AssignValue_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol></Protocol>",
                action:
                    m => m.Protocol.Name = "Name2",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("Name2", m.Protocol.Name.Value);
                    Assert.AreEqual("<Protocol>\r\n\t<Name>Name2</Name>\r\n</Protocol>", o);
                }
            );
        }

        #endregion

        #region Description

        [TestMethod]
        public void Description_ChangeValue_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><Description>Description1</Description></Protocol>",
                action:
                    m => m.Protocol.Description = "Description2",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("Description2", m.Protocol.Description.Value);
                    Assert.AreEqual("<Protocol>\r\n\t<Description>Description2</Description>\r\n</Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Description_ChangeValueWithSpecialCharacters_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><Description>Description1</Description></Protocol>",
                action:
                    m => m.Protocol.Description = "Description & B",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("Description & B", m.Protocol.Description.Value);
                    Assert.AreEqual("<Protocol>\r\n\t<Description>Description &amp; B</Description>\r\n</Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Description_AssignNull_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol><Description>Description1</Description></Protocol>",
                action:
                    m =>
                    {
                        m.Protocol.Description = null;
                        m.Protocol.Cleanup(cleanupSelf: false);
                    },
                checks: (m, x, o) =>
                {
                    Assert.IsNull(m.Protocol.Description);
                    Assert.AreEqual("<Protocol />", o);
                }
            );
        }

        [TestMethod]
        public void Description_AssignValue_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol></Protocol>",
                action:
                    m => m.Protocol.Description = "Description2",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("Description2", m.Protocol.Description.Value);
                    Assert.AreEqual("<Protocol>\r\n\t<Description>Description2</Description>\r\n</Protocol>", o);
                }
            );
        }

        [TestMethod]
        public void Description_AssignValueWithSpecialCharacters_CorrectlySet()
        {
            DoTest(
                input:
                    "<Protocol></Protocol>",
                action:
                    m => m.Protocol.Description = "Description & B",
                checks: (m, x, o) =>
                {
                    Assert.AreEqual("Description & B", m.Protocol.Description.Value);
                    Assert.AreEqual("<Protocol>\r\n\t<Description>Description &amp; B</Description>\r\n</Protocol>", o);
                }
            );
        }

        #endregion
    }
}
