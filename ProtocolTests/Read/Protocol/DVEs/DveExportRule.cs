namespace Models.ProtocolTests.Read.Protocol.DVEs
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class DveExportRule : ProtocolTestBase
    {
        #region Tag

        [TestMethod]
        public void ExportRule_ValidTag_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule tag='Test'/> 
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.DVEs.ExportRules[0];

            // Assert
            Assert.AreEqual("Test", rule.Tag.Value);
        }

        [TestMethod]
        public void ExportRule_EmptyTag_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule tag=''/> 
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.DVEs.ExportRules[0];

            // Assert
            Assert.AreEqual(String.Empty, rule.Tag.Value);
        }

        [TestMethod]
        public void ExportRule_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule/> 
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.DVEs.ExportRules[0];

            // Assert
            Assert.AreEqual(null, rule.Tag);
        }

        #endregion

        #region Value

        [TestMethod]
        public void ExportRule_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule value='Test'/> 
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.DVEs.ExportRules[0];

            // Assert
            Assert.AreEqual("Test", rule.ValueAttribute.Value);
        }

        [TestMethod]
        public void ExportRule_EmptyValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule value=''/> 
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.DVEs.ExportRules[0];

            // Assert
            Assert.AreEqual(String.Empty, rule.ValueAttribute.Value);
        }

        [TestMethod]
        public void ExportRule_MissingValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule/> 
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.DVEs.ExportRules[0];

            // Assert
            Assert.AreEqual(null, rule.ValueAttribute);
        }

        #endregion

        #region Table

        [TestMethod]
        public void ExportRule_ValidTable_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule table='10'/> 
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.DVEs.ExportRules[0];

            // Assert
            Assert.AreEqual("10", rule.Table.Value);
        }

        [TestMethod]
        public void ExportRule_EmptyTable_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule table=''/> 
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.DVEs.ExportRules[0];

            // Assert
            Assert.AreEqual("", rule.Table.Value);
        }

        [TestMethod]
        public void ExportRule_MissingTable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <DVEs>
                                <ExportRules>
                                    <ExportRule/> 
                                </ExportRules>
                            </DVEs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.DVEs.ExportRules[0];

            // Assert
            Assert.AreEqual(null, rule.Table);
        }
        #endregion
    }
}