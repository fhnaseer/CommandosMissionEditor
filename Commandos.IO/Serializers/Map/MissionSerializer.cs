﻿using Commandos.IO.Entities;
using Commandos.IO.Files;
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
                Music = MusicSerializer.GetMusic(multipleRecords.GetMultipleRecord(StringConstants.Music))
            };
        }
    }
}
