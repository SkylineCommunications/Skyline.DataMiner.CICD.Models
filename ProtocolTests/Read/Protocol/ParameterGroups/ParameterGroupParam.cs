namespace Models.ProtocolTests.Read.Protocol.ParameterGroups
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ParameterGroupParam : ProtocolTestBase
    {

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>
                                    <Params>
                                        <Param id='1'/>        
                                    </Params>
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var paramGroupsParams = paramGroups[0].Params;
            var parameter = paramGroupsParams[0];

            // Assert
            Assert.AreEqual((uint?) 1, parameter.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>
                                    <Params>
                                        <Param id='one'/>        
                                    </Params>
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var paramGroupsParams = paramGroups[0].Params;
            var parameter = paramGroupsParams[0];

            // Assert
            Assert.IsNull(parameter.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>
                                    <Params>
                                        <Param id=''/>        
                                    </Params>
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var paramGroupsParams = paramGroups[0].Params;
            var parameter = paramGroupsParams[0];

            // Assert
            Assert.IsNull(parameter.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>
                                    <Params>
                                        <Param/>        
                                    </Params>
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var paramGroupsParams = paramGroups[0].Params;
            var parameter = paramGroupsParams[0];

            // Assert
            Assert.IsNull(parameter.Id);
        }

        #endregion

        #region Index

        [TestMethod]
        public void Index_ValIndex_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>
                                    <Params>
                                        <Param index='value'/>        
                                    </Params>
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var paramGroupsParams = paramGroups[0].Params;
            var parameter = paramGroupsParams[0];

            // Assert
            Assert.AreEqual("value", parameter.Index.Value);
        }

        [TestMethod]
        public void Index_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>
                                    <Params>
                                        <Param index=''/>        
                                    </Params>
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var paramGroupsParams = paramGroups[0].Params;
            var parameter = paramGroupsParams[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Index.Value);
        }

        [TestMethod]
        public void Index_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>
                                    <Params>
                                        <Param />        
                                    </Params>
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var paramGroupsParams = paramGroups[0].Params;
            var parameter = paramGroupsParams[0];

            // Assert
            Assert.IsNull(parameter.Index);
        }

        #endregion

    }
}
