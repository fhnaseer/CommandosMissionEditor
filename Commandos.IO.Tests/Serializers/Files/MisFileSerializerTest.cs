using System.IO;
using Commandos.IO.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Files
{
    [TestClass]
    [DeploymentItem("TestFiles")]
    public class MisFileSerializerTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void MisFile_Read_Write_Works()
        {
            // Arrange,
            var inputPath = Path.Combine(TestContext.DeploymentDirectory, "5G1A.mis");
            var outputPath = Path.Combine(TestContext.DeploymentDirectory, "directOutput.mis");
            var expected = MisFileSerializer.ReadMisFile(inputPath);

            // Act,
            MisFileSerializer.WriteMisFile(outputPath, expected);
            var actual = MisFileSerializer.ReadMisFile(outputPath);

            // Assert,
            Assert.AreEqual(expected, actual);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void MisFile_Read_Write_Works_WrongBrackets()
        {
            // Arrange,
            var inputPath = Path.Combine(TestContext.DeploymentDirectory, "TU01A.mis");
            var outputPath = Path.Combine(TestContext.DeploymentDirectory, "directOutput.mis");
            var expected = MisFileSerializer.ReadMisFile(inputPath);

            // Act,
            MisFileSerializer.WriteMisFile(outputPath, expected);
            var actual = MisFileSerializer.ReadMisFile(outputPath);

            // Assert,
            Assert.AreEqual(expected, actual);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void MisFile_Read_Write_File_Content_Check()
        {
            // Arrange,
            var inputPath = Path.Combine(TestContext.DeploymentDirectory, "5G1A.mis");
            var firstOutputPath = Path.Combine(TestContext.DeploymentDirectory, "firstOutput.mis");
            var secondOutputPath = Path.Combine(TestContext.DeploymentDirectory, "secondOutput.mis");
            var mission = MisFileSerializer.ReadMisFile(inputPath);

            // Act,
            MisFileSerializer.WriteMisFile(firstOutputPath, mission);
            var expected = File.ReadAllLines(firstOutputPath);
            mission = MisFileSerializer.ReadMisFile(firstOutputPath);
            MisFileSerializer.WriteMisFile(secondOutputPath, mission);
            var actual = File.ReadAllLines(secondOutputPath);

            // Assert,
            CollectionAssert.AreEqual(expected, actual);
            File.Delete(firstOutputPath);
            File.Delete(secondOutputPath);
        }
    }
}
