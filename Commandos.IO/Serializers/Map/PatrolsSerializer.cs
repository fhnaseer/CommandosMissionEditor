﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Commandos.IO.Entities;
using Commandos.IO.Serializers.Helpers;
using Commandos.Model.Characters.Enemies;

namespace Commandos.IO.Serializers.Map
{
    public class PatrolsSerializer : RecordSerializerBase<ObservableCollection<EnemyPatrol>>
    {
        public const string Patrols = ".ENTES";
        private const string OnePatrol = "EntePatrulla";
        private const string ColumnsCount = ".NCOLUMNAS";
        private const string RowsCount = ".NSOLDADOSCOLUMNA";
        private const string SoldierFileName = ".ANIMSOLDADO";
        private const string LeaderFileName = ".ANIMSARGENTO";
        private const string EventsRoute = ".EVENTOSRUTA";

        public override string RecordName => Patrols;

        public override ObservableCollection<EnemyPatrol> Serialize(Record record)
        {
            var patrols = new ObservableCollection<EnemyPatrol>();
            if (record == null)
                return patrols;

            var patrolRecords = record.GetRecords();
            foreach (var patrolRecord in patrolRecords)
            {
                var mixedDataRecord = patrolRecord as MixedDataRecord;
                if (mixedDataRecord.GetStringValue(0) != OnePatrol)
                    continue;

                var patrol = new EnemyPatrol();
                var multipleRecords = mixedDataRecord.GetMultipleRecords(1);
                SerializerHelper.PopulateCharacter(patrol, multipleRecords);
                patrol.ColumnsCount = multipleRecords.GetStringValue(ColumnsCount);
                patrol.RowsCount = multipleRecords.GetStringValue(RowsCount);
                patrol.SoldiersFileName = multipleRecords.GetStringValue(SoldierFileName);
                patrol.LeaderFileName = multipleRecords.GetStringValue(LeaderFileName);
                var eventsRecord = multipleRecords.GetMixedDataRecord(EventsRoute);
                if (eventsRecord != null && eventsRecord.Count != 0)
                    patrol.EventRoute = eventsRecord[0].GetStringValue();
                EnemyRouteHelper.PopulateRoutes(patrol, EnemyRouteHelper.GetRoutesMultipleRecords(multipleRecords));
                patrols.Add(patrol);
            }
            return patrols;
        }

        public override Record Deserialize(ObservableCollection<EnemyPatrol> input)
        {
            var recordString = GetMultipleRecordString(input);
            var tokens = TokenParser.GetCleanedTokens(recordString);
            var tokenMetadata = new TokenMetadata(1, 2, tokens.Length - 2, tokens);
            return TokenParser.ParseTokens(tokenMetadata);
        }

        public override string GetMultipleRecordString(ObservableCollection<EnemyPatrol> input)
        {
            return $"{GetPatrolListRecordString(input)}";
        }

        private static string GetPatrolListRecordString(ICollection<EnemyPatrol> patrols)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"[ {Patrols} ( ");
            foreach (EnemyPatrol patrol in patrols)
                stringBuilder.Append($"( {OnePatrol} [ {EnemyRouteHelper.GetEnemyRoutesRecordString(patrol)}  {SerializerHelper.GetCharacterRecordString(patrol)} {EnemyRouteHelper.GetEventsRouteRecordString(patrol)} " +
                    $"{ColumnsCount} {patrol.ColumnsCount} {RowsCount} {patrol.RowsCount} {SoldierFileName} {patrol.SoldiersFileName} {LeaderFileName} {patrol.LeaderFileName} " +
                    $".DETIENE 0 ] ) ");
            stringBuilder.Append($") ]");
            return stringBuilder.ToString();
        }
    }
}
