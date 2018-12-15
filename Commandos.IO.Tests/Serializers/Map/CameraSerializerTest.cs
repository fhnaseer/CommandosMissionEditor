using System;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.Model.Common;
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
                Position = new Model.Common.Position(1, 2, 0),
                Escape = "EXTERIOR",
                CameraDirection = CameraDirection.Zero
            };
            var record = TokenParser.ParseTokens(tokens).GetMultipleRecord(StringConstants.Camera);

            // Act,
            var actual = CameraSerializer.GetCamera(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
