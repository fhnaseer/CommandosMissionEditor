﻿using System;
using Commandos.IO.Files;
using Commandos.IO.Serializers.Mission;
using Commandos.Model.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Mission
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
            var record = TokenParser.ParseTokens(tokens, 0);

            // Act,
            var actual = BriefingSerializer.GetBriefing(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
