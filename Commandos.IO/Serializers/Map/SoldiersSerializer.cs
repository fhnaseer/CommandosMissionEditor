using System;
using System.Collections.ObjectModel;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Helpers;
using Commandos.Model.Characters.Enemies;

namespace Commandos.IO.Serializers.Map
{
    public class SoldiersSerializer : RecordSerializerBase<ObservableCollection<Soldier>>
    {
        public const string Bichos = ".BICHOS";
        private const string CompartmentInfo = ".COMPORTAMIENTO";
        private const string ComporAlemanScript = "ComporAlemanScript";
        private const string MovementInfo = ".GESTOR_MOVIMIENTO";

        public override string RecordName => Bichos;

        public override ObservableCollection<Soldier> Serialize(Record record)
        {
            var soldiers = new ObservableCollection<Soldier>();
            if (record == null)
                return soldiers;

            var soldierRecords = record.GetRecords();
            foreach (MultipleRecords soldierRecord in soldierRecords)
            {
                if (!IsSolder(soldierRecord))
                    continue;
                var soldier = new Soldier();
                SerializerHelper.PopulateCharacter(soldier, soldierRecord);
                var movementRecord = GetMovementInfoRecord(soldierRecord);
                if (movementRecord == null)
                    continue;
                EnemyRouteHelper.PopulateRoutes(soldier, EnemyRouteHelper.GetRoutesMultipleRecords(movementRecord));
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

        public override string GetMultipleRecordString(ObservableCollection<Soldier> input)
        {
            throw new NotImplementedException();
        }
    }
}
