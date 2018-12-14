//using System;
//using Commandos.IO.Serializers;
//using Commandos.Model.Map;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Commandos.IO.Tests.Serializers.Mission
//{
//    [TestClass]
//    public class BriefingSerializerTest
//    {
//        [TestMethod]
//        public void GetBriefing_Works()
//        {
//            // Arrange,
//            const string text = "[    .MANUAL_LIBRETA Manual_Libreta_TU01A.msb     .VISORES     [         .XYZ         (             1 2 0         )         .ESC EXTERIOR        .CAMARA 0    ]    .BRIEFING    [        .INICIAL TU01A.BRI    ]";
//            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
//            var expected = new Briefing
//            {
//                FileName = "TU01A.BRI"
//            };

//            // Act,
//            var actual = BriefingSerializer.GetBriefing(tokens, 0);

//            // Assert,
//            Assert.AreEqual(expected, actual);
//        }
//    }
//}
