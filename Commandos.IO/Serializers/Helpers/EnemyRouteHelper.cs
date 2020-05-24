using System.Text;
using Commandos.IO.Entities;
using Commandos.Model.Characters;
using Commandos.Model.EnemyActions;

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

        public static string GetEventsRouteRecordString(EnemyCharacter enemy)
        {
            if (enemy.EventRoute == null)
                return string.Empty;
            return $"{EventsRoute} ( {enemy.EventRoute} )";
        }

        public static string GetEnemyRoutesRecordString(EnemyCharacter enemy)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"{Patrol} [ ");
            if (enemy.Routes.Count == 0)
                stringBuilder.Append($".NO_EXISTE 1.0  ]");
            else
            {
                stringBuilder.Append($"{EnemyAction} [ {Routes} ( ");
                foreach (var route in enemy.Routes)
                    stringBuilder.Append($"[ {RouteName} {route.RouteName} " +
                        $"{SerializerHelper.GetSpeedRecordString(route.Speed)} {SerializerHelper.GetActionTypeRecordString(route.ActionRepeatType)}" +
                        $" {EnemyActionHelper.GetEnemyActionsRecordString(route.Actions)} ] ");
                stringBuilder.Append($")");
                stringBuilder.Append($" {DefaultRoute} {enemy.DefaultRoute} ] ]");
            }
            return stringBuilder.ToString();
        }
    }
}
