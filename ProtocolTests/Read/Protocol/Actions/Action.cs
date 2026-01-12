namespace Models.ProtocolTests.Read.Protocol.Actions
{
    using System;
    using System.Collections.Immutable;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    [TestClass]
    public class Action : ProtocolTestBase
    {
        #region Id

        [TestMethod]
        public void Id_ValidId_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action id='10'></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual((uint?)10, action.Id.Value);
        }

        [TestMethod]
        public void Id_InvalidId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action id='ten'></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.IsNull(action.Id.Value);
        }

        [TestMethod]
        public void Id_EmptyId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action id=''></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.IsNull(action.Id.Value);
        }

        [TestMethod]
        public void Id_MissingIdTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.IsNull(action.Id);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Name>Test</Name>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual("Test", action.Name.Value);
        }

        [TestMethod]
        public void Name_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Name></Name>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(String.Empty, action.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.IsNull(action.Name);
        }

        #endregion

        #region Condition

        [TestMethod]
        public void Condition_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Condition>Test</Condition>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual("Test", action.Condition.Value);
        }

        [TestMethod]
        public void Condition_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Condition></Condition>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.AreEqual(String.Empty, action.Condition.Value);
        }

        [TestMethod]
        public void Condition_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action></Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);


            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.IsNull(action.Condition);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_Available_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <Type/>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.IsNotNull(action.Type);
        }

        [TestMethod]
        public void Type_NotAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.IsNull(action.Type);
        }

        #endregion

        #region On

        [TestMethod]
        public void On_Available_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action>
                                    <On></On>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.IsNotNull(action.On);
        }

        [TestMethod]
        public void On_NotAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Actions>
                                <Action
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            // Assert
            Assert.IsNull(action.On);
        }

        [TestMethod]
        public void AggregateActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                                <Param id=""3""></Param>
                                <Param id=""4""></Param>
                                <Param id=""5""></Param>
                                <Param id=""6""></Param>
                                <Param id=""7""></Param>
                                <Param id=""8""></Param>
                                <Param id=""9""></Param>
                                <Param id=""10""></Param>
                                <Param id=""11""></Param>
                                <Param id=""12""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1"">parameter</On>
                                    <Type id=""2"" options=""defaultValue:1,123;equation:regex,2;equationvalue:regex,123,3,;groupby:123:4,456:5;groupbyTable:6;join:7,8;return:9,10;status:11;weight:12"">aggregate</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            // Via On
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);

            // Via Type
            Assert.AreEqual("1", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[2].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
            Assert.AreEqual("3", references[3].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[2].TargetMapping);
            Assert.AreEqual("4", references[4].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[3].TargetMapping);
            Assert.AreEqual("5", references[5].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[4].TargetMapping);
            Assert.AreEqual("6", references[6].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[5].TargetMapping);
            Assert.AreEqual("7", references[7].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[6].TargetMapping);
            Assert.AreEqual("8", references[8].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[7].TargetMapping);
            Assert.AreEqual("9", references[9].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[8].TargetMapping);
            Assert.AreEqual("10", references[10].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[9].TargetMapping);
            Assert.AreEqual("11", references[11].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[10].TargetMapping);
            Assert.AreEqual("12", references[12].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[11].TargetMapping);
        }

        [TestMethod]
        public void AppendActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""728""></Param>
                                <Param id=""721""></Param>
                            </Params>
                            <Actions>
                                <Action id=""407"">
                                    <On id=""728"">parameter</On>
                                    <Type id=""721"" options=""hex-4"">append</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("728", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("721", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
        }

        [TestMethod]
        public void AppendDataActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1"">parameter</On>
                                    <Type id=""2"">append data</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
        }

        [TestMethod]
        public void ChangeLengthActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1"">parameter</On>
                                    <Type id=""2"">change length</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
        }

        [TestMethod]
        public void CloseActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On>protocol</On>
                                    <Type id=""1"">close</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
        }

        [TestMethod]
        public void CopyActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1"">parameter</On>
                                    <Type id=""2"">copy</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
        }

        [TestMethod]
        public void CopyReversActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1"">parameter</On>
                                    <Type id=""2"">copy reverse</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
        }

        [TestMethod]
        public void MergeActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                                <Param id=""3""></Param>
                                <Param id=""4""></Param>
                                <Param id=""5""></Param>
                                <Param id=""6""></Param>
                                <Param id=""7""></Param>
                                <Param id=""8""></Param>
                                <Param id=""9""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On>protocol</On>
                                    <Type id=""1"" options=""destination:1,2;defaultValue:3,123;destinationfindpk:4;limitresult:5;remoteElements:6;resolve:7,8;trigger:9"">merge</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
            Assert.AreEqual("3", references[2].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[2].TargetMapping);
            Assert.AreEqual("4", references[3].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[3].TargetMapping);
            Assert.AreEqual("5", references[4].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[4].TargetMapping);
            Assert.AreEqual("6", references[5].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[5].TargetMapping);
            Assert.AreEqual("7", references[6].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[6].TargetMapping);
            Assert.AreEqual("8", references[7].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[7].TargetMapping);
            Assert.AreEqual("9", references[8].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[8].TargetMapping);
        }

        [TestMethod]
        public void NormalizeActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1"">parameter</On>
                                    <Type id=""2"">normalize</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
        }

        [TestMethod]
        public void ReadFileActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                                <Param id=""3""></Param>
                                <Param id=""4""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On>protocol</On>
                                    <Type id=""1"" returnValue=""2"" nr=""3"" startoffset=""4"">read file</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("3", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
            Assert.AreEqual("2", references[2].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[2].TargetMapping);
            Assert.AreEqual("4", references[3].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[3].TargetMapping);
        }

        [TestMethod]
        public void ReplaceActionCommandRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""2""></Param>
                            </Params>
                            <Commands>
                                <Command id=""1""></Command>
                            </Commands>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1"">command</On>
                                    <Type id=""2"">replace</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.CommandsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
        }

        [TestMethod]
        public void ReplaceActionResponseRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""2""></Param>
                            </Params>
                            <Responses>
                                <Response id=""1""></Response>
                            </Responses>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1"">response</On>
                                    <Type id=""2"">replace</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ResponsesById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
        }

        [TestMethod]
        public void SetAndGetWithWaitActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1"">parameter</On>
                                    <Type id=""2"">set and get with wait</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
        }

        [TestMethod]
        public void SetNextActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""2""></Param>
                            </Params>
                            <Pairs>
                                <Pair id=""1""></Pair>
                            </Pairs>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1"">pair</On>
                                    <Type id=""2"">set next</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.PairsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
        }

        [TestMethod]
        public void SwapColumnActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                                <Param id=""3""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On>protocol</On>
                                    <Type options=""swap:1:2:3"">swap column</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
            Assert.AreEqual("3", references[2].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[2].TargetMapping);
        }

        [TestMethod]
        public void TimeoutActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""3""></Param>
                            </Params>
                            <Pairs>
                                <Pair id=""1""></Pair>
                                <Pair id=""2""></Pair>
                            </Pairs>
                            <Actions>
                                <Action id=""1"">
                                    <On id=""1;2"">pair</On>
                                    <Type id=""3"">timeout</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.PairsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.PairsById, references[1].TargetMapping);
            Assert.AreEqual("3", references[2].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[2].TargetMapping);
        }

        [TestMethod]
        public void WmiActionRelations()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Params>
                                <Param id=""1""></Param>
                                <Param id=""2""></Param>
                                <Param id=""3""></Param>
                                <Param id=""4""></Param>
                                <Param id=""5""></Param>
                                <Param id=""6""></Param>
                            </Params>
                            <Actions>
                                <Action id=""1"">
                                    <On>protocol</On>
                                    <Type returnValue=""1;2"" options=""pwd:3;server:4;uname:5;where:ID:6"">wmi</Type>
                                </Action>
                            </Actions>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var action = protocol.Actions[0];

            var references = protocol.Model.RelationManager.GetForwardReferences(action).ToImmutableList();

            // Assert
            Assert.AreEqual("1", references[0].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[0].TargetMapping);
            Assert.AreEqual("2", references[1].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[1].TargetMapping);
            Assert.AreEqual("3", references[2].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[2].TargetMapping);
            Assert.AreEqual("4", references[3].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[3].TargetMapping);
            Assert.AreEqual("5", references[4].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[4].TargetMapping);
            Assert.AreEqual("6", references[5].TargetId);
            Assert.AreEqual(Mappings.ParamsById, references[5].TargetMapping);
        }


        #endregion
    }
}