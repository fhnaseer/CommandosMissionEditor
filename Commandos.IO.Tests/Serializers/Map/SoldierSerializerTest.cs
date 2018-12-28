using System;
using System.Collections.ObjectModel;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.IO.Tests.Serializers.Helpers;
using Commandos.Model.Characters.Enemies;
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
            var text = SampleStrings.GetRecordString(SampleStrings.SoldiersString);
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = SampleObjects.Soldier;
            var record = TokenParser.ParseTokens(tokens).GetRecord(SoldiersSerializer.Bichos);
            var target = new SoldiersSerializer();

            // Act,
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual[0]);
        }

        [TestMethod]
        public void Serialize_Deserialize_Works()
        {
            // Arrange,
            var expected = SampleObjects.Soldier;
            var target = new SoldiersSerializer();

            // Act,
            var record = target.Deserialize(new ObservableCollection<Soldier> { expected });
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual[0]);
        }
    }
}
