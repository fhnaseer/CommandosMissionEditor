using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests
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
            Assert.AreEqual(1, result.nameIndex);
            Assert.AreEqual(2, result.startIndex);
            Assert.AreEqual(2, result.endIndex);
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
            Assert.AreEqual(3, result.nameIndex);
            Assert.AreEqual(4, result.startIndex);
            Assert.AreEqual(15, result.endIndex);
        }

        [TestMethod]
        public void GetRecordIndexes_MixedRecords_Works()
        {
            // Arrange,
            const string text = "[ .MANUAL_LIBRETA Manual_Libreta_TU01A.msb .VISORES [ .XYZ ( 241.0 - 248.0 0 ) .ESC EXTERIOR .CAMARA 0 ] " +
                ".MUSICA [ .MUSICAS ( ( Battle.WAV EXTERIOR ) ( Shadows.WAV INTERIOR ) ) .MUSICA_POR_DEFECTO EXTERIOR ] .BRIEFING [ .INICIAL TU01A.BRI ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var result = IndexHelper.GetIndexes(tokens, 3);

            // Assert,
            Assert.AreEqual(19, result.nameIndex);
            Assert.AreEqual(20, result.startIndex);
            Assert.AreEqual(29, result.endIndex);
        }
    }
}
