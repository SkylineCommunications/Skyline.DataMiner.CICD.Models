namespace Models.ProtocolTests.Read.Protocol.Parameters.Display.Trending
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Trending : ProtocolTestBase
    {
        #region Logarithmic

        [TestMethod]
        public void Logarithmic_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending logarithmic='true'>
                                        </Trending>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.Display.Trending.Logarithmic.Value);
        }

        [TestMethod]
        public void Logarithmic_EmptyAttribute_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending logarithmic=''>
                                        </Trending>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Trending.Logarithmic.Value);
        }

        [TestMethod]
        public void Logarithmic_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending logarithmic='abc'>
                                        </Trending>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Trending.Logarithmic.Value);
        }

        [TestMethod]
        public void Logarithmic_MissingAttribute_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending>
                                        </Trending>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Trending.Logarithmic);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending>
                                            <Type>average</Type>
                                        </Trending>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(EnumTrendingType.Average, parameter.Display.Trending.Type.Value);
        }

        [TestMethod]
        public void Type_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending>
                                            <Type>something</Type>
                                        </Trending>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Trending.Type.Value);
        }

        [TestMethod]
        public void Type_EmptyValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending>
                                            <Type></Type>
                                        </Trending>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Trending.Type.Value);
        }

        [TestMethod]
        public void Type_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending>
                                        </Trending>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Display.Trending.Type);
        }

        #endregion
    }
}