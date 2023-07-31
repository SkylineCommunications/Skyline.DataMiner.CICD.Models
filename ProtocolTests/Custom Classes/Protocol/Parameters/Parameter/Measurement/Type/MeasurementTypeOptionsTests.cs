namespace Models.ProtocolTests.Custom_Classes.Protocol.Parameters.Parameter.Measurement.Type
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class MeasurementTypeOptionsTests
    {
        // TODO: Extend unittests by adding multiple options at once and see if they are still correct.

        [TestMethod]
        [DynamicData(nameof(GetOptionsBoolean), DynamicDataSourceType.Method)]
        public void BooleanProperties(string options, Func<MeasurementTypeOptions, bool> property)
        {
            // Act.
            var result = new MeasurementTypeOptions(options);

            // Assert
            Assert.IsTrue(property(result));
        }

        private static IEnumerable<object[]> GetOptionsBoolean()
        {
            yield return new object[] { "hscroll", new Func<MeasurementTypeOptions, bool>((x) => x.HasHScroll) };
            yield return new object[] { "time;timeofday", new Func<MeasurementTypeOptions, bool>((x) => x.HasTimeOfDay) };
            yield return new object[] { "date", new Func<MeasurementTypeOptions, bool>((x) => x.HasDate) };
            yield return new object[] { "datetime", new Func<MeasurementTypeOptions, bool>((x) => x.DateTime != null) };
            yield return new object[] { "datetime", new Func<MeasurementTypeOptions, bool>((x) => x.DateTime.ExtraOption == null) };
            yield return new object[] { "datetime:minute", new Func<MeasurementTypeOptions, bool>((x) => x.DateTime.ExtraOption == MeasurementTypeOptions.DateTimeClass.Options.Minute) };
            yield return new object[] { "time", new Func<MeasurementTypeOptions, bool>((x) => x.Time != null) };
            yield return new object[] { "time", new Func<MeasurementTypeOptions, bool>((x) => x.Time.ExtraOption == null) };
            yield return new object[] { "time:minute", new Func<MeasurementTypeOptions, bool>((x) => x.Time.ExtraOption == MeasurementTypeOptions.TimeClass.Options.Minute) };
            yield return new object[] { "time:hour", new Func<MeasurementTypeOptions, bool>((x) => x.Time.ExtraOption == MeasurementTypeOptions.TimeClass.Options.Hour) };
            yield return new object[] { "fixedfont", new Func<MeasurementTypeOptions, bool>((x) => x.HasFixedFont) };
            yield return new object[] { "password", new Func<MeasurementTypeOptions, bool>((x) => x.HasPassword) };
            yield return new object[] { "begin;connect", new Func<MeasurementTypeOptions, bool>((x) => x.HasBegin) };
            yield return new object[] { "end;connect", new Func<MeasurementTypeOptions, bool>((x) => x.HasEnd) };
            yield return new object[] { "end;connect", new Func<MeasurementTypeOptions, bool>((x) => x.HasConnect) };
            yield return new object[] { "matrix=0,0,0,0,0,0,pages,noDisconnectsInBackup", new Func<MeasurementTypeOptions, bool>((x) => x.Matrix != null) };
            yield return new object[] { "matrix=0,0,0,0,0,0,evensmallpages,noDisconnectsInBackup", new Func<MeasurementTypeOptions, bool>((x) => x.Matrix.HasEvenSmallPages) };
            yield return new object[] { "matrix=0,0,0,0,0,0,pages,noDisconnectsInBackup", new Func<MeasurementTypeOptions, bool>((x) => x.Matrix.HasPages) };
            yield return new object[] { "matrix=0,0,0,0,0,0,pages,noDisconnectsInBackup", new Func<MeasurementTypeOptions, bool>((x) => x.Matrix.HasNoDisconnectsInBackup) };
            yield return new object[] { "tab=filter:true", new Func<MeasurementTypeOptions, bool>((x) => x.Table.Filter.Value) };
            yield return new object[] { "tab=sort:INT-INT|ASC|0", new Func<MeasurementTypeOptions, bool>((x) => x.Table.Sort.Columns.ToList()[0].direction == null) };
            yield return new object[] { "tab=sort:INT-INT|ASC|0", new Func<MeasurementTypeOptions, bool>((x) => x.Table.Sort.Columns.ToList()[0].priority == null) };
            yield return new object[] { "tab=sort:INT-INT|ASC|0", new Func<MeasurementTypeOptions, bool>((x) => x.Table.Sort.Columns.ToList()[0].type == MeasurementTypeOptions.TableClass.SortType.Integer) };
            yield return new object[] { "tab=sort:INT-INT|ASC|0", new Func<MeasurementTypeOptions, bool>((x) => x.Table.Sort.Columns.ToList()[1].direction == MeasurementTypeOptions.TableClass.SortDirection.Ascending) };
        }

        [TestMethod]
        [DynamicData(nameof(GetOptionsUInt32), DynamicDataSourceType.Method)]
        public void UInt32Properties(string options, uint value, Func<MeasurementTypeOptions, uint?> property)
        {
            // Act.
            var result = new MeasurementTypeOptions(options);

            // Assert
            Assert.AreEqual(value, property(result));
        }

        private static IEnumerable<object[]> GetOptionsUInt32()
        {
            yield return new object[] { "matrix=64,0,0,0,0,0,pages,noDisconnectsInBackup", (uint)64, new Func<MeasurementTypeOptions, uint?>((x) => x.Matrix.Inputs) };
            yield return new object[] { "matrix=64,128,0,0,0,0,pages,noDisconnectsInBackup", (uint)128, new Func<MeasurementTypeOptions, uint?>((x) => x.Matrix.Outputs) };
            yield return new object[] { "matrix=64,128,32,0,0,0,pages,noDisconnectsInBackup", (uint)32, new Func<MeasurementTypeOptions, uint?>((x) => x.Matrix.COMin) };
            yield return new object[] { "matrix=64,128,32,16,0,0,pages,noDisconnectsInBackup", (uint)16, new Func<MeasurementTypeOptions, uint?>((x) => x.Matrix.COMax) };
            yield return new object[] { "matrix=64,128,32,16,8,0,pages,noDisconnectsInBackup", (uint)8, new Func<MeasurementTypeOptions, uint?>((x) => x.Matrix.CIMin) };
            yield return new object[] { "matrix=64,128,32,16,8,4,pages,noDisconnectsInBackup", (uint)4, new Func<MeasurementTypeOptions, uint?>((x) => x.Matrix.CIMax) };
            yield return new object[] { "custom=disableWrite:1000=Test", (uint)1000, new Func<MeasurementTypeOptions, uint?>((x) => x.CustomDisableWrite.Column) };
            yield return new object[] { "tab=lines:20", (uint)20, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.Lines) };
            yield return new object[] { "tab=columns:100|0-101|1", (uint)2, new Func<MeasurementTypeOptions, uint?>((x) => (uint?)x.Table.Columns.Columns.Count) };
            yield return new object[] { "tab=columns:100|0-101|1", (uint)100, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.Columns.Columns.ToList()[0].columnPid) };
            yield return new object[] { "tab=columns:100|0-101|1", (uint)0, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.Columns.Columns.ToList()[0].columnIdx) };
            yield return new object[] { "tab=columns:100|0-101|1", (uint)101, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.Columns.Columns.ToList()[1].columnPid) };
            yield return new object[] { "tab=columns:100|0-101|1", (uint)1, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.Columns.Columns.ToList()[1].columnIdx) };
            yield return new object[] { "tab=sort:INT-INT|ASC|0", (uint)0, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.Sort.Columns.ToList()[1].priority) };
            yield return new object[] { "tab=width:50-51", (uint)2, new Func<MeasurementTypeOptions, uint?>((x) => (uint?)x.Table.Width.Columns.Count) };
            yield return new object[] { "tab=width:50-51", (uint)50, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.Width.Columns.ToList()[0].width) };
            yield return new object[] { "tab=width:50-51", (uint)51, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.Width.Columns.ToList()[1].width) };
            yield return new object[] { "tab=columns:100|0-101|1,width:50-51,sort:INT-STRING|ASC|0", (uint)100, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.ColumnsFull.ToList()[0].Pid) };
            yield return new object[] { "tab=columns:100|0-101|1,width:50-51,sort:INT-STRING|ASC|0", (uint)101, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.ColumnsFull.ToList()[1].Pid) };
            yield return new object[] { "tab=columns:100|0-101|1,width:50-51,sort:INT-STRING|ASC|0", (uint)1, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.ColumnsFull.ToList()[1].Idx) };
            yield return new object[] { "tab=columns:100|0-101|1,width:50-51,sort:INT-STRING|ASC|0", (uint)51, new Func<MeasurementTypeOptions, uint?>((x) => x.Table.ColumnsFull.ToList()[1].Width) };
        }

        [TestMethod]
        [DynamicData(nameof(GetOptionsString), DynamicDataSourceType.Method)]
        public void StringProperties(string options, string value, Func<MeasurementTypeOptions, string> property)
        {
            // Act.
            var result = new MeasurementTypeOptions(options);

            // Assert
            Assert.AreEqual(value, property(result));
        }

        private static IEnumerable<object[]> GetOptionsString()
        {
            yield return new object[] { "custom=disableWrite:1000=Test", "Test", new Func<MeasurementTypeOptions, string>((x) => x.CustomDisableWrite.Value) };
        }
    }
}