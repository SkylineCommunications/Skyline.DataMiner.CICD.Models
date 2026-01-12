using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Parameters.Information
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Include : ProtocolTestBase
    {

        [TestMethod]
        public void Include_RangeInclude_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Information>
                                        <Includes>
                                            <Include>range</Include>
                                        </Includes>
                                    </Information>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var includes = parameter.Information.Includes;

            // Assert
            Assert.AreEqual(Enums.EnumParamInformationInclude.Range, includes[0].Value);
        }

        [TestMethod]
        public void Include_StepsInclude_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Information>
                                        <Includes>
                                            <Include>steps</Include>
                                        </Includes>
                                    </Information>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var includes = parameter.Information.Includes;

            // Assert
            Assert.AreEqual(Enums.EnumParamInformationInclude.Steps, includes[0].Value);
        }

        [TestMethod]
        public void Include_TimeInclude_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Information>
                                        <Includes>
                                            <Include>time</Include>
                                        </Includes>
                                    </Information>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var includes = parameter.Information.Includes;

            // Assert
            Assert.AreEqual(Enums.EnumParamInformationInclude.Time, includes[0].Value);
        }

        [TestMethod]
        public void Include_UnitsInclude_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Information>
                                        <Includes>
                                            <Include>units</Include>
                                        </Includes>
                                    </Information>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
 
            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var includes = parameter.Information.Includes;

            // Assert
            Assert.AreEqual(Enums.EnumParamInformationInclude.Units, includes[0].Value);
        }

        [TestMethod]
        public void Include_InvalidInclude_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Information>
                                        <Includes>
                                            <Include>test</Include>
                                        </Includes>
                                    </Information>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var includes = parameter.Information.Includes;

            // Assert
            Assert.IsNull(includes[0].Value);
        }

        [TestMethod]
        public void Include_EmptyInclude_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Information>
                                        <Includes>
                                            <Include></Include>
                                        </Includes>
                                    </Information>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var includes = parameter.Information.Includes;

            // Assert
            Assert.IsNull(includes[0].Value);
        }

    }
}
