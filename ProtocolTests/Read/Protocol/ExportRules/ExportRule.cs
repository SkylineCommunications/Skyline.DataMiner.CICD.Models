namespace Models.ProtocolTests.Read.Protocol.ExportRules
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ExportRule : ProtocolTestBase
    {


        #region Attribute

        [TestMethod]
        public void Attribute_Valid_ReturnsCorrectValue()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule attribute='Test'/>
                            </ExportRules>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual("Test", rule.Attribute.Value);
        }

        [TestMethod]
        public void Attribute_Empty_IsEmpty()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule attribute=''/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual(String.Empty, rule.Attribute.Value);
        }

        [TestMethod]
        public void Attribute_Missing_IsNull()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.IsNull(rule.Attribute);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule name='Test'/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual("Test", rule.Name.Value);
        }

        [TestMethod]
        public void Name_Empty_IsEmpty()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule name=''/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual(String.Empty, rule.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_IsNull()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.IsNull(rule.Name);
        }

        #endregion

        #region Regex

        [TestMethod]
        public void Regex_Valid_ReturnsCorrectValue()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule regex='Test'/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual("Test", rule.Regex.Value);
        }

        [TestMethod]
        public void Regex_Empty_IsEmpty()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule regex=''/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual(String.Empty, rule.Regex.Value);
        }

        [TestMethod]
        public void Regex_Missing_IsNull()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.IsNull(rule.Regex);
        }

        #endregion

        #region Table

        [TestMethod]
        public void Table_Valid_ReturnsCorrectValue()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule table='Test'/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual("Test", rule.Table.Value);
        }

        [TestMethod]
        public void Table_Empty_IsEmpty()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule table=''/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual(String.Empty, rule.Table.Value);
        }

        [TestMethod]
        public void Table_Missing_IsNull()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.IsNull(rule.Table);
        }

        #endregion

        #region Tag

        [TestMethod]
        public void Tag_Valid_ReturnsCorrectValue()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule tag='Test'/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual("Test", rule.Tag.Value);
        }

        [TestMethod]
        public void Tag_Empty_IsEmpty()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule tag=''/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual(String.Empty, rule.Tag.Value);
        }

        [TestMethod]
        public void Tag_Missing_IsNull()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.IsNull(rule.Tag);
        }

        #endregion

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule value='Test'/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual("Test", rule.ValueAttribute.Value);
        }

        [TestMethod]
        public void Value_Empty_IsEmpty()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule value=''/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual(String.Empty, rule.ValueAttribute.Value);
        }

        [TestMethod]
        public void Value_Missing_IsNull()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.IsNull(rule.ValueAttribute);
        }

        #endregion

        #region WhereTag

        [TestMethod]
        public void WhereTag_Valid_ReturnsCorrectValue()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule whereTag='Test'/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual("Test", rule.WhereTag.Value);
        }

        [TestMethod]
        public void WhereTag_Empty_IsEmpty()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule whereTag=''/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual(String.Empty, rule.WhereTag.Value);
        }

        [TestMethod]
        public void WhereTag_Missing_IsNull()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.IsNull(rule.WhereTag);
        }

        #endregion

        #region WhereValue

        [TestMethod]
        public void WhereValue_Valid_ReturnsCorrectValue()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule whereValue='Test'/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual("Test", rule.WhereValue.Value);
        }

        [TestMethod]
        public void WhereValue_Empty_IsEmpty()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule whereValue=''/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.AreEqual(String.Empty, rule.WhereValue.Value);
        }

        [TestMethod]
        public void WhereValue_Missing_IsNull()
        {

            // Arrange.
            string xml = @"<Protocol>
                            <ExportRules>
                                <ExportRule/>
                            </ExportRules>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var rule = protocol.ExportRules[0];

            // Assert
            Assert.IsNull(rule.WhereValue);
        }

        #endregion

    }
}
