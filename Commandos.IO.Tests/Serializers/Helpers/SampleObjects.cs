using Commandos.Model.Characters.Enemies;
using Commandos.Model.Common;
using Commandos.Model.EnemyActions;
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

        public static string MoveActionString = $"( IR_A_PUNTO [ .MODO ANDANDO {IPositionString} ] )";

        public static string RotateActionString = $"( ENCARARSE [ .ANGULO 90 ] )";

        public static string PauseActionString = $"( ESPERAR [ .TIEMPO 300 ] )";

        public static string EnterDoorActionString = $"( IR_A_TRANSFER [ .MODO ANDANDO .IDA Door1 ] )";

        public static string MovementActionsString = $".ESCALAS ( {MoveActionString} {RotateActionString} {PauseActionString} {EnterDoorActionString} )";

        public static string LieDownActionString = "( AGACHARSE [ ] )";

        public static string GetUpActionString = "( LEVANTARSE [ ] )";

        public static string KneelDownActionString = "( ARRODILLARSE [ ] )";

        public static string DiveInActionString = "( BUCEAR [ ] )";

        public static string DiveOutActionString = "( EMERGER [ ] )";

        public static string BodyActionsString = $".ESCALAS ( {LieDownActionString} {GetUpActionString} {KneelDownActionString} {DiveInActionString} {DiveOutActionString} )";

        public static string MovementRouteString = $"[ .NOMBRE DEFAULT .VEL 1.5 .TIPO STOPPED {MovementActionsString} ]";

        public static string BodyRouteString = $"[ .NOMBRE BODY .VEL 1.5 .TIPO STOPPED {BodyActionsString} ]";

        public static string RoutesString = $".PATRULLAJE [ .RECPATRULLA [ .RUTAS ( {MovementRouteString} {BodyRouteString} ) .RUTA_POR_DEFECTO DEFAULT ] ]";

        public static string PatrolString = $"( EntePatrulla [ {RoutesString} .TOKEN PAT0001 {IPositionString} .ANGULO 0 .EMPIEZA PATRULLANDO .NCOLUMNAS 3.0 .NSOLDADOSCOLUMNA 3.0 .ANIMSOLDADO ALEMET.ANI .ANIMSARGENTO ALEOFI.ANI .DETIENE 0 ] )";

        public static string PatrolsString = $".ENTES ( {PatrolString} )";

        public static string SoldierString = $"[ .POS [ {IPositionString} ] .ANGULO 0 .TOKEN ALEPISTDELGADO .BANDO ALEMAN .HTIP SOLD " +
            $".COMPORTAMIENTO ( ComporAlemanScript [ .VIGILADOR [ .LONG_NORMAL 600.0 ] .EVENTOS_RUTA ( ) .DISPARADOR [ .ARMA ALEMAN_pistola ] " +
            $".NUM_GRANADAS 0 .ANIMACION ALEPISTDELGADO.ANI .GESTOR_MOVIMIENTO [ {RoutesString} ] ] ) .VISTA ( VistaTriangular [ ] ) .OIDO ( Oido [ ] ) " +
            $".MOTOR ( MotorPeaton [ ] ) .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 20.0 .ALTURA 50.0 ] ) .ANIM ALEPISTDELGADO.ANI ] ) " +
            $".VOLCOLISION ( Cilindro [ .RADIO 12.0 .ALTURA 50.0 ] ) .TIPOCOLISION PEATON .ZONASELECCION ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) " +
            $".LISTAS ( CHOC SELE VISI EJEC FLAE ) .COLORPUNTOLIBRETA ALEMAN .USAHAB [ ] .PUEDE_CONDUCIR ( WILLIS ZODIAK CAMION CANON LANCHA_MOTORA NIDO_AMETRALLADORAS ASCENSOR MONTA_ALEMAN SILLA CAMA ) " +
            $".MICUADRICULA [ .DIMCUADX  4.0 .DIMCUADY  6.0 .GFXCUAD CUADRIC ] .GEL [ ] .DUMMY [ .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) .ANIM ALEPISTDELGADO.ANI ] ) ] .BICHOS ( ) ]";

        public static string SoldiersString = $".BICHOS ( {SoldierString} )";
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

        public static RotateAction RotateAction => new RotateAction
        {
            Angle = "90"
        };

        public static PauseAction PauseAction => new PauseAction
        {
            Time = "300"
        };

        public static EnterDoorAction EnterDoorAction => new EnterDoorAction
        {
            MovementType = "ANDANDO",
            DoorName = "Door1"
        };

        public static EnemyRoute MovementEnemyRoute
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
                route.Actions.Add(RotateAction);
                route.Actions.Add(PauseAction);
                route.Actions.Add(EnterDoorAction);
                return route;
            }
        }

        public static EnemyRoute BodyEnemyRoute
        {
            get
            {
                var route = new EnemyRoute
                {
                    RouteName = "BODY",
                    Speed = "1.5",
                    ActionRepeatType = "STOPPED"
                };
                route.Actions.Add(new LieDownAction());
                route.Actions.Add(new GetUpAction());
                route.Actions.Add(new KneelDownAction());
                route.Actions.Add(new DiveInAction());
                route.Actions.Add(new DiveOutAction());
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
                patrol.Routes.Add(MovementEnemyRoute);
                patrol.Routes.Add(BodyEnemyRoute);
                return patrol;
            }
        }

        public static EnemySoldier Soldier
        {
            get
            {
                var soldier = new MechanicGerman
                {
                    TokenId = "ALEPISTDELGADO",
                    Angle = "0",
                    Position = Position,
                    Area = Area
                };
                soldier.Routes.Add(MovementEnemyRoute);
                soldier.Routes.Add(BodyEnemyRoute);
                return soldier;
            }
        }
    }
}
