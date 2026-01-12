namespace Models.ProtocolTests.Read.Protocol.PortSettings
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class PortSettings : ProtocolTestBase
    {

        #region Baudrate

        [TestMethod]
        public void Baudrate_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Baudrate></Baudrate>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.Baudrate);
        }

        [TestMethod]
        public void Baudrate_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.Baudrate);
        }

        #endregion

        #region BusAddress

        [TestMethod]
        public void BusAddress_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <BusAddress></BusAddress>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.BusAddress);
        }

        [TestMethod]
        public void BusAddress_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.BusAddress);
        }

        #endregion

        #region Databits

        [TestMethod]
        public void Databits_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Databits></Databits>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.Databits);
        }

        [TestMethod]
        public void Databits_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.Databits);
        }

        #endregion

        #region Flowcontrol

        [TestMethod]
        public void Flowcontrol_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Flowcontrol></Flowcontrol>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.Flowcontrol);
        }

        [TestMethod]
        public void Flowcontrol_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.Flowcontrol);
        }

        #endregion

        #region GetCommunity

        [TestMethod]
        public void GetCommunity_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <GetCommunity></GetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.GetCommunity);
        }

        [TestMethod]
        public void GetCommunity_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.GetCommunity);
        }

        #endregion

        #region IPport

        [TestMethod]
        public void IPport_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <IPport></IPport>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.IPport);
        }

        [TestMethod]
        public void IPport_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.IPport);
        }

        #endregion

        #region LocalIPport

        [TestMethod]
        public void LocalIPport_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <LocalIPport></LocalIPport>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.LocalIPport);
        }

        [TestMethod]
        public void LocalIPport_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.LocalIPport);
        }

        #endregion

        #region Parity

        [TestMethod]
        public void Parity_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Parity></Parity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.Parity);
        }

        [TestMethod]
        public void Parity_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.Parity);
        }

        #endregion

        #region PingInterval

        [TestMethod]
        public void PingInterval_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <PingInterval></PingInterval>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.PingInterval);
        }

        [TestMethod]
        public void PingInterval_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.PingInterval);
        }

        #endregion

        #region PortTypeIP

        [TestMethod]
        public void PortTypeIP_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <PortTypeIP></PortTypeIP>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.PortTypeIP);
        }

        [TestMethod]
        public void PortTypeIP_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.PortTypeIP);
        }

        #endregion

        #region PortTypeSerial

        [TestMethod]
        public void PortTypeSerial_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <PortTypeSerial></PortTypeSerial>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.PortTypeSerial);
        }

        [TestMethod]
        public void PortTypeSerial_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.PortTypeSerial);
        }

        #endregion

        #region PortTypeUDP

        [TestMethod]
        public void PortTypeUDP_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <PortTypeUDP></PortTypeUDP>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.PortTypeUDP);
        }

        [TestMethod]
        public void PortTypeUDP_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.PortTypeUDP);
        }

        #endregion

        #region Retries

        [TestMethod]
        public void Retries_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Retries></Retries>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.Retries);
        }

        [TestMethod]
        public void Retries_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.Retries);
        }

        #endregion

        #region SetCommunity

        [TestMethod]
        public void SetCommunity_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <SetCommunity></SetCommunity>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.SetCommunity);
        }

        [TestMethod]
        public void SetCommunity_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.SetCommunity);
        }

        #endregion

        #region SlowPoll

        [TestMethod]
        public void SlowPoll_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPoll></SlowPoll>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;

            // Assert
            Assert.IsNotNull(portSettings.SlowPoll);
        }

        [TestMethod]
        public void SlowPoll_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings></PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;

            // Assert
            Assert.IsNull(portSettings.SlowPoll);
        }

        #endregion

        #region SlowPollBase

        [TestMethod]
        public void SlowPollBase_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings>
                                    <SlowPollBase></SlowPollBase>
                                </PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;

            // Assert
            Assert.IsNotNull(portSettings.SlowPollBase);
        }

        [TestMethod]
        public void SlowPollBase_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                                <PortSettings></PortSettings>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettingsMain portSettings = protocol.PortSettings;

            // Assert
            Assert.IsNull(portSettings.SlowPollBase);
        }

        #endregion

        #region Stopbits

        [TestMethod]
        public void Stopbits_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Stopbits></Stopbits>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.Stopbits);
        }

        [TestMethod]
        public void Stopbits_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.Stopbits);
        }

        #endregion

        #region TimeoutTime

        [TestMethod]
        public void TimeoutTime_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <TimeoutTime></TimeoutTime>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.TimeoutTime);
        }

        [TestMethod]
        public void TimeoutTime_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.TimeoutTime);
        }

        #endregion

        #region TimeoutTimeElement

        [TestMethod]
        public void TimeoutTimeElement_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <TimeoutTimeElement></TimeoutTimeElement>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.TimeoutTimeElement);
        }

        [TestMethod]
        public void TimeoutTimeElement_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.TimeoutTimeElement);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type_AvailableTag_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings>
                                    <Type></Type>
                                </PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNotNull(portSettings.Type);
        }

        [TestMethod]
        public void Type_NoAvailableTag_IsNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;
            IPortSettings portSettings = protocol.Ports[0];

            // Assert
            Assert.IsNull(portSettings.Type);
        }

        #endregion

    }
}
