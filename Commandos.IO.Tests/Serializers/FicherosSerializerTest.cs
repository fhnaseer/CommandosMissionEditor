using System;
using Commandos.IO.Serializers;
using Commandos.Model.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers
{
    [TestClass]
    public class FicherosSerializerTest
    {
        [TestMethod]
        public void GetFicheros_Works()
        {
            // Arrange,
            const string text = "[     .FICHEROS     [        .STR TU1A.STR    ] ]";
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = new Ficheros
            {
                FileName = "TU1A.STR"
            };

            // Act,
            var actual = FicherosSerializer.GetFicheros(tokens, 0);

            // Assert,
            Assert.AreEqual(expected, actual);
        }
    }
}
