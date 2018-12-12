using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests
{
    [TestClass]
    public class IndexHelperTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GetSingleValueIndex_Works()
        {
            // Arrange,
            const string text = "[    .MANUAL_LIBRETA Manual_Libreta_TU01A.msb     .VISORES     [         .XYZ         (             241.0 - 248.0 0         )         .ESC EXTERIOR        .CAMARA 0    ]    .BRIEFING    [        .INICIAL TU01A.BRI    ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var result = IndexHelper.GetIndexes(tokens, StringConstants.MsbFile, 0, TokenType.SingleValue);

            // Assert,
            Assert.AreEqual(1, result.startIndex);
            Assert.AreEqual(2, result.endIndex);
        }

        [TestMethod]
        public void GetPositionIndex_Works()
        {
            // Arrange,
            const string text = "[    .MANUAL_LIBRETA Manual_Libreta_TU01A.msb     .VISORES     [         .XYZ         (             241.0 - 248.0 0         )         .ESC EXTERIOR        .CAMARA 0    ]    .BRIEFING    [        .INICIAL TU01A.BRI    ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var result = IndexHelper.GetPositionIndexes(tokens, 0);

            // Assert,
            Assert.AreEqual(5, result.startIndex);
            Assert.AreEqual(11, result.endIndex);
        }

        [TestMethod]
        public void GetCameraIndex_Works()
        {
            // Arrange,
            const string text = "[    .MANUAL_LIBRETA Manual_Libreta_TU01A.msb     .VISORES     [         .XYZ         (             241.0 - 248.0 0         )         .ESC EXTERIOR        .CAMARA 0    ]    .BRIEFING    [        .INICIAL TU01A.BRI    ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var result = IndexHelper.GetCameraIndexes(tokens);

            // Assert,
            Assert.AreEqual(3, result.startIndex);
            Assert.AreEqual(16, result.endIndex);
        }
    }
}
