namespace Models.ProtocolTests.Read.Protocol.Parameters.Display.Trending
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Type : ProtocolTestBase
    {
        #region Operations

        [TestMethod]
        public void Operations_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending>
                                            <Type operations='test'/>
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
            Assert.AreEqual("test", parameter.Display.Trending.Type.Operations.Value);
        }

        [TestMethod]
        public void Operations_EmptyAttribute_ReturnsEmptyString()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending>
                                            <Type operations=''/>
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
            Assert.AreEqual(String.Empty, parameter.Display.Trending.Type.Operations.Value);
        }

        [TestMethod]
        public void Operations_MissingAttribute_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Trending>
                                            <Type />
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
            Assert.IsNull(parameter.Display.Trending.Type.Operations);
        }

        #endregion
    }
}