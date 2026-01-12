namespace Models.ProtocolTests.Read.Protocol.TreeControls.Hierarchy
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Hierarchy : ProtocolTestBase
    {

        #region Path

        [TestMethod]
        public void Path_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy path='Test'>
                                        <Table/>
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

            // Assert
            Assert.AreEqual("Test", hierarchy.Path.Value);
        }

        [TestMethod]
        public void Path_Empty_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy path=''>
                                        <Table/>
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

            // Assert
            Assert.AreEqual(string.Empty, hierarchy.Path.Value);
        }

        [TestMethod]
        public void Path_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table/>
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

            // Assert
            Assert.IsNull(hierarchy.Path);
        }

        #endregion

        [TestMethod]
        public void Hierarchy_TagsAvailable_ReturnsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table/>
                                        <Table/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.Hierarchy;

            // Assert
            Assert.HasCount(2, details);
        }

        [TestMethod]
        public void Hierarchy_NoTagAvailable_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.Hierarchy;

            // Assert
            Assert.IsEmpty(details);
        }

        [TestMethod]
        public void GetEnumerator_TagsAvailable_IsNotEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <Hierarchy>
                                        <Table/>
                                        <Table/>
                                    </Hierarchy>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.Hierarchy;

            // Assert
            Assert.IsNotNull(details.GetEnumerator());
        }

    }
}
