using System.Collections.Generic;
using System.Text;
using Commandos.IO.Entities;
using Commandos.Model.Characters.Enemies.Actions;

namespace Commandos.IO.Serializers.Helpers
{
    public static class EnemyActionHelper
    {
        private const string ActionStep = ".ESCALAS";
        private const string MoveAction = "IR_A_PUNTO";
        private const string RotateAction = "ENCARARSE";
        private const string PauseAction = "ESPERAR";

        public static void AddEnemyActions(EnemyRoute enemyRoute, IList<RecordData> records)
        {
            foreach (var record in records)
            {
                var mixedDataRecord = record as MixedDataRecord;
                if (mixedDataRecord.Records.Count != 2) continue;
                AddEnemyAction(enemyRoute, mixedDataRecord);
            }
        }

        private static void AddEnemyAction(EnemyRoute enemyRoute, MixedDataRecord mixedDataRecord)
        {
            var actionName = mixedDataRecord.GetStringValue(0);
            var multipleRecords = mixedDataRecord.GetMultipleRecords(1);
            switch (actionName)
            {
                case MoveAction:
                    PopulateMoveAction(enemyRoute, multipleRecords);
                    break;
                case RotateAction:
                    PopulateRotateAction(enemyRoute, multipleRecords);
                    break;
                case PauseAction:
                    PopulatePauseAction(enemyRoute, multipleRecords);
                    break;
                default:
                    return;
            }
        }

        private static void PopulateMoveAction(EnemyRoute enemyRoute, MultipleRecords multipleRecords)
        {
            var action = new MoveAction();
            SerializerHelper.PopulateIPosition(action, multipleRecords);
            action.MovementType = SerializerHelper.GetMovementType(multipleRecords);
            enemyRoute.Actions.Add(action);
        }

        private static void PopulateRotateAction(EnemyRoute enemyRoute, MultipleRecords multipleRecords)
        {
            var action = new RotateAction();
            action.Angle = SerializerHelper.GetAngle(multipleRecords);
            enemyRoute.Actions.Add(action);
        }

        private static void PopulatePauseAction(EnemyRoute enemyRoute, MultipleRecords multipleRecords)
        {
            var action = new PauseAction();
            action.Time = SerializerHelper.GetTime(multipleRecords);
            enemyRoute.Actions.Add(action);
        }

        public static string GetEnemyActionsRecordString(ICollection<EnemyAction> actions)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"{ActionStep} ( ");
            foreach (var action in actions)
                stringBuilder.Append(GetEnemyActionRecordString(action));
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }

        private static string GetEnemyActionRecordString(EnemyAction action)
        {
            if (action is MoveAction moveAction)
                return $"( {MoveAction} [ {SerializerHelper.GetMovementTypeRecordString(moveAction.MovementType)} {SerializerHelper.GetIPositionRecordString(moveAction)} ] ) ";
            if (action is RotateAction rotateAction)
                return $"( {RotateAction} [ {SerializerHelper.GetAngleRecordString(rotateAction.Angle)} ] ) ";
            if (action is PauseAction pauseAction)
                return $"( {PauseAction} [ {SerializerHelper.GetTimeRecordString(pauseAction.Time)} ] ) ";
            return string.Empty;
        }
    }
}
