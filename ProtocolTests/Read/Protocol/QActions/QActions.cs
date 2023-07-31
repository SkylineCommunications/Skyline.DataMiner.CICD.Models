namespace Models.ProtocolTests.Read.Protocol.QActions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class QActions : ProtocolTestBase
    {

        [TestMethod]
        public void QActions_NoAvailableQActions_ReturnsEmptyCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                            </QActions>
                           </Protocol>";

            // Act.
             ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(0, protocol.QActions.Count);
        }

        [TestMethod]
        public void QActions_AvailableQActions_ReturnActionCollection()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreEqual(2, protocol.QActions.Count);
        }

        [TestMethod]
        public void GetEnumerator_AvailableQActions_ReturnsEnumerator()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.QActions.GetEnumerator());
        }

        [TestMethod]
        public void Indexer_AvailableQActions_ReturnsNotNull()
        {
            // Arrange.
            string xml = @"<Protocol>
                            <QActions>
                                <QAction></QAction>
                                <QAction></QAction>
                            </QActions>
                           </Protocol>";


            // Act.
            ProtocolModel model = CreateModelFromXML(xml);

            IProtocol protocol = model.Protocol;

            // Assert
            Assert.AreNotEqual(null, protocol.QActions[0]);
        }
    }
}
