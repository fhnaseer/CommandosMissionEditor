using Commandos.IO.Entities;
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
            var mission = new Mission();
            mission.MsbFileName = multipleRecords.GetStringValue(MsbFile);
            mission.BasFileName = multipleRecords.GetStringValue(BasFile);
            mission.Camera = SerializerHelper.Instance.CameraSerializer.Serialize(multipleRecords.GetRecord(CameraSerializer.Camera));
            mission.Briefing = SerializerHelper.Instance.BriefingSerializer.Serialize(multipleRecords.GetRecord(BriefingSerializer.Briefing));
            mission.Music = SerializerHelper.Instance.MusicSerializer.Serialize(multipleRecords.GetRecord(MusicSerializer.Music));
            mission.Ficheros = SerializerHelper.Instance.FicherosSerializer.Serialize(multipleRecords.GetRecord(FicherosSerializer.Ficheros));
            mission.Abilities = new Abilities(multipleRecords.GetMultipleRecord(StringConstants.Abilities));
            mission.World = SerializerHelper.Instance.WorldSerializer.Serialize(multipleRecords.GetRecord(WorldSerializer.World));
            return mission;
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
            if (mission.Abilities.MultipleRecords != null)
                records.AddMultipleRecords(StringConstants.Abilities, mission.Abilities.MultipleRecords);
            records.Records.Add(WorldSerializer.World, SerializerHelper.Instance.WorldSerializer.Deserialize(mission.World));
            return records;
        }
    }
}
