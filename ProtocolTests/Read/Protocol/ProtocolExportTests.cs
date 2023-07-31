namespace Models.ProtocolTests.Read.Protocol
{
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Export;

    [TestClass]
    public class ProtocolExportTests : ProtocolTestBase
    {
        [TestMethod]
        public void ProtocolExportTests_Basic()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <Type>snmp</Type>
    <Params>
        <Param id='10' export='true'>
            <Name>Param 10</Name>
        </Param>
        <Param id='11' export='100'>
            <Name>Param 11</Name>
        </Param>
        <Param id='12' export='200'>
            <Name>Param 12</Name>
        </Param>
    </Params>
    <Timers></Timers>
</Protocol>";

            var model = CreateModelFromXML(xml);

            var model100 = model.GetExportedProtocol(100, "My Protocol - DVE");
            var protocol = model100.Protocol;

            Assert.AreEqual(model, model100.Model.MainProtocolModel);
            Assert.IsTrue(model100.Model.IsExportedProtocolModel);
            Assert.AreEqual("My Protocol - DVE", protocol.Name.Value);
            Assert.AreEqual(EnumProtocolType.Virtual, protocol.Type.Value);
            Assert.IsNull(protocol.Timers);

            Assert.AreEqual(2, protocol.Params.Count);
            Assert.AreEqual("Param 10", protocol.Params[0].Name.Value);
            Assert.AreEqual("Param 11", protocol.Params[1].Name.Value);

            new ProtocolCheckVisitor(x => Assert.IsInstanceOfType(x.ReadNode, typeof(XmlElementExportOverride)))
                .VisitProtocol(protocol);

            // check if main protocol object is still intact
            var mainProtocol = model.Protocol;
            Assert.AreEqual("My Protocol", mainProtocol.Name.Value);
            Assert.AreEqual(3, mainProtocol.Params.Count);
            Assert.IsNotNull(mainProtocol.Timers);

            new ProtocolCheckVisitor(x => Assert.IsNotInstanceOfType(x.ReadNode, typeof(XmlElementExportOverride)))
                .VisitProtocol(mainProtocol);
        }

        [TestMethod]
        public void ProtocolExportTests_Multiple()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <Params>
        <Param id='10' export='true'>
            <Name>Param 10</Name>
        </Param>
        <Param id='11' export='100;200'>
            <Name>Param 11</Name>
        </Param>
    </Params>
</Protocol>";

            var model = CreateModelFromXML(xml);
            var model100 = model.GetExportedProtocol(100, "My Protocol - DVE 100");
            var model200 = model.GetExportedProtocol(200, "My Protocol - DVE 200");

            Assert.AreEqual(2, model100.Protocol.Params.Count);
            Assert.AreEqual(2, model200.Protocol.Params.Count);
        }

        [TestMethod]
        public void ProtocolExportTests_ParamDiscreets()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <Type>snmp</Type>
    <Params>
        <Param id='10' export='true'>
            <Name>Param 10</Name>
            <Measurement>
                <Discreets>
                    <Discreet export='100'>
                        <Value>Value1</Value>
                        <Display>Display1</Display>
                    </Discreet>
                    <Discreet export='200'>
                        <Value>Value2</Value>
                        <Display>Display2</Display>
                    </Discreet>
                    <Discreet export='100;200'>
                        <Value>Value3</Value>
                        <Display>Display3</Display>
                    </Discreet>
                    <Discreet>
                        <Value>Value4</Value>
                        <Display>Display4</Display>
                    </Discreet>
                </Discreets>
            </Measurement>
        </Param>
    </Params>
    <Timers></Timers>
</Protocol>";

            var model = CreateModelFromXML(xml);

            var model100 = model.GetExportedProtocol(100, "My Protocol - DVE");
            var protocol = model100.Protocol;
            var param = protocol.Params[0];
            var discreets = param.Measurement.Discreets;
            var values = discreets.Select(x => x.ValueElement.Value);

            values.Should().HaveCount(3)
                  .And.Equal(new[] { "Value1", "Value3", "Value4" });
        }

        [TestMethod]
        public void ProtocolExportTests_NoExportedProtocols()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <Type>virtual</Type>
</Protocol>";

            var model = CreateModelFromXML(xml);
            var allExportedProtocols = model.GetAllExportedProtocols();

            Assert.AreEqual(0, allExportedProtocols.Count());
        }

        [TestMethod]
        public void ProtocolExportTests_AllExportedProtocols_OldFormat()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <Type options='exportProtocol:Export A:100;exportProtocol:Export B:200'>virtual</Type>
</Protocol>";

            var model = CreateModelFromXML(xml);
            var allExportedProtocols = model.GetAllExportedProtocols().ToList();

            Assert.AreEqual(2, allExportedProtocols.Count);

            var exportA = allExportedProtocols[0];
            Assert.AreEqual(100, exportA.TablePid);
            Assert.AreEqual("Export A", exportA.Model.Protocol.Name.Value);

            var exportB = allExportedProtocols[1];
            Assert.AreEqual(200, exportB.TablePid);
            Assert.AreEqual("Export B", exportB.Model.Protocol.Name.Value);
        }

        [TestMethod]
        public void ProtocolExportTests_AllExportedProtocols_OldFormat_EmptyId()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <Type options='exportProtocol:Export A:'>virtual</Type>
</Protocol>";

            var model = CreateModelFromXML(xml);
            var allExportedProtocols = model.GetAllExportedProtocols().ToList();

            Assert.AreEqual(0, allExportedProtocols.Count);
        }

        [TestMethod]
        public void ProtocolExportTests_AllExportedProtocols_OldFormat_EmptyName()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <Type options='exportProtocol::100'>virtual</Type>
</Protocol>";

            var model = CreateModelFromXML(xml);
            var allExportedProtocols = model.GetAllExportedProtocols().ToList();

            Assert.AreEqual(0, allExportedProtocols.Count);
        }

        [TestMethod]
        public void ProtocolExportTests_AllExportedProtocols_NewFormat()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <Type>virtual</Type>
    <DVEs>
        <DVEProtocols>
            <DVEProtocol tablePID='100' name='Export A' />
            <DVEProtocol tablePID='200' name='Export B' />
        </DVEProtocols>
    </DVEs>
</Protocol>";

            var model = CreateModelFromXML(xml);
            var allExportedProtocols = model.GetAllExportedProtocols().ToList();

            Assert.AreEqual(2, allExportedProtocols.Count);

            var exportA = allExportedProtocols[0];
            Assert.AreEqual(100, exportA.TablePid);
            Assert.AreEqual("Export A", exportA.Model.Protocol.Name.Value);

            var exportB = allExportedProtocols[1];
            Assert.AreEqual(200, exportB.TablePid);
            Assert.AreEqual("Export B", exportB.Model.Protocol.Name.Value);
        }

        [TestMethod]
        public void ProtocolExportTests_AllExportedProtocols_NewFormat_EmptyId()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <Type>virtual</Type>
    <DVEs>
        <DVEProtocols>
            <DVEProtocol tablePID='' name='Export A' />
        </DVEProtocols>
    </DVEs>
</Protocol>";

            var model = CreateModelFromXML(xml);
            var allExportedProtocols = model.GetAllExportedProtocols().ToList();

            Assert.AreEqual(0, allExportedProtocols.Count);
        }

        [TestMethod]
        public void ProtocolExportTests_AllExportedProtocols_NewFormat_EmptyName()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <Type>virtual</Type>
    <DVEs>
        <DVEProtocols>
            <DVEProtocol tablePID='100' name='' />
        </DVEProtocols>
    </DVEs>
</Protocol>";

            var model = CreateModelFromXML(xml);
            var allExportedProtocols = model.GetAllExportedProtocols().ToList();

            Assert.AreEqual(0, allExportedProtocols.Count);
        }

        [TestMethod]
        public void ProtocolExportTests_ExportRules_Basic()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <ExportRules>
        <ExportRule table='*'   tag='Protocol/Display' attribute='defaultPage' value='OtherPage' />
        <ExportRule table='100' tag='Protocol/Params/Param/Name' value='OtherName' />
    </ExportRules>
    <Params>
        <Param id='10' export='true'>
            <Name>Param 10</Name>
        </Param>
    </Params>
</Protocol>";

            var model = CreateModelFromXML(xml);

            var exportRules = model.Protocol.ExportRules;
            var exportRule0 = exportRules[0];
            var exportRule1 = exportRules[1];

            var model100 = model.GetExportedProtocol(100, "My Protocol - DVE");

            var defaultPage = model100.Protocol.Display.DefaultPage;
            Assert.AreEqual("OtherPage", defaultPage.Value);
            Assert.AreEqual(exportRule0, ((XmlAttributeExportOverride)defaultPage.ReadAttribute).ExportRule);

            var param100 = model100.Protocol.Params[0];
            Assert.AreEqual("OtherName", param100.Name.Value);
            Assert.AreEqual(exportRule1, ((XmlElementExportOverride)param100.Name.ReadNode).ExportRule);

            // check if main protocol object is still intact
            var mainProtocol = model.Protocol;
            Assert.AreEqual("General", mainProtocol.Display.DefaultPage.Value);
            Assert.AreEqual("Param 10", mainProtocol.Params[0].Name.Value);
        }

        [TestMethod]
        public void ProtocolExportTests_ExportRules_Multiple()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <ExportRules>
        <ExportRule table='*'   tag='Protocol/Display' attribute='defaultPage' value='OtherPage' />
        <ExportRule table='100;200' tag='Protocol/Params/Param/Name' value='OtherName' />
    </ExportRules>
    <Params>
        <Param id='10' export='true'>
            <Name>Param 10</Name>
        </Param>
    </Params>
</Protocol>";

            var model = CreateModelFromXML(xml);

            var model100 = model.GetExportedProtocol(100, "My Protocol - DVE 100");
            Assert.AreEqual("OtherPage", model100.Protocol.Display.DefaultPage.Value);
            Assert.AreEqual("OtherName", model100.Protocol.Params[0].Name.Value);

            var model200 = model.GetExportedProtocol(100, "My Protocol - DVE 200");
            Assert.AreEqual("OtherPage", model200.Protocol.Display.DefaultPage.Value);
            Assert.AreEqual("OtherName", model200.Protocol.Params[0].Name.Value);

            // check if main protocol object is still intact
            var mainProtocol = model.Protocol;
            Assert.AreEqual("General", mainProtocol.Display.DefaultPage.Value);
            Assert.AreEqual("Param 10", mainProtocol.Params[0].Name.Value);
        }

        [TestMethod]
        public void ProtocolExportTests_ExportRules_Regex()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <ExportRules>
        <ExportRule table='100' tag='Protocol/Params/Param/Name' regex='\s\(.+\)$' value='' />
    </ExportRules>
    <Params>
        <Param id='10' export='true'>
            <Name>Param 10 (Test)</Name>
        </Param>
        <Param id='11' export='true'>
            <Name>Param 11 (Test)</Name>
        </Param>
    </Params>
</Protocol>";

            var model = CreateModelFromXML(xml);

            var model100 = model.GetExportedProtocol(100, "My Protocol - DVE");
            Assert.AreEqual("Param 10", model100.Protocol.Params[0].Name.Value);
            Assert.AreEqual("Param 11", model100.Protocol.Params[1].Name.Value);

            // check if main protocol object is still intact
            var mainProtocol = model.Protocol;
            Assert.AreEqual("Param 10 (Test)", mainProtocol.Params[0].Name.Value);
            Assert.AreEqual("Param 11 (Test)", mainProtocol.Params[1].Name.Value);
        }

        [TestMethod]
        public void ProtocolExportTests_ExportRules_InvalidRegex()
        {
            // invalid regex should be ignored

            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <ExportRules>
        <ExportRule table='100' tag='Protocol/Params/Param/Name' regex='\s\(.+\)$[' value='' />
    </ExportRules>
    <Params>
        <Param id='10' export='true'>
            <Name>Param 10 (Test)</Name>
        </Param>
        <Param id='11' export='true'>
            <Name>Param 11 (Test)</Name>
        </Param>
    </Params>
</Protocol>";

            var model = CreateModelFromXML(xml);

            var model100 = model.GetExportedProtocol(100, "My Protocol - DVE");
            Assert.AreEqual("Param 10 (Test)", model100.Protocol.Params[0].Name.Value);
            Assert.AreEqual("Param 11 (Test)", model100.Protocol.Params[1].Name.Value);

            // check if main protocol object is still intact
            var mainProtocol = model.Protocol;
            Assert.AreEqual("Param 10 (Test)", mainProtocol.Params[0].Name.Value);
            Assert.AreEqual("Param 11 (Test)", mainProtocol.Params[1].Name.Value);
        }

        [TestMethod]
        public void ProtocolExportTests_ExportRules_WhereTag()
        {
            // language=xml
            string xml = @"
<Protocol>
    <Name>My Protocol</Name>
    <Display defaultPage='General' />
    <ExportRules>
        <ExportRule table='100' tag='Protocol/Params/Param/Name' value='Param Ten'    whereTag='Protocol/Params/Param/Description' whereValue='Desc 10' />
        <ExportRule table='100' tag='Protocol/Params/Param/Name' value='Param Eleven' whereTag='Protocol/Params/Param/Description' whereValue='Desc 11' />
    </ExportRules>
    <Params>
        <Param id='10' export='true'>
            <Name>Param 10</Name>
            <Description>Desc 10</Description>
        </Param>
        <Param id='11' export='true'>
            <Name>Param 11</Name>
            <Description>Desc 11</Description>
        </Param>
    </Params>
</Protocol>";

            var model = CreateModelFromXML(xml);

            var model100 = model.GetExportedProtocol(100, "My Protocol - DVE");
            Assert.AreEqual("Param Ten", model100.Protocol.Params[0].Name.Value);
            Assert.AreEqual("Param Eleven", model100.Protocol.Params[1].Name.Value);

            // check if main protocol object is still intact
            var mainProtocol = model.Protocol;
            Assert.AreEqual("Param 10", mainProtocol.Params[0].Name.Value);
            Assert.AreEqual("Param 11", mainProtocol.Params[1].Name.Value);
        }
    }
}