using System.Collections.Generic;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public class CameraSerializer : RecordSerializerBase<Camera>
    {
        public const string Camera = ".VISORES";
        public const string CameraDirection = ".CAMARA";

        public override string RecordName => Camera;

        public override Camera Serialize(Record record)
        {
            var multipleRecords = record.GetMultipleRecords();
            return new Camera
            {
                Position = GetPosition(multipleRecords.GetMixedDataRecord(StringConstants.Position)),
                Area = multipleRecords.GetStringValue(StringConstants.Area),
                CameraDirection = multipleRecords.GetStringValue(CameraDirection)
            };
        }

        private static Position GetPosition(IList<RecordData> mixedDataRecord)
        {
            var x = mixedDataRecord[0].GetStringValue();
            var y = mixedDataRecord[1].GetStringValue();
            var z = mixedDataRecord[2].GetStringValue();
            return new Position(x, y, z);
        }

        public override string GetMultipleRecordString(Camera input) => $"[ {CameraDirection} {input.CameraDirection} {StringConstants.Area} {input.Area} {GetPositionRecordString(input.Position)} ]";

        private static string GetPositionRecordString(Position position) => $"{StringConstants.Position} ( {position.X} {position.Y} {position.Z} )";
    }
}
