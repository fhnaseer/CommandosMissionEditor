using System;
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
                Ficheros = FicherosSerializer.GetFicheros(multipleRecords.GetMultipleRecord(StringConstants.Ficheros))
            };
        }

        public static MultipleRecords GetMultipleRecords(Mission mission)
        {
            throw new NotImplementedException();
        }
    }
}
