namespace Models.ProtocolTests.Read.Protocol.Relations
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class Relation : ProtocolTestBase
    {

        #region Name

        [TestMethod]
        public void Name_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation name='Test'>
                                </Relation>
                            </Relations>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("Test", protocol.Relations[0].Name.Value);
        }

        [TestMethod]
        public void Name_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation name=''/>
                            </Relations>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Relations[0].Name.Value);
        }

        [TestMethod]
        public void Name_Missing_Null()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation/>
                            </Relations>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Relations[0].Name);
        }

        #endregion

        #region Options

        [TestMethod]
        public void Options_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation options='Test'/>
                            </Relations>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("Test", protocol.Relations[0].Options.Value);
        }

        [TestMethod]
        public void Options_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation options='' />
                            </Relations>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Relations[0].Options.Value);
        }

        [TestMethod]
        public void Options_Missing_Null()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation/>
                            </Relations>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Relations[0].Options);
        }

        #endregion

        #region Path

        [TestMethod]
        public void Path_Valid_ReturnsCorrectValue()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation path='Test'/>
                            </Relations>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual("Test", protocol.Relations[0].Path.Value);
        }

        [TestMethod]
        public void Path_Empty_IsEmpty()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation path='' />
                            </Relations>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(String.Empty, protocol.Relations[0].Path.Value);
        }

        [TestMethod]
        public void Path_Missing_Null()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <Relations>
                                <Relation/>
                            </Relations>
                           </Protocol>";

            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.IsNull(protocol.Relations[0].Path);
        }

        #endregion

    }
}
