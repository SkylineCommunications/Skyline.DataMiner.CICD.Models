namespace Models.ProtocolTests.Read.Protocol.Actions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

    [TestClass]
    public class ActionType : ProtocolTestBase
    {
        #region Allowed

        [TestMethod]
        public void Allowed_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type allowed='true'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual("true", type.Allowed.Value);
        }

        [TestMethod]
        public void Allowed_IsEmpty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type allowed=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual("", type.Allowed.Value);
        }

        [TestMethod]
        public void Allowed_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Allowed);
        }

        #endregion

        #region Arguments

        [TestMethod]
        public void Arguments_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type arguments='Test'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual("Test", type.Arguments.Value);
        }

        [TestMethod]
        public void Arguments_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type arguments=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(String.Empty, type.Arguments.Value);
        }

        [TestMethod]
        public void Arguments_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Arguments);
        }

        #endregion

        #region EndOffset

        [TestMethod]
        public void EndOffset_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type endoffset='Test'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Endoffset.Value);
        }

        [TestMethod]
        public void EndOffset_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type endoffset=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Endoffset.Value);
        }

        [TestMethod]
        public void EndOffset_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Endoffset);
        }

        #endregion

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type id='20'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual((uint)20, type.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type id='tt'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Id.Value);
        }

        [TestMethod]
        public void Id_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Id);
        }

        #endregion

        #region Nr

        [TestMethod]
        public void Nr_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type nr='Test'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual("Test", type.Nr.Value);
        }

        [TestMethod]
        public void Nr_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type nr=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(String.Empty, type.Nr.Value);
        }

        [TestMethod]
        public void Nr_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Nr);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type options='Test'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual("Test", type.Options.Value);
        }

        [TestMethod]
        public void Options_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type options=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(String.Empty, type.Options.Value);
        }

        [TestMethod]
        public void Options_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Options);
        }

        #endregion

        #region Reschedule

        [TestMethod]
        public void Reschedule_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type reschedule='true'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(true, type.Reschedule.Value);
        }

        [TestMethod]
        public void Reschedule_Empty_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type reschedule=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Reschedule.Value);
        }

        [TestMethod]
        public void Reschedule_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Reschedule);
        }

        #endregion

        #region ReturnValue

        [TestMethod]
        public void ReturnValue_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type returnValue='Test'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual("Test", type.ReturnValue.Value);
        }

        [TestMethod]
        public void ReturnValue_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type returnValue=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(String.Empty, type.ReturnValue.Value);
        }

        [TestMethod]
        public void ReturnValue_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.ReturnValue);
        }

        #endregion

        #region Scale

        [TestMethod]
        public void Scale_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type scale='Test'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual("Test", type.Scale.Value);
        }

        [TestMethod]
        public void Scale_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type scale=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(String.Empty, type.Scale.Value);
        }

        [TestMethod]
        public void Scale_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Scale);
        }

        #endregion

        #region Script

        [TestMethod]
        public void Script_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type script='Test'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual("Test", type.Script.Value);
        }

        [TestMethod]
        public void Script_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type script=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(String.Empty, type.Script.Value);
        }

        [TestMethod]
        public void Script_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Script);
        }

        #endregion

        #region Sequence

        [TestMethod]
        public void Sequence_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type sequence='Test'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual("Test", type.Sequence.Value);
        }

        [TestMethod]
        public void Sequence_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type sequence=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(String.Empty, type.Sequence.Value);
        }

        [TestMethod]
        public void Sequence_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Sequence);
        }

        #endregion

        #region StartOffset

        [TestMethod]
        public void StartOffset_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type startoffset='10'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual((uint)10, type.Startoffset.Value);
        }

        [TestMethod]
        public void StartOffset_Empty_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type startoffset=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Startoffset.Value);
        }

        [TestMethod]
        public void StartOffset_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.Startoffset);
        }

        #endregion

        #region ValueAttribute

        [TestMethod]
        public void ValueAttribute_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type value='Test'></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual("Test", type.ValueAttribute.Value);
        }

        [TestMethod]
        public void ValueAttribute_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type value=''></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(String.Empty, type.ValueAttribute.Value);
        }

        [TestMethod]
        public void ValueAttribute_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type></Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var type = action.Type;

            // Assert
            Assert.AreEqual(null, type.ValueAttribute);
        }

        #endregion

        #region Value

        [TestMethod]
        [DataRow("add to execute", Enums.EnumActionType.AddToExecute)]
        [DataRow("aggregate", Enums.EnumActionType.Aggregate)]
        [DataRow("append", Enums.EnumActionType.Append)]
        [DataRow("append data", Enums.EnumActionType.AppendData)]
        [DataRow("change length", Enums.EnumActionType.ChangeLength)]
        [DataRow("clear", Enums.EnumActionType.Clear)]
        [DataRow("clear length info", Enums.EnumActionType.ClearLengthInfo)]
        [DataRow("clear on display", Enums.EnumActionType.ClearOnDisplay)]
        [DataRow("close", Enums.EnumActionType.Close)]
        [DataRow("copy", Enums.EnumActionType.Copy)]
        [DataRow("copy reverse", Enums.EnumActionType.CopyReverse)]
        [DataRow("crc", Enums.EnumActionType.Crc)]
        [DataRow("create element", Enums.EnumActionType.CreateElement)]
        [DataRow("execute", Enums.EnumActionType.Execute)]
        [DataRow("execute next", Enums.EnumActionType.ExecuteNext)]
        [DataRow("execute one", Enums.EnumActionType.ExecuteOne)]
        [DataRow("execute one top", Enums.EnumActionType.ExecuteOneTop)]
        [DataRow("execute one now", Enums.EnumActionType.ExecuteOneNow)]
        [DataRow("force execute", Enums.EnumActionType.ForceExecute)]
        [DataRow("go", Enums.EnumActionType.Go)]
        [DataRow("increment", Enums.EnumActionType.Increment)]
        [DataRow("length", Enums.EnumActionType.Length)]
        [DataRow("lock", Enums.EnumActionType.Lock)]
        [DataRow("make", Enums.EnumActionType.Make)]
        [DataRow("merge", Enums.EnumActionType.Merge)]
        [DataRow("multiply", Enums.EnumActionType.Multiply)]
        [DataRow("normalize", Enums.EnumActionType.Normalize)]
        [DataRow("open", Enums.EnumActionType.Open)]
        [DataRow("pow", Enums.EnumActionType.Pow)]
        [DataRow("priority lock", Enums.EnumActionType.PriorityLock)]
        [DataRow("priority unlock", Enums.EnumActionType.PriorityUnlock)]
        [DataRow("read", Enums.EnumActionType.Read)]
        [DataRow("read file", Enums.EnumActionType.ReadFile)]
        [DataRow("read stuffing", Enums.EnumActionType.ReadStuffing)]
        [DataRow("replace", Enums.EnumActionType.Replace)]
        [DataRow("replace data", Enums.EnumActionType.ReplaceData)]
        [DataRow("restart timer", Enums.EnumActionType.RestartTimer)]
        [DataRow("reverse", Enums.EnumActionType.Reverse)]
        [DataRow("run actions", Enums.EnumActionType.RunActions)]
        [DataRow("save", Enums.EnumActionType.Save)]
        [DataRow("set", Enums.EnumActionType.Set)]
        [DataRow("set and get with wait", Enums.EnumActionType.SetAndGetWithWait)]
        [DataRow("set info", Enums.EnumActionType.SetInfo)]
        [DataRow("set next", Enums.EnumActionType.SetNext)]
        [DataRow("set with wait", Enums.EnumActionType.SetWithWait)]
        [DataRow("sleep", Enums.EnumActionType.Sleep)]
        [DataRow("start", Enums.EnumActionType.Start)]
        [DataRow("stop", Enums.EnumActionType.Stop)]
        [DataRow("stop current group", Enums.EnumActionType.StopCurrentGroup)]
        [DataRow("stuffing", Enums.EnumActionType.Stuffing)]
        [DataRow("swap column", Enums.EnumActionType.SwapColumn)]
        [DataRow("timeout", Enums.EnumActionType.Timeout)]
        [DataRow("unlock", Enums.EnumActionType.Unlock)]
        [DataRow("wmi", Enums.EnumActionType.Wmi)]
        [DataRow("invalidABC", null)]
        [DataRow("", null)]
        public void Value_EachItem_ReturnsCorrectValue(string type, Enums.EnumActionType? enumType)
        {
            // Arrange.
            string xml = "@<Protocol><Actions><Action><Type>" + type + "</Type></Action></Actions></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(enumType, action.Type.Value);
        }
       
        #endregion
    }
}