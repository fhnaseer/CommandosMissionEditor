using Commandos.Model.Common;
using Commandos.Model.Map;

namespace Commandos.IO.Tests.Serializers.Helpers
{
    public static class SampleStrings
    {
        public static string GetRecordString(string record)
        {
            return $"[ {record} ]";
        }

        public static string PositionString => ".XYZ ( 1 2 0 )";

        public static string AreaString => ".ESC EXTERIOR";

        public static string IPositionString => $"{PositionString} {AreaString}";

        public static string BriefingString => ".BRIEFING [ .INICIAL TU01A.BRI ]";

        public static string CameraString => $".VISORES [ {IPositionString} .CAMARA 0 ]";

        public static string FicherosString => ".FICHEROS [ .STR TU1A.STR ]";

        public static string MusicString => ".MUSICA  [ .MUSICAS (  ( M_BU_Ext.WAV EXTERIOR ) ( M_BU_Agu.WAV AGUA ) ( M_BU_Int.WAV INTERIOR ) ) .MUSICA_POR_DEFECTO INTERIOR ]";
    }

    public static class SampleObjects
    {
        public static Position Position => new Position("1", "2", "0");

        public static string Area = "EXTERIOR";

        public static Briefing Briefing => new Briefing
        {
            FileName = "TU01A.BRI"
        };

        public static Camera Camera => new Camera
        {
            Position = Position,
            Area = Area,
            CameraDirection = "0"
        };

        public static Ficheros Ficheros => new Ficheros
        {
            FileName = "TU1A.STR"
        };

        public static Music Music
        {
            get
            {
                var music = new Music
                {
                    StartingMusicEnvironment = "INTERIOR"
                };
                music.BackgroundMusics.Add(new Model.Common.BackgroundMusic { Environment = "EXTERIOR", MusicFileName = "M_BU_Ext.WAV" });
                music.BackgroundMusics.Add(new Model.Common.BackgroundMusic { Environment = "AGUA", MusicFileName = "M_BU_Agu.WAV" });
                music.BackgroundMusics.Add(new Model.Common.BackgroundMusic { Environment = "INTERIOR", MusicFileName = "M_BU_Int.WAV" });
                return music;
            }
        }
    }
}
