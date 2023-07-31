namespace Models.ProtocolTests.Read.Protocol.Commands
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Command : ProtocolTestBase
    {
        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command id='10'></Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual((uint)10, Command.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command id='ten'></Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual(null, Command.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command id=''></Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual(null, Command.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command></Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual(null, Command.Id);
        }

        #endregion

        #region Ascii

        [TestMethod]
        public void Ascii_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command ascii='true'></Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual("true", Command.Ascii.Value);
        }

        [TestMethod]
        public void Ascii_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command ascii=''></Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual("", Command.Ascii.Value);
        }

        [TestMethod]
        public void Ascii_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command></Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual(null, Command.Ascii);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Name>Test</Name>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual("Test", Command.Name.Value);
        }
     
        [TestMethod]
        public void Name_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Name></Name>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual(String.Empty, Command.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command></Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual(null, Command.Name);
        }

        #endregion

        #region Description

        [TestMethod]
        public void Description_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Description>Test</Description>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual("Test", Command.Description.Value);
        }

        [TestMethod]
        public void Description_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Description></Description>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual(String.Empty, Command.Description.Value);
        }

        [TestMethod]
        public void Description_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command></Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual(null, Command.Description);
        }

        #endregion

        #region Content

        [TestMethod]
        public void Content_NotAvailable_Null()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreEqual(null, Command.Content);
        }

        [TestMethod]
        public void Content_Available_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Commands>
                                <Command>
                                    <Content></Content>
                                </Command>
                            </Commands>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var Command = protocol.Commands[0];

            // Assert
            Assert.AreNotEqual(null, Command.Content);
        }



        #endregion
    }
}