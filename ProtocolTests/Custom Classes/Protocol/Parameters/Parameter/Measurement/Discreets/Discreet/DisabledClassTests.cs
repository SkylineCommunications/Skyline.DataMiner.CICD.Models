namespace Models.ProtocolTests.Custom_Classes.Protocol.Parameters.Parameter.Measurement.Discreets.Discreet
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class DisabledClassTests
    {
        [DataTestMethod]
        [DataRow("disabled=109,0", 109, new[] { "0" })]
        [DataRow("disabled=109,0,7,4,5", 109, new[] { "0", "7", "4", "5" })]
        public void DisabledClassTest_Valid(string fullOption, int expectedColumnPid, IReadOnlyList<string> expectedValues)
        {
            // Act
            var result = new DiscreetsDiscreetOptions.DisabledClass(fullOption);

            // Assert

            result.ColumnPid.Should().NotBeNull();
            result.ColumnPid.Should().Be((uint)expectedColumnPid);

            result.Values.Should().NotBeNullOrEmpty();
            result.Values.Should().BeEquivalentTo(expectedValues);
        }

        [TestMethod]
        public void DisabledClassTest_Invalid()
        {
            // Arrange
            const string FullOption = "disabled=";

            // Act
            var result = new DiscreetsDiscreetOptions.DisabledClass(FullOption);

            // Assert

            result.ColumnPid.Should().BeNull();
            result.Values.Should().BeNull();
        }
    }
}