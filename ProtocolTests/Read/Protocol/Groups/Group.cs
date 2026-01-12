using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

namespace Models.ProtocolTests.Read.Protocol.Groups
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    [TestClass]
    public class Group : ProtocolTestBase
    {

        #region Id

        [TestMethod]
        public void Id_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group id='10'></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual((uint?)10, group.Id.Value);
        }

        [TestMethod]
        public void Id_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group id='ten'></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.IsNull(group.Id.Value);
        }

        [TestMethod]
        public void Id_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group id=''></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.IsNull(group.Id.Value);
        }

        [TestMethod]
        public void Id_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.IsNull(group.Id);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Name>Test</Name></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual("Test", group.Name.Value);
        }

        [TestMethod]
        public void Name_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Name></Name></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual(String.Empty, group.Name.Value);
        }

        [TestMethod]
        public void Name_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.IsNull(group.Name);
        }
        #endregion

        #region Description

        [TestMethod]
        public void Description_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Description>Test</Description></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual("Test", group.Description.Value);
        }

        [TestMethod]
        public void Description_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Description></Description></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual(String.Empty, group.Description.Value);
        }

        [TestMethod]
        public void Description_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.IsNull(group.Description);
        }
        #endregion

        #region Type

        [TestMethod]
        public void Type_Poll_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Type>poll</Type></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual(Enums.EnumGroupType.Poll, group.Type.Value);
        }

        [TestMethod]
        public void Type_Action_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Type>action</Type></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual(Enums.EnumGroupType.Action, group.Type.Value);
        }

        [TestMethod]
        public void Type_PollAction_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Type>poll action</Type></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual(Enums.EnumGroupType.PollAction, group.Type.Value);
        }

        [TestMethod]
        public void Type_PollTrigger_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Type>poll trigger</Type></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual(Enums.EnumGroupType.PollTrigger, group.Type.Value);
        }

        [TestMethod]
        public void Type_Trigger_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Type>trigger</Type></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual(Enums.EnumGroupType.Trigger, group.Type.Value);
        }

        [TestMethod]
        public void Type_Empty_ReturnNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Type></Type></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.IsNull(group.Type.Value);
        }

        [TestMethod]
        public void Type_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.IsNull(group.Type);
        }
        #endregion

        #region Condition

        [TestMethod]
        public void Condition_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Condition>Test</Condition></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual("Test", group.Condition.Value);
        }

        [TestMethod]
        public void Condition_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Condition></Condition></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.AreEqual(String.Empty, group.Condition.Value);
        }

        [TestMethod]
        public void Condition_Missing_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml); ;

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.IsNull(group.Condition);
        }
        #endregion

        #region Content

        [TestMethod]
        public void Content_MissingTag_Null()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.IsNull(group.Content);
        }

        [TestMethod]
        public void Content_AvailableTag_NotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Groups>
                                <Group><Content></Content></Group>
                            </Groups>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];

            // Assert
            Assert.IsNotNull(group.Content);
        }


        #endregion

        [TestMethod]
        public void GetRelations_NoConnectionPID_EmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Groups>
		<Group id='2'>
			<Name>After Startup</Name>
			<Description>After Startup</Description>
			<Type>poll action</Type>
			<Content>
			</Content>
		</Group>
	</Groups>
         </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var relations = ((IRelationEvaluator)group).GetRelations().ToList();

            // Assert
            Assert.IsEmpty(relations);
        }

        [TestMethod]
        public void GetRelations_ConnectionPidNotEmpty_ReferenceToOtherParam()
        {
            // Arrange.
            // Arrange.
            string xml = @"<Protocol>
	<Groups>
		<Group id='2' connectionPID='2'>
			<Name>After Startup</Name>
			<Description>After Startup</Description>
			<Type>poll action</Type>
			<Content>
			</Content>
		</Group>
	</Groups>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var group = protocol.Groups[0];
            var relations = ((IRelationEvaluator)group).GetRelations().ToList();

            // Assert
            var reference = relations.First();
            Assert.HasCount(1, relations);
            Assert.AreEqual("2", reference.TargetId);
        }
    }
}
