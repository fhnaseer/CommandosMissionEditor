﻿using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests
{
    [TestClass]
    [DeploymentItem("TestFiles")]
    public class MisFileReaderTest
    {
        public TestContext TestContext { get; set; }


        [TestMethod]
        public void MethodName()
        {
            // Arrange,
            var path = Path.Combine(TestContext.DeploymentDirectory, "5G1A.mis");

            // Act,
            var actual = MisFileReader.ReadMisFile(path);

            // Assert,
            //Assert.AreEqual(expected, actual);
        }
    }
}
