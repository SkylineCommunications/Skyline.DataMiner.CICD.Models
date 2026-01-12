namespace Models.ProtocolTests.Read.Protocol.Triggers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Trigger : ProtocolTestBase
    {

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger id='10'></Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual((uint?) 10, trigger.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger id='ten'></Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger id=''></Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger></Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Id);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Name>Test</Name>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual("Test", trigger.Name.Value);
        }

        [TestMethod]
        public void Name_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                     <Name></Name>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(String.Empty, trigger.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Name);
        }

        #endregion

        #region Condition

        [TestMethod]
        public void Condition_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Condition>Test</Condition>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual("Test", trigger.Condition.Value);
        }

        [TestMethod]
        public void Condition_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                     <Condition></Condition>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.AreEqual(String.Empty, trigger.Condition.Value);
        }

        [TestMethod]
        public void Condition_Missing_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Condition);
        }

        #endregion

        #region On

        [TestMethod]
        public void On_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.On);
        }

        [TestMethod]
        public void On_AvailableTag_IsNotNull()
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
            Assert.IsNotNull(trigger.On);
        }

        #endregion

        #region Time

        [TestMethod]
        public void Time_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Time);
        }

        [TestMethod]
        public void Time_AvailableTag_IsNotNull()
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
            Assert.IsNotNull(trigger.Time);
        }

        #endregion

        #region Content

        [TestMethod]
        public void Content_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Content);
        }

        [TestMethod]
        public void Content_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                    <Content></Content>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNotNull(trigger.Content);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Triggers>
                                <Trigger>
                                </Trigger>
                            </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var trigger = protocol.Triggers[0];

            // Assert
            Assert.IsNull(trigger.Type);
        }

        [TestMethod]
        public void Type_AvailableTag_IsNotNull()
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
            Assert.IsNotNull(trigger.Type);
        }

        #endregion

    }
}
