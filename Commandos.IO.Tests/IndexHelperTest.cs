//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Commandos.IO.Tests
//{
//    [TestClass]
//    public class IndexHelperTest
//    {
//        public TestContext TestContext { get; set; }

//        [TestMethod]
//        public void GetRecordIndexes_SingleValue_Works()
//        {
//            // Arrange,
//            const string text = "[    .MANUAL_LIBRETA Manual_Libreta_TU01A.msb     .VISORES     [         .XYZ         (             241.0 - 248.0 0         )         .ESC EXTERIOR        .CAMARA 0    ]    .BRIEFING    [        .INICIAL TU01A.BRI    ]";
//            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

//            // Act,
//            var result = IndexHelper.GetRecordIndexes(tokens, StringConstants.MsbFile, 0, TokenType.SingleValue);

//            // Assert,
//            Assert.AreEqual(1, result.startIndex);
//            Assert.AreEqual(2, result.endIndex);
//        }

//        [TestMethod]
//        public void GetRecordIndexes_MultipleValues_Works()
//        {
//            // Arrange,
//            const string text = "[    .MANUAL_LIBRETA Manual_Libreta_TU01A.msb     .VISORES     [         .XYZ         (             241.0 - 248.0 0         )         .ESC EXTERIOR        .CAMARA 0    ]    .BRIEFING    [        .INICIAL TU01A.BRI    ]";
//            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

//            // Act,
//            var result = IndexHelper.GetRecordIndexes(tokens, StringConstants.Camera, 0, TokenType.MultipleRecords);

//            // Assert,
//            Assert.AreEqual(3, result.startIndex);
//            Assert.AreEqual(16, result.endIndex);
//        }

//        //[TestMethod]
//        //public void GetIndexes_RoundBracket_Works()
//        //{
//        //    // Arrange,
//        //    const string text = "[    .MANUAL_LIBRETA Manual_Libreta_TU01A.msb     .VISORES     [         .XYZ         (             241.0 - 248.0 0         )         .ESC EXTERIOR        .CAMARA 0    ]    .BRIEFING    [        .INICIAL TU01A.BRI    ]";
//        //    var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

//        //    // Act,
//        //    var result = IndexHelper.GetRecordIndexes(tokens, StringConstants.Position, 0, TokenType.RoundBrackets);

//        //    // Assert,
//        //    Assert.AreEqual(5, result.startIndex);
//        //    Assert.AreEqual(11, result.endIndex);
//        //}

//        //[TestMethod]
//        //public void GetPositionIndexes_Works()
//        //{
//        //    // Arrange,
//        //    const string text = "[    .MANUAL_LIBRETA Manual_Libreta_TU01A.msb     .VISORES     [         .XYZ         (             241.0 - 248.0 0         )         .ESC EXTERIOR        .CAMARA 0    ]    .BRIEFING    [        .INICIAL TU01A.BRI    ]";
//        //    var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

//        //    // Act,
//        //    var result = IndexHelper.GetPositionIndexes(tokens, 0);

//        //    // Assert,
//        //    Assert.AreEqual(5, result.startIndex);
//        //    Assert.AreEqual(11, result.endIndex);
//        //}
//    }
//}
