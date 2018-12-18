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
            var record = TokenParser.ParseTokens(tokens).GetMultipleRecord(BriefingSerializer.Briefing);

            // Act,
            var actual = BriefingSerializer.GetBriefing(record);

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

            // Act,
            var record = BriefingSerializer.GetRecord(expected);
            var actual = BriefingSerializer.GetBriefing(record.GetMultipleRecords());

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
