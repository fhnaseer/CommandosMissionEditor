using System.Collections.ObjectModel;
using System.Text;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Helpers;
using Commandos.Model.Characters;
using Commandos.Model.Characters.Enemies;

namespace Commandos.IO.Serializers.Map
{
    public static class SoldiersSerializer //: RecordSerializerBase<ObservableCollection<EnemySoldier>>
    {
        public const string Bichos = ".BICHOS";
        private const string CompartmentInfo = ".COMPORTAMIENTO";
        private const string ComporAlemanScript = "ComporAlemanScript";
        private const string MovementInfo = ".GESTOR_MOVIMIENTO";

        private const string PrimarySoldierType = "ALEMAN";
        private const string SecondarySoldierType = "SOLD";
        private const string AnimationFile = ".ANIMACION";

        //public override string RecordName => Bichos;
        public static bool IsSolder(MultipleRecords multipleRecords)
        {
            var primaryType = multipleRecords.GetStringValue(StringConstants.PrimaryObjectType);
            var secondaryType = multipleRecords.GetStringValue(StringConstants.SecondaryObjectType);
            if (primaryType == PrimarySoldierType && secondaryType == SecondarySoldierType)
                return true;
            return false;
        }

        public static EnemySoldier Serialize(MultipleRecords multipleRecords)
        {
            var soldier = GetEnemySoldier(multipleRecords);
            if (soldier == null) return null;
            SerializerHelper.PopulateCharacter(soldier, multipleRecords);
            var movementRecord = GetMovementInfoRecord(multipleRecords);
            if (movementRecord == null || movementRecord.Records.Count == 0)
                return soldier;
            var routesRecord = EnemyRouteHelper.GetRoutesMultipleRecords(movementRecord);
            if (routesRecord != null && movementRecord.Records.Count != 0)
                EnemyRouteHelper.PopulateRoutes(soldier, routesRecord);
            return soldier;
        }

        public static string GetSoldiersRecordString(ObservableCollection<EnemyCharacter> soldiers)
        {
            var stringBuilder = new StringBuilder();
            foreach (EnemySoldier soldier in soldiers)
                stringBuilder.Append($"[ {SerializerHelper.GetCharacterRecordString(soldier)} .BANDO ALEMAN .HTIP SOLD .COMPORTAMIENTO ( ComporAlemanScript [ .VIGILADOR [ .LONG_NORMAL {soldier.Range} ] .EVENTOS_RUTA ( ) .DISPARADOR [ .ARMA {soldier.Trigger} ALEMAN_pistola ] " +
                    $".NUM_GRANADAS 0 .ANIMACION {soldier.AnimationFileNameComplete} .GESTOR_MOVIMIENTO [ {EnemyRouteHelper.GetEnemyRoutesRecordString(soldier)} ] ] ) " +
                    $".VISTA ( VistaTriangular [ ] ) .OIDO ( Oido [ ] ) .MOTOR ( MotorPeaton [ ] ) .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 20.0 .ALTURA 50.0 ] ) .ANIM {soldier.AnimationFileNameComplete} ] ) .VOLCOLISION ( Cilindro [ .RADIO 12.0 .ALTURA 50.0 ] ) " +
                    ".TIPOCOLISION PEATON .ZONASELECCION ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) .LISTAS ( CHOC SELE VISI EJEC FLAE ) .COLORPUNTOLIBRETA ALEMAN .USAHAB [ ] " +
                    ".PUEDE_CONDUCIR ( WILLIS ZODIAK CAMION CANON LANCHA_MOTORA NIDO_AMETRALLADORAS ASCENSOR MONTA_ALEMAN SILLA CAMA ) " +
                    $".MICUADRICULA [ .DIMCUADX  4.0 .DIMCUADY  6.0 .GFXCUAD CUADRIC ] .GEL [ ] .DUMMY [ .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) .ANIM {soldier.AnimationFileNameComplete} ] ) ] " +
                    ".BICHOS ( ) ] ");
            return stringBuilder.ToString().Trim();
        }

        //public override ObservableCollection<EnemySoldier> Serialize(Record record)
        //{
        //    var soldiers = new ObservableCollection<EnemySoldier>();
        //    if (record == null)
        //        return soldiers;

        //    var soldierRecords = record.GetRecords();
        //    foreach (MultipleRecords soldierRecord in soldierRecords)
        //    {
        //        if (!IsSolder(soldierRecord))
        //            continue;
        //        var soldier = GetEnemySoldier(soldierRecord);
        //        if (soldier == null) continue;
        //        SerializerHelper.PopulateCharacter(soldier, soldierRecord);
        //        var movementRecord = GetMovementInfoRecord(soldierRecord);
        //        if (movementRecord == null || movementRecord.Records.Count == 0)
        //            continue;
        //        var routesRecord = EnemyRouteHelper.GetRoutesMultipleRecords(movementRecord);
        //        if (routesRecord != null && movementRecord.Records.Count != 0)
        //            EnemyRouteHelper.PopulateRoutes(soldier, routesRecord);
        //        soldiers.Add(soldier);
        //    }
        //    return soldiers;
        //}

        private static MultipleRecords GetMovementInfoRecord(MultipleRecords multipleRecords)
        {
            var mixedDataRecord = multipleRecords.GetMixedDataRecordTemp(CompartmentInfo);
            if (mixedDataRecord.GetStringValue(0) == ComporAlemanScript)
            {
                var movementRecords = mixedDataRecord.GetMultipleRecords(1);
                return movementRecords.GetMultipleRecord(MovementInfo);
            }
            return null;
        }

        private static EnemySoldier GetEnemySoldier(MultipleRecords multipleRecords)
        {
            var mixedDataRecord = multipleRecords.GetMixedDataRecordTemp(CompartmentInfo);
            if (mixedDataRecord.GetStringValue(0) == ComporAlemanScript)
            {
                var movementRecords = mixedDataRecord.GetMultipleRecords(1);
                var animationFile = movementRecords.GetStringValue(AnimationFile);
                switch (animationFile)
                {
                    case "MECANICOAZUL.ANI": return new BlueMechanicGerman();
                    case "ALEJAIMITO.ANI": return new BlueSoldierGerman();
                    case "ALEMECANICO.ANI": return new MechanicGerman();
                    case "DESNUDO.ANI": return new UnderwearSoldierGerman();
                    case "ENBOLAS.ANI": return new TowelSoldierGerman();
                    case "ALEMARINERO.ANI": return new WorkerGerman();
                    case "OFICINISTA.ANI": return new OfficerAssistantGerman();
                    case "ALEPISTDELGADO.ANI": return new GunSoldier1German();
                    case "ALEPISTGORDO1.ANI": return new GunSoldier2German();
                    case "ALEPISTGORDO2.ANI": return new GunSoldier3German();
                    case "ALEPISTGORDO3.ANI": return new GunSoldier4German();
                    case "ALEPISTLINTERNERO.ANI": return new GunSoldierTorchGerman();
                    case "CARCELEROALE.ANI": return new JailerGerman();
                    case "ALEFUS.ANI": return new Rifleman1German();
                    case "ALEFUSDELGADO.ANI": return new Rifleman2German();
                    case "ALEFUSGORDO1.ANI": return new Rifleman3German();
                    case "ALEFUSGORDO2.ANI": return new Rifleman4German();
                    case "ALEICEF.ANI": return new RiflemanArcticGerman();
                    case "ALEPISTFRANCO.ANI": return new SniperGunGerman();
                    case "ALEMET.ANI": return new SubmachineGunnerGerman();
                    case "ALEICEZ.ANI": return new SubmachineGunnerArcticGerman();
                    case "JAPOIGNIFUGO.ANI": return new AtomicWorkerJapanese();
                    case "CARCELEROJAPO.ANI": return new JailerJapanese();
                    case "MECANICOJAPO.ANI": return new MechanicJapanese();
                    case "DESNUDOJAPO.ANI": return new UnderwearSoldierJapanese();
                    case "ENBOLASJAPO.ANI": return new TowelSoldierJapanese();
                    case "CURRITOJAPO.ANI": return new WorkerJapanese();
                    case "JAPOGORRONEGRO.ANI": return new BigHatWorkerBlackJapanese();
                    case "JAPOGORROVERDE.ANI": return new BigHatWorkerGreenJapanese();
                    case "JAPOGORRO.ANI": return new BigHatWorkerWhiteJapanese();
                    case "JAPOCANONIERO.ANI": return new CannonierJapanese();
                    case "JAPO.ANI": return new GunSoldierJapanese();
                    case "JAPOMOCH.ANI": return new GunSoldierBackpackJapanese();
                    case "CARCELEROKWAI.ANI": return new JailerGunJapanese();
                    case "JAPOPILOTO.ANI": return new PilotJapanese();
                    case "JAPOFUS.ANI": return new RiflemanJapanese();
                    case "JAPOMOCHFUS.ANI": return new RiflemanBackpackJapanese();
                    case "JAPOINFMAR.ANI": return new BlueSoldierGerman();
                    case "JAPOMARINERO.ANI": return new SailorWhiteJapanese();
                    case "JAPOVIGIA.ANI": return new ScoutJapanese();
                    case "JAPOTORTURADOR.ANI": return new TorturerJapanese();
                    default:
                        break;
                }
            }
            return null;
        }

        //public override Record Deserialize(ObservableCollection<EnemySoldier> input)
        //{
        //    var recordString = GetMultipleRecordString(input);
        //    var tokens = recordString.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        //    return TokenParser.ParseTokens(tokens, 0);
        //}

        //public override string GetMultipleRecordString(ObservableCollection<EnemySoldier> input)
        //{
        //    return $"{GetPatrolListRecordString(input)}";
        //}

        //private static string GetPatrolListRecordString(ICollection<EnemySoldier> soldiers)
        //{
        //    var stringBuilder = new StringBuilder();
        //    stringBuilder.Append($"[ {Bichos} ( ");
        //    foreach (var soldier in soldiers)
        //        stringBuilder.Append($"[ {SerializerHelper.GetCharacterRecordString(soldier)} .BANDO ALEMAN .HTIP SOLD .COMPORTAMIENTO ( ComporAlemanScript [ .VIGILADOR [ .LONG_NORMAL {soldier.Range} ] .EVENTOS_RUTA ( ) .DISPARADOR [ .ARMA {soldier.Trigger} ALEMAN_pistola ] " +
        //            $".NUM_GRANADAS 0 .ANIMACION {soldier.AnimationFileNameComplete} .GESTOR_MOVIMIENTO [ {EnemyRouteHelper.GetEnemyRoutesRecordString(soldier)} ] ] ) " +
        //            $".VISTA ( VistaTriangular [ ] ) .OIDO ( Oido [ ] ) .MOTOR ( MotorPeaton [ ] ) .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 20.0 .ALTURA 50.0 ] ) .ANIM {soldier.AnimationFileNameComplete} ] ) .VOLCOLISION ( Cilindro [ .RADIO 12.0 .ALTURA 50.0 ] ) " +
        //            ".TIPOCOLISION PEATON .ZONASELECCION ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) .LISTAS ( CHOC SELE VISI EJEC FLAE ) .COLORPUNTOLIBRETA ALEMAN .USAHAB [ ] " +
        //            ".PUEDE_CONDUCIR ( WILLIS ZODIAK CAMION CANON LANCHA_MOTORA NIDO_AMETRALLADORAS ASCENSOR MONTA_ALEMAN SILLA CAMA ) " +
        //            $".MICUADRICULA [ .DIMCUADX  4.0 .DIMCUADY  6.0 .GFXCUAD CUADRIC ] .GEL [ ] .DUMMY [ .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) .ANIM {soldier.AnimationFileNameComplete} ] ) ]" +
        //            " ] ");
        //    stringBuilder.Append($") ]");
        //    return stringBuilder.ToString();
        //}
    }
}
