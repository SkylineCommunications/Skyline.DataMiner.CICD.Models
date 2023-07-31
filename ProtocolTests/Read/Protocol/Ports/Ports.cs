﻿namespace Models.ProtocolTests.Read.Protocol.Ports
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Ports : ProtocolTestBase
    {

        [TestMethod]
        public void Ports_NoAvailablePortSettings_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                            </Ports>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(0, protocol.Ports.Count);
        }

        [TestMethod]
        public void Ports_AvailablePortSettings_ReturnActionCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(2, protocol.Ports.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailablePortSettings_IsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Ports>
                                <PortSettings></PortSettings>
                                <PortSettings></PortSettings>
                            </Ports>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Ports.GetEnumerator());
        }


    }
}
