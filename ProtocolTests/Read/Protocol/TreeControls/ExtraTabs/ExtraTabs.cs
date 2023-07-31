namespace Models.ProtocolTests.Read.Protocol.TreeControls.ExtraTabs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ExtraTabs : ProtocolTestBase
    {

        [TestMethod]
        public void ExtraTabs_TagsAvailable_ReturnsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab/>
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

            // Assert
            Assert.AreEqual(2, details.Count);
        }

        [TestMethod]
        public void ExtraTabs_NoTagAvailable_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                    </ExtraTabs>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraTabs;

            // Assert
            Assert.AreEqual(0, details.Count);
        }

        [TestMethod]
        public void GetEnumerator_TagsAvailable_IsNotEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraTabs>
                                        <Tab/>
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

            // Assert
            Assert.AreNotEqual(null, details.GetEnumerator());
        }

    }
}
