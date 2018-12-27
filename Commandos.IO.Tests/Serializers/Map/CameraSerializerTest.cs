using System;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.IO.Tests.Serializers.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Map
{
    [TestClass]
    public class CameraSerializerTest
    {
        [TestMethod]
        public void GetCamera_Works()
        {
            // Arrange,
            var text = SampleStrings.GetRecordString(SampleStrings.CameraString);
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = SampleObjects.Camera;
            var record = TokenParser.ParseTokens(tokens).GetRecord(CameraSerializer.Camera);
            var target = new CameraSerializer();

            // Act,
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Camera_Read_WriteWorks()
        {
            // Arrange,
            var expected = SampleObjects.Camera;
            var target = new CameraSerializer();

            // Act,
            var record = target.Deserialize(expected);
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
