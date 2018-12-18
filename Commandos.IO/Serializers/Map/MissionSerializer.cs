using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public static class MissionSerializer
    {
        public static Mission GetMission(MultipleRecords multipleRecords)
        {
            return new Mission
            {
                MsbFileName = multipleRecords.GetStringValue(StringConstants.MsbFile),
                BasFileName = multipleRecords.GetStringValue(StringConstants.BasFile),
                Camera = CameraSerializer.GetCamera(multipleRecords.GetMultipleRecord(StringConstants.Camera)),
                Briefing = BriefingSerializer.GetBriefing(multipleRecords.GetMultipleRecord(StringConstants.Briefing)),
                Music = MusicSerializer.GetMusic(multipleRecords.GetMultipleRecord(StringConstants.Music)),
                Ficheros = FicherosSerializer.GetFicheros(multipleRecords.GetMultipleRecord(StringConstants.Ficheros)),
                Abilities = new Abilities(multipleRecords.GetMultipleRecord(StringConstants.Abilities)),
                World = new World(multipleRecords.GetMultipleRecord(StringConstants.World))
            };
        }

        public static MultipleRecords GetMultipleRecords(Mission mission)
        {
            var records = new MultipleRecords();
            records.Records.Add(StringConstants.MsbFile, RecordExtensions.GetSingleDataRecord(StringConstants.MsbFile, mission.MsbFileName));
            records.Records.Add(StringConstants.BasFile, RecordExtensions.GetSingleDataRecord(StringConstants.BasFile, mission.BasFileName));
            records.Records.Add(StringConstants.Camera, CameraSerializer.GetRecord(mission.Camera));
            records.Records.Add(StringConstants.Briefing, BriefingSerializer.GetRecord(mission.Briefing));
            records.Records.Add(StringConstants.Music, MusicSerializer.GetRecord(mission.Music));
            records.Records.Add(StringConstants.Ficheros, FicherosSerializer.GetRecord(mission.Ficheros));
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
