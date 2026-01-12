using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Triggers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TriggerType : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void Value_Action_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Type>action</Type>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerType.Action, trigger.Type.Value);
        }

        [TestMethod]
        public void Value_Trigger_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Type>trigger</Type>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(Enums.EnumTriggerType.Trigger, trigger.Type.Value);
        }

        [TestMethod]
        public void Value_Invalid_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Type>acon</Type>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Type.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Type></Type>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Type.Value);
        }

        #endregion

    }
}
