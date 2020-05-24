using System;
using Commandos.IO.Entities;
using Commandos.IO.Serializers.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Helpers
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
            Assert.AreEqual("1", ((SingleDataRecord)actual.Data).Data);
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
            var values = (MixedDataRecord)actual.Data;
            Assert.AreEqual("1", values.Records[0].ToString());
            Assert.AreEqual("2", values.Records[1].ToString());
            Assert.AreEqual("0", values.Records[2].ToString());
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
            var values = (MixedDataRecord)actual.Data;
            Assert.AreEqual("Battle.WAV", ((MixedDataRecord)values.Records[0]).Records[0].ToString());
            Assert.AreEqual("EXTERIOR", ((MixedDataRecord)values.Records[0]).Records[1].ToString());
            Assert.AreEqual("Shadows.WAV", ((MixedDataRecord)values.Records[1]).Records[0].ToString());
            Assert.AreEqual("INTERIOR", ((MixedDataRecord)values.Records[1]).Records[1].ToString());
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
            var values = (MultipleRecords)actual.Data;
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
            var records = ((MultipleRecords)((MixedDataRecord)actual.Data).Records[0]).Records;
            Assert.IsTrue(records.ContainsKey(".TOKEN"));
            Assert.IsTrue(records.ContainsKey(".FLAGS"));
            //Assert.AreEqual(".TOKEN", records.Values[0].Name);
            //Assert.AreEqual(".FLAGS", records[1].Name);
        }
    }
}
