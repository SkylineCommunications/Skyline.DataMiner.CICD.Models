namespace Models.ProtocolTests.Read.Protocol.Parameters.ArrayOptions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ArrayOptions : ProtocolTestBase
    {
        #region Attributes

        #region DeleteRow

        [TestMethod]
        public void DeleteRow_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions deleteRow='true'></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsTrue(arrayOptions.DeleteRow.Value);
        }

        [TestMethod]
        public void DeleteRow_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions deleteRow='tr'></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.DeleteRow.Value);
        }

        [TestMethod]
        public void DeleteRow_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions deleteRow=''></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.DeleteRow.Value);
        }

        [TestMethod]
        public void DeleteRow_NoTagAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.DeleteRow);
        }

        #endregion

        #region DisplayColumn

        [TestMethod]
        public void DisplayColumn_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions displayColumn='10'></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.AreEqual(10u, arrayOptions.DisplayColumn.Value);
        }

        [TestMethod]
        public void DisplayColumn_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions displayColumn=''></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.DisplayColumn.Value);
        }

        [TestMethod]
        public void DisplayColumn_NoTagAvailble_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.DisplayColumn);
        }
        #endregion

        #region Index

        [TestMethod]
        public void Index_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions index='10'></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.AreEqual(10u, arrayOptions.Index.Value);
        }

        [TestMethod]
        public void Index_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions index=''></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.Index.Value);
        }

        [TestMethod]
        public void Index_NoTagAvailble_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.Index);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions options='Test'></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.AreEqual("Test", arrayOptions.Options.Value);
        }

        [TestMethod]
        public void Options_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions options=''></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.AreEqual(String.Empty, arrayOptions.Options.Value);
        }

        [TestMethod]
        public void Options_NoTagAvailble_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.Options);
        }

        #endregion

        #region Partial

        [TestMethod]
        public void Partial_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions partial='Test'></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.AreEqual("Test", arrayOptions.Partial.Value);
        }

        [TestMethod]
        public void Partial_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions partial=''></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.AreEqual(String.Empty, arrayOptions.Partial.Value);
        }

        [TestMethod]
        public void Partial_NoTagAvailble_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.Partial);
        }

        #endregion

        #region SnmpIndex

        [TestMethod]
        public void SnmpIndex_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions snmpIndex='Test'></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.AreEqual("Test", arrayOptions.SnmpIndex.Value);
        }

        [TestMethod]
        public void SnmpIndex_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions snmpIndex=''></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.AreEqual(String.Empty, arrayOptions.SnmpIndex.Value);
        }

        [TestMethod]
        public void SnmpIndex_NoTagAvailble_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.SnmpIndex);
        }

        #endregion

        #endregion

        #region Tags
        
        #region ColumnOption

        [TestMethod]
        public void ArrayOptions_NoTagsAvailable_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id='1'>
                                    <ArrayOptions></ArrayOptions>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsEmpty(arrayOptions);
        }

        [TestMethod]
        public void ArrayOptions_AvailableColumnOptions_ReturnsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id='1'>
                                    <ArrayOptions>
                                        <ColumnOption/>
                                        <ColumnOption/>
                                    </ArrayOptions>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.HasCount(2, arrayOptions);
        }

        [TestMethod]
        public void GetEnumerator_AvailableColumnOptions_ReturnEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id='1'>
                                    <ArrayOptions>
                                        <ColumnOption/>
                                        <ColumnOption/>
                                    </ArrayOptions>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNotNull(arrayOptions.GetEnumerator());
        }

        #endregion

        #region NamingFormat

        [TestMethod]
        public void NamingFormat_NoTagAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id='1'>
                                    <ArrayOptions></ArrayOptions>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.IsNull(arrayOptions.NamingFormat);
        }


        [TestMethod]
        public void NamingFormat_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id='1'>
                                    <ArrayOptions><NamingFormat>Test</NamingFormat></ArrayOptions>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.AreEqual("Test", arrayOptions.NamingFormat.Value);
        }

        [TestMethod]
        public void NamingFormat_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id='1'>
                                    <ArrayOptions><NamingFormat></NamingFormat></ArrayOptions>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;

            // Assert
            Assert.AreEqual(String.Empty, arrayOptions.NamingFormat.Value);
        }

        #endregion

        #endregion

        #region Methods
        
        #endregion
    }
}

/*

        [TestMethod]
        public void METHOD_WHAT_OUTCOME()
        {
            // Arrange.
            string xml = @"";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
        }

     */
