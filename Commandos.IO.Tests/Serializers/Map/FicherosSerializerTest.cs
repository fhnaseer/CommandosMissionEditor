using System;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.Model.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Map
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
            var record = TokenParser.ParseTokens(tokens).GetMultipleRecord(StringConstants.Ficheros);

            // Act,
            var actual = FicherosSerializer.GetFicheros(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
