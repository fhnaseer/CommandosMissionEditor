using System;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.Model.Map;
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
            const string text = "[ .VISORES [ .XYZ ( 1 2 0 ) .ESC EXTERIOR .CAMARA 0 ] ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = new Camera
            {
                Position = new Model.Common.Position("1", "2", "0"),
                Area = "EXTERIOR",
                CameraDirection = "0"
            };
            var record = TokenParser.ParseTokens(tokens).GetMultipleRecord(CameraSerializer.Camera);
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
            var expected = new Camera
            {
                Position = new Model.Common.Position("1", "2", "0"),
                Area = "EXTERIOR",
                CameraDirection = "0"
            };
            var target = new CameraSerializer();

            // Act,
            var record = target.Deserialize(expected);
            var actual = target.Serialize(record.GetMultipleRecords());

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
