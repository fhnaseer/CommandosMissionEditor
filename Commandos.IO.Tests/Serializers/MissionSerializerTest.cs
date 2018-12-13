using System;
using Commandos.IO.Serializers;
using Commandos.Model.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers
{
    [TestClass]
    public class MissionSerializerTest
    {
        [TestMethod]
        public void ToMission_Works()
        {
            // Arrange,
            const string text = "[    .MANUAL_LIBRETA Manual_Libreta_TU01A.msb     .VISORES     [         .XYZ         (             1 2 0         )         .ESC EXTERIOR        .CAMARA 0    ]    .BRIEFING    [        .INICIAL TU01A.BRI    ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var camera = new Model.Camera
            {
                Position = new Model.Common.Position(1, 2, 0),
                Escape = "EXTERIOR",
                CameraDirection = Model.CameraDirection.Zero
            };
            var expected = new Mission
            {
                Camera = camera,
                MsbFileName = "Manual_Libreta_TU01A.msb"
            };

            // Act,
            var actual = MissionSerializer.ToMission(tokens);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
