namespace Models.ProtocolTests.Read.Protocol.ParameterGroups
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ParameterGroupParams : ProtocolTestBase
    {

        [TestMethod]
        public void ParameterGroupParams_NoAvailableParams_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>
                                    <Params>
                                    </Params>
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var paramGroupsParams = paramGroups[0].Params;

            // Assert
            Assert.IsEmpty(paramGroupsParams);
        }

        [TestMethod]
        public void ParameterGroupParams_AvailableParams_ReturnTriggerCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>
                                    <Params>
                                        <Param/>
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

            // Assert
            Assert.HasCount(2, paramGroupsParams);
        }

        [TestMethod]
        public void GetEnumerator_AvailableParams_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>
                                    <Params>
                                        <Param/>
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

            // Assert
            Assert.IsNotNull(paramGroupsParams.GetEnumerator());
        }

    }
}
