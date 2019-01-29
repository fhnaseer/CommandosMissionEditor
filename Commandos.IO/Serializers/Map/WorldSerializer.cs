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
                MissionObjects = MissionObjectsSerializer.Serialize(multipleRecords.GetRecord(MissionObjects)),
                SpecialAreas = new SpecialAreas(multipleRecords.GetMixedDataRecordTemp(SpecialAreas)),
                SoundAreas = new SoundAreas(multipleRecords.GetMixedDataRecordTemp(SoundAreas)),
            };
            var patrols = PatrolsSerializer.Serialize(multipleRecords.GetRecord(Patrols));
            foreach (var patrol in patrols)
                world.Patrols.Add(patrol);

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
            if (input.Administration.MultipleRecords != null)
                records.AddMultipleRecords(Administration, input.Administration.MultipleRecords);
            records.AddMixedDataRecord(MissionObjects, MissionObjectsSerializer.Deserialize(input.MissionObjects));
            records.AddMixedDataRecord(Patrols, PatrolsSerializer.Deserialize(input.Patrols));
            if (input.SpecialAreas.MultipleRecords != null)
                records.AddMixedDataRecord(SpecialAreas, input.SpecialAreas.MultipleRecords);
            if (input.SoundAreas.MultipleRecords != null)
                records.AddMixedDataRecord(SoundAreas, input.SoundAreas.MultipleRecords);
            record.Data = records;
            return record;
        }
    }
}
