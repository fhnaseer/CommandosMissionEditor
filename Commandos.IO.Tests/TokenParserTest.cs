using System;
using Commandos.IO.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests
{
    [TestClass]
    public class TokenParserTest
    {
        [TestMethod]
        public void ParseTokens_SingleValue_Works()
        {
            // Arrange,
            const string expectedName = ".msb";
            const string expectedValue = "msb.msb";
            var text = $"[ {expectedName} {expectedValue} ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var actual = (SingleValue)TokenParser.ParseTokens(tokens, 1);

            // Assert,
            Assert.AreEqual(expectedName, actual.Name);
            Assert.AreEqual(expectedValue, actual.Value);
        }

        [TestMethod]
        public void ParseTokens_MultipleValues_Works()
        {
            // Arrange,
            var text = "[ .XYZ ( 1 2 0 ) ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Act,
            var actual = (MultipleValues)TokenParser.ParseTokens(tokens, 1);

            // Assert,
            Assert.AreEqual(".XYZ", actual.Name);
            Assert.AreEqual("1", actual.Values[0]);
            Assert.AreEqual("2", actual.Values[1]);
            Assert.AreEqual("0", actual.Values[2]);
        }
    }
}
