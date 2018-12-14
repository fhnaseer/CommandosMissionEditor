using System;
using Commandos.IO.Files;
using Commandos.IO.Serializers.Mission;
using Commandos.Model.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Mission
{
    [TestClass]
    public class FicherosSerializerTest
    {
        [TestMethod]
        public void GetFicheros_Works()
        {
            // Arrange,
            const string text = "[ .FICHEROS [ .STR TU1A.STR ] ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = new Ficheros
            {
                FileName = "TU1A.STR"
            };
            var record = TokenParser.ParseTokens(tokens, 0);

            // Act,
            var actual = FicherosSerializer.GetFicheros(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
