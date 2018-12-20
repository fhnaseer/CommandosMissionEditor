using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Helpers;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public static class MissionSerializer
    {
        public const string MsbFile = ".MANUAL_LIBRETA";
        public const string BasFile = ".BAS";

        public static Mission GetMission(MultipleRecords multipleRecords)
        {
            return new Mission
            {
                MsbFileName = multipleRecords.GetStringValue(MsbFile),
                BasFileName = multipleRecords.GetStringValue(BasFile),
                Camera = SerializerHelper.Instance.CameraSerializer.Serialize(multipleRecords.GetMultipleRecord(CameraSerializer.Camera)),
                Briefing = SerializerHelper.Instance.BriefingSerializer.Serialize(multipleRecords.GetMultipleRecord(BriefingSerializer.Briefing)),
                Music = SerializerHelper.Instance.MusicSerializer.Serialize(multipleRecords.GetMultipleRecord(MusicSerializer.Music)),
                Ficheros = SerializerHelper.Instance.FicherosSerializer.Serialize(multipleRecords.GetMultipleRecord(FicherosSerializer.Ficheros)),
                Abilities = new Abilities(multipleRecords.GetMultipleRecord(StringConstants.Abilities)),
                World = new World(multipleRecords.GetMultipleRecord(StringConstants.World))
            };
        }

        public static MultipleRecords GetMultipleRecords(Mission mission)
        {
            var records = new MultipleRecords();
            records.Records.Add(MsbFile, RecordExtensions.GetSingleDataRecord(MsbFile, mission.MsbFileName));
            records.Records.Add(BasFile, RecordExtensions.GetSingleDataRecord(BasFile, mission.BasFileName));
            records.Records.Add(CameraSerializer.Camera, SerializerHelper.Instance.CameraSerializer.Deserialize(mission.Camera));
            records.Records.Add(BriefingSerializer.Briefing, SerializerHelper.Instance.BriefingSerializer.Deserialize(mission.Briefing));
            records.Records.Add(MusicSerializer.Music, SerializerHelper.Instance.MusicSerializer.Deserialize(mission.Music));
            records.Records.Add(FicherosSerializer.Ficheros, SerializerHelper.Instance.FicherosSerializer.Deserialize(mission.Ficheros));
            var abilitiesRecord = new Record(StringConstants.Abilities);
            abilitiesRecord.Data = (MultipleRecords)mission.Abilities.MultipleRecords;
            records.Records.Add(StringConstants.Abilities, abilitiesRecord);
            var worldRecord = new Record(StringConstants.World);
            worldRecord.Data = (MultipleRecords)mission.World.MultipleRecords;
            records.Records.Add(StringConstants.World, worldRecord);
            return records;
        }
    }
}
