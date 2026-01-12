namespace Models.ProtocolTests.Read.Protocol.TreeControls.ExtraTabs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TreeControlTab : ProtocolTestBase
    {

        #region Parameter

        [TestMethod]
        public void Parameter_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab parameter='Test'/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.AreEqual("Test", tab.Parameter.Value);
        }

        [TestMethod]
        public void Parameter_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab parameter=''/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.AreEqual(string.Empty, tab.Parameter.Value);
        }

        [TestMethod]
        public void Parameter_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.IsNull(tab.Parameter);
        }

        #endregion

        #region TableId

        [TestMethod]
        public void TableId_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab tableId='1'/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.AreEqual((uint?)1, tab.TableId.Value);
        }

        [TestMethod]
        public void TableId_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab tableId='one'/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.IsNull(tab.TableId.Value);
        }

        [TestMethod]
        public void TableId_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab tableId=''/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.IsNull(tab.TableId.Value);
        }

        [TestMethod]
        public void TableId_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.IsNull(tab.TableId);
        }

        #endregion

        #region Title

        [TestMethod]
        public void Title_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab title='Test'/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.AreEqual("Test", tab.Title.Value);
        }
        
        [TestMethod]
        public void Title_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab title=''/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.AreEqual(string.Empty, tab.Title.Value);
        }

        [TestMethod]
        public void Title_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.IsNull(tab.Title);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab type='Test'/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.AreEqual("Test", tab.Type.Value);
        }

        [TestMethod]
        public void Type_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab type=''/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.AreEqual(string.Empty, tab.Type.Value);
        }

        [TestMethod]
        public void Type_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab/>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;
            var tab = details[0];

            // Assert
            Assert.IsNull(tab.Type);
        }

        #endregion

    }
}
