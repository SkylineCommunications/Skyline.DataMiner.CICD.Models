namespace Models.ProtocolTests.Read.Protocol.DVEs
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class DveProtocol : ProtocolTestBase
    {
        #region Name

        [TestMethod]
        public void DVEProtocol_ValidName_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol name='Test'>
                                    </DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var dve = protocol.DVEs.DVEProtocols[0];

            // Assert
            Assert.AreEqual("Test", dve.Name.Value);
        }

        [TestMethod]
        public void DVEProtocol_EmptyName_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol name=''>
                                    </DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var dve = protocol.DVEs.DVEProtocols[0];

            // Assert
            Assert.AreEqual(String.Empty, dve.Name.Value);
        }

        [TestMethod]
        public void DVEProtocol_MissingNameTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol>
                                    </DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var dve = protocol.DVEs.DVEProtocols[0];

            // Assert
            Assert.IsNull(dve.Name);
        }

        #endregion Name

        #region TablePID

        [TestMethod]
        public void DVEProtocol_ValidTablePID_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol tablePID='10'>
                                    </DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var dve = protocol.DVEs.DVEProtocols[0];

            // Assert
            Assert.AreEqual((uint?)10, dve.TablePID.Value);
        }

        [TestMethod]
        public void DVEProtocol_EmptyTablePID_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol tablePID=''>
                                    </DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var dve = protocol.DVEs.DVEProtocols[0];

            // Assert
            Assert.IsNull(dve.TablePID.Value);
        }

        [TestMethod]
        public void DVEProtocol_MissingTablePIDTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol>
                                    </DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var dve = protocol.DVEs.DVEProtocols[0];

            // Assert
            Assert.IsNull(dve.TablePID);
        }

        #endregion TablePID

        #region ElementPrefix

        [TestMethod]
        public void DVEProtocol_ValidElementPrefix_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol>
                                        <ElementPrefix>true</ElementPrefix>
                                    </DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var dve = protocol.DVEs.DVEProtocols[0];

            // Assert
            Assert.IsTrue(dve.ElementPrefix.Value);
        }

        [TestMethod]
        public void DVEProtocol_InvalidElementPrefix_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol>
                                        <ElementPrefix>tr</ElementPrefix>
                                    </DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var dve = protocol.DVEs.DVEProtocols[0];

            // Assert
            Assert.IsNull(dve.ElementPrefix.Value);
        }

        [TestMethod]
        public void DVEProtocol_MissingElementPrefixTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <DVEProtocols>
                                    <DVEProtocol>
                                    </DVEProtocol>
                                </DVEProtocols>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var dve = protocol.DVEs.DVEProtocols[0];

            // Assert
            Assert.IsNull(dve.ElementPrefix);
        }

        #endregion ElementPrefix
    }
}