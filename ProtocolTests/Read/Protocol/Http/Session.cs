namespace Models.ProtocolTests.Read.Protocol.Http
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Session : ProtocolTestBase
    {

        #region Id

        [TestMethod]
        public void Id_ValidId_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session id='10'></Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];

            // Assert
            Assert.AreEqual((uint?) 10, session.Id.Value);
        }

        [TestMethod]
        public void Id_InvalidId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session id='ten'></Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];

            // Assert
            Assert.AreEqual(null, session.Id.Value);
        }

        [TestMethod]
        public void Id_EmptyId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session id=''></Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];

            // Assert
            Assert.AreEqual(null, session.Id.Value);
        }

        [TestMethod]
        public void Id_MissingIdTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session></Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];

            // Assert
            Assert.AreEqual(null, session.Id);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_ValidName_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session name='name'></Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];

            // Assert
            Assert.AreEqual("name", session.Name.Value);
        }

        [TestMethod]
        public void Name_EmptyName_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session name=''></Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];

            // Assert
            Assert.AreEqual(String.Empty, session.Name.Value);
        }

        [TestMethod]
        public void Name_MissingName_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session></Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];

            // Assert
            Assert.AreEqual(null, session.Name);
        }

        #endregion

        #region Connection


        [TestMethod]
        public void Connection_MissingConnectionTag_EmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];

            // Assert
            Assert.AreEqual(0, session.Count);
        }

        [TestMethod]
        public void Connection_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <HTTP>
                                <Session>
                                    <Connection></Connection>
                                </Session>
                            </HTTP>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var session = protocol.HTTP[0];
            var connection = session[0];

            // Assert
            Assert.AreNotEqual(null, connection);
        }

        #endregion

    }
}
