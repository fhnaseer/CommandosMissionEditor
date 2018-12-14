using System.IO;
using Commandos.IO.Files;
using Commandos.IO.Serializers.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Files
{
    [TestClass]
    [DeploymentItem("TestFiles")]
    public class RecordWriterTest
    {
        public TestContext TestContext { get; set; }


        [TestMethod]
        public void RecordWriter_Works()
        {
            // Arrange,
            var path = Path.Combine(TestContext.DeploymentDirectory, "5G1A.mis");
            var outputPath = Path.Combine(TestContext.DeploymentDirectory, "output.mis");
            var input = MisFileReader.GetMultipleRecords(path);
            var target = new RecordWriter(input);

            // Act,
            var lines = target.GetTextLines();
            File.WriteAllLines(outputPath, lines);

            // Assert,
        }
    }
}
