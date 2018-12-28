using Commandos.Model.Characters.Enemies.Actions;
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

        public static string MsbFileString = ".MANUAL_LIBRETA Manual_Libreta_TU01A.msb";

        public static string BasFileString = ".BAS TU01.BAS";

        public static string PositionString = ".XYZ ( 1 2 0 )";

        public static string AreaString = ".ESC EXTERIOR";

        public static string IPositionString = $"{PositionString} {AreaString}";

        public static string BriefingString = ".BRIEFING [ .INICIAL TU01A.BRI ]";

        public static string CameraString = $".VISORES [ {IPositionString} .CAMARA 0 ]";

        public static string FicherosString = ".FICHEROS [ .STR TU1A.STR ]";

        public static string MusicString = ".MUSICA  [ .MUSICAS (  ( M_BU_Ext.WAV EXTERIOR ) ( M_BU_Agu.WAV AGUA ) ( M_BU_Int.WAV INTERIOR ) ) .MUSICA_POR_DEFECTO INTERIOR ]";

        public static string MoveActionString = $"IR_A_PUNTO [ .MODO ANDANDO {IPositionString} ]";

        public static string ActionsString = $".ESCALAS ( ( {MoveActionString} ) )";

        public static string PatrolsString = $".ENTES ( ( EntePatrulla [ .PATRULLAJE [ .RECPATRULLA [ .RUTAS ( [ .NOMBRE DEFAULT .VEL 1.5 .TIPO STOPPED {ActionsString} ] ) " +
            $".RUTA_POR_DEFECTO DEFAULT ] ] .TOKEN PAT0001 {IPositionString} .ANGULO 0 .EMPIEZA PATRULLANDO .NCOLUMNAS 3.0 " +
            ".NSOLDADOSCOLUMNA 3.0 .ANIMSOLDADO ALEMET.ANI .ANIMSARGENTO ALEOFI.ANI .DETIENE 0 ] ) )";
    }

    public static class SampleObjects
    {
        public static string MsbFileName = "Manual_Libreta_TU01A.msb";

        public static string BasFileName = "TU01.BAS";

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

        public static MoveAction MoveAction => new MoveAction
        {
            Area = Area,
            Position = Position,
            MovementType = "ANDANDO"
        };

        public static EnemyRoute EnemyRoute
        {
            get
            {
                var route = new EnemyRoute
                {
                    RouteName = "DEFAULT",
                    Speed = "1.5",
                    ActionRepeatType = "STOPPED"
                };
                route.Actions.Add(MoveAction);
                return route;
            }
        }

        public static EnemyPatrol EnemyPatrol
        {
            get
            {
                var patrol = new EnemyPatrol
                {
                    TokenId = "PAT0001",
                    Angle = "0",
                    ColumnsCount = "3.0",
                    RowsCount = "3.0",
                    SoldiersFileName = "ALEMET.ANI",
                    LeaderFileName = "ALEOFI.ANI",
                    Area = Area,
                    DefaultRoute = "DEFAULT",
                    Position = Position
                };
                patrol.Routes.Add(EnemyRoute);
                return patrol;
            }
        }
    }
}
