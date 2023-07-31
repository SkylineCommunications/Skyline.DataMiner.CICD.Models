namespace Models.ProtocolTests.Custom_Classes.Protocol.Parameters.Parameter.Measurement.Discreets.Discreet
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class EnabledClassTests
    {
        [DataTestMethod]
        [DataRow("enabled=109,0", 109, new[] { "0" })]
        [DataRow("enabled=109,0,7,4,5", 109, new[] { "0", "7", "4", "5" })]
        public void EnabledClassTest_Valid(string fullOption, int expectedColumnPid, IReadOnlyList<string> expectedValues)
        {
            // Act
            var result = new DiscreetsDiscreetOptions.EnabledClass(fullOption);

            // Assert

            result.ColumnPid.Should().NotBeNull();
            result.ColumnPid.Should().Be((uint)expectedColumnPid);

            result.Values.Should().NotBeNullOrEmpty();
            result.Values.Should().BeEquivalentTo(expectedValues);
        }

        [TestMethod]
        public void EnabledClassTest_Invalid()
        {
            // Arrange
            const string FullOption = "enabled=";

            // Act
            var result = new DiscreetsDiscreetOptions.EnabledClass(FullOption);

            // Assert

            result.ColumnPid.Should().BeNull();
            result.Values.Should().BeNull();
        }
    }
}