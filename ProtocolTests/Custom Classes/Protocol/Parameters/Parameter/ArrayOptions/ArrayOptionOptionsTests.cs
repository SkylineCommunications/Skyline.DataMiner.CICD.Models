namespace Models.ProtocolTests.Custom_Classes.Protocol.Parameters.Parameter.ArrayOptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ArrayOptionOptionsTests
    {
        // TODO: Extend unittests by adding multiple options at once and see if they are still correct.

        [TestMethod]
        [DynamicData(nameof(GetOptionsBoolean), DynamicDataSourceType.Method)]
        public void BooleanProperties(string options, Func<ArrayOptionsOptions, bool> property)
        {
            // Act.
            var result = new ArrayOptionsOptions(options);

            // Assert
            Assert.IsTrue(property(result));
        }

        private static IEnumerable<object[]> GetOptionsBoolean()
        {
            yield return new object[] { ";autoAdd", new Func<ArrayOptionsOptions, bool>((x) => x.HasAutoAdd) };
            yield return new object[] { ";interruptTrend", new Func<ArrayOptionsOptions, bool>((x) => x.HasInterruptTrend) };
            yield return new object[] { ";onlyFilteredDirectView", new Func<ArrayOptionsOptions, bool>((x) => x.HasOnlyFilteredDirectView) };
            yield return new object[] { ";preserve state", new Func<ArrayOptionsOptions, bool>((x) => x.HasPreserveState) };
            yield return new object[] { ";volatile", new Func<ArrayOptionsOptions, bool>((x) => x.HasVolatile) };

            // Special case (Database can be used without rows (defaults to 500 in DMA))
            yield return new object[] { ";database", new Func<ArrayOptionsOptions, bool>((x) => x.Database.Rows == null) };
        }

        [TestMethod]
        [DynamicData(nameof(GetOptionsUInt32), DynamicDataSourceType.Method)]
        public void UInt32Properties(string options, uint value, Func<ArrayOptionsOptions, uint?> property)
        {
            // Act.
            var result = new ArrayOptionsOptions(options);

            // Assert
            Assert.AreEqual(value, property(result));
        }

        private static IEnumerable<object[]> GetOptionsUInt32()
        {
            yield return new object[] { ";queryTablePID=1500", (uint)1500, new Func<ArrayOptionsOptions, uint?>((x) => x.QueryTablePid) };
            yield return new object[] { ";directView=1234", (uint)1234, new Func<ArrayOptionsOptions, uint?>((x) => x.DirectView.Pid) };
            yield return new object[] { ";database:1234", (uint)1234, new Func<ArrayOptionsOptions, uint?>((x) => x.Database.Rows) };

            yield return new object[] { ";filterChange=701-40001,702-40002", (uint)701, new Func<ArrayOptionsOptions, uint?>((x) => x.FilterChange.Pairs[0].LocalId) };
            yield return new object[] { ";filterChange=701-40001,702-40002", (uint)40001, new Func<ArrayOptionsOptions, uint?>((x) => x.FilterChange.Pairs[0].RemoteId) };
            yield return new object[] { ";filterChange=701-40001,702-40002", (uint)702, new Func<ArrayOptionsOptions, uint?>((x) => x.FilterChange.Pairs[1].LocalId) };
            yield return new object[] { ";filterChange=701-40001,702-40002", (uint)40002, new Func<ArrayOptionsOptions, uint?>((x) => x.FilterChange.Pairs[1].RemoteId) };
            yield return new object[] { ";filterChange=701-40001,702-40002", (uint)2, new Func<ArrayOptionsOptions, uint?>((x) => (uint?)x.FilterChange.Pairs.Count) };

            yield return new object[] { ";naming=/1001,1002", (uint)1001, new Func<ArrayOptionsOptions, uint?>((x) => x.Naming.Columns.ToList()[0]) };
            yield return new object[] { ";naming=/1001,1002", (uint)1002, new Func<ArrayOptionsOptions, uint?>((x) => x.Naming.Columns.ToList()[1]) };
            yield return new object[] { ";naming=/1001,1002", (uint)2, new Func<ArrayOptionsOptions, uint?>((x) => (uint?)x.Naming.Columns.Count) };
        }

        [TestMethod]
        [DynamicData(nameof(GetOptionsString), DynamicDataSourceType.Method)]
        public void StringProperties(string options, string value, Func<ArrayOptionsOptions, string> property)
        {
            // Act.
            var result = new ArrayOptionsOptions(options);

            // Assert
            Assert.AreEqual(value, property(result));
        }

        private static IEnumerable<object[]> GetOptionsString()
        {
            yield return new object[] { ";discreetDestination=ports.xml", "ports.xml", new Func<ArrayOptionsOptions, string>((x) => x.DiscreetDestination) };

            yield return new object[] { ";naming=/1001,1002", "/", new Func<ArrayOptionsOptions, string>((x) => Convert.ToString(x.Naming.Separator)) };

        }
    }
}