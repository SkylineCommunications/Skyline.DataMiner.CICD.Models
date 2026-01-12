using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Triggers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class OnTrigger : ProtocolTestBase
    {
        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On id='10'></On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual("10", trigger.On.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On id=''></On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(String.Empty, trigger.On.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On></On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.On.Id);
        }

        #endregion

        #region Value

        [TestMethod]
        public void Value_Command_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On>command</On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerOn.Command, trigger.On.Value);
        }

        [TestMethod]
        public void Value_Communication_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On>communication</On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerOn.Communication, trigger.On.Value);
        }

        [TestMethod]
        public void Value_Group_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On>group</On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerOn.Group, trigger.On.Value);
        }

        [TestMethod]
        public void Value_Pair_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On>pair</On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerOn.Pair, trigger.On.Value);
        }

        [TestMethod]
        public void Value_Parameter_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On>parameter</On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerOn.Parameter, trigger.On.Value);
        }

        [TestMethod]
        public void Value_Protocol_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On>protocol</On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerOn.Protocol, trigger.On.Value);
        }

        [TestMethod]
        public void Value_Response_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On>response</On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerOn.Response, trigger.On.Value);
        }

        [TestMethod]
        public void Value_Timer_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On>timer</On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerOn.Timer, trigger.On.Value);
        }

        [TestMethod]
        public void Value_Invalid_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On>abc</On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.On.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <On></On>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.On.Value);
        }
        #endregion
    }
}