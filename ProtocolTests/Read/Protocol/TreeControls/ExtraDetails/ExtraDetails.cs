namespace Models.ProtocolTests.Read.Protocol.TreeControls.ExtraDetails
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ExtraDetails : ProtocolTestBase
    {

        [TestMethod]
        public void ExtraDetails_TagsAvailable_ReturnsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
                                        <LinkedDetails/>
                                        <LinkedDetails/>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;

            // Assert
            Assert.HasCount(2, details);
        }

        [TestMethod]
        public void ExtraDetails_NoTagAvailable_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;

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
                                    <ExtraDetails>
                                        <LinkedDetails/>
                                        <LinkedDetails/>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;

            // Assert
            Assert.IsNotNull(details.GetEnumerator());
        }

    }
}
