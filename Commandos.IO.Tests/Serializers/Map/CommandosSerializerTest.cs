using System;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.IO.Tests.Serializers.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Map
{
    [TestClass]
    public class CommandosSerializerTest
    {
        [TestMethod]
        public void Serialize_Works()
        {
            // Arrange,
            var text = SampleStrings.GreenBeretString;
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = SampleObjects.GreenBeret;
            var record = TokenParser.ParseTokens(tokens);

            // Act,
            var actual = CommandosSerializer.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
