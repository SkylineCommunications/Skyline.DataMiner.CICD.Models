namespace Models.ProtocolTests.Read.Protocol.Responses
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Response : ProtocolTestBase
    {

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response id='10'></Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual((uint)10, Response.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response id='ten'></Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual(null, Response.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response id=''></Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual(null, Response.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response></Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual(null, Response.Id);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response options='Test'></Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual("Test", Response.Options.Value);
        }

        [TestMethod]
        public void Options_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response options=''></Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual(String.Empty, Response.Options.Value);
        }

        [TestMethod]
        public void Options_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response></Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual(null, Response.Options);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Name>Test</Name>
                                </Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual("Test", Response.Name.Value);
        }

        [TestMethod]
        public void Name_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Name></Name>
                                </Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual(String.Empty, Response.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response></Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual(null, Response.Name);
        }

        #endregion

        #region Description

        [TestMethod]
        public void Description_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Description>Test</Description>
                                </Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual("Test", Response.Description.Value);
        }

        [TestMethod]
        public void Description_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Description></Description>
                                </Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual(String.Empty, Response.Description.Value);
        }

        [TestMethod]
        public void Description_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response></Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual(null, Response.Description);
        }

        #endregion

        #region Content

        [TestMethod]
        public void Content_Available_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                    <Content></Content>
                                </Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreNotEqual(null, Response.Content);
        }

        [TestMethod]
        public void Content_NotAvailable_Null()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response>
                                </Response>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Response = protocol.Responses[0];

            // Assert
            Assert.AreEqual(null, Response.Content);
        }

        #endregion

    }
}
