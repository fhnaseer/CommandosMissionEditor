using Commandos.IO.Entities;
using Commandos.IO.Helpers;
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
                Position = Helpers.SerializerHelper.GetPosition(multipleRecords),
                Area = Helpers.SerializerHelper.GetArea(multipleRecords),
                CameraDirection = multipleRecords.GetStringValue(CameraDirection)
            };
        }

        public override string GetMultipleRecordString(Camera input) => $"[ {CameraDirection} {input.CameraDirection} {StringConstants.Area} {input.Area} {Helpers.SerializerHelper.GetPositionRecordString(input.Position)} ]";
    }
}
