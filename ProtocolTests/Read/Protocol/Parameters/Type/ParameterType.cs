namespace Models.ProtocolTests.Read.Protocol.Parameters.Type
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Enums = Skyline.DataMiner.CICD.Models.Protocol.Enums;

    [TestClass]
    public class ParameterType : ProtocolTestBase
    { 
        #region Value

        [TestMethod]
        public void Type_Array_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>array</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Array, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Bus_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>bus</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Bus, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_CRC_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>crc</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Crc, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_DataminerInfo_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>dataminer info</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.DataminerInfo, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_DiscreetInfo_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>discreet info</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.DiscreetInfo, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Dummy_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>dummy</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Dummy, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_ElementDmaId_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>elementdmaid</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Elementdmaid, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_ElementId_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>elementid</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Elementid, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_ElementName_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>elementname</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Elementname, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Fixed_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>fixed</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Fixed, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Group_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>group</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Group, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Header_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>header</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Header, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Ip_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>ip</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Ip, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Length_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>length</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Length, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_PollingIp_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>pollingip</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Pollingip, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Read_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>read</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Read, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_ReadBit_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>read bit</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.ReadBit, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Response_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>response</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Response, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Trailer_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>trailer</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Trailer, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_Write_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>write</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.Write, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_WriteBit_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>write bit</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(Enums.EnumParamType.WriteBit, parameter.Type.Value);
        }

        [TestMethod]
        public void Type_InvalidParameterType_ReturnsUnknown()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type>arr</Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Type.Value);
        }

        [TestMethod]
        public void Type_EmptyParameterType_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type></Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Type.Value);
        }

        [TestMethod]
        public void Type_MissingParameterType_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Type);
        }

        #endregion

        #region Id

        [TestMethod]
        public void Id_ValidId_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type id='Read'></Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual("Read", parameter.Type.Id.Value);
        }

        [TestMethod]
        public void Id_EmptyValue_ReturnsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type id=''></Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.AreEqual(String.Empty, parameter.Type.Id.Value);
        }

        [TestMethod]
        public void Id_MissingTag_ReturnsNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params><Param><Type></Type></Param></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];

            // Assert
            Assert.IsNull(parameter.Type.Id);
        }

        #endregion

        #region Methods

        #region ExtractOptions

        [TestMethod]
        public void ExtractOptions_NoAttribute_Null()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
        <Param id='1'>
            <Type>array</Type>
        </Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var result = parameter.Type.GetOptions();

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ExtractOptions_Dimensions_CorrectDimensions()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
        <Param id='3'>
            <Type options='dimensions=64,128'>array</Type>
        </Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var result = parameter.Type.GetOptions();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((uint)64, result.Dimensions.Rows);
            Assert.AreEqual((uint)128, result.Dimensions.Columns);
        }

        [TestMethod]
        public void ExtractOptions_IncorrectDimensions_NullDimensions()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
        <Param id='3'>
            <Type options='dimensions=128'>array</Type>
        </Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var result = parameter.Type.GetOptions();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((uint)128, result.Dimensions.Rows);
            Assert.IsNull(result.Dimensions.Columns);
        }

        [TestMethod]
        public void ExtractOptions_ColumnTypes_CorrectColumnTypes()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
        <Param id='3'>
            <Type options='columntypes=101:0-128'>array</Type>
        </Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var result = parameter.Type.GetOptions();

            // Assert
            Assert.IsNotNull(result);
            Assert.HasCount(1, result.ColumnTypes.ColumnTypes);
        }

        [TestMethod]
        public void ExtractOptions_ColumnTypes2_CorrectColumnTypes()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
        <Param id='3'>
            <Type options='columntypes=101:0-128,222|102:0-128'>array</Type>
        </Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var result = parameter.Type.GetOptions();

            // Assert
            Assert.IsNotNull(result);
            Assert.HasCount(2, result.ColumnTypes.ColumnTypes);
        }

        [TestMethod]
        public void ExtractOptions_OtherOptionWithDimensions_CorrectDimensions()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
        <Param id='3'>
            <Type options='connection=0;dimensions=64,128'>array</Type>
        </Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var result = parameter.Type.GetOptions();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((uint)64, result.Dimensions.Rows);
            Assert.AreEqual((uint)128, result.Dimensions.Columns);
        }

        [TestMethod]
        public void ExtractOptions_OtherOption_NullDimensionNullColumnTypes()
        {
            // Arrange.
            string xml = @"<Protocol>
	<Params>
        <Param id='3'>
            <Type options='connection=0'>array</Type>
        </Param>
	</Params>
</Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            var parameter = protocol.Params[0];
            var result = parameter.Type.GetOptions();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Dimensions);
            Assert.IsNull(result.ColumnTypes);
        }

        #endregion

        #endregion
    }
}