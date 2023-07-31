namespace Models.ProtocolTests.Custom_Classes.Protocol.Type
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class ExportProtocolTests
    {
        [TestMethod]
        public void ExportProtocol_ValidValue_CorrectData()
        {
            // Arrange.
            string[] options = new string[]
            {
                "exportProtocol",
                "MotherChildASlot",
                "100",
                "noElementPrefix",
            };

            // Act.
            var result = new ExportProtocol(options);

            // Assert
            Assert.AreEqual("MotherChildASlot", result.Name);
            Assert.AreEqual((uint)100, result.TablePid);
            Assert.IsTrue(result.NoElementPrefix);
        }

        [TestMethod]
        public void ExportProtocol_EmptyName_EmptyName()
        {
            // Arrange.
            string[] options = new string[]
            {
                "exportProtocol",
                String.Empty,
                "100",
                "noElementPrefix",
            };

            // Act.
            var result = new ExportProtocol(options);

            // Assert
            Assert.AreEqual(String.Empty, result.Name);
            Assert.AreEqual((uint)100, result.TablePid);
            Assert.IsTrue(result.NoElementPrefix);
        }

        [TestMethod]
        public void ExportProtocol_EmptyTableId_Null()
        {
            // Arrange.
            string[] options = new string[]
            {
                "exportProtocol",
                "MotherChildASlot",
                String.Empty,
                "noElementPrefix",
            };

            // Act.
            var result = new ExportProtocol(options);

            // Assert
            Assert.AreEqual("MotherChildASlot", result.Name);
            Assert.AreEqual(null, result.TablePid);
            Assert.IsTrue(result.NoElementPrefix);
        }

        [TestMethod]
        public void ExportProtocol_EmptyNoElementPrefix_False()
        {
            // Arrange.
            string[] options = new string[]
            {
                "exportProtocol",
                "MotherChildASlot",
                "100",
                String.Empty,
            };

            // Act.
            var result = new ExportProtocol(options);

            // Assert
            Assert.AreEqual("MotherChildASlot", result.Name);
            Assert.AreEqual((uint)100, result.TablePid);
            Assert.IsFalse(result.NoElementPrefix);
        }

        [TestMethod]
        public void ExportProtocol_EmptyList_False()
        {
            // Arrange.
            string[] options = new string[0];

            // Act.
            var result = new ExportProtocol(options);

            // Assert
            Assert.AreEqual(String.Empty, result.Name);
            Assert.AreEqual(null, result.TablePid);
            Assert.IsFalse(result.NoElementPrefix);
        }
    }
}