using System;
using Commandos.IO.Files;
using Commandos.IO.Serializers.Map;
using Commandos.Model.Common;
using Commandos.Model.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Map
{
    [TestClass]
    public class MissionSerializerTest
    {
        [TestMethod]
        public void GetMission_Works()
        {
            // Arrange,
            const string text = "[ .MANUAL_LIBRETA Manual_Libreta_TU01A.msb .VISORES [ .XYZ ( 1 2 0 ) .ESC EXTERIOR .CAMARA 0 ] .BRIEFING [ .INICIAL TU01A.BRI ] .BAS TU01.BAS ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = new Mission
            {
                MsbFileName = "Manual_Libreta_TU01A.msb",
                BasFileName = "TU01.BAS",
                Camera = new Camera
                {
                    Position = new Position(1, 2, 0),
                    Escape = "EXTERIOR",
                    CameraDirection = CameraDirection.Zero
                },
                Briefing = new Briefing
                {
                    FileName = "TU01A.BRI"
                },
            };
            var record = TokenParser.ParseTokens(tokens);

            // Act,
            var actual = MissionSerializer.GetMission(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
