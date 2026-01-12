namespace Models.ProtocolTests.Read.Protocol.Parameters.Display.ParametersView
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ParametersView : ProtocolTestBase
    {
        #region Attributes

        #region Type

        [TestMethod]
        public void Type_ValidValue_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
				                        <ParametersView type='column'>     
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
            Assert.AreEqual(EnumParametersViewType.Column, parameter.Display.ParametersView.Type.Value);
        }

        [TestMethod]
        public void Type_InvalidValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
				                        <ParametersView type='abc'>     
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
            Assert.IsNull(parameter.Display.ParametersView.Type.Value);
        }

        [TestMethod]
        public void Type_EmptyValue_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
				                        <ParametersView type=''>     
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
            Assert.IsNull(parameter.Display.ParametersView.Type.Value);
        }

        [TestMethod]
        public void Type_MissingAttribute_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
				                        <ParametersView>     
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
            Assert.IsNull(parameter.Display.ParametersView.Type);
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
                                        <ParametersView options='abc'>
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
            Assert.AreEqual("abc", parameter.Display.ParametersView.Options.Value);
        }

        [TestMethod]
        public void Options_EmptyValue_ReturnsEmptyString()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView options=''>
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
            Assert.AreEqual(String.Empty, parameter.Display.ParametersView.Options.Value);
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
            Assert.IsNull(parameter.Display.ParametersView.Options);
        }

        #endregion

        #endregion

        #region SubTags

        [TestMethod]
        public void ParametersView_NoParametersTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
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
            Assert.IsNull(parameter.Display.ParametersView.Parameters);
        }

        [TestMethod]
        public void ParametersView_NoParameters_ReturnsEmptyList()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters></Parameters>
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
            Assert.IsEmpty(parameter.Display.ParametersView.Parameters);
        }

        [TestMethod]
        public void ParametersView_ParametersTagAvailable_ReturnsListOfParameters()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter />
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
            Assert.HasCount(2, parameter.Display.ParametersView.Parameters);
        }

        [TestMethod]
        public void GetEnumerator_ParameterTagAvailable_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param>
                                    <Display>
                                        <ParametersView>
                                            <Parameters>
                                                <Parameter />
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
            Assert.IsNotNull(parameter.Display.ParametersView.Parameters.GetEnumerator());
        }

        #endregion
    }
}