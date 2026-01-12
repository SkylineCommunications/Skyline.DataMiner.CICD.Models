namespace Models.ProtocolTests.Read.Protocol.Parameters.CRC
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class CrcType : ProtocolTestBase
    {
        #region Byteoffset

        [TestMethod]
        public void Byteoffset_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type byteoffset='5'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(5, parameter.CRC.Type.Byteoffset.Value);
        }

        [TestMethod]
        public void Byteoffset_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type byteoffset='0.5'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Byteoffset.Value);
        }

        [TestMethod]
        public void Byteoffset_EmptyAttribute_Returnsnull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type byteoffset=''/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Byteoffset.Value);
        }

        [TestMethod]
        public void Byteoffset_NoAttribute_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Byteoffset);
        }

        #endregion

        #region Groupbytes

        [TestMethod]
        public void Groupbytes_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type groupbytes='5'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("5", parameter.CRC.Type.Groupbytes.Value);
        }

        [TestMethod]
        public void Groupbytes_EmptyAttribute_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type groupbytes=''/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.CRC.Type.Groupbytes.Value);
        }

        [TestMethod]
        public void Groupbytes_NoAttribute_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Groupbytes);
        }

        #endregion

        #region Mod

        [TestMethod]
        public void Mod_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type mod='5'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual((uint?)5, parameter.CRC.Type.Mod.Value);
        }

        [TestMethod]
        public void Mod_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type mod='0.5'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Mod.Value);
        }

        [TestMethod]
        public void Mod_MinusOne_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type mod='-1'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Mod.Value);
        }

        [TestMethod]
        public void Mod_EmptyAttribute_Returnsnull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type mod=''/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Mod.Value);
        }

        [TestMethod]
        public void Mod_NoAttribute_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Mod);
        }

        #endregion

        #region Off

        [TestMethod]
        public void Off_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type off='5'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(5, parameter.CRC.Type.Off.Value);
        }

        [TestMethod]
        public void Off_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type off='0.5'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Off.Value);
        }

        [TestMethod]
        public void Off_EmptyAttribute_Returnsnull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type off=''/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Off.Value);
        }

        [TestMethod]
        public void Off_NoAttribute_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Off);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type options='Test'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("Test", parameter.CRC.Type.Options.Value);
        }

        [TestMethod]
        public void Options_EmptyAttribute_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type options=''/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.CRC.Type.Options.Value);
        }

        [TestMethod]
        public void Options_NoAttribute_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Options);
        }

        #endregion

        #region Totaloffset

        [TestMethod]
        public void Totaloffset_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type totaloffset='5'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual((uint?)5, parameter.CRC.Type.Totaloffset.Value);
        }

        [TestMethod]
        public void Totaloffset_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type totaloffset='0.5'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Totaloffset.Value);
        }

        [TestMethod]
        public void Totaloffset_MinusOne_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type totaloffset='-1'/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Totaloffset.Value);
        }

        [TestMethod]
        public void Totaloffset_EmptyAttribute_Returnsnull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type totaloffset=''/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Totaloffset.Value);
        }

        [TestMethod]
        public void Totaloffset_NoAttribute_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC><Type/></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.CRC.Type.Totaloffset);
        }

        #endregion
    }
}