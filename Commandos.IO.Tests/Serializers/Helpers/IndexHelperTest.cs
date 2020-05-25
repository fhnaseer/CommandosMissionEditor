using System;
using Commandos.IO.Serializers.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Helpers
{
    [TestClass]
    public class IndexHelperTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GetIndexes_SingleValue_Works()
        {
            // Arrange,
            const string text = "[ .MANUAL_LIBRETA Manual_Libreta_TU01A.msb .VISORES [ .XYZ ( 241.0 - 248.0 0 ) .ESC EXTERIOR .CAMARA 0 ] " +
                ".MUSICA [ .MUSICAS ( ( Battle.WAV EXTERIOR ) ( Shadows.WAV INTERIOR ) ) .MUSICA_POR_DEFECTO EXTERIOR ] .BRIEFING [ .INICIAL TU01A.BRI ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var result = IndexHelper.GetIndexes(tokens, 0);

            // Assert,
            Assert.AreEqual(1, result.NameIndex);
            Assert.AreEqual(2, result.StartIndex);
            Assert.AreEqual(2, result.EndIndex);
        }

        [TestMethod]
        public void GetRecordIndexes_MultipleRecords_Works()
        {
            // Arrange,
            const string text = "[ .MANUAL_LIBRETA Manual_Libreta_TU01A.msb .VISORES [ .XYZ ( 241.0 - 248.0 0 ) .ESC EXTERIOR .CAMARA 0 ] " +
                ".MUSICA [ .MUSICAS ( ( Battle.WAV EXTERIOR ) ( Shadows.WAV INTERIOR ) ) .MUSICA_POR_DEFECTO EXTERIOR ] .BRIEFING [ .INICIAL TU01A.BRI ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var result = IndexHelper.GetIndexes(tokens, 3);

            // Assert,
            Assert.AreEqual(3, result.NameIndex);
            Assert.AreEqual(4, result.StartIndex);
            Assert.AreEqual(16, result.EndIndex);
        }

        [TestMethod]
        public void GetRecordIndexes_MixedRecords_Works()
        {
            // Arrange,
            const string text = "[ .MANUAL_LIBRETA Manual_Libreta_TU01A.msb .VISORES [ .XYZ ( 241.0 - 248.0 0 ) .ESC EXTERIOR .CAMARA 0 ] " +
                ".MUSICA [ .MUSICAS ( ( Battle.WAV EXTERIOR ) ( Shadows.WAV INTERIOR ) ) .MUSICA_POR_DEFECTO EXTERIOR ] .BRIEFING [ .INICIAL TU01A.BRI ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var result = IndexHelper.GetIndexes(tokens, 19);

            // Assert,
            Assert.AreEqual(19, result.NameIndex);
            Assert.AreEqual(20, result.StartIndex);
            Assert.AreEqual(29, result.EndIndex);
        }
    }
}
