namespace Models.ProtocolTests.Custom_Classes.Protocol.Parameters.Parameter.Type
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ParamTypeOptionsTests
    {
        [TestMethod]
        public void ParamTypeOptions_ValidValue_ReturnsData()
        {
            // Arrange.
            string option = "dimensions=64,128;columnTypes=2:0-20,35|3:21-34,36";

            // Act.
            var result = new ParamTypeOptions(option);

            // Assert
            Assert.IsNotNull(result.Dimensions);
            Assert.IsNotNull(result.ColumnTypes);
        }

        [TestMethod]
        public void ParamTypeOptions_EmptyValue_ReturnsNullData()
        {
            // Arrange.
            string option = String.Empty;

            // Act.
            var result = new ParamTypeOptions(option);

            // Assert
            Assert.IsNull(result.Dimensions);
            Assert.IsNull(result.ColumnTypes);
        }

        [TestMethod]
        public void ParamTypeOptions_ValidDimensions_ReturnsDimensionsData()
        {
            // Arrange.
            string option = "dimensions=64,128";

            // Act.
            var result = new ParamTypeOptions(option);

            // Assert
            Assert.IsNotNull(result.Dimensions);
            Assert.IsNull(result.ColumnTypes);
        }

        [TestMethod]
        public void ParamTypeOptions_ValidColumnType_ReturnsColumnTypeData()
        {
            // Arrange.
            string option = "columnTypes=2:0-20,35|3:21-34,36";

            // Act.
            var result = new ParamTypeOptions(option);

            // Assert
            Assert.IsNull(result.Dimensions);
            Assert.IsNotNull(result.ColumnTypes);
        }

        [TestMethod]
        public void ParamTypeOptions_OtherValue_ReturnsNullData()
        {
            // Arrange.
            string option = "connection=0";

            // Act.
            var result = new ParamTypeOptions(option);

            // Assert
            Assert.IsNull(result.Dimensions);
            Assert.IsNull(result.ColumnTypes);
        }
    }

    [TestClass]
    public class ParamTypeOptionsTests2
    {
        // TODO: Extend unittests by adding multiple options at once and see if they are still correct.

        [TestMethod]
        [DynamicData(nameof(GetOptionsBoolean), DynamicDataSourceType.Method)]
        public void BooleanProperties(string options, Func<ParamTypeOptions, bool> property)
        {
            // Act.
            var result = new ParamTypeOptions(options);

            // Assert
            Assert.IsTrue(property(result));
        }

        private static IEnumerable<object[]> GetOptionsBoolean()
        {
            yield return new object[] { "dynamic ip", new Func<ParamTypeOptions, bool>((x) => x.DynamicIp != null) };
            yield return new object[] { "dynamic ip 2", new Func<ParamTypeOptions, bool>((x) => x.DynamicIp.Connection != null) };
            yield return new object[] { "ssh pwd", new Func<ParamTypeOptions, bool>((x) => x.HasSshPwd) };
            yield return new object[] { "ssh username", new Func<ParamTypeOptions, bool>((x) => x.HasSshUsername) };
            yield return new object[] { "ssh options", new Func<ParamTypeOptions, bool>((x) => x.HasSshOptions) };
            yield return new object[] { "connection=", new Func<ParamTypeOptions, bool>((x) => x.Connection == null) };
            yield return new object[] { "loadOID", new Func<ParamTypeOptions, bool>((x) => x.HasLoadOID) };
            yield return new object[] { "loadOID", new Func<ParamTypeOptions, bool>((x) => x.Dimensions == null) };
            yield return new object[] { "dimensions=,", new Func<ParamTypeOptions, bool>((x) => x.Dimensions.Columns == null) };
            yield return new object[] { "dimensions=,", new Func<ParamTypeOptions, bool>((x) => x.Dimensions.Rows == null) };
            yield return new object[] { "columnTypes=10:0-6,8", new Func<ParamTypeOptions, bool>((x) => !x.ColumnTypes.ColumnTypes[0].isValid) };
            yield return new object[] { "columnTypes=10:0-6", new Func<ParamTypeOptions, bool>((x) => x.ColumnTypes.ColumnTypes[0].isValid) };
            yield return new object[] { "columntypes=500:0-14", new Func<ParamTypeOptions, bool>((x) => x.ColumnTypes.ColumnTypes[0].isValid) };
            yield return new object[] { "headerTrailerLink=", new Func<ParamTypeOptions, bool>((x) => x.HeaderTrailerLink.Id == null) };
            yield return new object[] { "linkAlarmValue=true", new Func<ParamTypeOptions, bool>((x) => x.LinkAlarmValue.IsValid) };
            yield return new object[] { "linkAlarmValue=()", new Func<ParamTypeOptions, bool>((x) => x.LinkAlarmValue.IsValid) };
            yield return new object[] { "linkAlarmValue=()", new Func<ParamTypeOptions, bool>((x) => x.LinkAlarmValue.FirstChar == '(') };
            
            // Not really used anymore ...
            yield return new object[] { "dynamic snmp get", new Func<ParamTypeOptions, bool>((x) => x.HasDynamicSnmpGet) };
        }

        [TestMethod]
        [DynamicData(nameof(GetOptionsUInt32), DynamicDataSourceType.Method)]
        public void UInt32Properties(string options, uint value, Func<ParamTypeOptions, uint?> property)
        {
            // Act.
            var result = new ParamTypeOptions(options);

            // Assert
            Assert.AreEqual(value, property(result));
        }

        private static IEnumerable<object[]> GetOptionsUInt32()
        {
            yield return new object[] { "connection=1", (uint)1, new Func<ParamTypeOptions, uint?>((x) => x.Connection) };
            yield return new object[] { "dimensions=64,32", (uint)64, new Func<ParamTypeOptions, uint?>((x) => x.Dimensions.Rows) };
            yield return new object[] { "dimensions=64,32", (uint)32, new Func<ParamTypeOptions, uint?>((x) => x.Dimensions.Columns) };
            yield return new object[] { "columnTypes=10:0-64", (uint)0, new Func<ParamTypeOptions, uint?>((x) => x.ColumnTypes.ColumnTypes[0].fromIdx) };
            yield return new object[] { "columnTypes=10:0-64", (uint)64, new Func<ParamTypeOptions, uint?>((x) => x.ColumnTypes.ColumnTypes[0].toIndex) };
            yield return new object[] { "columnTypes=10:0-64", (uint)10, new Func<ParamTypeOptions, uint?>((x) => x.ColumnTypes.ColumnTypes[0].pid) };
            yield return new object[] { "headerTrailerLink=1", (uint)1, new Func<ParamTypeOptions, uint?>((x) => x.HeaderTrailerLink.Id) };
        }

        [TestMethod]
        [DynamicData(nameof(GetOptionsString), DynamicDataSourceType.Method)]
        public void StringProperties(string options, string value, Func<ParamTypeOptions, string> property)
        {
            // Act.
            var result = new ParamTypeOptions(options);

            // Assert
            Assert.AreEqual(value, property(result));
        }

        private static IEnumerable<object[]> GetOptionsString()
        {
            yield return new object[] { "linkAlarmValue=()", "(", new Func<ParamTypeOptions, string>((x) => Convert.ToString(x.LinkAlarmValue.FirstChar)) };
            yield return new object[] { "linkAlarmValue=()", ")", new Func<ParamTypeOptions, string>((x) => Convert.ToString(x.LinkAlarmValue.SecondChar)) };
        }
    }
}