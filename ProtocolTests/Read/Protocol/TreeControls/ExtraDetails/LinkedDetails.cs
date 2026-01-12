namespace Models.ProtocolTests.Read.Protocol.TreeControls.ExtraDetails
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class LinkedDetails : ProtocolTestBase
    {

        #region DetailsTableId

        [TestMethod]
        public void DetailsTableId_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
                                        <LinkedDetails detailsTableId='1'/>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;
            var detail = details[0];

            // Assert
            Assert.AreEqual((uint?) 1, detail.DetailsTableId.Value);
        }
    
        [TestMethod]
        public void DetailsTableId_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
                                        <LinkedDetails detailsTableId='one'/>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;
            var detail = details[0];

            // Assert
            Assert.IsNull(detail.DetailsTableId.Value);
        }

        [TestMethod]
        public void DetailsTableId_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
                                        <LinkedDetails detailsTableId=''/>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;
            var detail = details[0];

            // Assert
            Assert.IsNull(detail.DetailsTableId.Value);
        }

        [TestMethod]
        public void DetailsTableId_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
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
            var detail = details[0];

            // Assert
            Assert.IsNull(detail.DetailsTableId);
        }

        #endregion

        #region DiscreetColumnId

        [TestMethod]
        public void DiscreetColumnId_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
                                        <LinkedDetails discreetColumnId='1'/>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;
            var detail = details[0];

            // Assert
            Assert.AreEqual((uint?)1, detail.DiscreetColumnId.Value);
        }

        [TestMethod]
        public void DiscreetColumnId_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
                                        <LinkedDetails discreetColumnId='one'/>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;
            var detail = details[0];

            // Assert
            Assert.IsNull(detail.DiscreetColumnId.Value);
        }

        [TestMethod]
        public void DiscreetColumnId_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
                                        <LinkedDetails discreetColumnId=''/>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;
            var detail = details[0];

            // Assert
            Assert.IsNull(detail.DiscreetColumnId.Value);
        }

        [TestMethod]
        public void DiscreetColumnId_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
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
            var detail = details[0];

            // Assert
            Assert.IsNull(detail.DiscreetColumnId);
        }

        #endregion

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
                                        <LinkedDetails value='Test'/>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;
            var detail = details[0];

            // Assert
            Assert.AreEqual("Test", detail.ValueAttribute.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
                                        <LinkedDetails value=''/>
                                    </ExtraDetails>
                                </TreeControl>
                            </TreeControls>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var treeControl = protocol.TreeControls[0];
            var details = treeControl.ExtraDetails;
            var detail = details[0];

            // Assert
            Assert.AreEqual(string.Empty, detail.ValueAttribute.Value);
        }

        [TestMethod]
        public void Value_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <TreeControls>
                                <TreeControl>
                                    <ExtraDetails>
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
            var detail = details[0];

            // Assert
            Assert.IsNull(detail.ValueAttribute);
        }

        #endregion


    }
}
