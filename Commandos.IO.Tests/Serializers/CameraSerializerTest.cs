using System;
using Commandos.IO.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers
{
    [TestClass]
    public class CameraSerializerTest
    {
        [TestMethod]
        public void ToCamera_Works()
        {
            // Arrange,
            const string text = "[    .MANUAL_LIBRETA Manual_Libreta_TU01A.msb     .VISORES     [         .XYZ         (             1 2 0         )         .ESC EXTERIOR        .CAMARA 0    ]    .BRIEFING    [        .INICIAL TU01A.BRI    ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = new Model.Camera
            {
                Position = new Model.Common.Position(1, 2, 0),
                Escape = "EXTERIOR",
                CameraDirection = Model.CameraDirection.Zero
            };

            // Act,
            var actual = CameraSerializer.ToCamera(tokens, 0);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
