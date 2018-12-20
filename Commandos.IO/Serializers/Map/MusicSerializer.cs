using System.Collections.Generic;
using System.Text;
using Commandos.IO.Entities;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public class MusicSerializer : RecordSerializerBase<Music>
    {
        public const string Music = ".MUSICA";
        public const string MusicList = ".MUSICAS";
        public const string StartingMusicEnvironment = ".MUSICA_POR_DEFECTO";

        public override string RecordName => Music;

        public override Music Serialize(MultipleRecords multipleRecords)
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

        public override string GetMultipleRecordString(Music input)
        {
            return $"[ {StartingMusicEnvironment} {input.StartingMusicEnvironment} {MusicList} {GetMusicListRecordString(input.BackgroundMusics)} ]";
        }

        private static string GetMusicListRecordString(ICollection<BackgroundMusic> collection)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("(");
            foreach (var item in collection)
                stringBuilder.Append($" ( {item.MusicFileName} {item.Environment} )");
            stringBuilder.Append(" )");
            return stringBuilder.ToString();
        }
    }
}
