namespace Models.ProtocolTests.Read.Protocol.TreeControls
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TreeControl : ProtocolTestBase
    {

        #region ReadOnly

        [TestMethod]
        public void ReadOnly_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl readOnly='true'></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsTrue(treeControl.ReadOnly.Value);
        }

        [TestMethod]
        public void ReadOnly_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl readOnly='tru'></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.ReadOnly.Value);
        }

        [TestMethod]
        public void ReadOnly_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl readOnly=''></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.ReadOnly.Value);
        }

        [TestMethod]
        public void ReadOnly_Mising_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.ReadOnly);
        }

        #endregion

        #region ParameterId

        [TestMethod]
        public void ParameterId_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl parameterId='1'></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.AreEqual((uint?) 1, treeControl.ParameterId.Value);
        }

        [TestMethod]
        public void ParameterId_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl parameterId='one'></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.ParameterId.Value);
        }

        [TestMethod]
        public void ParameterId_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl parameterId=''></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.ParameterId.Value);
        }

        [TestMethod]
        public void ParameterId_Mising_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.ParameterId);
        }

        #endregion

        #region HiddenColumns

        [TestMethod]
        public void HiddenColumns_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <HiddenColumns>Test</HiddenColumns>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.AreEqual("Test", treeControl.HiddenColumns.Value);
        }

        [TestMethod]
        public void HiddenColumns_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <HiddenColumns></HiddenColumns>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.AreEqual(String.Empty, treeControl.HiddenColumns.Value);
        }

        [TestMethod]
        public void HiddenColumns_Mising_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.HiddenColumns);
        }

        #endregion

        #region OverrideDisplayColumns

        [TestMethod]
        public void OverrideDisplayColumns_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <OverrideDisplayColumns>Test</OverrideDisplayColumns>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.AreEqual("Test", treeControl.OverrideDisplayColumns.Value);
        }

        [TestMethod]
        public void OverrideDisplayColumns_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <OverrideDisplayColumns></OverrideDisplayColumns>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.AreEqual(String.Empty, treeControl.OverrideDisplayColumns.Value);
        }

        [TestMethod]
        public void OverrideDisplayColumns_Mising_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.OverrideDisplayColumns);
        }

        #endregion

        #region OverrideIconColumns

        [TestMethod]
        public void OverrideIconColumns_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <OverrideIconColumns>Test</OverrideIconColumns>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.AreEqual("Test", treeControl.OverrideIconColumns.Value);
        }

        [TestMethod]
        public void OverrideIconColumns_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <OverrideIconColumns></OverrideIconColumns>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.AreEqual(String.Empty, treeControl.OverrideIconColumns.Value);
        }

        [TestMethod]
        public void OverrideIconColumns_Mising_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.OverrideIconColumns);
        }

        #endregion

        #region ReadonlyColumns

        [TestMethod]
        public void ReadonlyColumns_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ReadonlyColumns>Test</ReadonlyColumns>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.AreEqual("Test", treeControl.ReadonlyColumns.Value);
        }

        [TestMethod]
        public void ReadonlyColumns_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ReadonlyColumns></ReadonlyColumns>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.AreEqual(String.Empty, treeControl.ReadonlyColumns.Value);
        }

        [TestMethod]
        public void ReadonlyColumns_Mising_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl></TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.ReadonlyColumns);
        }

        #endregion

        #region ExtraDetails

        [TestMethod]
        public void ExtraDetails_NoTagAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.ExtraDetails);
        }

        [TestMethod]
        public void ExtraDetails_TagAvailable_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails></ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNotNull(treeControl.ExtraDetails);
        }

        #endregion

        #region ExtraTabs

        [TestMethod]
        public void ExtraTabs_NoTagAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.ExtraTabs);
        }

        [TestMethod]
        public void ExtraTabs_TagAvailable_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs></ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNotNull(treeControl.ExtraTabs);
        }

        #endregion

        #region Hierarchy

        [TestMethod]
        public void Hierarchy_NoTagAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNull(treeControl.Hierarchy);
        }

        [TestMethod]
        public void Hierarchy_TagAvailable_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy></Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            ITreeControls treeControls = protocol.TreeControls;
            var treeControl = treeControls[0];

            // Assert
            Assert.IsNotNull(treeControl.Hierarchy);
        }

        #endregion

    }
}
