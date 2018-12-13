//using System;
//using Commandos.IO.Entities;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Commandos.IO.Tests
//{
//    [TestClass]
//    public class TokenParserTest
//    {
//        [TestMethod]
//        public void ParseTokens_SingleValue_Works()
//        {
//            // Arrange,
//            const string expectedName = ".msb";
//            const string expectedValue = "msb.msb";
//            var text = $"[ {expectedName} {expectedValue} ]";
//            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

//            // Act,
//            var actual = (SingleValue)TokenParser.ParseTokens(tokens, 1);

//            // Assert,
//            Assert.AreEqual(expectedName, actual.Name);
//            Assert.AreEqual(expectedValue, actual.Value);
//        }

//        [TestMethod]
//        public void ParseTokens_MultipleValues_Works()
//        {
//            // Arrange,
//            var text = "[ .XYZ ( 1 2 0 ) ]";
//            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

//            // Act,
//            var actual = (MultipleValues)TokenParser.ParseTokens(tokens, 1);

//            // Assert,
//            Assert.AreEqual(".XYZ", actual.Name);
//            Assert.AreEqual("1", actual.Values[0]);
//            Assert.AreEqual("2", actual.Values[1]);
//            Assert.AreEqual("0", actual.Values[2]);
//        }

//        [TestMethod]
//        public void ParseTokens_MultipleList_Works()
//        {
//            // Arrange,
//            var text = "[ .MUSICAS ( ( Battle.WAV EXTERIOR ) ( Shadows.WAV INTERIOR ) ) ]";
//            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

//            // Act,
//            var actual = (MultipleList)TokenParser.ParseTokens(tokens, 1);

//            // Assert,
//            Assert.AreEqual(".MUSICAS", actual.Name);
//            Assert.AreEqual("Battle.WAV", actual.Values[0].Values[0]);
//            Assert.AreEqual("EXTERIOR", actual.Values[0].Values[1]);
//            Assert.AreEqual("Shadows.WAV", actual.Values[1].Values[0]);
//            Assert.AreEqual("INTERIOR", actual.Values[1].Values[1]);
//        }

//        [TestMethod]
//        public void ParseTokens_MultipleRecords_Works()
//        {
//            // Arrange,
//            var text = "[ .VISORES [ .XYZ ( 1 2 0 ) .ESC EXTERIOR .CAMARA 0 ] .BRIEFING [ .INICIAL TU01A.BRI ] .BAS TU01.BAS ]";
//            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

//            // Act,
//            var actual = (MultipleRecords)TokenParser.ParseTokens(tokens, 1);

//            // Assert,
//            Assert.AreEqual(".VISORES", actual.Name);
//            Assert.AreEqual(".XYZ", actual.Values[0].Name);
//            Assert.AreEqual(".ESC", actual.Values[1].Name);
//            Assert.AreEqual(".CAMARA", actual.Values[2].Name);
//        }

//        [TestMethod]
//        public void ParseTokens_MultipleRecords_Works_2()
//        {
//            // Arrange,
//            var text = "[ .PUERTAS ( [ .TOKEN PI_TU03I00-EXT .FLAGS ( CERRADA_CON_LLAVE ) ] ) ]";
//            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

//            // Act,
//            var actual = (MultipleRecords)TokenParser.ParseTokens(tokens, 1);

//            // Assert,
//            Assert.AreEqual(".PUERTAS", actual.Name);
//            Assert.AreEqual(".TOKEN", ((MultipleRecords)actual.Values[0]).Values[0].Name);
//            Assert.AreEqual(".FLAGS", ((MultipleRecords)actual.Values[0]).Values[1].Name);
//        }
//    }
//}
