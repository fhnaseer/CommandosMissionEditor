﻿using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public static class MusicSerializer
    {
        public static Music GetMusic(MultipleRecords multipleRecords)
        {
            var music = new Music();
            var mixedValues = multipleRecords.GetMixedDataRecord(StringConstants.MusicList);
            for (var i = 0; i < mixedValues.Count; i++)
            {
                var musicValues = (MixedDataRecord)mixedValues[i];
                music.BackgroundMusics.Add(new BackgroundMusic
                {
                    MusicFileName = musicValues.GetStringValue(0),
                    Environment = musicValues.GetStringValue(1)
                });
            }
            music.StartingMusicEnvironment = multipleRecords.GetStringValue(StringConstants.StartingMusicEnvironment);
            return music;
        }

    }
}
