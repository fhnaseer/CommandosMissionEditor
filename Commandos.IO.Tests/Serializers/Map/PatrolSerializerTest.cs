using System;
using System.Collections.ObjectModel;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Map;
using Commandos.IO.Tests.Serializers.Helpers;
using Commandos.Model.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commandos.IO.Tests.Serializers.Map
{
    [TestClass]
    public class PatrolSerializerTest
    {
        [TestMethod]
        public void Serialize_Works()
        {
            // Arrange,
            var text = SampleStrings.GetRecordString(SampleStrings.PatrolsString);
            var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var expected = SampleObjects.EnemyPatrol;
            var record = TokenParser.ParseTokens(tokens).GetRecord(PatrolsSerializer.Patrols);
            var target = new PatrolsSerializer();

            // Act,
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual[0]);
        }

        [TestMethod]
        public void Serialize_Deserialize_Works()
        {
            // Arrange,
            var expected = SampleObjects.EnemyPatrol;
            var target = new PatrolsSerializer();

            // Act,
            var record = target.Deserialize(new ObservableCollection<EnemyPatrol> { expected });
            var actual = target.Serialize(record);

            // Assert,
            Assert.AreEqual(expected, actual[0]);
        }
    }
}
