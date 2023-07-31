﻿namespace Models.ProtocolTests.Read.Protocol.Pairs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ResponseCommandContent : ProtocolTestBase
    {

        #region Value

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content>
                                        <Response>2</Response>
                                    </Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];
            var command = pair.Content[0];

            // Assert
            Assert.AreEqual((uint?)2, command.Value);
        }

        [TestMethod]
        public void Value_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content>
                                        <Response>ten</Response>
                                    </Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];
            var command = pair.Content[0];

            // Assert
            Assert.AreEqual(null, command.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Pairs>
                                <Pair>
                                    <Content>
                                        <Response></Response>
                                    </Content>
                                </Pair>
                            </Pairs>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var pair = protocol.Pairs[0];
            var command = pair.Content[0];

            // Assert
            Assert.AreEqual(null, command.Value);
        }

        #endregion

    }
}
