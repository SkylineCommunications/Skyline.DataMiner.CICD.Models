using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.QActions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class QAction : ProtocolTestBase
    {

        #region Condition

        [TestMethod]
        public void Condition_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction><Condition>Test</Condition></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual("Test", qaction.Condition.Value);
        }

        [TestMethod]
        public void Condition_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction><Condition></Condition></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(String.Empty, qaction.Condition.Value);
        }

        [TestMethod]
        public void Condition_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Condition);
        }


        #endregion

        #region DllImport

        [TestMethod]
        public void DllImport_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction dllImport='Test'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual("Test", qaction.DllImport.Value);
        }

        [TestMethod]
        public void DllImport_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction dllImport=''></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(String.Empty, qaction.DllImport.Value);
        }

        [TestMethod]
        public void DllImport_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.DllImport);
        }


        #endregion

        #region Encoding

        [TestMethod]
        public void Encoding_JScript_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction encoding='jscript'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(Enums.EnumQActionEncoding.Jscript, qaction.Encoding.Value);
        }

        [TestMethod]
        public void Encoding_VBScript_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction encoding='vbscript'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(Enums.EnumQActionEncoding.Vbscript, qaction.Encoding.Value);
        }

        [TestMethod]
        public void Encoding_CSharp_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction encoding='csharp'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(Enums.EnumQActionEncoding.Csharp, qaction.Encoding.Value);
        }

        [TestMethod]
        public void Encoding_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction encoding='abc'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Encoding.Value);
        }

        [TestMethod]
        public void Encoding_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction encoding=''></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Encoding.Value);
        }

        [TestMethod]
        public void Encoding_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Encoding);
        }

        #endregion

        #region EntryPoint

        [TestMethod]
        public void EntryPoint_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction entryPoint='Test'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual("Test", qaction.EntryPoint.Value);
        }

        [TestMethod]
        public void EntryPoint_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction entryPoint=''></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(String.Empty, qaction.EntryPoint.Value);
        }

        [TestMethod]
        public void EntryPoint_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.EntryPoint);
        }


        #endregion

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction id='1'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual((uint?)1, qaction.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction id='one'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction id=''></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Id);
        }


        #endregion

        #region Include

        [TestMethod]
        public void Include_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction include='Test'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual("Test", qaction.Include.Value);
        }

        [TestMethod]
        public void Include_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction include=''></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(String.Empty, qaction.Include.Value);
        }

        [TestMethod]
        public void Include_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Include);
        }


        #endregion

        #region InputParameters

        [TestMethod]
        public void InputParameters_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction inputParameters='Test'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual("Test", qaction.InputParameters.Value);
        }

        [TestMethod]
        public void InputParameters_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction inputParameters=''></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(String.Empty, qaction.InputParameters.Value);
        }

        [TestMethod]
        public void InputParameters_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.InputParameters);
        }


        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction name='Test'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual("Test", qaction.Name.Value);
        }

        [TestMethod]
        public void Name_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction name=''></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(String.Empty, qaction.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Name);
        }


        #endregion

        #region Options

        [TestMethod]
        public void Options_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction options='Test'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual("Test", qaction.Options.Value);
        }

        [TestMethod]
        public void Options_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction options=''></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(String.Empty, qaction.Options.Value);
        }

        [TestMethod]
        public void Options_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Options);
        }


        #endregion

        #region Id

        [TestMethod]
        public void Row_ValRow_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction row='true'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(true, qaction.Row.Value);
        }

        [TestMethod]
        public void Row_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction row='tru'></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Row.Value);
        }

        [TestMethod]
        public void Row_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction row=''></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Row.Value);
        }

        [TestMethod]
        public void Row_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Row);
        }


        #endregion

        #region Code

        [TestMethod]
        public void Code_ValCode_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                              <QAction>
                                  <![CDATA[using System;]]>
                              </QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IQActionsQAction qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual("using System;", qaction.Code);
        }

        [TestMethod]
        public void Code_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                              <QAction>
                                  <![CDATA[]]>
                              </QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IQActionsQAction qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(String.Empty, qaction.Code);
        }

        [TestMethod]
        public void Code_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                              <QAction>
                              </QAction>
                            </QActions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IQActionsQAction qaction = protocol.QActions[0];

            // Assert
            Assert.AreEqual(null, qaction.Code);
        }


        #endregion

    }
}
