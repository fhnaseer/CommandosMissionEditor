using System;
using Commandos.IO.Entities;
using Commandos.IO.Serializers.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.IO.Tests.Serializers.Helpers;
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
            var text = SampleStrings.GetRecordString(SampleStrings.FicherosString);
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = SampleObjects.Ficheros;
            var record = TokenParser.ParseTokens(tokens).GetRecord(FicherosSerializer.Ficheros);
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
            var expected = SampleObjects.Ficheros;
            var target = new FicherosSerializer();

            // Act,
            var record = target.Deserialize(expected);
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
