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
                EnemyActionHelper.AddEnemyActions(enemyActions, record.GetMixedDataRecord(ActionStep));
                enemy.Routes.Add(enemyActions);
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
                    $"{SerializerHelper.GetSpeedRecordString(route.Speed)} {SerializerHelper.GetActionTypeRecordString(route.ActionRepeatType)}" +
                    $" {EnemyActionHelper.GetEnemyActionsRecordString(route.Actions)} ] ");
            stringBuilder.Append($") {DefaultRoute} {patrol.DefaultRoute} ] ]");
            return stringBuilder.ToString();
        }
    }
}
