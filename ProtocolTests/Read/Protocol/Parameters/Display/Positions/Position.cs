namespace Models.ProtocolTests.Read.Protocol.Parameters.Display.Positions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Position : ProtocolTestBase
    {
        #region Page

        [TestMethod]
        public void Page_ValidPageValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Page>General</Page>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.AreEqual("General", position.Page.Value);
        }

        [TestMethod]
        public void Page_ValidPageValueWithSpecialCharacters_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Page>A &amp; B</Page>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.AreEqual("A & B", position.Page.Value);
        }

        [TestMethod]
        public void Page_EmptyPageValue_ReturnsCorrectValueEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Page></Page>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.AreEqual(String.Empty, position.Page.Value);
        }

        [TestMethod]
        public void Page_MissingPageValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.IsNull(position.Page);
        }

        #endregion

        #region Row

        [TestMethod]
        public void Row_ValidRowValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Row>0</Row>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.AreEqual((uint?)0, position.Row.Value);
        }

        [TestMethod]
        public void Row_InvalidRowValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Row>nul</Row>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.IsNull(position.Row.Value);
        }

        [TestMethod]
        public void Row_EmptyRowValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Row></Row>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.IsNull(position.Row.Value);
        }

        [TestMethod]
        public void Row_MissingRowTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.IsNull(position.Row);
        }

        #endregion

        #region Column

        [TestMethod]
        public void Col_ValidColValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Column>0</Column>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.AreEqual((uint?)0, position.Column.Value);
        }

        [TestMethod]
        public void Col_InvalidColValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Column>nul</Column>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.IsNull(position.Column.Value);
        }

        [TestMethod]
        public void Col_EmptyColValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
                                            <Position>
                                                <Column></Column>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.IsNull(position.Column.Value);
        }

        [TestMethod]
        public void Col_MissingColTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <Positions>
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
            IParamsParamDisplayPositionsPosition position = parameter.Display.Positions[0];

            // Assert
            Assert.IsNull(position.Column);
        }

        #endregion
    }
}