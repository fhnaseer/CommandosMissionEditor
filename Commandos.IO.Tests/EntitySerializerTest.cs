using System.IO;
using Commandos.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests
{
    [TestClass]
    public class EntitySerializerTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void TestMethodName()
        {
            // Arrange,
            var tokens = new[] { ".XYZ", "(", "4", "5", "6", "}" };

            // Act,
            var actual = EntitySerializer.ToCamera(tokens);

            // Assert - No Assert, Exception expected,
        }

        [TestMethod]
        public void ToCamera_Works()
        {
            // Arrange,
            var expected = new Camera { Value = 1 };
            var tokens = new[] { ".XYZ", "1" };

            // Act,
            var actual = EntitySerializer.ToCamera(tokens);

            // Assert,
            Assert.AreEqual(expected.Value, actual.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ToPoint3D_Invalid()
        {
            // Arrange,
            var tokens = new[] { ".XYZ", "value" };

            // Act,
            var actual = EntitySerializer.ToPoint3D(tokens);

            // Assert - No Assert, Exception expected,
        }

        [TestMethod]
        public void ToPoint3D_Works()
        {
            // Arrange,
            var expected = new Point3D(4, 5, 6);
            var tokens = new[] { ".XYZ", "(", "4", "5", "6", "}" };

            // Act,
            var actual = EntitySerializer.ToPoint3D(tokens);

            // Assert,
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
            Assert.AreEqual(expected.Z, actual.Z);
        }
    }
}
