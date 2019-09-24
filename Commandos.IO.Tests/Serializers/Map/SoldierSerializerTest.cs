using System;
using Commandos.IO.Serializers.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.IO.Tests.Serializers.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Map
{
    [TestClass]
    public class SoldierSerializerTest
    {
        [TestMethod]
        public void Serialize_Works()
        {
            // Arrange,
            var text = SampleStrings.SoldierString;
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = SampleObjects.Soldier;
            var record = TokenParser.ParseTokens(tokens);

            // Act,
            var actual = SoldiersSerializer.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Serialize_Deserialize_Works()
        //{
        //    // Arrange,
        //    var expected = SampleObjects.Soldier;
        //    var target = new SoldiersSerializer();

        //    // Act,
        //    var record = target.Deserialize(new ObservableCollection<EnemySoldier> { expected });
        //    var actual = target.Serialize(record);

        //    // Assert,
        //    Assert.AreEqual(expected, actual[0]);
        //}
    }
}
