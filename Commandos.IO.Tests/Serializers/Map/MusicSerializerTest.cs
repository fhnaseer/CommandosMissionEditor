using System;
using Commandos.IO.Entities;
using Commandos.IO.Serializers.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.IO.Tests.Serializers.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Map
{
    [TestClass]
    public class MusicSerializerTest
    {
        [TestMethod]
        public void GetMusic_Works()
        {
            // Arrange,
            var text = SampleStrings.GetRecordString(SampleStrings.MusicString);
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = SampleObjects.Music;
            var record = TokenParser.ParseTokens(tokens).GetRecord(MusicSerializer.Music);
            var target = new MusicSerializer();

            // Act,
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Read_Write_Works()
        {
            // Arrange,
            var expected = SampleObjects.Music;
            var target = new MusicSerializer();

            // Act,
            var record = target.Deserialize(expected);
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
