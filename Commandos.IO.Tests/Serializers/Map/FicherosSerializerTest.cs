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
            var record = TokenParser.ParseTokens(tokens).GetMultipleRecord(FicherosSerializer.Ficheros);
            var target = new FicherosSerializer();

            // Act,
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Read_Write_Works()
        {
            // Arrange,
            var expected = new Ficheros
            {
                FileName = "TU1A.STR"
            };
            var target = new FicherosSerializer();

            // Act,
            var record = target.Deserialize(expected);
            var actual = target.Serialize(record.GetMultipleRecords());

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
