namespace Models.ProtocolTests.Read.Protocol.Parameters.ArrayOptions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ColumnOption : ProtocolTestBase
    {
        #region TagName

        [TestMethod]
        public void ColumnOption_TagName_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption /></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual("ColumnOption", columnOption.TagName);
        }

        #endregion

        #region CPE Alignment

        [TestMethod]
        public void CPEAlignment_Left_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption cpeAlignment='left'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumCpeAlignment.Left, columnOption.CpeAlignment.Value);
        }

        [TestMethod]
        public void CPEAlignment_Center_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption cpeAlignment='center'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumCpeAlignment.Center, columnOption.CpeAlignment.Value);
        }

        [TestMethod]
        public void CPEAlignment_Right_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption cpeAlignment='right'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumCpeAlignment.Right, columnOption.CpeAlignment.Value);
        }

        [TestMethod]
        public void CPEAlignment_Invalid_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption cpeAlignment='lft'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.CpeAlignment.Value);
        }

        [TestMethod]
        public void CPEAlignment_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption cpeAlignment=''/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.CpeAlignment.Value);
        }

        [TestMethod]
        public void CPEAlignment_NoTagAvailable_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.CpeAlignment);
        }

        #endregion

        #region IDX

        [TestMethod]
        public void Idx_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption idx='1'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual((uint) 1, columnOption.Idx.Value);
        }

        [TestMethod]
        public void Idx_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption idx='one'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.Idx.Value);
        }

        [TestMethod]
        public void Idx_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption idx=''/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.Idx.Value);
        }

        [TestMethod]
        public void Idx_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.Idx);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption options='Test'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual("Test", columnOption.Options.Value);
        }
   
        [TestMethod]
        public void Options_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption options=''/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(String.Empty, columnOption.Options.Value);
        }

        [TestMethod]
        public void Options_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.Options);
        }

        #endregion

        #region PID

        [TestMethod]
        public void PID_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption pid='1'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual((uint)1, columnOption.Pid.Value);
        }

        [TestMethod]
        public void PID_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption pid='one'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.Pid.Value);
        }

        [TestMethod]
        public void PID_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption pid=''/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.Pid.Value);
        }

        [TestMethod]
        public void PID_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.Pid);
        }

        #endregion

        #region PollingRate

        [TestMethod]
        public void PollingRate_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption pollingRate='1'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual((uint)1, columnOption.PollingRate.Value);
        }

        [TestMethod]
        public void PollingRate_Invalid_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption pollingRate='one'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.PollingRate.Value);
        }

        [TestMethod]
        public void PollingRate_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption pollingRate=''/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.PollingRate.Value);
        }

        [TestMethod]
        public void PollingRate_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.PollingRate);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Value_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption value='Test'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual("Test", columnOption.ValueAttribute.Value);
        }

        [TestMethod]
        public void Value_Empty_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption value=''/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(String.Empty, columnOption.ValueAttribute.Value);
        }

        [TestMethod]
        public void Value_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.ValueAttribute);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_AutoIncrement_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption type='autoincrement'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumColumnOptionType.Autoincrement, columnOption.Type.Value);
        }

        [TestMethod]
        public void Type_Concatenation_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption type='concatenation'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumColumnOptionType.Concatenation, columnOption.Type.Value);
        }

        [TestMethod]
        public void Type_Custom_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption type='custom'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumColumnOptionType.Custom, columnOption.Type.Value);
        }

        [TestMethod]
        public void Type_DisplayKey_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption type='displaykey'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumColumnOptionType.Displaykey, columnOption.Type.Value);
        }

        [TestMethod]
        public void Type_Index_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption type='index'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumColumnOptionType.Index, columnOption.Type.Value);
        }

        [TestMethod]
        public void Type_Rtrieved_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption type='retrieved'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumColumnOptionType.Retrieved, columnOption.Type.Value);
        }

        [TestMethod]
        public void Type_Snmp_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption type='snmp'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumColumnOptionType.Snmp, columnOption.Type.Value);
        }

        [TestMethod]
        public void Type_State_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption type='state'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(EnumColumnOptionType.State, columnOption.Type.Value);
        }

        [TestMethod]
        public void Type_Invalid_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption type='ancrement'/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.Type.Value);
        }

        [TestMethod]
        public void Type_Empty_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption type=''/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.Type.Value);
        }

        [TestMethod]
        public void Type_NoTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><ArrayOptions><ColumnOption/></ArrayOptions></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var arrayOptions = parameter.ArrayOptions;
            var columnOption = arrayOptions[0];

            // Assert
            Assert.AreEqual(null, columnOption.Type);
        }

        #endregion
    }
}