using Commandos.IO.Entities;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public class WorldSerializer : RecordSerializerBase<World>
    {
        public const string World = ".MUNDO";
        public const string GscFile = ".FILE_GRUPOS_SCRIPT";
        public const string Administration = ".INTENDENCIA";
        public const string MissionObjects = ".BICHOS";
        public const string Patrols = ".ENTES";
        public const string SpecialAreas = ".ZONASFLOTANTES";
        public const string SoundAreas = ".SONIDOSAMBIENTE";

        public override string RecordName => World;

        public override World Serialize(Record record)
        {
            var multipleRecords = record.GetMultipleRecords();
            var world = new World
            {
                GscFileName = multipleRecords.GetStringValue(GscFile),
                Administration = new Administration(multipleRecords.GetMultipleRecord(Administration)),
                MissionObjects = new MissionObjects(multipleRecords.GetMixedDataRecordTemp(MissionObjects)),
                EnemyPatrols = PatrolsSerializer.Serialize(multipleRecords.GetRecord(Patrols)),
                SpecialAreas = new SpecialAreas(multipleRecords.GetMixedDataRecordTemp(SpecialAreas)),
                SoundAreas = new SoundAreas(multipleRecords.GetMixedDataRecordTemp(SoundAreas)),
            };
            return world;
        }

        public override string GetMultipleRecordString(World input)
        {
            throw new System.NotImplementedException();
        }

        public override Record Deserialize(World input)
        {
            var record = new Record(RecordName);
            var records = new MultipleRecords();
            if (input.GscFileName != null)
                records.Records.Add(GscFile, RecordExtensions.GetSingleDataRecord(GscFile, input.GscFileName));
            records.AddMultipleRecords(Administration, input.Administration.MultipleRecords);
            records.AddMixedDataRecord(MissionObjects, input.MissionObjects.MultipleRecords);
            records.AddMixedDataRecord(Patrols, PatrolsSerializer.Deserialize(input.EnemyPatrols));
            records.AddMixedDataRecord(SpecialAreas, input.SpecialAreas.MultipleRecords);
            records.AddMixedDataRecord(SoundAreas, input.SoundAreas.MultipleRecords);
            record.Data = records;
            return record;
        }
    }
}
