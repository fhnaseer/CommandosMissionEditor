﻿using Commandos.IO.Serializers;
using Commandos.Model.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers
{
    [TestClass]
    public class EntitySerializerTest
    {
        [TestMethod]
        public void ToStringValue_Works()
        {
            // Arrange,
            var expected = "Exterior";
            var tokens = new[] { ".ESC", expected };

            // Act,
            var actual = EntitySerializer.ToStringValue(tokens, StringConstants.Escape, 0);

            // Assert,
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDoubleValue_Works()
        {
            // Arrange,
            var expected = 5.2;
            var tokens = new[] { "paani", ".ESC", expected.ToString() };

            // Act,
            var actual = EntitySerializer.ToDoubleValue(tokens, StringConstants.Escape, 0);

            // Assert,
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToIntValue_Works()
        {
            // Arrange,
            var expected = 5;
            var tokens = new[] { "paani", ".ESC", expected.ToString() };

            // Act,
            var actual = EntitySerializer.ToIntValue(tokens, StringConstants.Escape, 0);

            // Assert,
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPosition_Works()
        {
            // Arrange,
            var expected = new Position(4, 5, 6);
            var tokens = new[] { StringConstants.Position, "(", "4", "5", "6", ")" };

            // Act,
            var actual = EntitySerializer.ToPosition(tokens, 0);

            // Assert,
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
            Assert.AreEqual(expected.Z, actual.Z);
        }
    }
}