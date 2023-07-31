namespace Models.ProtocolTests.Read.Protocol.Parameters.Snmp
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TrapMappings : ProtocolTestBase
    {

        [TestMethod]
        public void TrapMappings_NoAvailableChildren_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mappings = param.SNMP.TrapMappings;

            // Assert
            Assert.AreEqual(0, mappings.Count);
        }

        [TestMethod]
        public void TrapMappings_AvailableChildren_ReturnsCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping/>
                                            <TrapMapping/>
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mappings = param.SNMP.TrapMappings;

            // Assert
            Assert.AreEqual(2, mappings.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableChildren_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping\>
                                            <TrapMapping\>
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mappings = param.SNMP.TrapMappings;

            // Assert
            Assert.AreNotEqual(null, mappings.GetEnumerator());
        }

    }
}
