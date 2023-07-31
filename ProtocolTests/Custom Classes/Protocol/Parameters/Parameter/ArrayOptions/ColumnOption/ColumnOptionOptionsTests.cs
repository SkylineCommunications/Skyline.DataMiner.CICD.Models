namespace Models.ProtocolTests.Custom_Classes.Protocol.Parameters.Parameter.ArrayOptions.ColumnOption
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ColumnOptionOptionsTests
    {
        // TODO: Extend unittests by adding multiple options at once and see if they are still correct.

        [TestMethod]
        [DynamicData(nameof(GetOptionsBoolean), DynamicDataSourceType.Method)]
        public void BooleanProperties(string options, Func<ColumnOptionOptions, bool> property)
        {
            // Act.
            var result = new ColumnOptionOptions(options);

            // Assert
            Assert.IsTrue(property(result));
        }

        private static IEnumerable<object[]> GetOptionsBoolean()
        {
            yield return new object[] { ";CPEDummyColumn", new Func<ColumnOptionOptions, bool>((x) => x.CPE.IsCPEDummyColumn) };
            yield return new object[] { ";delete", new Func<ColumnOptionOptions, bool>((x) => x.IsDelete) };
            yield return new object[] { ";displayIcon", new Func<ColumnOptionOptions, bool>((x) => x.IsDisplayIcon) };
            yield return new object[] { ";displayElementAlarm", new Func<ColumnOptionOptions, bool>((x) => x.IsDisplayElementAlarm) };
            yield return new object[] { ";displayServiceAlarm", new Func<ColumnOptionOptions, bool>((x) => x.IsDisplayServiceAlarm) };
            yield return new object[] { ";displayViewAlarm", new Func<ColumnOptionOptions, bool>((x) => x.IsDisplayViewAlarm) };
            //yield return new object[] { ";disableHeaderAvg", new Func<ColumnOptionOptions, bool>((x) => x.IsDisableHeaderAvg) };
            yield return new object[] { ";dynamicData", new Func<ColumnOptionOptions, bool>((x) => x.Visio.IsDynamicData) };
            yield return new object[] { ";element", new Func<ColumnOptionOptions, bool>((x) => x.DVE.IsElement) };
            yield return new object[] { ";hidden", new Func<ColumnOptionOptions, bool>((x) => x.DVE.IsHidden) };
            yield return new object[] { ";HideKPI", new Func<ColumnOptionOptions, bool>((x) => x.CPE.IsHideKPI) };
            yield return new object[] { ";hideSummaryColumn", new Func<ColumnOptionOptions, bool>((x) => x.SOM.IsHideSummaryColumn) };
            yield return new object[] { ";indexColumn", new Func<ColumnOptionOptions, bool>((x) => x.IsIndexColumn) };
            yield return new object[] { ";KPIHideWrite", new Func<ColumnOptionOptions, bool>((x) => x.CPE.IsKPIHideWrite) };
            yield return new object[] { ";linkElement", new Func<ColumnOptionOptions, bool>((x) => x.IsLinkElement) };
            yield return new object[] { ";rowTextColoring", new Func<ColumnOptionOptions, bool>((x) => x.IsRowTextColoring) };
            yield return new object[] { ";save", new Func<ColumnOptionOptions, bool>((x) => x.IsSaved) };
            yield return new object[] { ";SetOnTable", new Func<ColumnOptionOptions, bool>((x) => x.IsSetOnTable) };
            yield return new object[] { ";severity", new Func<ColumnOptionOptions, bool>((x) => x.DVE.IsSeverity) };
            yield return new object[] { ";SeverityColumn", new Func<ColumnOptionOptions, bool>((x) => x.SOM.IsSeverityColumn) };
            yield return new object[] { ";SeverityColumnIndex", new Func<ColumnOptionOptions, bool>((x) => x.SOM.IsSeverityColumnIndex) };
            yield return new object[] { ";space", new Func<ColumnOptionOptions, bool>((x) => x.CPE.IsSpace) };
            yield return new object[] { ";volatile", new Func<ColumnOptionOptions, bool>((x) => x.IsVolatile) };
            yield return new object[] { ";view", new Func<ColumnOptionOptions, bool>((x) => x.DVE.IsDveViewColumn) };
            yield return new object[] { ";view=:2802:1000:1", new Func<ColumnOptionOptions, bool>((x) => x.ViewTable.IsRemote) };
        }

        [TestMethod]
        [DynamicData(nameof(GetOptionsUInt32), DynamicDataSourceType.Method)]
        public void UInt32Properties(string options, uint value, Func<ColumnOptionOptions, uint?> property)
        {
            // Act.
            var result = new ColumnOptionOptions(options);

            // Assert
            Assert.AreEqual(value, property(result));
        }

        private static IEnumerable<object[]> GetOptionsUInt32()
        {
            yield return new object[] { ";groupBy=1", (uint)1, new Func<ColumnOptionOptions, uint?>((x) => x.GroupBy.Idx) };
            yield return new object[] { ";foreignKey=1000", (uint)1000, new Func<ColumnOptionOptions, uint?>((x) => x.ForeignKey.Pid) };
            yield return new object[] { ";delta=1000", (uint)1000, new Func<ColumnOptionOptions, uint?>((x) => x.Delta.Index) };
            yield return new object[] { ";delta=1000:2000", (uint)2000, new Func<ColumnOptionOptions, uint?>((x) => x.Delta.Pid) };
            yield return new object[] { ";view=1000", (uint)1000, new Func<ColumnOptionOptions, uint?>((x) => x.ViewTable.Id) };
            yield return new object[] { ";view=:2802:1000:1", (uint)2802, new Func<ColumnOptionOptions, uint?>((x) => x.ViewTable.Id) };
            yield return new object[] { ";view=:2802:1000:1", (uint)1000, new Func<ColumnOptionOptions, uint?>((x) => x.ViewTable.Id2) };
            yield return new object[] { ";view=:2802:1000:1", (uint)1, new Func<ColumnOptionOptions, uint?>((x) => x.ViewTable.Id3) };
            yield return new object[] { ";view=5201:1100", (uint)5201, new Func<ColumnOptionOptions, uint?>((x) => x.ViewTable.Id) };
            yield return new object[] { ";view=5201:1100", (uint)1100, new Func<ColumnOptionOptions, uint?>((x) => x.ViewTable.Id2) };
        }

        [TestMethod]
        [DynamicData(nameof(GetOptionsString), DynamicDataSourceType.Method)]
        public void StringProperties(string options, string value, Func<ColumnOptionOptions, string> property)
        {
            // Act.
            var result = new ColumnOptionOptions(options);

            // Assert
            Assert.AreEqual(value, property(result));
        }

        private static IEnumerable<object[]> GetOptionsString()
        {
            yield return new object[] { ";SelectionSetVar:ABC", "ABC", new Func<ColumnOptionOptions, string>((x) => x.Visio.SelectionSetVar.Variable) };
            yield return new object[] { ";SelectionSetVar:", "", new Func<ColumnOptionOptions, string>((x) => x.Visio.SelectionSetVar.Variable) };
            yield return new object[] { ";SelectionSetCardVar:ABCD", "ABCD", new Func<ColumnOptionOptions, string>((x) => x.Visio.SelectionSetCardVar.Variable) };
            yield return new object[] { ";SelectionSetPageVar:AD", "AD", new Func<ColumnOptionOptions, string>((x) => x.Visio.SelectionSetPageVar.Variable) };
            yield return new object[] { ";SelectionSetWorkspaceVar:A", "A", new Func<ColumnOptionOptions, string>((x) => x.Visio.SelectionSetWorkspaceVar.Variable) };
            yield return new object[] { ";subTitle:AA", "AA", new Func<ColumnOptionOptions, string>((x) => x.CPE.SubTitle.Value) };

            yield return new object[] { ";view=1000", "1000", new Func<ColumnOptionOptions, string>((x) => x.ViewTable.OptionValue) };
        }
    }
}