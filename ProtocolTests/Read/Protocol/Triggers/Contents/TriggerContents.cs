namespace Models.ProtocolTests.Read.Protocol.Triggers.Contents
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TriggerContent : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <Triggers>
                                     <Trigger>
                                          <Content>
                                            <Id>1</Id>
                                          </Content>
                                     </Trigger>
                                </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITriggers triggers = protocol.Triggers;
            var trigger = triggers[0];
            var contents = trigger.Content;

            // Assert
            Assert.AreEqual((uint?) 1, contents[0].Value);
        }


        [TestMethod]
        public void Value_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <Triggers>
                                     <Trigger>
                                          <Content>
                                            <Id></Id>
                                          </Content>
                                     </Trigger>
                                </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITriggers triggers = protocol.Triggers;
            var trigger = triggers[0];
            var contents = trigger.Content;

            // Assert
            Assert.IsNull(contents[0].Value);
        }


        [TestMethod]
        public void Value_Invalid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <Triggers>
                                     <Trigger>
                                          <Content>
                                            <Id>ten</Id>
                                          </Content>
                                     </Trigger>
                                </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITriggers triggers = protocol.Triggers;
            var trigger = triggers[0];
            var contents = trigger.Content;

            // Assert
            Assert.IsNull(contents[0].Value);
        }

        #endregion

        #region Else

        [TestMethod]
        public void Else_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <Triggers>
                                     <Trigger>
                                          <Content>
                                            <Id else='true'></Id>
                                          </Content>
                                     </Trigger>
                                </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITriggers triggers = protocol.Triggers;
            var trigger = triggers[0];
            var contents = trigger.Content;

            // Assert
            Assert.IsTrue(contents[0].Else.Value);
        }

        [TestMethod]
        public void Else_Invalid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <Triggers>
                                     <Trigger>
                                          <Content>
                                            <Id else='tue'></Id>
                                          </Content>
                                     </Trigger>
                                </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITriggers triggers = protocol.Triggers;
            var trigger = triggers[0];
            var contents = trigger.Content;

            // Assert
            Assert.IsNull(contents[0].Else.Value);
        }

        [TestMethod]
        public void Else_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <Triggers>
                                     <Trigger>
                                          <Content>
                                            <Id else=''></Id>
                                          </Content>
                                     </Trigger>
                                </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITriggers triggers = protocol.Triggers;
            var trigger = triggers[0];
            var contents = trigger.Content;

            // Assert
            Assert.IsNull(contents[0].Else.Value);
        }


        [TestMethod]
        public void Else_Missing_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <Triggers>
                                     <Trigger>
                                          <Content>
                                            <Id></Id>
                                          </Content>
                                     </Trigger>
                                </Triggers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITriggers triggers = protocol.Triggers;
            var trigger = triggers[0];
            var contents = trigger.Content;

            // Assert
            Assert.IsNull(contents[0].Else);
        }

        #endregion



    }
}
