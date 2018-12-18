using Commandos.IO.Entities;
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

        public static Record GetRecord(Music music)
        {
            var record = RecordExtensions.GetMultipleDataRecord(StringConstants.Music);
            var data = (MultipleRecords)record.Data;
            data.AddSingleDataRecord(StringConstants.StartingMusicEnvironment, music.StartingMusicEnvironment);
            var musicRecord = RecordExtensions.GetMixedDataRecord(StringConstants.MusicList);
            var musicData = (MixedDataRecord)musicRecord.Data;
            foreach (var background in music.BackgroundMusics)
            {
                var mixedMusicRecord = new MixedDataRecord();
                mixedMusicRecord.Data.Add(new SingleDataRecord(background.MusicFileName));
                mixedMusicRecord.Data.Add(new SingleDataRecord(background.Environment));
                musicData.Data.Add(mixedMusicRecord);
            }
            data.AddMixedDataRecord(StringConstants.MusicList, musicRecord);
            return record;
        }
    }
}
