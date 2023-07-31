namespace Models.ProtocolTests.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.ProtocolTests.Read.Protocol;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class IReadableExtensionsTests : ProtocolTestBase
    {
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void GetIdentifierTest(string xml, Func<ProtocolModel, IReadable> getItem, string expectedResult)
        {
            // Arrange
            ProtocolModel model = CreateModelFromXML(xml);
            IReadable node = getItem.Invoke(model);
            
            // Act
            string result = node.GetIdentifier();
            
            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        private static IEnumerable<object[]> GetTestData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    "<Protocol />",
                    (Func<ProtocolModel, IReadable>)(a => null),
                    ""
                },
                new object[]
                {
                    "<Protocol />",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol),
                    "Protocol"
                },
                new object[]
                {
                    "<Protocol><Params><Param id='123' /></Params></Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.Params.First()),
                    "Protocol/Params/Param[@id:123]"
                },
                new object[]
                {
                    "<Protocol><Params><Param id='123' /></Params></Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.Params.First().Id),
                    "Protocol/Params/Param[@id:123]/id"
                },
                new object[]
                {
                    "<Protocol><Params><Param id='A' /></Params></Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.Params.First()),
                    "Protocol/Params/Param[@id:A]"
                },
                new object[]
                {
                    "<Protocol><Params><Param id='1234'><Name>Test</Name></Param></Params></Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.Params.First().Name),
                    "Protocol/Params/Param[@id:1234]/Name"
                },
                new object[]
                {
                    // Position based (no id available)
                    "<Protocol><Params><Param /></Params></Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.Params.First()),
                    "Protocol/Params/Param[0]"
                },
                new object[]
                {
                    // Position based (no id available)
                    "<Protocol><Params><Param><Name>Test</Name></Param></Params></Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.Params.First().Name),
                    "Protocol/Params/Param[0]/Name"
                },
                new object[]
                {
                    "<Protocol><Groups><Group id='123'><Name>Test</Name></Group></Groups></Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.Groups.First().Name),
                    "Protocol/Groups/Group[@id:123]/Name"
                },
                new object[]
                {
                    "<Protocol><QActions><QAction id='123' name='test'>Test</QAction></QActions></Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.QActions.First().Name),
                    "Protocol/QActions/QAction[@id:123]/name"
                },
                new object[]
                {
                    @"<Protocol>
                        <Params>
                            <Param id='123'>
                                <Display>
                                    <Positions>
                                        <Position />
                                        <Position>
                                            <Page>RandomPage</Page>
                                        </Position>
                                    </Positions>
                                </Display>
                            </Param>
                        </Params>
                    </Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.Params.First().Display.Positions[1].Page),
                    "Protocol/Params/Param[@id:123]/Display/Positions/Position[1]/Page"
                },
                new object[]
                {
                    // Prefer id above name
                    @"<Protocol>
                        <ParameterGroups>
                            <Group id='123' name='testing'>
                            </Group>
                        </ParameterGroups>
                    </Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.ParameterGroups.First()),
                    "Protocol/ParameterGroups/Group[@id:123]"
                },
                new object[]
                {
                    // Fallback to name when id is not available
                    @"<Protocol>
                        <ParameterGroups>
                            <Group name='testing'>
                            </Group>
                        </ParameterGroups>
                    </Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.ParameterGroups.First()),
                    "Protocol/ParameterGroups/Group[@name:testing]"
                },
                new object[]
                {
                    // Fallback to position when id & name are not available
                    @"<Protocol>
                        <ParameterGroups>
                            <Group>
                            </Group>
                        </ParameterGroups>
                    </Protocol>",
                    (Func<ProtocolModel, IReadable>)(a => a.Protocol.ParameterGroups.First()),
                    "Protocol/ParameterGroups/Group[0]"
                },
            };
        }
    }
}