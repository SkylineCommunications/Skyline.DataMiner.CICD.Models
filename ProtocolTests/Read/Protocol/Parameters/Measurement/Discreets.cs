namespace Models.ProtocolTests.Read.Protocol.Parameters.Measurement
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Discreets : ProtocolTestBase
    {

        #region Dependency Id

        [TestMethod]
        public void DependencyId_ValidDependencyId_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='10'></Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual((uint)10, parameter.Measurement.Discreets.DependencyId.Value);
        }

        [TestMethod]
        public void DependencyId_InvalidDependencyId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='ten'></Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement.Discreets.DependencyId.Value);
        }

        [TestMethod]
        public void DependencyId_EmptyDependencyId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId=''></Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement.Discreets.DependencyId.Value);
        }

        [TestMethod]
        public void DependencyId_MissingDependencyIdTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets></Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement.Discreets.DependencyId);
        }

        #endregion

        [TestMethod]
        public void Discreets_NoAvailableDiscreets_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='10'>
                                        </Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(0, parameter.Measurement.Discreets.Count);
        }

        [TestMethod]
        public void Discreets_AvailableDiscreets_ReturnDiscreetCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='10'>
                                           <Discreet></Discreet>
                                           <Discreet></Discreet>
                                        </Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(2, parameter.Measurement.Discreets.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableDiscreets_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Measurement>
                                        <Discreets dependencyId='10'>
                                           <Discreet></Discreet>
                                           <Discreet></Discreet>
                                        </Discreets>
                                    </Measurement>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(2, parameter.Measurement.Discreets.GetEnumerator());
        }

    }
}
