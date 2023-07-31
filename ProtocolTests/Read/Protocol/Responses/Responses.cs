﻿namespace Models.ProtocolTests.Read.Protocol.Responses
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Responses : ProtocolTestBase
    {

        [TestMethod]
        public void Responses_NoAvailableResponses_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                            </Responses>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(0, protocol.Responses.Count);
        }

        [TestMethod]
        public void Responses_AvailableResponses_ReturnsResponsesCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response></Response>
                                <Response></Response>
                            </Responses>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(2, protocol.Responses.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableResponses_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Responses>
                                <Response></Response>
                                <Response></Response>
                            </Responses>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.Responses.GetEnumerator());
        }

    }
}
