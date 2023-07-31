namespace Models.ProtocolTests.Read.Protocol
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Protocol : ProtocolTestBase
    {
        #region Attributes

        #region BaseFor

        [TestMethod]
        public void BaseFor_ValidBaseFor_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol baseFor='Test'></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("Test", protocol.BaseFor.Value);
        }

        [TestMethod]
        public void BaseFor_EmptyBaseFor_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol baseFor=''></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.BaseFor.Value);
        }

        [TestMethod]
        public void BaseFor_MissingBaseFor_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.BaseFor);
        }

        #endregion

        #endregion
        
        #region Tags

        #region Name

        [TestMethod]
        public void Name_ValidProtocolName_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Name>Skyline SmartRec Application</Name></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("Skyline SmartRec Application", protocol.Name.Value);
        }

        [TestMethod]
        public void Name_EmptyProtocolName_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Name></Name></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Name.Value);
        }

        [TestMethod]
        public void Name_MissingProtocolName_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Name);
        }

        #endregion

        #region Description

        [TestMethod]
        public void Description_ValidProtocolDescription_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Description>Protocol Description</Description></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("Protocol Description", protocol.Description.Value);
        }

        [TestMethod]
        public void Description_EmptyProtocolDescription_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Description></Description></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Description.Value);
        }

        [TestMethod]
        public void Description_MissingProtocolDescription_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Description);
        }

        #endregion

        #region Version

        [TestMethod]
        public void Version_ValidProtocolVersion_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Version>1.0.0.1</Version></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("1.0.0.1", protocol.Version.Value);
        }

        [TestMethod]
        public void Version_EmptyProtocolVersion_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Version></Version></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Version.Value);
        }

        [TestMethod]
        public void Version_MissingProtocolVersion_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Version);
        }

        #endregion

        #region Provider

        [TestMethod]
        public void Provider_ValidProtocolProvider_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Provider>Skyline Communications</Provider></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("Skyline Communications", protocol.Provider.Value);
        }

        [TestMethod]
        public void Provider_EmptyProtocolProvider_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Provider></Provider></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Provider.Value);
        }

        [TestMethod]
        public void Provider_MissingProtocolProvider_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Provider);
        }

        #endregion

        #region Vendor

        [TestMethod]
        public void Vendor_ValidProtocolVendor_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><Vendor>Skyline Communications</Vendor></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("Skyline Communications", protocol.Vendor.Value);
        }

        [TestMethod]
        public void Vendor_EmptyProtocolVendor_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><Vendor></Vendor></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Vendor.Value);
        }

        [TestMethod]
        public void Vendor_MissingProtocolVendor_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Vendor);
        }

        #endregion

        #region VendorOID

        [TestMethod]
        public void VendorOID_ValidProtocolVendorOID_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><VendorOID>1.3.6.1.4.1.8813.2.48</VendorOID></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("1.3.6.1.4.1.8813.2.48", protocol.VendorOID.Value);
        }

        [TestMethod]
        public void VendorOID_EmptyProtocolVendorOID_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><VendorOID></VendorOID></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.VendorOID.Value);
        }

        [TestMethod]
        public void VendorOID_MissingProtocolVendorOID_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);
            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.VendorOID);
        }

        #endregion

        #region DeviceOID

        [TestMethod]
        public void DeviceOID_ValidProtocolDeviceOID_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><DeviceOID>32</DeviceOID></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual((uint)32, protocol.DeviceOID.Value);
        }

        [TestMethod]
        public void DeviceOID_EmptyProtocolDeviceOID_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol><DeviceOID></DeviceOID></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.DeviceOID.Value);
        }

        [TestMethod]
        public void DeviceOID_MissingProtocolDeviceOID_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.DeviceOID);
        }

        #endregion

        #region ElementType

        [TestMethod]
        public void ElementType_ValidProtocolElementType_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol><ElementType>Manager</ElementType></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("Manager", protocol.ElementType.Value);
        }

        [TestMethod]
        public void ElementType_EmptyProtocolElementType_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol><ElementType></ElementType></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.ElementType.Value);
        }

        [TestMethod]
        public void ElementType_MissingProtocolElementType_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.ElementType);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_AvailableProtocolType_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Type></Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Type);
        }

        [TestMethod]
        public void Type_MissingProtocolType_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Type);
        }

        #endregion

        #region Display

        [TestMethod]
        public void Display_AvailableProtocolDisplay_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Display></Display></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Display);
        }

        [TestMethod]
        public void Display_MissingProtocolDisplay_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Display);
        }

        #endregion

        #region SNMP

        [TestMethod]
        public void SNMP_AvailableProtocolSNMP_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><SNMP></SNMP></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.SNMP);
        }

        [TestMethod]
        public void SNMP_MissingProtocolSNMP_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.SNMP);
        }

        #endregion

        #region Parameters

        [TestMethod]
        public void Parameters_AvailableProtocolParameters_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Params></Params></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Params);
        }

        [TestMethod]
        public void Parameters_MissingProtocolParameters_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Params);
        }

        #endregion

        #region QActions

        [TestMethod]
        public void QActions_AvailableProtocolQActions_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><QActions></QActions></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.QActions);
        }

        [TestMethod]
        public void QActions_MissingProtocolQActions_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.QActions);
        }

        #endregion

        #region Groups

        [TestMethod]
        public void Groups_AvailableProtocolGroups_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Groups></Groups></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Groups);
        }

        [TestMethod]
        public void Groups_MissingProtocolGroups_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Groups);
        }

        #endregion

        #region Triggers

        [TestMethod]
        public void Triggers_AvailableProtocolTriggers_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Triggers></Triggers></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Triggers);
        }

        [TestMethod]
        public void Triggers_MissingProtocolTriggers_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Triggers);
        }

        #endregion

        #region Actions

        [TestMethod]
        public void Actions_AvailableProtocolActions_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Actions></Actions></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Actions);
        }

        [TestMethod]
        public void Actions_MissingProtocolActions_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Actions);
        }

        #endregion

        #region Timers

        [TestMethod]
        public void Timers_AvailableProtocolTimers_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Timers></Timers></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Timers);
        }

        [TestMethod]
        public void Timers_MissingProtocolTimers_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Timers);
        }

        #endregion

        #region PortSettings

        [TestMethod]
        public void PortSettings_AvailableProtocolPortSettings_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><PortSettings></PortSettings></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.PortSettings);
        }

        [TestMethod]
        public void PortSettings_MissingProtocolPortSettings_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.PortSettings);
        }

        #endregion

        #region Commands

        [TestMethod]
        public void Commands_AvailableProtocolCommands_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Commands></Commands></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Commands);
        }

        [TestMethod]
        public void Commands_MissingProtocolCommands_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Commands);
        }

        #endregion

        #region Responses

        [TestMethod]
        public void Responses_AvailableProtocolResponses_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Responses></Responses></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Responses);
        }

        [TestMethod]
        public void Responses_MissingProtocolResponses_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Responses);
        }

        #endregion

        #region Pairs

        [TestMethod]
        public void Pairs_AvailableProtocolPairs_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Pairs></Pairs></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Pairs);
        }

        [TestMethod]
        public void Pairs_MissingProtocolPairs_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Pairs);
        }

        #endregion

        #region Relations

        [TestMethod]
        public void Relations_AvailableProtocolRelations_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Relations></Relations></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Relations);
        }

        [TestMethod]
        public void Relations_MissingProtocolRelations_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Relations);
        }

        #endregion

        #region HTTP

        [TestMethod]
        public void HTTP_AvailableProtocolHTTP_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><HTTP></HTTP></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.HTTP);
        }

        [TestMethod]
        public void HTTP_MissingProtocolHTTP_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.HTTP);
        }

        #endregion

        #region Ports

        [TestMethod]
        public void Ports_AvailableProtocolPorts_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><Ports></Ports></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Ports);
        }

        [TestMethod]
        public void Ports_MissingProtocolPorts_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.Ports);
        }

        #endregion

        #region ExportRules

        [TestMethod]
        public void ExportRules_AvailableProtocolExportRules_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><ExportRules></ExportRules></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.ExportRules);
        }

        [TestMethod]
        public void ExportRules_MissingProtocolExportRules_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.ExportRules);
        }

        #endregion

        #region ParameterGroups

        [TestMethod]
        public void ParameterGroups_AvailableProtocolParameterGroups_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol><ParameterGroups></ParameterGroups></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.ParameterGroups);
        }

        [TestMethod]
        public void ParameterGroups_MissingProtocolParameterGroups_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(null, protocol.ParameterGroups);
        }

        #endregion

        #endregion

        #region Methods

        #region IsSpectrum

        [TestMethod]
        public void IsSpectrum_ValidAttribute_True()
        {
            // Arrange.
            string xml = @"<Protocol><Display type='spectrum analyzer'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsTrue(protocol.IsSpectrum());
        }

        [TestMethod]
        public void IsSpectrum_EmptyAttribute_False()
        {
            // Arrange.
            string xml = @"<Protocol><Display type=''/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsSpectrum());
        }

        [TestMethod]
        public void IsSpectrum_MissingAttribute_False()
        {
            // Arrange.
            string xml = @"<Protocol><Display/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsSpectrum());
        }

        [TestMethod]
        public void IsSpectrum_InvalidAttribute_False()
        {
            // Arrange.
            string xml = @"<Protocol><Display type='agdfslf'/></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsSpectrum());
        }

        #endregion

        #region IsEnhancedService

        [TestMethod]
        public void IsEnhancedService_ValidTag_True()
        {
            // Arrange.
            string xml = @"<Protocol><Type>service</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsTrue(protocol.IsEnhancedService());
        }

        [TestMethod]
        public void IsEnhancedService_EmptyTag_False()
        {
            // Arrange.
            string xml = @"<Protocol><Type></Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsEnhancedService());
        }

        [TestMethod]
        public void IsEnhancedService_MissingTag_False()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsEnhancedService());
        }

        [TestMethod]
        public void IsEnhancedService_InvalidTag_False()
        {
            // Arrange.
            string xml = @"<Protocol><Type>virtual</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsEnhancedService());
        }

        #endregion

        #region IsMediation

        [TestMethod]
        public void IsMediation_ValidAttribute_True()
        {
            // Arrange.
            string xml = @"<Protocol baseFor='TestProtocol'></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsTrue(protocol.IsMediation());
        }

        [TestMethod]
        public void IsMediation_EmptyAttribute_False()
        {
            // Arrange.
            string xml = @"<Protocol baseFor=''></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsMediation());
        }

        [TestMethod]
        public void IsMediation_MissingAttribute_False()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsMediation());
        }

        #endregion

        #region IsSLA

        [TestMethod]
        public void IsSLA_ValidTag_True()
        {
            // Arrange.
            string xml = @"<Protocol><Type>sla</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsTrue(protocol.IsSLA());
        }

        [TestMethod]
        public void IsSLA_EmptyTag_False()
        {
            // Arrange.
            string xml = @"<Protocol><Type></Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsSLA());
        }

        [TestMethod]
        public void IsSLA_MissingTag_False()
        {
            // Arrange.
            string xml = @"<Protocol></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsSLA());
        }

        [TestMethod]
        public void IsSLA_InvalidTag_False()
        {
            // Arrange.
            string xml = @"<Protocol><Type>virtual</Type></Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsFalse(protocol.IsSLA());
        }

        #endregion

        #endregion
    }
}