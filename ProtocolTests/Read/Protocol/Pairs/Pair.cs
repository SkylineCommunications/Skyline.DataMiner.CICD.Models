namespace Models.ProtocolTests.Read.Protocol.Pairs
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Pair : ProtocolTestBase
    {

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair id='10'></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual((uint?)10, pair.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair id='ten'></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair id=''></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Id);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair options='Test'></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual("Test", pair.Options.Value);
        }

        [TestMethod]
        public void Options_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair options=''></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(String.Empty, pair.Options.Value);
        }

        [TestMethod]
        public void Options_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Options);
        }

        #endregion

        #region Ping

        [TestMethod]
        public void Ping_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair ping='true'></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(true, pair.Ping.Value);
        }

        [TestMethod]
        public void Ping_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair ping='tru'></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Ping.Value);
        }

        [TestMethod]
        public void Ping_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair ping=''></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Ping.Value);
        }

        [TestMethod]
        public void Ping_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Ping);
        }

        #endregion

        #region Timeout

        [TestMethod]
        public void Timeout_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair timeout='10'></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual((uint?) 10, pair.Timeout.Value);
        }

        [TestMethod]
        public void Timeout_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair timeout='ten'></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Timeout.Value);
        }

        [TestMethod]
        public void Timeout_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair timeout=''></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Timeout.Value);
        }

        [TestMethod]
        public void Timeout_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Timeout);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Name>Test</Name>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual("Test", pair.Name.Value);
        }

        [TestMethod]
        public void Name_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Name></Name>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(String.Empty, pair.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Name);
        }

        #endregion

        #region Description

        [TestMethod]
        public void Description_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Description>Test</Description>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual("Test", pair.Description.Value);
        }

        [TestMethod]
        public void Description_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Description></Description>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(String.Empty, pair.Description.Value);
        }

        [TestMethod]
        public void Description_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Description);
        }

        #endregion

        #region Condition

        [TestMethod]
        public void Condition_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Condition>Test</Condition>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual("Test", pair.Condition.Value);
        }

        [TestMethod]
        public void Condition_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Condition></Condition>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(String.Empty, pair.Condition.Value);
        }

        [TestMethod]
        public void Condition_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair></Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Condition);
        }

        #endregion

        #region Content

        [TestMethod]
        public void Content_TagAvailable_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content></Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreNotEqual(null, pair.Content);
        }

        [TestMethod]
        public void Content_TagNotAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];

            // Assert
            Assert.AreEqual(null, pair.Content);
        }

        #endregion


    }
}
