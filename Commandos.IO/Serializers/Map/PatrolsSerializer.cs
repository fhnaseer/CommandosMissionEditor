using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.Model.Characters.Enemies.Actions;
using Commandos.Model.Map;

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

        private const string Patrol = ".PATRULLAJE";
        private const string EnemyAction = ".RECPATRULLA";
        private const string Routes = ".RUTAS";
        private const string DefaultRoute = ".RUTA_POR_DEFECTO";
        private const string RouteName = ".NOMBRE";
        private const string ActionStep = ".ESCALAS";

        private const string MoveAction = "IR_A_PUNTO";

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
                patrol.TokenId = multipleRecords.GetStringValue(StringConstants.TokenId);
                Helpers.SerializerHelper.PopulateIPosition(patrol, multipleRecords);
                patrol.Angle = multipleRecords.GetStringValue(StringConstants.Angle);
                patrol.ColumnsCount = multipleRecords.GetStringValue(ColumnsCount);
                patrol.RowsCount = multipleRecords.GetStringValue(RowsCount);
                patrol.SoldiersFileName = multipleRecords.GetStringValue(SoldierFileName);
                patrol.LeaderFileName = multipleRecords.GetStringValue(LeaderFileName);
                var eventsRecord = multipleRecords.GetMixedDataRecord(EventsRoute);
                if (eventsRecord != null && eventsRecord.Count != 0)
                    patrol.EventRoute = eventsRecord[0].GetStringValue();
                AddPatrolRoutes(patrol, multipleRecords.GetMultipleRecord(Patrol).GetMultipleRecord(EnemyAction));
                patrols.Add(patrol);
            }
            return patrols;
        }

        private static void AddPatrolRoutes(EnemyPatrol patrol, MultipleRecords multipleRecords)
        {
            patrol.DefaultRoute = multipleRecords.GetStringValue(DefaultRoute);
            var routes = multipleRecords.GetMixedDataRecord(Routes);
            foreach (var route in routes)
            {
                var record = route as MultipleRecords;
                var enemyActions = new EnemyRoute();
                enemyActions.RouteName = record.GetStringValue(RouteName);
                enemyActions.Speed = record.GetStringValue(StringConstants.Speed);
                enemyActions.ActionRepeatType = record.GetStringValue(StringConstants.EnemyActionType);
                AddEnemyActions(enemyActions, record.GetMixedDataRecord(ActionStep));
                patrol.Routes.Add(enemyActions);
            }
        }

        private static void AddEnemyActions(EnemyRoute enemyActions, IList<RecordData> records)
        {
            foreach (var record in records)
            {
                var mixedDataRecord = record as MixedDataRecord;
                if (mixedDataRecord.GetStringValue(0) == MoveAction)
                {
                    var multipleRecords = mixedDataRecord.GetMultipleRecords(1);
                    var action = new MoveAction();
                    Helpers.SerializerHelper.PopulateIPosition(action, multipleRecords);
                    action.MovementType = Helpers.SerializerHelper.GetMovementType(multipleRecords);
                    enemyActions.Actions.Add(action);
                }
            }
        }

        public override Record Deserialize(ObservableCollection<EnemyPatrol> input)
        {
            var recordString = GetMultipleRecordString(input);
            var tokens = recordString.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return TokenParser.ParseTokens(tokens, 0);
        }

        public override string GetMultipleRecordString(ObservableCollection<EnemyPatrol> input)
        {
            return $"{GetPatrolListRecordString(input)}";
        }

        private static string GetPatrolListRecordString(ICollection<EnemyPatrol> patrols)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"[ {Patrols} ( ");
            foreach (var patrol in patrols)
                stringBuilder.Append($"( {OnePatrol} [ {GetEnemyRoutesRecordString(patrol)} {StringConstants.TokenId} {patrol.TokenId} {GetEventsRouteRecordString(patrol)} " +
                    $"{Helpers.SerializerHelper.GetIPositionRecordString(patrol)} {Helpers.SerializerHelper.GetAngleRecordString(patrol.Angle)} .EMPIEZA PATRULLANDO " +
                    $"{ColumnsCount} {patrol.ColumnsCount} {RowsCount} {patrol.RowsCount} {SoldierFileName} {patrol.SoldiersFileName} {LeaderFileName} {patrol.LeaderFileName} " +
                    $".DETIENE 0 ] ) ");
            stringBuilder.Append($") ]");
            return stringBuilder.ToString();
        }

        private static string GetEventsRouteRecordString(EnemyPatrol patrol)
        {
            if (patrol.EventRoute == null)
                return string.Empty;
            return $"{EventsRoute} ( {patrol.EventRoute} )";
        }

        private static string GetEnemyRoutesRecordString(EnemyPatrol patrol)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"{Patrol} [ {EnemyAction} [ {Routes} ( ");
            foreach (var route in patrol.Routes)
                stringBuilder.Append($"[ {RouteName} {route.RouteName} " +
                    $"{Helpers.SerializerHelper.GetSpeedRecordString(route.Speed)} {Helpers.SerializerHelper.GetActionTypeRecordString(route.ActionRepeatType)}" +
                    $" {GetEnemyActionsRecordString(route.Actions)} ] ");
            stringBuilder.Append($") {DefaultRoute} {patrol.DefaultRoute} ] ]");
            return stringBuilder.ToString();
        }

        private static string GetEnemyActionsRecordString(ICollection<EnemyAction> actions)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"{ActionStep} ( ");
            foreach (var action in actions)
            {
                if (action is MoveAction moveAction)
                    stringBuilder.Append($"( {MoveAction} [ {Helpers.SerializerHelper.GetMovementTypeRecordString(moveAction.MovementType)} {Helpers.SerializerHelper.GetIPositionRecordString(moveAction)} ] ) ");
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }
    }
}
