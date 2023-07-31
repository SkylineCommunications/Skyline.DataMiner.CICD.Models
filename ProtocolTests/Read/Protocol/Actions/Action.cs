namespace Models.ProtocolTests.Read.Protocol.Actions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Action : ProtocolTestBase
    {
        #region Id

        [TestMethod]
        public void Id_ValidId_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action id='10'></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual((uint?)10, action.Id.Value);
        }

        [TestMethod]
        public void Id_InvalidId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action id='ten'></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(null, action.Id.Value);
        }

        [TestMethod]
        public void Id_EmptyId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action id=''></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(null, action.Id.Value);
        }

        [TestMethod]
        public void Id_MissingIdTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(null, action.Id);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Name>Test</Name>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual("Test", action.Name.Value);
        }

        [TestMethod]
        public void Name_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Name></Name>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(String.Empty, action.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(null, action.Name);
        }

        #endregion

        #region Condition

        [TestMethod]
        public void Condition_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Condition>Test</Condition>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual("Test", action.Condition.Value);
        }

        [TestMethod]
        public void Condition_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Condition></Condition>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(String.Empty, action.Condition.Value);
        }

        [TestMethod]
        public void Condition_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(null, action.Condition);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_Available_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type/>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreNotEqual(null, action.Type);
        }

        [TestMethod]
        public void Type_NotAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(null, action.Type);
        }

        #endregion

        #region On

        [TestMethod]
        public void On_Available_IsNotNull()
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

            // Assert
            Assert.AreNotEqual(null, action.On);
        }

        [TestMethod]
        public void On_NotAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(null, action.On);
        }

        #endregion
    }
}