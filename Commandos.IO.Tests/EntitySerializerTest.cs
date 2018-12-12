using System.IO;
using Commandos.Model.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests
{
    [TestClass]
    public class EntitySerializerTest
    {
        //[TestMethod]
        //[ExpectedException(typeof(InvalidDataException))]
        //public void ToCamera_Invalid()
        //{
        //    // Arrange,
        //    var tokens = new[] { ".XYZ", "(", "4", "5", "6", "}" };

        //    // Act,
        //    var actual = EntitySerializer.ToCamera(tokens);

        //    // Assert - No Assert, Exception expected,
        //}

        //[TestMethod]
        //public void ToCamera_Works()
        //{
        //    // Arrange,
        //    var expected = new Camera { Value = Model.CameraDirection.One };
        //    var tokens = new[] { ".XYZ", "1" };

        //    // Act,
        //    var actual = EntitySerializer.ToCamera(tokens);

        //    // Assert,
        //    Assert.AreEqual(expected.Value, actual.Value);
        //}

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ToPosition_Invalid()
        {
            // Arrange,
            var tokens = new[] { ".XYZ", "value" };

            // Act,
            var actual = EntitySerializer.ToPosition(tokens);

            // Assert - No Assert, Exception expected,
        }

        [TestMethod]
        public void ToPosition_Works()
        {
            // Arrange,
            var expected = new Position(4, 5, 6);
            var tokens = new[] { ".XYZ", "(", "4", "5", "6", "}" };

            // Act,
            var actual = EntitySerializer.ToPosition(tokens);

            // Assert,
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
            Assert.AreEqual(expected.Z, actual.Z);
        }
    }
}
