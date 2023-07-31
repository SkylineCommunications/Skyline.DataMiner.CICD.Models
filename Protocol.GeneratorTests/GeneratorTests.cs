namespace Protocol.GeneratorTests
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Protocol.Generator;
    using Protocol.Generator.XSD;

    [TestClass]
    public class GeneratorTests
    {
        private static ProtocolXsd _xsd;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var baseDir = Path.GetDirectoryName(typeof(ModelGenerator).Assembly.Location);
            var xsdPath = Path.GetFullPath(Path.Combine(baseDir, "Skyline", "XSD", "protocol.xsd"));

            _xsd = new ProtocolXsd(xsdPath);
        }

        [TestMethod]
        public void ModelGenerator_GenerateEnums()
        {
            // just trigger the generator, to check if no exceptions occur
            string code = ModelGenerator.GenerateEnums(_xsd);

            Assert.IsNotNull(code);
            Assert.AreNotEqual(0, code.Length);
        }

        [TestMethod]
        public void ModelGenerator_GenerateReadInterfaces()
        {
            // just trigger the generator, to check if no exceptions occur
            string code = ModelGenerator.GenerateReadInterfaces(_xsd);

            Assert.IsNotNull(code);
            Assert.AreNotEqual(0, code.Length);
        }

        [TestMethod]
        public void ModelGenerator_GenerateReadClasses()
        {
            // just trigger the generator, to check if no exceptions occur
            string code = ModelGenerator.GenerateReadClasses(_xsd);

            Assert.IsNotNull(code);
            Assert.AreNotEqual(0, code.Length);
        }

        [TestMethod]
        public void ModelGenerator_GenerateEditClasses()
        {
            // just trigger the generator, to check if no exceptions occur
            string code = ModelGenerator.GenerateEditClasses(_xsd);

            Assert.IsNotNull(code);
            Assert.AreNotEqual(0, code.Length);
        }

        [TestMethod]
        public void ModelGenerator_GenerateReadProtocolVisitor()
        {
            // just trigger the generator, to check if no exceptions occur
            string code = ModelGenerator.GenerateReadProtocolVisitor(_xsd);

            Assert.IsNotNull(code);
            Assert.AreNotEqual(0, code.Length);
        }

        [TestMethod]
        public void ModelGenerator_GenerateEditProtocolVisitor()
        {
            // just trigger the generator, to check if no exceptions occur
            string code = ModelGenerator.GenerateEditProtocolVisitor(_xsd);

            Assert.IsNotNull(code);
            Assert.AreNotEqual(0, code.Length);
        }
    }
}
