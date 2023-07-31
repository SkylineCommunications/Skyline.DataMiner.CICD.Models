namespace Models.ProtocolTests.Read.Protocol.Parameters.Display.ParametersView
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ParametersViewParameter : ProtocolTestBase
    {
        #region Id

        [TestMethod]
        public void Id_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter id='2' />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual((uint?)2, parameter.Display.ParametersView.Parameters[0].Id.Value);
        }

        [TestMethod]
        public void Id_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter id='abc' />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Display.ParametersView.Parameters[0].Id.Value);
        }

        [TestMethod]
        public void Id_EmptyValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter id='' />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Display.ParametersView.Parameters[0].Id.Value);
        }

        [TestMethod]
        public void Id_MinusOne_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter id='-1' />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Display.ParametersView.Parameters[0].Id.Value);
        }

        [TestMethod]
        public void Id_MissingAttribute_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Display.ParametersView.Parameters[0].Id);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter options='abc' />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("abc", parameter.Display.ParametersView.Parameters[0].Options.Value);
        }

        [TestMethod]
        public void Options_EmptyValue_ReturnsEmptyString()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter options='' />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Display.ParametersView.Parameters[0].Options.Value);
        }

        [TestMethod]
        public void Options_MissingAttribute_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Display.ParametersView.Parameters[0].Options);
        }

        #endregion

        #region TableIndex

        [TestMethod]
        public void TableIndex_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter tableIndex='abc' />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("abc", parameter.Display.ParametersView.Parameters[0].TableIndex.Value);
        }

        [TestMethod]
        public void TableIndex_EmptyValue_ReturnsEmptyString()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter tableIndex='' />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Display.ParametersView.Parameters[0].TableIndex.Value);
        }

        [TestMethod]
        public void TableIndex_MissingAttribute_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter />
                                            </Parameters>
                                        </ParametersView>
                                    </Display>
                                </Param>
                            </Params>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Display.ParametersView.Parameters[0].TableIndex);
        }

        #endregion
    }
}