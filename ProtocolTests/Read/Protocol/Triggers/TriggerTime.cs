using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Triggers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TriggerTime : ProtocolTestBase
    {

        #region Case

        [TestMethod]
        public void Case_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time case='Test'></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual("Test", trigger.Time.Case.Value);
        }

        [TestMethod]
        public void Case_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time case=''></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(String.Empty, trigger.Time.Case.Value);
        }

        [TestMethod]
        public void Case_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Time.Case);
        }

        #endregion

        #region ValueAttribute

        [TestMethod]
        public void ValueAttribute_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time value='Test'></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual("Test", trigger.Time.ValueAttribute.Value);
        }

        [TestMethod]
        public void ValueAttribute_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time value=''></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(String.Empty, trigger.Time.ValueAttribute.Value);
        }

        [TestMethod]
        public void ValueAttribute_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Time.ValueAttribute);

        }

        #endregion

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time id='10'></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual((uint?) 10, trigger.Time.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time id='ten'></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Time.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time id=''></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Time.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Time.Id);

        }

        #endregion

        #region Nr

        [TestMethod]
        public void Nr_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time nr='true'></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsTrue(trigger.Time.Nr.Value);
        }

        [TestMethod]
        public void Nr_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time nr='tru'></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Time.Nr.Value);
        }

        [TestMethod]
        public void Nr_Empty_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time nr=''></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Time.Nr.Value);
        }

        [TestMethod]
        public void Nr_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time></Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Time.Nr);

        }

        #endregion

        #region Value

        [TestMethod]
        public void Value_After_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time>after</Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerTime.After, EnumTriggerTimeConverter.Convert(trigger.Time.Value));
        }

        [TestMethod]
        public void Value_AfterStartup_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time>after startup</Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerTime.AfterStartup, EnumTriggerTimeConverter.Convert(trigger.Time.Value));
        }

        [TestMethod]
        public void Value_Before_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time>before</Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerTime.Before, EnumTriggerTimeConverter.Convert(trigger.Time.Value));
        }

        [TestMethod]
        public void Value_Change_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time>change</Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerTime.Change, EnumTriggerTimeConverter.Convert(trigger.Time.Value));
        }

        [TestMethod]
        public void Value_ChangeAfterResponse_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time>change after response</Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerTime.ChangeAfterResponse, EnumTriggerTimeConverter.Convert(trigger.Time.Value));
        }

        [TestMethod]
        public void Value_LinkFileChange_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time>link file change</Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerTime.LinkFileChange, EnumTriggerTimeConverter.Convert(trigger.Time.Value));
        }

        [TestMethod]
        public void Value_Succeeded_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time>succeeded</Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerTime.Succeeded, EnumTriggerTimeConverter.Convert(trigger.Time.Value));
        }

        [TestMethod]
        public void Value_Timeout_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time>timeout</Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerTime.Timeout, EnumTriggerTimeConverter.Convert(trigger.Time.Value));
        }

        [TestMethod]
        public void Value_Unknown_ReturnsString()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Time>AAA</Time>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual("AAA", trigger.Time.Value);
        }

        #endregion

    }
}
