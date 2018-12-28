using System.Collections.Generic;
using System.Text;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.Model.Characters;
using Commandos.Model.Characters.Enemies.Actions;

namespace Commandos.IO.Serializers.Helpers
{
    public static class EnemyRouteHelper
    {
        private const string EventsRoute = ".EVENTOSRUTA";

        private const string Patrol = ".PATRULLAJE";
        private const string EnemyAction = ".RECPATRULLA";
        private const string Routes = ".RUTAS";
        private const string DefaultRoute = ".RUTA_POR_DEFECTO";
        private const string RouteName = ".NOMBRE";
        private const string ActionStep = ".ESCALAS";

        private const string MoveAction = "IR_A_PUNTO";

        public static MultipleRecords GetRoutesMultipleRecords(MultipleRecords multipleRecords)
        {
            return multipleRecords.GetMultipleRecord(Patrol).GetMultipleRecord(EnemyAction);
        }

        public static void PopulateRoutes(EnemyCharacter enemy, MultipleRecords multipleRecords)
        {
            enemy.DefaultRoute = multipleRecords.GetStringValue(DefaultRoute);
            var routes = multipleRecords.GetMixedDataRecord(Routes);
            foreach (var route in routes)
            {
                var record = route as MultipleRecords;
                var enemyActions = new EnemyRoute();
                enemyActions.RouteName = record.GetStringValue(RouteName);
                enemyActions.Speed = record.GetStringValue(StringConstants.Speed);
                enemyActions.ActionRepeatType = record.GetStringValue(StringConstants.EnemyActionType);
                AddEnemyActions(enemyActions, record.GetMixedDataRecord(ActionStep));
                enemy.Routes.Add(enemyActions);
            }
        }

        public static void AddEnemyActions(EnemyRoute enemyActions, IList<RecordData> records)
        {
            foreach (var record in records)
            {
                var mixedDataRecord = record as MixedDataRecord;
                if (mixedDataRecord.Records.Count == 1) continue;
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

        public static string GetEventsRouteRecordString(EnemyCharacter patrol)
        {
            if (patrol.EventRoute == null)
                return string.Empty;
            return $"{EventsRoute} ( {patrol.EventRoute} )";
        }

        public static string GetEnemyRoutesRecordString(EnemyCharacter patrol)
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

        public static string GetEnemyActionsRecordString(ICollection<EnemyAction> actions)
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
