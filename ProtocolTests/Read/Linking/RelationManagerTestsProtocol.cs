namespace Models.ProtocolTests.Read.Linking
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.ProtocolTests.Read.Protocol;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class RelationManagerTestsProtocol: ProtocolTestBase
    {
        [TestMethod]
        public void RelationManager_Protocol_ParamDuplicateAs()
        {
            string xml = @"
<Protocol>
    <Params>
        <Param id=""1"" duplicateAs=""2,3"" />
    </Params>
    <Groups>
        <Group id=""1"">
            <Content>
                <Param>1</Param>
                <Param>2</Param>
                <Param>3</Param>
            </Content>
        </Group>
    </Groups>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            var param1 = model.Protocol.Params[0];
            var group1 = model.Protocol.Groups[0];

            var linksParam = model.RelationManager.GetLinks(param1).ToList();
            Assert.AreEqual(3, linksParam.Count);

            var linksGroup = model.RelationManager.GetLinks(group1).ToList();
            Assert.AreEqual(3, linksGroup.Count);

        }
    }
}
