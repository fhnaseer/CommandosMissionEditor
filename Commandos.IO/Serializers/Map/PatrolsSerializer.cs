using System;
using System.Collections.ObjectModel;
using Commandos.IO.Entities;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public class PatrolsSerializer : RecordSerializerBase<ObservableCollection<EnemyPatrol>>
    {
        public const string Patrols = ".ENTES";

        public override string RecordName => Patrols;

        public override ObservableCollection<EnemyPatrol> Serialize(Record record)
        {
            return null;
        }

        public override string GetMultipleRecordString(ObservableCollection<EnemyPatrol> input)
        {
            throw new NotImplementedException();
        }
    }
}
