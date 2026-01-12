namespace Models.ProtocolTests.Read.Protocol.TreeControls.Hierarchy
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class HierarchyTable : ProtocolTestBase
    {

        #region Condition

        [TestMethod]
        public void Condition_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table condition='Test'/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.AreEqual("Test", table.Condition.Value);
        }

        [TestMethod]
        public void Condition_IsEmpty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table condition=''/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.AreEqual(string.Empty, table.Condition.Value);
        }

        [TestMethod]
        public void Condition_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.IsNull(table.Condition);
        }

        #endregion

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table id='1'/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.AreEqual((uint?) 1, table.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table id='one'/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.IsNull(table.Id.Value);
        }


        [TestMethod]
        public void Id_IsEmpty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table id=''/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.IsNull(table.Id.Value);
        }

        [TestMethod]
        public void Id_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.IsNull(table.Id);
        }

        #endregion

        #region Parent

        [TestMethod]
        public void Parent_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table parent='1'/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.AreEqual((uint?) 1, table.ParentAttribute.Value);
        }

        [TestMethod]
        public void Parent_InvalParent_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table parent='one'/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.IsNull(table.ParentAttribute.Value);
        }


        [TestMethod]
        public void Parent_IsEmpty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table parent=''/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.IsNull(table.ParentAttribute.Value);
        }

        [TestMethod]
        public void Parent_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var hierarchy = treeControl.Hierarchy;
            var table = hierarchy[0];

            // Assert
            Assert.IsNull(table.ParentAttribute);
        }

        #endregion

    }
}
