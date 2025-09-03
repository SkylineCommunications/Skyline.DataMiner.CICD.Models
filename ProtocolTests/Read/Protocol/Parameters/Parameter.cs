namespace Models.ProtocolTests.Read.Protocol.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    [TestClass]
    public class ParameterAttributes : ProtocolTestBase
    {
        #region ConfirmPopup

        [TestMethod]
        public void ConfirmPopup_ValidConfirmPopup_ReturnsAlways()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param confirmPopup='always'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(EnumParamConfirmPopup.Always, parameter.ConfirmPopup.Value);
        }

        [TestMethod]
        public void ConfirmPopup_ValidConfirmPopup_ReturnsNever()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param confirmPopup='never'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(EnumParamConfirmPopup.Never, parameter.ConfirmPopup.Value);
        }

        [TestMethod]
        public void ConfirmPopup_ValidConfirmPopup_ReturnsDm()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param confirmPopup='dm'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(EnumParamConfirmPopup.Dm, parameter.ConfirmPopup.Value);
        }

        [TestMethod]
        public void ConfirmPopup_EmptyConfirmPopup_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param confirmPopup=''></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.ConfirmPopup.Value);
        }

        [TestMethod]
        public void ConfirmPopup_MissingConfirmPopup_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.ConfirmPopup);
        }

        #endregion

        #region DuplicateAs

        [TestMethod]
        public void DuplicateAs_ValidDuplicateAs_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param duplicateAs='2001'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("2001", parameter.DuplicateAs.Value);
        }

        [TestMethod]
        public void DuplicateAs_EmptyDuplicateAs_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param duplicateAs=''></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.DuplicateAs.Value);
        }

        [TestMethod]
        public void DuplicateAs_MissingDuplicateAs_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.DuplicateAs);
        }

        #endregion

        #region Export

        [TestMethod]
        public void Export_ValidExport_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param export='Test'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("Test", parameter.Export.Value);
        }

        [TestMethod]
        public void Export_EmptyExport_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param export=''></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Export.Value);
        }

        [TestMethod]
        public void Export_MissingExport_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Export);
        }

        #endregion

        #region HistorySet

        [TestMethod]
        public void HistorySet_ValidHistorySet_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param historySet='true'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(true, parameter.HistorySet.Value);
        }

        [TestMethod]
        public void HistorySet_InvalidHistorySet_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param historySet='tr'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.HistorySet.Value);
        }

        [TestMethod]
        public void HistorySet_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param historySet=''></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.HistorySet.Value);
        }

        [TestMethod]
        public void HistorySet_MissingHistorySet_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.HistorySet);
        }

        #endregion

        #region Id

        [TestMethod]
        public void Id_ValidParameterId_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param id='10'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual((uint)10, parameter.Id.Value);
        }

        [TestMethod]
        public void Id_InvalidParameterId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param id='invalid'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Id.Value);
        }

        [TestMethod]
        public void Id_MissingParameterId_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Id);
        }

        [TestMethod]
        public void Id_MinusOne_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param id='-1'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Id.Value);
        }

        #endregion

        #region Level

        [TestMethod]
        public void Level_ValidLevel_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param level='3'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual((uint)3, parameter.Level.Value);
        }

        [TestMethod]
        public void Level_InvalidLevel_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param level='invalid'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Level.Value);
        }

        [TestMethod]
        public void Level_MissingLevel_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Level);
        }

        [TestMethod]
        public void Level_MinusOne_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param level='-1'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Level.Value);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_ValidOptions_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param options='Test'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("Test", parameter.Options.Value);
        }

        [TestMethod]
        public void Options_EmptyOptions_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param options=''></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Options.Value);
        }

        [TestMethod]
        public void Options_MissingOptions_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Options);
        }

        #endregion

        #region PollingInterval

        [TestMethod]
        public void PollingInterval_ValidPollingInterval_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param pollingInterval='100'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(100u, parameter.PollingInterval.Value);
        }

        [TestMethod]
        public void PollingInterval_InvalidPollingInterval_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param pollingInterval='invalid'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.PollingInterval.Value);
        }

        [TestMethod]
        public void PollingInterval_MissingPollingInterval_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.PollingInterval);
        }

        [TestMethod]
        public void PollingInterval_MinusOne_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param pollingInterval='-1'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.PollingInterval.Value);
        }

        #endregion

        #region Save

        [TestMethod]
        public void Save_ValidSave_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param save='true'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(true, parameter.Save.Value);
        }

        [TestMethod]
        public void Save_InvalidSave_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param save='tr'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Save.Value);
        }

        [TestMethod]
        public void Save_MissingSave_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Save);
        }

        #endregion

        #region SaveInterval

        [TestMethod]
        public void SaveInterval_ValidSaveInterval_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param saveInterval='PT1H2M3S'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(new TimeSpan(1, 2, 3), parameter.SaveInterval.Value);
        }

        [TestMethod]
        public void SaveInterval_InvalidSaveInterval_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param saveInterval='1H2M3S'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.SaveInterval.Value);
        }

        [TestMethod]
        public void SaveInterval_MissingSaveInterval_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.SaveInterval);
        }

        #endregion

        #region Setter

        [TestMethod]
        public void Setter_ValidSetter_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param setter='true'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(true, parameter.Setter.Value);
        }

        [TestMethod]
        public void Setter_InvalidSetter_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param setter='tr'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Setter.Value);
        }

        [TestMethod]
        public void Setter_MissingSetter_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Setter);
        }

        #endregion

        #region Snapshot

        [TestMethod]
        public void Snapshot_ValidSnapshot_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param snapshot='true'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(true, parameter.Snapshot.Value);
        }

        [TestMethod]
        public void Snapshot_InvalidSnapshot_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param snapshot='tr'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Snapshot.Value);
        }

        [TestMethod]
        public void Snapshot_MissingSnapshot_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Snapshot);
        }

        #endregion

        #region SnmpSetAndGet

        [TestMethod]
        public void SnmpSetAndGet_ValidSnmpSetAndGet_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param snmpSetAndGet='true'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("true", parameter.SnmpSetAndGet.Value);
        }

        [TestMethod]
        public void SnmpSetAndGet_EmptySnmpSetAndGet_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param snmpSetAndGet=''></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.SnmpSetAndGet.Value);
        }

        [TestMethod]
        public void SnmpSetAndGet_MissingSnmpSetAndGet_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.SnmpSetAndGet);
        }

        #endregion

        #region Trending

        [TestMethod]
        public void Trending_ValidTrending_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param trending='true'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(true, parameter.Trending.Value);
        }

        [TestMethod]
        public void Trending_InvalidTrending_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param trending='tr'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Trending.Value);
        }

        [TestMethod]
        public void Trending_MissingTrending_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Trending);
        }

        #endregion

        #region VerificationTimout

        [TestMethod]
        public void VerificationTimeout_ValidVerificationTimeout_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param verificationTimeout='100'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual((uint)100, parameter.VerificationTimeout.Value);
        }

        [TestMethod]
        public void VerificationTimeout_InvalidVerificationTimeout_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param verificationTimeout='invalid'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.VerificationTimeout.Value);
        }

        [TestMethod]
        public void VerificationTimeout_MissingVerificationTimeout_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.VerificationTimeout);
        }

        [TestMethod]
        public void VerificationTimeout_MinusOne_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param verificationTimeout='-1'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.VerificationTimeout.Value);
        }

        #endregion
    }

    [TestClass]
    public class ParameterTags : ProtocolTestBase
    {
        #region Alarm

        [TestMethod]
        public void Alarm_AlarmTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Alarm></Alarm></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Alarm);
        }

        [TestMethod]
        public void Alarm_AlarmTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Alarm);
        }

        #endregion

        #region ArrayOptions

        [TestMethod]
        public void ArrayOptions_ArrayOptionsTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.ArrayOptions);
        }

        [TestMethod]
        public void ArrayOptions_ArrayOptionsTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.ArrayOptions);
        }

        #endregion

        #region CRC

        [TestMethod]
        public void CRC_CRCTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><CRC></CRC></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.CRC);
        }

        [TestMethod]
        public void CRC_CRCTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.CRC);
        }

        #endregion

        #region Database

        [TestMethod]
        public void Database_DatabaseTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Database></Database></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Database);
        }

        [TestMethod]
        public void Database_DatabaseTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Database);
        }

        #endregion

        #region Dependencies

        [TestMethod]
        public void Dependencies_DependenciesTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Dependencies></Dependencies></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Dependencies);
        }

        [TestMethod]
        public void Dependencies_DependenciesTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Dependencies);
        }

        #endregion

        #region Description

        [TestMethod]
        public void Description_ValidParameterDescription_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Description>Description</Description></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("Description", parameter.Description.Value);
        }

        [TestMethod]
        public void Description_EmptyParameterDescription_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Description></Description></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Description.Value);
        }

        [TestMethod]
        public void Description_MissingParameterDescription_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Description);
        }

        #endregion

        #region Display

        [TestMethod]
        public void Display_DisplayTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Display></Display></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Display);
        }

        [TestMethod]
        public void Display_DisplayTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Display);
        }

        #endregion

        #region HyperLinks

        [TestMethod]
        public void HyperLinks_HyperLinksTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><HyperLinks></HyperLinks></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.HyperLinks);
        }

        [TestMethod]
        public void HyperLinks_HyperLinksTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.HyperLinks);
        }

        #endregion

        #region Icon

        [TestMethod]
        public void Icon_ValidIcon_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Icon>Test</Icon></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("Test", parameter.Icon.Value);
        }

        [TestMethod]
        public void Icon_EmptyIcon_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Icon></Icon></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Icon.Value);
        }

        [TestMethod]
        public void Icon_MissingIcon_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Icon);
        }

        #endregion

        #region Information

        [TestMethod]
        public void Information_InformationTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Information></Information></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Information);
        }

        [TestMethod]
        public void Information_InformationTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Information);
        }

        #endregion

        #region Interprete

        [TestMethod]
        public void Interprete_InterpreteTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Interprete></Interprete></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Interprete);
        }

        [TestMethod]
        public void Interprete_InterpreteTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Interprete);
        }

        #endregion

        #region Length

        [TestMethod]
        public void Length_LengthTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Length></Length></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Length);
        }

        [TestMethod]
        public void Length_LengthTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Length);
        }

        #endregion

        #region Measurement

        [TestMethod]
        public void Measurement_MeasurementTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Measurement></Measurement></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Measurement);
        }

        [TestMethod]
        public void Measurement_MeasurementTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Measurement);
        }

        #endregion

        #region Mediation

        [TestMethod]
        public void Mediation_MediationTagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Mediation></Mediation></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Mediation);
        }

        [TestMethod]
        public void Mediation_MediationTagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Mediation);
        }

        #endregion

        #region Message

        [TestMethod]
        public void Message_ValidMessage_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Message>Test</Message></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("Test", parameter.Message.Value);
        }

        [TestMethod]
        public void Message_EmptyMessage_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Message></Message></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Message.Value);
        }

        [TestMethod]
        public void Message_MissingMessage_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Message);
        }

        #endregion

        #region Name

        [TestMethod]
        public void Name_ValidParameterName_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Name>Test</Name></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("Test", parameter.Name.Value);
        }

        [TestMethod]
        public void Name_EmptyParameterName_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Name></Name></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Name.Value);
        }

        [TestMethod]
        public void Name_MissingParameterName_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Name);
        }

        #endregion

        #region Replication

        [TestMethod]
        public void Replication_TagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Replication></Replication></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Replication);
        }

        [TestMethod]
        public void Replication_TagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Replication);
        }

        #endregion

        #region Snmp

        [TestMethod]
        public void Snmp_TagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><SNMP></SNMP></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.SNMP);
        }

        [TestMethod]
        public void Snmp_TagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.SNMP);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_TagAvailable_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type></Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreNotEqual(null, parameter.Type);
        }

        [TestMethod]
        public void Type_TagNotAvailable_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type></Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(null, parameter.Type.Id);
        }

        #endregion
    }

    [TestClass]
    public class ParameterMethods : ProtocolTestBase
    {
        #region Is[Type]

        #region IsRead

        [TestMethod]
        public void IsRead_ReadParam_True()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>read</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsRead());
        }

        [TestMethod]
        public void IsRead_ReadBitParam_True()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>read bit</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsRead());
        }

        [TestMethod]
        public void IsRead_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>write</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsRead());
        }

        [TestMethod]
        public void IsRead_EmptyTag_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type></Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsRead());
        }

        [TestMethod]
        public void IsRead_MissingTag_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsRead());
        }

        #endregion

        #region IsWrite

        [TestMethod]
        public void IsWrite_WriteParam_True()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>write</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsWrite());
        }

        [TestMethod]
        public void IsWrite_WriteBitParam_True()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>write bit</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsWrite());
        }

        [TestMethod]
        public void IsWrite_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>array</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsWrite());
        }

        [TestMethod]
        public void IsWrite_EmptyTag_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type></Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsWrite());
        }

        [TestMethod]
        public void IsWrite_MissingTag_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsWrite());
        }

        #endregion

        #endregion

        #region Is[MeasurementType]

        #region IsButton

        [TestMethod]
        public void IsButton_ButtonParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>button</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsButton());
        }

        [TestMethod]
        public void IsButton_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>discreet</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsButton());
        }

        [TestMethod]
        public void IsButton_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsButton());
        }

        #endregion

        #region IsNumber

        [TestMethod]
        public void IsNumber_NumberParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>number</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsNumber());
        }

        [TestMethod]
        public void IsNumber_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>discreet</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsNumber());
        }

        [TestMethod]
        public void IsNumber_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsNumber());
        }

        #endregion

        #region IsDateTime

        [TestMethod]
        public void IsDateTime_datetimeParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type options='datetime'></Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsDateTime());
        }

        [TestMethod]
        public void IsDateTime_dateParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type options='date'></Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsDateTime());
        }

        [TestMethod]
        public void IsDateTime_DateParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type options='Date'></Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsDateTime());
        }

        [TestMethod]
        public void IsDateTime_dateTimeParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type options='dateTime'></Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsDateTime());
        }

        [TestMethod]
        public void IsDateTime_DateTimeParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type options='DateTime'></Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsDateTime());
        }

        [TestMethod]
        public void IsDateTime_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>discreet</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsDateTime());
        }

        [TestMethod]
        public void IsDateTime_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsDateTime());
        }

        #endregion

        #region IsTime

        [TestMethod]
        public void IsTime_TimeParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type options='time'></Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsTime());
        }

        [TestMethod]
        public void IsTime_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>discreet</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsTime());
        }

        [TestMethod]
        public void IsTime_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsTime());
        }

        #endregion

        #region IsString

        [TestMethod]
        public void IsString_StringParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>string</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsString());
        }

        [TestMethod]
        public void IsString_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>discreet</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsString());
        }

        [TestMethod]
        public void IsString_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsString());
        }

        #endregion

        #region IsPageButton

        [TestMethod]
        public void IsPageButton_ButtonParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>pagebutton</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsPageButton());
        }

        [TestMethod]
        public void IsPageButton_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>discreet</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsPageButton());
        }

        [TestMethod]
        public void IsPageButton_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsPageButton());
        }

        #endregion

        #region IsTitle

        [TestMethod]
        public void IsTitle_TitleParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>title</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsTitle());
        }

        [TestMethod]
        public void IsTitle_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>discreet</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsTitle());
        }

        [TestMethod]
        public void IsTitle_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsTitle());
        }

        #endregion

        #region IsProgress

        [TestMethod]
        public void IsProgress_ProgressParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>progress</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsProgress());
        }

        [TestMethod]
        public void IsProgress_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>discreet</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsProgress());
        }

        [TestMethod]
        public void IsProgress_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsProgress());
        }

        #endregion

        #region IsAnalog

        [TestMethod]
        public void IsAnalog_AnalogParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>analog</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsTrue(parameter.IsAnalog());
        }

        [TestMethod]
        public void IsAnalog_OtherParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Measurement>
				<Type>discreet</Type>
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsAnalog());
        }

        [TestMethod]
        public void IsAnalog_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsFalse(parameter.IsAnalog());
        }

        #endregion

        #endregion

        #region TryGet

        #region TryGetRead

        [TestMethod]
        public void TryGetRead_ReadWriteParam_WriteParam()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>ReadWriteParam</Name>
        			<Description>ReadWriteParam</Description>
        			<Type>read</Type>
        		</Param>
        		<Param id='2'>
        			<Name>ReadWriteParam</Name>
        			<Description>ReadWriteParam</Description>
        			<Type>write</Type>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var writeParam = protocol.Params[1];

            bool success = writeParam.TryGetRead(model.RelationManager, out var readParam);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual((uint)1, readParam.Id.Value);
        }

        [TestMethod]
        public void TryGetRead_OnlyWriteParam_FalseAndNull()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='2'>
        			<Name>ReadWriteParam</Name>
        			<Description>ReadWriteParam</Description>
        			<Type>write</Type>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var writeParam = protocol.Params[0];

            bool success = writeParam.TryGetRead(model.RelationManager, out var readParam);

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(null, readParam);
        }

        [TestMethod]
        public void TryGetRead_OnlyReadParam_FalseAndNull()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>ReadWriteParam</Name>
        			<Description>ReadWriteParam</Description>
        			<Type>read</Type>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var writeParam = protocol.Params[0];

            bool success = writeParam.TryGetRead(model.RelationManager, out var readParam);

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(null, readParam);
        }

        [TestMethod]
        public void TryGetRead_OtherParam_FalseAndNull()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>ReadWriteParam</Name>
        			<Description>ReadWriteParam</Description>
        			<Type>array</Type>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var writeParam = protocol.Params[0];

            bool success = writeParam.TryGetRead(model.RelationManager, out var readParam);

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(null, readParam);
        }

        #endregion

        #region TryGetWrite

        [TestMethod]
        public void TryGetWrite_ReadWriteParam_ReadParam()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>ReadWriteParam</Name>
        			<Description>ReadWriteParam</Description>
        			<Type>read</Type>
        		</Param>
        		<Param id='2'>
        			<Name>ReadWriteParam</Name>
        			<Description>ReadWriteParam</Description>
        			<Type>write</Type>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var readParam = protocol.Params[0];

            bool success = readParam.TryGetWrite(model.RelationManager, out var writeParam);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual((uint)2, writeParam.Id.Value);
        }

        [TestMethod]
        public void TryGetWrite_OnlyWriteParam_FalseAndNull()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='2'>
        			<Name>ReadWriteParam</Name>
        			<Description>ReadWriteParam</Description>
        			<Type>write</Type>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var readParam = protocol.Params[0];

            bool success = readParam.TryGetWrite(model.RelationManager, out var writeParam);

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(null, writeParam);
        }

        [TestMethod]
        public void TryGetWrite_OnlyReadParam_FalseAndNull()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>ReadWriteParam</Name>
        			<Description>ReadWriteParam</Description>
        			<Type>read</Type>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var readParam = protocol.Params[0];

            bool success = readParam.TryGetWrite(model.RelationManager, out var writeParam);

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(null, writeParam);
        }

        [TestMethod]
        public void TryGetWrite_OtherParam_FalseAndNull()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>ReadWriteParam</Name>
        			<Description>ReadWriteParam</Description>
        			<Type>array</Type>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var readParam = protocol.Params[0];

            bool success = readParam.TryGetWrite(model.RelationManager, out var writeParam);

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(null, writeParam);
        }

        #endregion

        #region TryGetTable

        [TestMethod]
        public void TryGetTable_Column_True_Table()
        {
            // Arrange
            string xml = @"<Protocol>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions>
				<ColumnOption pid='1001'/>
			</ArrayOptions>
			<Measurement>
				<Type>table</Type>
			</Measurement>
		</Param>
		<Param id='1001'/>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var column = protocol.Params[1];
            bool success = column.TryGetTable(model.RelationManager, out var table);

            // Assert
            Assert.IsTrue(success);
            Assert.IsNotNull(table);
            Assert.AreEqual((uint)1000, table.Id.Value);
        }

        [TestMethod]
        public void TryGetTable_Table_False_Null()
        {
            // Arrange
            string xml = @"<Protocol>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions>
				<ColumnOption pid='1001'/>
			</ArrayOptions>
			<Measurement>
				<Type>table</Type>
			</Measurement>
		</Param>
		<Param id='1001'/>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var column = protocol.Params[0];
            bool success = column.TryGetTable(model.RelationManager, out var table);

            // Assert
            Assert.IsFalse(success);
            Assert.IsNull(table);
        }

        [TestMethod]
        public void TryGetTable_NormalParam_False_Null()
        {
            // Arrange
            string xml = @"<Protocol><Params><Param><Type>read</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var column = protocol.Params[0];
            bool success = column.TryGetTable(model.RelationManager, out var table);

            // Assert
            Assert.IsFalse(success);
            Assert.IsNull(table);
        }

        #endregion

        #region TryGetIndexColumn

        [TestMethod]
        public void TryGetIndexColumn_Table_True_Column()
        {
            // Arrange
            string xml = @"<Protocol>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions index='0'>
				<ColumnOption idx='0' pid='1001'/>
			</ArrayOptions>
			<Measurement>
				<Type>table</Type>
			</Measurement>
		</Param>
		<Param id='1001'/>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var table = protocol.Params[0];
            bool success = table.TryGetPrimaryKeyColumn(model.RelationManager, out var primaryKeyColumn);

            // Assert
            Assert.IsTrue(success);
            Assert.IsNotNull(primaryKeyColumn);
            Assert.AreEqual((uint)1001, primaryKeyColumn.Id.Value);
        }

        [TestMethod]
        public void TryGetIndexColumn_Column_False_Null()
        {
            // Arrange
            string xml = @"<Protocol>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions index='0'>
				<ColumnOption idx='0' pid='1001'/>
			</ArrayOptions>
			<Measurement>
				<Type>table</Type>
			</Measurement>
		</Param>
		<Param id='1001'/>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var table = protocol.Params[1];
            bool success = table.TryGetPrimaryKeyColumn(model.RelationManager, out var column);

            // Assert
            Assert.IsFalse(success);
            Assert.IsNull(column);
        }

        [TestMethod]
        public void TryGetIndexColumn_NormalParam_False_Null()
        {
            // Arrange
            string xml = @"<Protocol><Params><Param><Type>read</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var table = protocol.Params[0];
            bool success = table.TryGetPrimaryKeyColumn(model.RelationManager, out var column);

            // Assert
            Assert.IsFalse(success);
            Assert.IsNull(column);
        }

        #endregion

        #region TryGetIndexColumnFromOptions

        [TestMethod]
        public void TryGetIndexColumnFromOptions_Table_True_Column()
        {
            // Arrange
            string xml = @"<Protocol>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions index='0'>
				<ColumnOption idx='0' pid='1001'/>
                <ColumnOption idx='1' pid='1002' options='indexColumn'/>
			</ArrayOptions>
			<Measurement>
				<Type>table</Type>
			</Measurement>
		</Param>
		<Param id='1001'/>
        <Param id='1002'/>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var table = protocol.Params[0];
            (uint? idx, string pid, IParamsParam column) = table.GetIndexColumns(model.RelationManager).FirstOrDefault();

            // Assert
            Assert.IsNotNull(column);
            Assert.AreEqual("1002", pid);
        }

        [TestMethod]
        public void TryGetIndexColumnFromOptions_Column_False_Null()
        {
            // Arrange
            string xml = @"<Protocol>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions index='0'>
				<ColumnOption idx='0' pid='1001'/>
                <ColumnOption idx='1' pid='1002' options='indexColumn'/>
			</ArrayOptions>
			<Measurement>
				<Type>table</Type>
			</Measurement>
		</Param>
		<Param id='1001'/>
        <Param id='1002'/>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var table = protocol.Params[1];
            bool success = table.GetIndexColumns(model.RelationManager).Any();

            // Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void TryGetIndexColumnFromOptions_NormalParam_False_Null()
        {
            // Arrange
            string xml = @"<Protocol><Params><Param><Type>read</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var table = protocol.Params[0];
            bool success = table.GetIndexColumns(model.RelationManager).Any();

            // Assert
            Assert.IsFalse(success);
        }

        #endregion
        
        #endregion

        #region IsTreeControl

        [TestMethod]
        public void IsTreeControl_True()
        {
            // Arrange
            string xml = @"<Protocol>
	<TreeControls>
		<TreeControl parameterId='10'></TreeControl>
	</TreeControls>
	<Params>
		<Param id='10'></Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.IsTreeControl(model.RelationManager);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void IsTreeControl_False()
        {
            // Arrange
            string xml = @"<Protocol>
	<TreeControls>
		<TreeControl parameterId='10'></TreeControl>
	</TreeControls>
	<Params>
		<Param id='5'></Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.IsTreeControl(model.RelationManager);

            // Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void IsTreeControl_NoTreeControl_False()
        {
            // Arrange
            string xml = @"<Protocol>
	<Params>
		<Param id='5'></Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.IsTreeControl(model.RelationManager);

            // Assert
            Assert.IsFalse(success);
        }

        #endregion

        #region GetRTDisplay

        [TestMethod]
        public void GetRTDisplay_True_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Display>
				<RTDisplay>true</RTDisplay>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.GetRTDisplay();

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetRTDisplay_False_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Display>
				<RTDisplay>false</RTDisplay>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.GetRTDisplay();

            // Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void GetRTDisplay_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.GetRTDisplay();

            // Assert
            Assert.IsFalse(success);
        }

        #endregion

        #region GetId

        [TestMethod]
        [DataRow("1")]
        [DataRow("1 ")]
        [DataRow(" 1")]
        [DataRow("01 ")]
        [DataRow("ABC")]
        [DataRow("")]
        public void GetId_CorrectAttribute_CorrectId(string idFormat)
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param id='" + idFormat + "'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            string id = parameter.Id?.RawValue;

            // Assert
            Assert.AreEqual(idFormat, id);
        }

        [TestMethod]
        public void GetId_MissingAttribute_Null()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            string id = parameter.Id?.RawValue;

            // Assert
            Assert.IsNull(id);
        }

        #endregion

        #region WillBeExported

        [TestMethod]
        public void WillBeExported_ExportedParam_True()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param export='true'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.WillBeExported();

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("false")]
        public void WillBeExported_WrongValues_False(string value)
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param export='" + value + "'></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.WillBeExported();

            // Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void WillBeExported_MissingAttribute_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.WillBeExported();

            // Assert
            Assert.IsFalse(success);
        }

        #endregion

        #region HasPosition

        [TestMethod]
        public void HasPosition_Position_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Display>
				<Positions>
					<Position>
					</Position>
				</Positions>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.HasPosition();

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void HasPosition_NoPosition_False()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Display>
				<Positions>
				</Positions>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.HasPosition();

            // Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void HasPosition_MissingTags_False()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.HasPosition();

            // Assert
            Assert.IsFalse(success);
        }

        #endregion

        #region IsInSLElement

        [TestMethod]
        public void IsInSLElement_NormalParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Display>
				<RTDisplay>true</RTDisplay>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.IsInSLElement(model.RelationManager);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void IsInSLElement_HiddenParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param>
        			<Display>
        				<RTDisplay>false</RTDisplay>
        			</Display>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.IsInSLElement(model.RelationManager);

            // Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void IsInSLElement_ColumnParam_True()
        {
            // Arrange.
            string xml = @"<Protocol xmlns='http://www.skyline.be/protocol'>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions index='0'>
				<ColumnOption idx='0' pid='1001' type='retrieved' options=''/>
			</ArrayOptions>
			<Display>
				<RTDisplay>true</RTDisplay>
			</Display>
		</Param>
		<Param id='1001'>
			<Type>read</Type>
			<Display>
				<RTDisplay>true</RTDisplay>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[1];
            bool success = parameter.IsInSLElement(model.RelationManager);

            // Assert
            Assert.IsTrue(success);
        }

        #endregion

        #region IsDisplayed

        [TestMethod]
        public void IsDisplayed_NormalParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Display>
				<RTDisplay>true</RTDisplay>
				<Positions>
					<Position>
						<Page>Page</Page>
						<Row>0</Row>
						<Column>0</Column>
					</Position>
				</Positions>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.IsDisplayed(model.RelationManager);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void IsDisplayed_HiddenParam_False()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param>
        			<Display>
        				<RTDisplay>false</RTDisplay>
				           <Positions>
				           	    <Position>
				           	    	<Page>Page</Page>
				           	    	<Row>0</Row>
				           	    	<Column>0</Column>
				           	    </Position>
				           </Positions>
        			</Display>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.IsDisplayed(model.RelationManager);

            // Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void IsDisplayed_ColumnParamTableWithPosition_True()
        {
            // Arrange.
            string xml = @"<Protocol xmlns='http://www.skyline.be/protocol'>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions index='0'>
				<ColumnOption idx='0' pid='1001' type='retrieved' options=''/>
			</ArrayOptions>
			<Display>
				<RTDisplay>true</RTDisplay>
				<Positions>
					<Position>
						<Page>Page</Page>
						<Row>0</Row>
						<Column>0</Column>
					</Position>
				</Positions>
			</Display>
		</Param>
		<Param id='1001'>
			<Type>read</Type>
			<Display>
				<RTDisplay>true</RTDisplay>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[1];
            bool success = parameter.IsDisplayed(model.RelationManager);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void IsDisplayed_ColumnParamTableWithoutPosition_False()
        {
            // Arrange.
            string xml = @"<Protocol xmlns='http://www.skyline.be/protocol'>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions index='0'>
				<ColumnOption idx='0' pid='1001' type='retrieved' options=''/>
			</ArrayOptions>
			<Display>
				<RTDisplay>true</RTDisplay>
			</Display>
		</Param>
		<Param id='1001'>
			<Type>read</Type>
			<Display>
				<RTDisplay>true</RTDisplay>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[1];
            bool success = parameter.IsDisplayed(model.RelationManager);

            // Assert
            Assert.IsFalse(success);
        }

        #endregion

        #region IsPositioned

        [TestMethod]
        public void IsPositioned_NormalParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param>
			<Display>
				<RTDisplay>true</RTDisplay>
				<Positions>
					<Position>
						<Page>Page</Page>
						<Row>0</Row>
						<Column>0</Column>
					</Position>
				</Positions>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.IsPositioned(model.RelationManager);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void IsPositioned_HiddenParam_True()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param>
        			<Display>
        				<RTDisplay>false</RTDisplay>
				           <Positions>
				           	    <Position>
				           	    	<Page>Page</Page>
				           	    	<Row>0</Row>
				           	    	<Column>0</Column>
				           	    </Position>
				           </Positions>
        			</Display>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            bool success = parameter.IsPositioned(model.RelationManager);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void IsPositioned_ColumnParamTableWithPosition_True()
        {
            // Arrange.
            string xml = @"<Protocol xmlns='http://www.skyline.be/protocol'>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions index='0'>
				<ColumnOption idx='0' pid='1001' type='retrieved' options=''/>
			</ArrayOptions>
			<Display>
				<RTDisplay>true</RTDisplay>
				<Positions>
					<Position>
						<Page>Page</Page>
						<Row>0</Row>
						<Column>0</Column>
					</Position>
				</Positions>
			</Display>
		</Param>
		<Param id='1001'>
			<Type>read</Type>
			<Display>
				<RTDisplay>true</RTDisplay>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[1];
            bool success = parameter.IsPositioned(model.RelationManager);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void IsPositioned_ColumnParamTableWithHiddenTable_True()
        {
            // Arrange.
            string xml = @"<Protocol xmlns='http://www.skyline.be/protocol'>
	<Params>
		<Param id='1000'>
			<Type>array</Type>
			<ArrayOptions index='0'>
				<ColumnOption idx='0' pid='1001' type='retrieved' options=''/>
			</ArrayOptions>
			<Display>
				<RTDisplay>false</RTDisplay>
				<Positions>
					<Position>
						<Page>Page</Page>
						<Row>0</Row>
						<Column>0</Column>
					</Position>
				</Positions>
			</Display>
		</Param>
		<Param id='1001'>
			<Type>read</Type>
			<Display>
				<RTDisplay>false</RTDisplay>
			</Display>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[1];
            bool success = parameter.IsPositioned(model.RelationManager);

            // Assert
            Assert.IsTrue(success);
        }

        #endregion

        #region LoggerTable

        [DataTestMethod]
        [DataRow("<Type>array</Type><ArrayOptions options=';database:100'></ArrayOptions>")]
        [DataRow("<ArrayOptions options=';database:100'></ArrayOptions>")]
        [DataRow("<ArrayOptions options='database:100'></ArrayOptions>")]
        public void IsLoggerTable_DataDriven_True(string innerParam)
        {
            // Arrange.
            string xml = "<Protocol><Params><Param id='100'>" + innerParam + "</Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol?.Params[0];
            bool isLoggerTable = param.IsLoggerTable();

            // Assert
            Assert.IsTrue(isLoggerTable);
        }

        [DataTestMethod]
        [DataRow("<Type>array</Type><ArrayOptions options=''></ArrayOptions>")]
        [DataRow("")]
        [DataRow("<ArrayOptions options='100'></ArrayOptions>")]
        public void IsLoggerTable_DataDriven_False(string innerParam)
        {
            // Arrange.
            string xml = "<Protocol><Params><Param id='100'>" + innerParam + "</Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol?.Params[0];
            bool isLoggerTable = param.IsLoggerTable();

            // Assert
            Assert.IsFalse(isLoggerTable);
        }

        #endregion

        #region GetDependencyReferenceParameters

        [TestMethod]
        public void GetDependencyReferenceParameters_DependencyParamWithReferenceParam_ReferenceParam()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='1'>
			<Dependencies>
				<Id>2</Id>
			</Dependencies>
		</Param>
		<Param id='2'>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[1];
            ICollection<IParamsParam> refParams = parameter.GetDependencyReferenceParameters(model.RelationManager);

            // Assert
            Assert.AreEqual(1, refParams.Count);
            Assert.AreEqual((uint?)1, refParams.ToList()[0].Id.Value);
        }

        [TestMethod]
        public void GetDependencyReferenceParameters_NormalParam_EmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='1'>
		</Param>
		<Param id='2'>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            ICollection<IParamsParam> refParams = parameter.GetDependencyReferenceParameters(model.RelationManager);

            // Assert
            Assert.AreEqual(0, refParams.Count);
        }

        [TestMethod]
        public void GetDependencyReferenceParameters_ReferenceParamCircular_Itself()
        {
            /*
             * Technically this is correct, but should be checked in the validator as this probably gives issues inside a DataMiner?
             */

            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='1'>
			<Dependencies>
				<Id>1</Id>
			</Dependencies>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            ICollection<IParamsParam> refParams = parameter.GetDependencyReferenceParameters(model.RelationManager);

            // Assert
            Assert.AreEqual(1, refParams.Count);
            Assert.AreEqual((uint?)1, refParams.ToList()[0].Id.Value);
        }
        #endregion

        #region GetDependencyParameters

        [TestMethod]
        public void GetDependencyParameters_DependencyParamWithReferenceParam_DependencyParam()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='1'>
			<Dependencies>
				<Id>2</Id>
			</Dependencies>
		</Param>
		<Param id='2'>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            ICollection<IParamsParam> dependencyParams = parameter.GetDependencyParameters(model.RelationManager);

            // Assert
            Assert.AreEqual(1, dependencyParams.Count);
            Assert.AreEqual((uint?)2, dependencyParams.ToList()[0].Id.Value);
        }

        [TestMethod]
        public void GetDependencyParameters_DependencyParamsWithReferenceParam_DependencyParams()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='1'>
			<Dependencies>
				<Id>2</Id>
                <Id>3</Id>
			</Dependencies>
		</Param>
		<Param id='2'>
		</Param>
        <Param id='3'>
        </Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            ICollection<IParamsParam> dependencyParams = parameter.GetDependencyParameters(model.RelationManager);

            // Assert
            Assert.AreEqual(2, dependencyParams.Count);
        }

        [TestMethod]
        public void GetDependencyParameters_ReferenceParam_EmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='1'>
		</Param>
		<Param id='2'>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            ICollection<IParamsParam> dependencyParams = parameter.GetDependencyParameters(model.RelationManager);

            // Assert
            Assert.AreEqual(0, dependencyParams.Count);
        }

        [TestMethod]
        public void GetDependencyParameters_ReferenceParamCircular_Itself()
        {
            /*
             * Technically this is correct, but should be checked in the validator as this probably gives issues inside a DataMiner?
             */

            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='1'>
			<Dependencies>
				<Id>1</Id>
			</Dependencies>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            ICollection<IParamsParam> dependencyParams = parameter.GetDependencyParameters(model.RelationManager);

            // Assert
            Assert.AreEqual(1, dependencyParams.Count);
            Assert.AreEqual((uint?)1, dependencyParams.ToList()[0].Id.Value);
        }

        #endregion

        #region GetDependencyIdParams

        [TestMethod]
        public void GetDependencyIdParams_DropdownParamWithDependencyParam_DependencyParam()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='1'>
			<Measurement>
				<Discreets dependencyId='2' />
			</Measurement>
		</Param>
		<Param id='2' />
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[1];
            var dependencyParams = parameter.GetDependencyIdParams(model.RelationManager).ToList();

            // Assert
            Assert.AreEqual(1, dependencyParams.Count);
            Assert.AreEqual((uint?)1, dependencyParams[0].Id.Value);
        }

        [TestMethod]
        public void GetDependencyIdParams_DropdownParamWithDependencyParams_DependencyParams()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='1'>
			<Measurement>
				<Discreets dependencyId='2' />
			</Measurement>
		</Param>
		<Param id='10'>
			<Measurement>
				<Discreets dependencyId='2' />
			</Measurement>
		</Param>
		<Param id='2' />
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[2];
            var dependencyParams = parameter.GetDependencyIdParams(model.RelationManager).ToList();

            // Assert
            Assert.AreEqual(2, dependencyParams.Count);
        }

        [TestMethod]
        public void GetDependencyIdParams_OtherParam_EmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='2' />
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var dependencyParams = parameter.GetDependencyIdParams(model.RelationManager).ToList();

            // Assert
            Assert.AreEqual(0, dependencyParams.Count);
        }

        [TestMethod]
        public void GetDependencyIdParams_DependencyParam_EmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='1'>
			<Measurement>
				<Discreets dependencyId='2' />
			</Measurement>
		</Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var dependencyParams = parameter.GetDependencyIdParams(model.RelationManager).ToList();

            // Assert
            Assert.AreEqual(0, dependencyParams.Count);
        }


        [TestMethod]
        public void GetRelations_NoLengthTypeId_EmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='2'>
            <Name></Name>
            <Description>After Startup</Description>   
            <Type></Type>   
            <Interprete>   
                <LengthType>other param</LengthType>        
            </Interprete>        
        </Param>           
    </Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var relations = ((IRelationEvaluator)parameter).GetRelations().ToList();

            // Assert
            Assert.AreEqual(0, relations.Count);
        }

        [TestMethod]
        public void GetRelations_LengthTypeIdNotEmpty_ReferenceToOtherParam()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
		<Param id='2'>
            <Name></Name>
            <Description>After Startup</Description>   
            <Type></Type>   
            <Interprete>   
                <LengthType id='7'>other param</LengthType>        
            </Interprete>        
        </Param>           
    </Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var relations = ((IRelationEvaluator)parameter).GetRelations().ToList();

            // Assert
            var reference = relations.First();
            Assert.AreEqual(1, relations.Count);
            Assert.AreEqual("7", reference.TargetId);
        }
        #endregion

        #region GetCommands

        [TestMethod]
        public void GetCommands_ZeroCommand()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>Param</Name>
        			<Description>Param</Description>
        			<Type>read</Type>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];

            var result = param.GetCommands(model.RelationManager).ToList();

            // Assert
            result.Should().HaveCount(0);
        }

        [TestMethod]
        public void GetCommands_OneCommand()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>Param</Name>
        			<Description>Param</Description>
        			<Type>read</Type>
        		</Param>
        	</Params>
            <Commands>
                <Command id='10'>
                    <Name>Command</Name>
                    <Content>
                        <Param>1</Param>
                    </Content>
                </Command>
            </Commands>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];

            var result = param.GetCommands(model.RelationManager).ToList();

            // Assert
            result.Should().HaveCount(1);
            result[0].Id.Value.Should().Be(10);
        }

        [TestMethod]
        public void GetCommands_TwoCommands()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>Param</Name>
        			<Description>Param</Description>
        			<Type>read</Type>
        		</Param>
        	</Params>
            <Commands>
                <Command id='10'>
                    <Name>Command1</Name>
                    <Content>
                        <Param>1</Param>
                    </Content>
                </Command>
                <Command id='20'>
                    <Name>Command2</Name>
                    <Content>
                        <Param>1</Param>
                    </Content>
                </Command>
            </Commands>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];

            var result = param.GetCommands(model.RelationManager).ToList();

            // Assert
            result.Should().HaveCount(2);
        }

        #endregion

        #region GetResponses

        [TestMethod]
        public void GetResponses_ZeroResponse()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>Param</Name>
        			<Description>Param</Description>
        			<Type>read</Type>
        		</Param>
        	</Params>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];

            var result = param.GetResponses(model.RelationManager).ToList();

            // Assert
            result.Should().HaveCount(0);
        }

        [TestMethod]
        public void GetResponses_OneResponse()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>Param</Name>
        			<Description>Param</Description>
        			<Type>read</Type>
        		</Param>
        	</Params>
            <Responses>
                <Response id='10'>
                    <Name>Response</Name>
                    <Content>
                        <Param>1</Param>
                    </Content>
                </Response>
            </Responses>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];

            var result = param.GetResponses(model.RelationManager).ToList();

            // Assert
            result.Should().HaveCount(1);
            result[0].Id.Value.Should().Be(10);
        }

        [TestMethod]
        public void GetResponses_TwoResponses()
        {
            // Arrange.
            string xml = @"<Protocol>
        	<Params>
        		<Param id='1'>
        			<Name>Param</Name>
        			<Description>Param</Description>
        			<Type>read</Type>
        		</Param>
        	</Params>
            <Responses>
                <Response id='10'>
                    <Name>Response1</Name>
                    <Content>
                        <Param>1</Param>
                    </Content>
                </Response>
                <Response id='20'>
                    <Name>Response2</Name>
                    <Content>
                        <Param>1</Param>
                    </Content>
                </Response>
            </Responses>
        </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var param = protocol.Params[0];

            var result = param.GetResponses(model.RelationManager).ToList();

            // Assert
            result.Should().HaveCount(2);
        }

        #endregion
    }
}

/*

        [TestMethod]
        public void METHOD_WHAT_OUTCOME()
        {
            // Arrange.
            string xml = @"";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
        }

     */
