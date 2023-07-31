using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ProtocolDisplay : ProtocolTestBase
    {
        #region Default Page

        [TestMethod]
        public void DefaultPage_ValidDefaultPage_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Display defaultPage='General'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("General", protocol.Display.DefaultPage.Value);
        }

        [TestMethod]
        public void DefaultPage_ValidDefaultPageWithSpecialCharacters_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Display defaultPage='A &amp; B'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("A & B", protocol.Display.DefaultPage.Value);
        }

        [TestMethod]
        public void DefaultPage_EmptyDefaultPage_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Display defaultPage=''/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(string.Empty, protocol.Display.DefaultPage.Value);
        }

        [TestMethod]
        public void DefaultPage_MissingDefaultPage_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Display/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Display.DefaultPage);
        }

        #endregion

        #region Page Order

        [TestMethod]
        public void PageOrder_ValidPageOrder_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Display pageOrder='General;System;Config'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("General;System;Config", protocol.Display.PageOrder.Value);
        }

        [TestMethod]
        public void PageOrder_ValidPageOrderWithSpecialCharacters_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Display pageOrder='General;A &amp; B;Config'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("General;A & B;Config", protocol.Display.PageOrder.Value);
        }

        [TestMethod]
        public void PageOrder_EmptyPageOrder_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Display pageOrder=''/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Display.PageOrder.Value);
        }

        [TestMethod]
        public void PageOrder_MissingPageOrder_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Display/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Display.DefaultPage);
        }

        #endregion

        #region Wide Column Pages

        [TestMethod]
        public void WideColumnPages_ValidWideColumnPages_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Display wideColumnPages='General;System;Config'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("General;System;Config", protocol.Display.WideColumnPages.Value);
        }

        [TestMethod]
        public void WideColumnPages_ValidWideColumnPagesWithSpecialCharacters_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Display wideColumnPages='General;A &amp; B;Config'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("General;A & B;Config", protocol.Display.WideColumnPages.Value);
        }

        [TestMethod]
        public void WideColumnPages_EmptyWideColumnPages_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Display wideColumnPages=''/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
 
            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Display.WideColumnPages.Value);
        }

        [TestMethod]
        public void WideColumnPages_MissingWideColumnPages_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Display/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Display.WideColumnPages);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_SpectrumAnalyzer_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Display type='spectrum analyzer'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumDisplayType.SpectrumAnalyzer, protocol.Display.Type.Value);
        }


        [TestMethod]
        public void Type_ElementManager_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Display type='element manager'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(Enums.EnumDisplayType.ElementManager, protocol.Display.Type.Value);
        }

        [TestMethod]
        public void Type_InvalidType_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol><Display type='spectyzer'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Display.Type.Value);
        }

        [TestMethod]
        public void Type_EmptyType_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Display type=''/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Display.Type.Value);
        }

        [TestMethod]
        public void Type_MissingType_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Display/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Display.Type);
        }


        #endregion
    }
}
