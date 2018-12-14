using Commandos.IO.Entities;
using Commandos.IO.Files;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public static class MusicSerializer
    {
        public static Music GetMusic(MultipleRecords multipleRecords)
        {
            var music = new Music();
            var mixedValues = multipleRecords.GetMixedValues(StringConstants.MusicList);
            for (var i = 0; i < mixedValues.Values.Count; i++)
            {
                var musicValues = mixedValues.GetMixedValues(i);
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
