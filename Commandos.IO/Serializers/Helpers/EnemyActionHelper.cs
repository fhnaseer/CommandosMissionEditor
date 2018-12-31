using System.Collections.Generic;
using System.Text;
using Commandos.IO.Entities;
using Commandos.Model.EnemyActions;

namespace Commandos.IO.Serializers.Helpers
{
    public static class EnemyActionHelper
    {
        private const string ActionStep = ".ESCALAS";
        private const string MoveAction = "IR_A_PUNTO";
        private const string RotateAction = "ENCARARSE";
        private const string PauseAction = "ESPERAR";
        private const string EnterDoorAction = "IR_A_TRANSFER";
        private const string DoorName = ".IDA";
        private const string LieDown = "AGACHARSE";
        private const string GetUp = "LEVANTARSE";
        private const string KneelDown = "ARRODILLARSE";
        private const string DiveIn = "BUCEAR";
        private const string DiveOut = "EMERGER";


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
            EnemyAction action;
            if (actionName == MoveAction)
                action = GetMoveAction(multipleRecords);
            else if (actionName == RotateAction)
                action = GetRotateAction(multipleRecords);
            else if (actionName == PauseAction)
                action = GetPauseAction(multipleRecords);
            else if (actionName == EnterDoorAction)
                action = GetEnterDoorAction(multipleRecords);
            else if (actionName == LieDown)
                action = new LieDownAction();
            else if (actionName == GetUp)
                action = new GetUpAction();
            else if (actionName == KneelDown)
                action = new KneelDownAction();
            else if (actionName == DiveIn)
                action = new DiveInAction();
            else if (actionName == DiveOut)
                action = new DiveOutAction();
            else
                return;
            enemyRoute.Actions.Add(action);
        }

        private static MoveAction GetMoveAction(MultipleRecords multipleRecords)
        {
            var action = new MoveAction();
            SerializerHelper.PopulateIPosition(action, multipleRecords);
            action.MovementType = SerializerHelper.GetMovementType(multipleRecords);
            return action;
        }

        private static RotateAction GetRotateAction(MultipleRecords multipleRecords)
        {
            var action = new RotateAction();
            action.Angle = SerializerHelper.GetAngle(multipleRecords);
            return action;
        }

        private static PauseAction GetPauseAction(MultipleRecords multipleRecords)
        {
            var action = new PauseAction();
            action.Time = SerializerHelper.GetTime(multipleRecords);
            return action;
        }

        private static EnterDoorAction GetEnterDoorAction(MultipleRecords multipleRecords)
        {
            var action = new EnterDoorAction();
            action.MovementType = SerializerHelper.GetMovementType(multipleRecords);
            action.DoorName = multipleRecords.GetStringValue(DoorName);
            return action;
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
            if (action is EnterDoorAction doorAction)
                return $"( {EnterDoorAction} [ {SerializerHelper.GetMovementTypeRecordString(doorAction.MovementType)} {DoorName} {doorAction.DoorName} ] ) ";
            if (action is LieDownAction lieDownAction)
                return $"( {LieDown} [ ] ) ";
            if (action is GetUpAction getUpAction)
                return $"( {GetUp} [ ] ) ";
            if (action is KneelDownAction kneelDownAction)
                return $"( {KneelDown} [ ] ) ";
            if (action is DiveInAction diveInAction)
                return $"( {DiveIn} [ ] ) ";
            if (action is DiveOutAction diveOutAction)
                return $"( {DiveOut} [ ] ) ";
            return string.Empty;
        }
    }
}
