namespace Models.ProtocolTests.Read.Protocol.Timers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Time : ProtocolTestBase
    {

        #region DataDisplay

        [TestMethod]
        public void DataDisplay_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Time dataDisplay='10'></Time>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var time = timer.Time;

            // Assert
            Assert.AreEqual((uint?) 10, time.DataDisplay.Value);
        }

        [TestMethod]
        public void DataDisplay_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Time dataDisplay='seventhyfixe'></Time>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var time = timer.Time;

            // Assert
            Assert.IsNull(time.DataDisplay.Value);

        }

        [TestMethod]
        public void DataDisplay_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Time dataDisplay=''></Time>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var time = timer.Time;

            // Assert
            Assert.IsNull(time.DataDisplay.Value);

        }

        [TestMethod]
        public void DataDisplay_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Time></Time>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var time = timer.Time;

            // Assert
            Assert.IsNull(time.DataDisplay);

        }




        #endregion

        #region Initial

        [TestMethod]
        public void Initial_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Time initial='true'></Time>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var time = timer.Time;

            // Assert
            Assert.AreEqual("true", time.Initial.Value);
        }

        [TestMethod]
        public void Initial_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Time initial=''></Time>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var time = timer.Time;

            // Assert
            Assert.AreEqual("", time.Initial.Value);

        }

        [TestMethod]
        public void Initial_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Time></Time>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var time = timer.Time;

            // Assert
            Assert.IsNull(time.Initial);

        }

        #endregion

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Time>10</Time>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var time = timer.Time;

            // Assert
            Assert.AreEqual("10", time.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Timers>
                                <Timer>
                                    <Time Value=''></Time>
                                </Timer>
                            </Timers>
                           </Protocol>";

            // Act
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var timer = protocol.Timers[0];
            var time = timer.Time;

            // Assert
            Assert.AreEqual("", time.Value);

        }

       

        #endregion

    }
}
