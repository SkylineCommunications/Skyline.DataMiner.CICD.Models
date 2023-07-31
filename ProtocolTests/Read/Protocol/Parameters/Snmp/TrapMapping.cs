namespace Models.ProtocolTests.Read.Protocol.Parameters.Snmp
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class TrapMapping : ProtocolTestBase
    {

        #region BindingMatch

        [TestMethod]
        public void BindingMatch_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping bindingMatch='Value'/>
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mapping = param.SNMP.TrapMappings[0];

            // Assert
            Assert.AreEqual("Value", mapping.BindingMatch.Value);
        }

        [TestMethod]
        public void BindingMatch_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping bindingMatch=''/>
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mapping = param.SNMP.TrapMappings[0];

            // Assert
            Assert.AreEqual(String.Empty, mapping.BindingMatch.Value);
        }

        [TestMethod]
        public void BindingMatch_NoTagAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping />
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mapping = param.SNMP.TrapMappings[0];

            // Assert
            Assert.AreEqual(null, mapping.BindingMatch);
        }

        #endregion

        #region Severity

        [TestMethod]
        public void Severity_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping severity='Value'/>
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mapping = param.SNMP.TrapMappings[0];

            // Assert
            Assert.AreEqual("Value", mapping.Severity.Value);
        }

        [TestMethod]
        public void Severity_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping severity=''/>
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mapping = param.SNMP.TrapMappings[0];

            // Assert
            Assert.AreEqual(String.Empty, mapping.Severity.Value);
        }

        [TestMethod]
        public void Severity_NoTagAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping />
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mapping = param.SNMP.TrapMappings[0];

            // Assert
            Assert.AreEqual(null, mapping.Severity);
        }

        #endregion

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping value='Value'/>
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mapping = param.SNMP.TrapMappings[0];

            // Assert
            Assert.AreEqual("Value", mapping.ValueAttribute.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping value=''/>
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mapping = param.SNMP.TrapMappings[0];

            // Assert
            Assert.AreEqual(String.Empty, mapping.ValueAttribute.Value);
        }

        [TestMethod]
        public void Value_NoTagAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <SNMP>
                                        <TrapMappings>
                                            <TrapMapping />
                                        </TrapMappings>
                                    </SNMP>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];
            var mapping = param.SNMP.TrapMappings[0];

            // Assert
            Assert.AreEqual(null, mapping.ValueAttribute);
        }

        #endregion

    }
}
