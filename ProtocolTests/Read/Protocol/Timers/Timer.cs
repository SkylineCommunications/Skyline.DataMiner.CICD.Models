namespace Models.ProtocolTests.Read.Protocol.Timers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Timer : ProtocolTestBase
    {

        #region Id

        [TestMethod]
        public void Id_ValidId_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer id='10'></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreEqual((uint)10, timer.Id.Value);
        }

        [TestMethod]
        public void Id_InvalidId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer id='ten'></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);
 
            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer id=''></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Id.Value);
        }

        [TestMethod]
        public void Id_MissingIdTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Id);
        }

        #endregion

        #region FixedTimer

        [TestMethod]
        public void FixedTimer_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer fixedTimer='true'></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsTrue(timer.FixedTimer.Value);
        }

        [TestMethod]
        public void FixedTimer_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer fixedTimer='tue'></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.FixedTimer.Value);
        }

        [TestMethod]
        public void FixedTimer_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer fixedTimer=''></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.FixedTimer.Value);
        }

        [TestMethod]
        public void FixedTimer_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.FixedTimer);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer options='Test'></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreEqual("Test", timer.Options.Value);
        }

        [TestMethod]
        public void Options_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer options=''></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreEqual(String.Empty, timer.Options.Value);
        }

        [TestMethod]
        public void Options_MissingTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Options);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer><Name>Test</Name></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreEqual("Test", timer.Name.Value);
        }

        [TestMethod]
        public void Name_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer><Name></Name></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreEqual(String.Empty, timer.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Name);
        }

        #endregion

        #region Interval

        [TestMethod]
        public void Interval_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer><Interval>75</Interval></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreEqual((uint?) 75, timer.Interval.Value);
        }

        [TestMethod]
        public void Interval_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer><Interval>seventhyfive</Interval></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Interval.Value);
        }

        [TestMethod]
        public void Interval_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer><Interval></Interval></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Interval.Value);
        }

        [TestMethod]
        public void Interval_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Interval);
        }

        #endregion

        #region Time

        [TestMethod]
        public void Time_TagAvailable_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer><Time></Time></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNotNull(timer.Time);
        }

        [TestMethod]
        public void Time_TagNotAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Time);
        }

        #endregion

        #region Content

        [TestMethod]
        public void Content_TagAvailable_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer><Content></Content></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNotNull(timer.Content);
        }

        [TestMethod]
        public void Content_TagNotAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Content);
        }

        #endregion

        #region Condition

        [TestMethod]
        public void Condition_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer><Condition>Test</Condition></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreEqual("Test", timer.Condition.Value);
        }

        [TestMethod]
        public void Condition_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer><Condition></Condition></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.AreEqual(String.Empty, timer.Condition.Value);
        }

        [TestMethod]
        public void Condition_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer></Timer>
                            </Timers>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];

            // Assert
            Assert.IsNull(timer.Condition);
        }

        #endregion

    }
}
