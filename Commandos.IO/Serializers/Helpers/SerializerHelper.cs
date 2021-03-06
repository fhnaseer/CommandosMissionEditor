﻿using Commandos.IO.Entities;
using Commandos.IO.Serializers.Map;
using Commandos.Model.Characters;
using Commandos.Model.Characters.Enemies;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Helpers
{
    public class SerializerHelper
    {
        private SerializerHelper() { }

        private static SerializerHelper _instance;
        public static SerializerHelper Instance => _instance ?? (_instance = new SerializerHelper());

        private BriefingSerializer _breifeingSerializer;
        public BriefingSerializer BriefingSerializer => _breifeingSerializer ?? (_breifeingSerializer = new BriefingSerializer());

        private CameraSerializer _cameraSerializer;
        public CameraSerializer CameraSerializer => _cameraSerializer ?? (_cameraSerializer = new CameraSerializer());

        private FicherosSerializer _ficherosSerializer;
        public FicherosSerializer FicherosSerializer => _ficherosSerializer ?? (_ficherosSerializer = new FicherosSerializer());

        private MusicSerializer _musicSerializer;
        public MusicSerializer MusicSerializer => _musicSerializer ?? (_musicSerializer = new MusicSerializer());

        private WorldSerializer _worldSerializer;
        public WorldSerializer WorldSerializer => _worldSerializer ?? (_worldSerializer = new WorldSerializer());

        private PatrolsSerializer _patrolsSerializer;
        public PatrolsSerializer PatrolsSerializer => _patrolsSerializer ?? (_patrolsSerializer = new PatrolsSerializer());

        private MissionObjectsSerializer _missionObjectsSerializer;
        public MissionObjectsSerializer MissionObjectsSerializer => _missionObjectsSerializer ?? (_missionObjectsSerializer = new MissionObjectsSerializer());

        //private SoldiersSerializer _soldiersSerializer;
        //public SoldiersSerializer SoldiersSerializer => _soldiersSerializer ?? (_soldiersSerializer = new SoldiersSerializer());

        public static void PopulateCharacter(Character character, MultipleRecords multipleRecords)
        {
            if (character is EnemyPatrol)
                PopulateIPosition(character, multipleRecords);
            else
                PopulateIPosition(character, multipleRecords.GetMultipleRecord(StringConstants.CharacterPosition));
            character.TokenId = multipleRecords.GetStringValue(StringConstants.TokenId);
            character.Angle = multipleRecords.GetStringValue(StringConstants.Angle);
        }

        public static void PopulateIPosition(IPosition target, MultipleRecords multipleRecords)
        {
            target.Position = GetPosition(multipleRecords);
            target.Area = GetArea(multipleRecords);
        }

        private static Position GetPosition(MultipleRecords multipleRecords)
        {
            var mixedDataRecord = multipleRecords.GetMixedDataRecord(StringConstants.Position);
            var x = mixedDataRecord[0].GetStringValue();
            var y = mixedDataRecord[1].GetStringValue();
            var z = mixedDataRecord[2].GetStringValue();
            return new Position(x, y, z);
        }

        private static string GetArea(MultipleRecords multipleRecords) => multipleRecords.GetStringValue(StringConstants.Area);

        internal static string GetAngle(MultipleRecords multipleRecords) => multipleRecords.GetStringValue(StringConstants.Angle);

        internal static string GetTime(MultipleRecords multipleRecords) => multipleRecords.GetStringValue(StringConstants.Time);

        public static string GetSpeed(MultipleRecords multipleRecords) => multipleRecords.GetStringValue(StringConstants.Speed);

        public static string GetMovementType(MultipleRecords multipleRecords) => multipleRecords.GetStringValue(StringConstants.MovementType);

        public static string GetCharacterRecordString(Character character)
        {
            var iPositionString = character is EnemyPatrol ? GetIPositionRecordString(character) : $"{StringConstants.CharacterPosition} [ {GetIPositionRecordString(character)} ]";
            return $"{iPositionString} {GetAngleRecordString(character.Angle)} {GetTokenRecordString(character.TokenId)}";
        }

        public static string GetIPositionRecordString(IPosition target) => $"{StringConstants.Position} ( {target.Position.X} {target.Position.Y} {target.Position.Z} ) {StringConstants.Area} {target.Area}";

        private static string GetPositionRecordString(Position position) => $"{StringConstants.Position} ( {position.X} {position.Y} {position.Z} )";

        private static string GetAreaRecordString(string area) => $"{StringConstants.Area} {area}";

        public static string GetSpeedRecordString(string speed) => $"{StringConstants.Speed} {speed}";

        public static string GetMovementTypeRecordString(string movementType) => $"{StringConstants.MovementType} {movementType}";

        public static string GetActionTypeRecordString(string actionType) => $"{StringConstants.EnemyActionType} {actionType}";

        internal static object GetAngleRecordString(string angle) => $"{StringConstants.Angle} {angle}";

        internal static object GetTimeRecordString(string time) => $"{StringConstants.Time} {time}";

        internal static object GetTokenRecordString(string tokenId) => $"{StringConstants.TokenId} {tokenId}";
    }
}
