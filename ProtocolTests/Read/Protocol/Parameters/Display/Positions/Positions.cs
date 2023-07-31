﻿namespace Models.ProtocolTests.Read.Protocol.Parameters.Display.Positions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Positions : ProtocolTestBase
    {
        [TestMethod]
        public void Positions_NoPositionsAvailable_ReturnsEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions></Positions>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(0, parameter.Display.Positions.Count);
        }

        [TestMethod]
        public void Positions_PositionTagAvailable_ReturnsListOfPositions()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                            </Position>
                                            <Position>
                                            </Position>
                                        </Positions>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(2, parameter.Display.Positions.Count);
        }

        [TestMethod]
        public void GetEnumerator_PositionTagAvailable_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                            </Position>
                                            <Position>
                                            </Position>
                                        </Positions>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Display.Positions.GetEnumerator());
        }
    }
}