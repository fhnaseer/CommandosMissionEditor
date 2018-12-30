using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Helpers;
using Commandos.Model.Characters.Enemies;

namespace Commandos.IO.Serializers.Map
{
    public class SoldiersSerializer : RecordSerializerBase<ObservableCollection<EnemySoldier>>
    {
        public const string Bichos = ".BICHOS";
        private const string CompartmentInfo = ".COMPORTAMIENTO";
        private const string ComporAlemanScript = "ComporAlemanScript";
        private const string MovementInfo = ".GESTOR_MOVIMIENTO";

        public override string RecordName => Bichos;

        public override ObservableCollection<EnemySoldier> Serialize(Record record)
        {
            var soldiers = new ObservableCollection<EnemySoldier>();
            if (record == null)
                return soldiers;

            var soldierRecords = record.GetRecords();
            foreach (MultipleRecords soldierRecord in soldierRecords)
            {
                if (!IsSolder(soldierRecord))
                    continue;
                var soldier = new WorkerGerman();
                SerializerHelper.PopulateCharacter(soldier, soldierRecord);
                var movementRecord = GetMovementInfoRecord(soldierRecord);
                if (movementRecord == null || movementRecord.Records.Count == 0)
                    continue;
                var routesRecord = EnemyRouteHelper.GetRoutesMultipleRecords(movementRecord);
                if (routesRecord == null || movementRecord.Records.Count == 0)
                    continue;
                EnemyRouteHelper.PopulateRoutes(soldier, routesRecord);
                soldiers.Add(soldier);
            }
            return soldiers;
        }

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

        private static bool IsSolder(MultipleRecords multipleRecords)
        {
            var tokenId = multipleRecords.GetStringValue(StringConstants.TokenId);
            switch (tokenId)
            {
                case StringConstants.GreenBeretToken:
                case StringConstants.SniperToken:
                case StringConstants.MarineToken:
                case StringConstants.SapperToken:
                case StringConstants.DriverToken:
                case StringConstants.SpyToken:
                case StringConstants.NatashaToken:
                case StringConstants.ThiefToken:
                case StringConstants.WilsonToken:
                case StringConstants.WhiskyToken:
                    return false;
                default:
                    return true;
            }
        }

        public override Record Deserialize(ObservableCollection<EnemySoldier> input)
        {
            var recordString = GetMultipleRecordString(input);
            var tokens = recordString.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return TokenParser.ParseTokens(tokens, 0);
        }

        public override string GetMultipleRecordString(ObservableCollection<EnemySoldier> input)
        {
            return $"{GetPatrolListRecordString(input)}";
        }

        private static string GetPatrolListRecordString(ICollection<EnemySoldier> soldiers)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"[ {Bichos} ( ");
            foreach (var soldier in soldiers)
                stringBuilder.Append($"[ {SerializerHelper.GetCharacterRecordString(soldier)} .BANDO ALEMAN .HTIP SOLD .COMPORTAMIENTO ( ComporAlemanScript [ .VIGILADOR [ .LONG_NORMAL 600.0 ] .EVENTOS_RUTA ( ) .DISPARADOR [ .ARMA ALEMAN_pistola ] " +
                    $".NUM_GRANADAS 0 .ANIMACION ALEPISTDELGADO.ANI .GESTOR_MOVIMIENTO [ {EnemyRouteHelper.GetEnemyRoutesRecordString(soldier)} ] ] ) " +
                    ".VISTA ( VistaTriangular [ ] ) .OIDO ( Oido [ ] ) .MOTOR ( MotorPeaton [ ] ) .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 20.0 .ALTURA 50.0 ] ) .ANIM ALEPISTDELGADO.ANI ] ) .VOLCOLISION ( Cilindro [ .RADIO 12.0 .ALTURA 50.0 ] ) .TIPOCOLISION PEATON .ZONASELECCION ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) .LISTAS ( CHOC SELE VISI EJEC FLAE ) .COLORPUNTOLIBRETA ALEMAN .USAHAB [ ] .PUEDE_CONDUCIR ( WILLIS ZODIAK CAMION CANON LANCHA_MOTORA NIDO_AMETRALLADORAS ASCENSOR MONTA_ALEMAN SILLA CAMA ) .MICUADRICULA [ .DIMCUADX  4.0 .DIMCUADY  6.0 .GFXCUAD CUADRIC ] .GEL [ ] .DUMMY [ .ANIMADOR ( AnimadorHumano [ .VOL ( Cilindro [ .RADIO 10.0 .ALTURA 50.0 ] ) .ANIM ALEPISTDELGADO.ANI ] ) ]" +
                    " ] ");
            stringBuilder.Append($") ]");
            return stringBuilder.ToString();
        }
    }
}
