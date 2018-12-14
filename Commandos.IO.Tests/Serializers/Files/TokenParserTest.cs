using System;
using Commandos.IO.Entities;
using Commandos.IO.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Files
{
    [TestClass]
    public class TokenParserTest
    {
        [TestMethod]
        public void ParseTokens_SingleValue_Works()
        {
            // Arrange,
            var text = $"[ .XYZ 1 ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var actual = TokenParser.ParseTokens(tokens, 1);

            // Assert,
            Assert.AreEqual(".XYZ", actual.Name);
            Assert.AreEqual("1", ((SingleValue)actual.Value).Value);
        }

        [TestMethod]
        public void ParseTokens_MultipleValues_Works()
        {
            // Arrange,
            var text = "[ .XYZ ( 1 2 0 ) ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var actual = TokenParser.ParseTokens(tokens, 1);

            // Assert,
            Assert.AreEqual(".XYZ", actual.Name);
            var values = (MixedRecords)actual.Value;
            Assert.AreEqual("1", values.Values[0].ToString());
            Assert.AreEqual("2", values.Values[1].ToString());
            Assert.AreEqual("0", values.Values[2].ToString());
        }

        [TestMethod]
        public void ParseTokens_MultipleList_Works()
        {
            // Arrange,
            var text = "[ .MUSICAS ( ( Battle.WAV EXTERIOR ) ( Shadows.WAV INTERIOR ) ) ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var actual = TokenParser.ParseTokens(tokens, 1);

            // Assert,
            Assert.AreEqual(".MUSICAS", actual.Name);
            var values = (MixedRecords)actual.Value;
            Assert.AreEqual("Battle.WAV", ((MixedRecords)values.Values[0]).Values[0].ToString());
            Assert.AreEqual("EXTERIOR", ((MixedRecords)values.Values[0]).Values[1].ToString());
            Assert.AreEqual("Shadows.WAV", ((MixedRecords)values.Values[1]).Values[0].ToString());
            Assert.AreEqual("INTERIOR", ((MixedRecords)values.Values[1]).Values[1].ToString());
        }

        [TestMethod]
        public void ParseTokens_MultipleRecords_Works()
        {
            // Arrange,
            var text = "[ .VISORES [ .XYZ ( 1 2 0 ) .ESC EXTERIOR .CAMARA 0 ] .BRIEFING [ .INICIAL TU01A.BRI ] .BAS TU01.BAS ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var actual = TokenParser.ParseTokens(tokens, 1);

            // Assert,
            Assert.AreEqual(".VISORES", actual.Name);
            var values = (MultipleRecords)actual.Value;
            Assert.IsTrue(values.Records.ContainsKey(".XYZ"));
            Assert.IsTrue(values.Records.ContainsKey(".ESC"));
            Assert.IsTrue(values.Records.ContainsKey(".CAMARA"));

            //Assert.AreEqual(".XYZ", values.Records[0].Name);
            //Assert.AreEqual(".ESC", values.Records[1].Name);
            //Assert.AreEqual(".CAMARA", values.Records[2].Name);
        }

        [TestMethod]
        public void ParseTokens_MultipleRecords_Works_2()
        {
            // Arrange,
            var text = "[ .PUERTAS ( [ .TOKEN PI_TU03I00-EXT .FLAGS ( CERRADA_CON_LLAVE ) ] ) ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var actual = TokenParser.ParseTokens(tokens, 1);

            // Assert,
            Assert.AreEqual(".PUERTAS", actual.Name);
            var records = ((MultipleRecords)((MixedRecords)actual.Value).Values[0]).Records;
            Assert.IsTrue(records.ContainsKey(".TOKEN"));
            Assert.IsTrue(records.ContainsKey(".FLAGS"));
            //Assert.AreEqual(".TOKEN", records.Values[0].Name);
            //Assert.AreEqual(".FLAGS", records[1].Name);
        }
    }
}
