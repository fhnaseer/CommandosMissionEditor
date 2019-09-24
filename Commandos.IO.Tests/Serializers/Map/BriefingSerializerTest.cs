using System;
using Commandos.IO.Entities;
using Commandos.IO.Serializers.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.IO.Tests.Serializers.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Map
{
    [TestClass]
    public class BriefingSerializerTest
    {
        [TestMethod]
        public void GetBriefing_Works()
        {
            // Arrange,
            var text = SampleStrings.GetRecordString(SampleStrings.BriefingString);
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = SampleObjects.Briefing;
            var record = TokenParser.ParseTokens(tokens).GetRecord(BriefingSerializer.Briefing);
            var target = new BriefingSerializer();

            // Act,
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Read_Write_Works()
        {
            // Arrange,
            var expected = SampleObjects.Briefing;
            var target = new BriefingSerializer();

            // Act,
            var record = target.Deserialize(expected);
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
