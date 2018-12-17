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
            var outputPath = Path.Combine(TestContext.DeploymentDirectory, "5G1A.mis");
            var expected = MisFileSerializer.ReadMisFile(inputPath);

            // Act,
            MisFileSerializer.WriteMisFile(outputPath, expected);
            var actual = MisFileSerializer.ReadMisFile(outputPath);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
