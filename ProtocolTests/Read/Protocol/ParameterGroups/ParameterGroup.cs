using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.ParameterGroups
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ParameterGroup : ProtocolTestBase
    {

        #region DynamicId

        [TestMethod]
        public void DynamicId_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group dynamicId='1'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual((uint?) 1, group.DynamicId.Value);
        }

        [TestMethod]
        public void DynamicId_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group dynamicId='one'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.DynamicId.Value);
        }

        [TestMethod]
        public void DynamicId_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group dynamicId=''>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.DynamicId.Value);
        }

        [TestMethod]
        public void DynamicId_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.DynamicId);
        }

        #endregion

        #region DynamicIndex

        [TestMethod]
        public void DynamicIndex_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group dynamicIndex='Value'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual("Value", group.DynamicIndex.Value);
        }

        [TestMethod]
        public void DynamicIndex_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group dynamicIndex=''>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(String.Empty, group.DynamicIndex.Value);
        }

        [TestMethod]
        public void DynamicIndex_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.DynamicIndex);
        }

        #endregion

        #region DynamicUsePK

        [TestMethod]
        public void DynamicUsePK_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group dynamicUsePK='true'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(true, group.DynamicUsePK.Value);
        }

        [TestMethod]
        public void DynamicUsePK_Invalid_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group dynamicUsePK='rfrf'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.DynamicUsePK.Value);
        }

        [TestMethod]
        public void DynamicUsePK_Empty_IsFalse()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group dynamicUsePK=''>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.DynamicUsePK.Value);
        }

        [TestMethod]
        public void DynamicUsePK_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.DynamicUsePK);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group name='Value'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual("Value", group.Name.Value);
        }

        [TestMethod]
        public void Name_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group name=''>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(String.Empty, group.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.Name);
        }

        #endregion

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group id='1'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual((uint?)1, group.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group id='one'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group id=''>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.Id);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_Valid_ReturnsIn()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group type='in'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamGroupType.In, group.Type.Value);
        }

        [TestMethod]
        public void Type_Valid_ReturnsInOut()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group type='inout'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamGroupType.Inout, group.Type.Value);
        }

        [TestMethod]
        public void Type_Valid_ReturnsOut()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group type='out'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamGroupType.Out, group.Type.Value);
        }

        [TestMethod]
        public void Type_Empty_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group type='efzf'>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.Type.Value);
        }

        [TestMethod]
        public void Type_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group type=''>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.Type.Value);
        }

        [TestMethod]
        public void Type_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <ParameterGroups>
                                <Group>                                    
                                </Group>
                            </ParameterGroups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IParameterGroups paramGroups = protocol.ParameterGroups;
            var group = paramGroups[0];

            // Assert
            Assert.AreEqual(null, group.Type);
        }

        #endregion

    }
}
