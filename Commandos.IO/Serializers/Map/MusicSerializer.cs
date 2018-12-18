using Commandos.IO.Entities;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public static class MusicSerializer
    {
        public const string Music = ".MUSICA";
        public const string MusicList = ".MUSICAS";
        public const string StartingMusicEnvironment = ".MUSICA_POR_DEFECTO";

        public static Music GetMusic(MultipleRecords multipleRecords)
        {
            var music = new Music();
            var mixedValues = multipleRecords.GetMixedDataRecord(MusicList);
            for (var i = 0; i < mixedValues.Count; i++)
            {
                var musicValues = (MixedDataRecord)mixedValues[i];
                music.BackgroundMusics.Add(new BackgroundMusic
                {
                    MusicFileName = musicValues.GetStringValue(0),
                    Environment = musicValues.GetStringValue(1)
                });
            }
            music.StartingMusicEnvironment = multipleRecords.GetStringValue(StartingMusicEnvironment);
            return music;
        }

        public static Record GetRecord(Music music)
        {
            var record = RecordExtensions.GetMultipleDataRecord(Music);
            var data = (MultipleRecords)record.Data;
            data.AddSingleDataRecord(StartingMusicEnvironment, music.StartingMusicEnvironment);
            var musicRecord = RecordExtensions.GetMixedDataRecord(MusicList);
            var musicData = (MixedDataRecord)musicRecord.Data;
            foreach (var background in music.BackgroundMusics)
            {
                var mixedMusicRecord = new MixedDataRecord();
                mixedMusicRecord.Data.Add(new SingleDataRecord(background.MusicFileName));
                mixedMusicRecord.Data.Add(new SingleDataRecord(background.Environment));
                musicData.Data.Add(mixedMusicRecord);
            }
            data.AddMixedDataRecord(MusicList, musicRecord);
            return record;
        }
    }
}
