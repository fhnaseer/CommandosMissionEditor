using System;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.Model.Map;
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
            const string text = "[ .BRIEFING [ .INICIAL TU01A.BRI ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = new Briefing
            {
                FileName = "TU01A.BRI"
            };
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
            var expected = new Briefing
            {
                FileName = "TU01A.BRI"
            };
            var target = new BriefingSerializer();

            // Act,
            var record = target.Deserialize(expected);
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
