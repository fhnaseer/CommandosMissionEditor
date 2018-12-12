using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests
{
    [TestClass]
    [DeploymentItem("TestFiles")]
    public class MisFileReaderTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GetCameraIndex_Works()
        {
            // Arrange,
            var path = Path.Combine(TestContext.DeploymentDirectory, "5G1A.mis");
            var tokens = MisFileReader.GetTokens(path);

            // Act,
            var result = MisFileReader.GetCameraIndex(tokens);

            // Assert,
            Assert.AreEqual(3, result.startIndex);
            Assert.AreEqual(15, result.endIndex);
        }
    }
}
