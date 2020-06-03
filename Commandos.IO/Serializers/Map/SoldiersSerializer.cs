using System;
using System.Collections.ObjectModel;
using System.Text;
using Commandos.IO.Entities;
using Commandos.IO.Serializers.Helpers;
using Commandos.Model.Characters;
using Commandos.Model.Characters.Enemies;

namespace Commandos.IO.Serializers.Map
{
    public static class SoldiersSerializer
    {
        public const string Bichos = ".BICHOS";
        private const string Behavior = ".COMPORTAMIENTO";
        private const string ComporAlemanScript = "ComporAlemanScript";
        private const string MovementInfo = ".GESTOR_MOVIMIENTO";

        private const string PrimarySoldierType = "ALEMAN";
        private const string SecondarySoldierType = "SOLD";
        private const string AnimationFile = ".ANIMACION";

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
            if (soldier == null)
                return null;
            SerializerHelper.PopulateCharacter(soldier, multipleRecords);
            var movementRecord = GetMovementInfoRecord(multipleRecords);
            if (movementRecord == null || movementRecord.Records.Count == 0)
                return soldier;
            var routesRecord = EnemyRouteHelper.GetRoutesMultipleRecords(movementRecord);
            if (routesRecord != null && movementRecord.Records.Count != 0)
                EnemyRouteHelper.PopulateRoutes(soldier, routesRecord);
            return soldier;
        }

        private static EnemySoldier GetEnemySoldier(MultipleRecords multipleRecords)
        {
            var mixedDataRecord = multipleRecords.GetMixedDataRecordTemp(Behavior);
            if (mixedDataRecord.GetStringValue(0) == ComporAlemanScript)
            {
                var movementRecords = mixedDataRecord.GetMultipleRecords(1);
                var animationFile = movementRecords.GetStringValue(AnimationFile);
                if (animationFile.Equals("MECANICOAZUL.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new BlueMechanicGerman();
                if (animationFile.Equals("ALEJAIMITO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new BlueSoldierGerman();
                if (animationFile.Equals("ALEMECANICO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new MechanicGerman();
                if (animationFile.Equals("DESNUDO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new UnderwearSoldierGerman();
                if (animationFile.Equals("ENBOLAS.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new TowelSoldierGerman();
                if (animationFile.Equals("ALEMARINERO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new WorkerGerman();
                if (animationFile.Equals("OFICINISTA.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new OfficerAssistantGerman();
                if (animationFile.Equals("ALEPISTDELGADO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new GunSoldier1German();
                if (animationFile.Equals("ALEPISTGORDO1.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new GunSoldier2German();
                if (animationFile.Equals("ALEPISTGORDO2.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new GunSoldier3German();
                if (animationFile.Equals("ALEPISTGORDO3.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new GunSoldier4German();
                if (animationFile.Equals("ALEPISTLINTERNERO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new GunSoldierTorchGerman();
                if (animationFile.Equals("CARCELEROALE.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new JailerGerman();
                if (animationFile.Equals("ALEFUS.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new Rifleman1German();
                if (animationFile.Equals("ALEFUSDELGADO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new Rifleman2German();
                if (animationFile.Equals("ALEFUSGORDO1.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new Rifleman3German();
                if (animationFile.Equals("ALEFUSGORDO2.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new Rifleman4German();
                if (animationFile.Equals("ALEICEF.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new RiflemanArcticGerman();
                if (animationFile.Equals("ALEPISTFRANCO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new SniperGunGerman();
                if (animationFile.Equals("ALEMET.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new SubmachineGunnerGerman();
                if (animationFile.Equals("ALEICEZ.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new SubmachineGunnerArcticGerman();
                if (animationFile.Equals("JAPOIGNIFUGO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new AtomicWorkerJapanese();
                if (animationFile.Equals("CARCELEROJAPO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new JailerJapanese();
                if (animationFile.Equals("MECANICOJAPO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new MechanicJapanese();
                if (animationFile.Equals("DESNUDOJAPO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new UnderwearSoldierJapanese();
                if (animationFile.Equals("ENBOLASJAPO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new TowelSoldierJapanese();
                if (animationFile.Equals("CURRITOJAPO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new WorkerJapanese();
                if (animationFile.Equals("JAPOGORRONEGRO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new BigHatWorkerBlackJapanese();
                if (animationFile.Equals("JAPOGORROVERDE.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new BigHatWorkerGreenJapanese();
                if (animationFile.Equals("JAPOGORRO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new BigHatWorkerWhiteJapanese();
                if (animationFile.Equals("JAPOCANONIERO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new CannonierJapanese();
                if (animationFile.Equals("JAPO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new GunSoldierJapanese();
                if (animationFile.Equals("JAPOMOCH.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new GunSoldierBackpackJapanese();
                if (animationFile.Equals("CARCELEROKWAI.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new JailerGunJapanese();
                if (animationFile.Equals("JAPOPILOTO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new PilotJapanese();
                if (animationFile.Equals("JAPOFUS.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new RiflemanJapanese();
                if (animationFile.Equals("JAPOMOCHFUS.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new RiflemanBackpackJapanese();
                if (animationFile.Equals("JAPOINFMAR.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new BlueSoldierGerman();
                if (animationFile.Equals("JAPOMARINERO.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new SailorWhiteJapanese();
                if (animationFile.Equals("JAPOVIGIA.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new ScoutJapanese();
                if (animationFile.Equals("JAPOTORTURADOR.ANI", StringComparison.CurrentCultureIgnoreCase))
                    return new TorturerJapanese();
            }
            return null;
        }

        private static MultipleRecords GetMovementInfoRecord(MultipleRecords multipleRecords)
        {
            var mixedDataRecord = multipleRecords.GetMixedDataRecordTemp(Behavior);
            if (mixedDataRecord.GetStringValue(0) == ComporAlemanScript)
            {
                var movementRecords = mixedDataRecord.GetMultipleRecords(1);
                return movementRecords.GetMultipleRecord(MovementInfo);
            }
            return null;
        }

        public static string GetSoldiersRecordString(ObservableCollection<EnemyCharacter> soldiers)
        {
            var stringBuilder = new StringBuilder();
            foreach (EnemySoldier soldier in soldiers)
                stringBuilder.Append($"[ {SerializerHelper.GetCharacterRecordString(soldier)} .BANDO ALEMAN .HTIP SOLD .COMPORTAMIENTO ( ComporAlemanScript [ .VIGILADOR [ .LONG_NORMAL {soldier.Range} ] .EVENTOS_RUTA ( ) .DISPARADOR [ .ARMA {soldier.Trigger} ] " +
                    $".NUM_GRANADAS 0 .ANIMACION {soldier.AnimationFileNameComplete} .GESTOR_MOVIMIENTO [ {EnemyRouteHelper.GetEnemyRoutesRecordString(soldier)} ] ] ) " +
                    $".VISTA ( VistaTriangular [ ] ) .OIDO ( Oido [ ] ) .MOTOR ( MotorPeaton [ ] ) .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 20.0 .ALTURA 50.0 ] ) .ANIM {soldier.AnimationFileNameComplete} ] ) .VOLCOLISION ( Cilindro [ .RADIO 12.0 .ALTURA 50.0 ] ) " +
                    ".TIPOCOLISION PEATON .ZONASELECCION ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) .LISTAS ( CHOC SELE VISI EJEC FLAE ) .COLORPUNTOLIBRETA ALEMAN .USAHAB [ ] " +
                    ".PUEDE_CONDUCIR ( WILLIS ZODIAK CAMION CANON LANCHA_MOTORA NIDO_AMETRALLADORAS ASCENSOR MONTA_ALEMAN SILLA CAMA ) " +
                    $".MICUADRICULA [ .DIMCUADX  4.0 .DIMCUADY  6.0 .GFXCUAD CUADRIC ] .GEL [ ] .DUMMY [ .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) .ANIM {soldier.AnimationFileNameComplete} ] ) ] " +
                    ".BICHOS ( ) ] ");
            return stringBuilder.ToString().Trim();
        }
    }
}
