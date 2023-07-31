namespace Models.ProtocolTests.Read.Protocol.Actions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class OnAction : ProtocolTestBase
    {
        #region Value

        [TestMethod]
        public void Value_Command_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On>command</On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual( EnumActionOn.Command, on.Value);
        }

        [TestMethod]
        public void Value_Group_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On>group</On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(EnumActionOn.Group, on.Value);
        }

        [TestMethod]
        public void Value_Pair_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On>pair</On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(EnumActionOn.Pair, on.Value);
        }

        [TestMethod]
        public void Value_Parameter_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On>parameter</On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(EnumActionOn.Parameter, on.Value);
        }

        [TestMethod]
        public void Value_Protocol_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On>protocol</On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(EnumActionOn.Protocol, on.Value);
        }

        [TestMethod]
        public void Value_Response_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On>response</On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(EnumActionOn.Response, on.Value);
        }

        [TestMethod]
        public void Value_Timer_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On>timer</On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(EnumActionOn.Timer, on.Value);
        }

        [TestMethod]
        public void Value_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On>Test</On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(null, on.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On></On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(null, on.Value);
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
                                    <On id='1'>1</On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual("1", on.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On id=''></On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(String.Empty, on.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On></On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(null, on.Id);
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
                                    <On nr='1'>1</On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual("1", on.Nr.Value);
        }

        [TestMethod]
        public void Nr_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On nr=''></On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(String.Empty, on.Nr.Value);
        }

        [TestMethod]
        public void Nr_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On></On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];
            var on = action.On;

            // Assert
            Assert.AreEqual(null, on.Nr);
        }

        #endregion
    }
}