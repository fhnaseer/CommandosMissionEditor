using Commandos.IO.Serializers;
using Commandos.Model.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers
{
    [TestClass]
    public class EntitySerializerTest
    {
        [TestMethod]
        public void ToEscape_Works()
        {
            // Arrange,
            var expected = new Escape { Value = "Exterior" };
            var tokens = new[] { ".ESC", "Exterior" };

            // Act,
            var actual = EntitySerializer.ToEscape(tokens, 0);

            // Assert,
            Assert.AreEqual(expected.Value, actual.Value);
        }

        [TestMethod]
        public void ToPosition_Works()
        {
            // Arrange,
            var expected = new Position(4, 5, 6);
            var tokens = new[] { StringConstants.Position, "(", "4", "5", "6", "}" };

            // Act,
            var actual = EntitySerializer.ToPosition(tokens, 0);

            // Assert,
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
            Assert.AreEqual(expected.Z, actual.Z);
        }
    }
}
