using Commandos.IO.Entities;
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
            var camera = new Camera();
            Helpers.SerializerHelper.PopulateIPosition(camera, multipleRecords);
            camera.CameraDirection = multipleRecords.GetStringValue(CameraDirection);
            return camera;
        }

        public override string GetMultipleRecordString(Camera input) => $"[ {CameraDirection} {input.CameraDirection} {Helpers.SerializerHelper.GetIPositionRecordString(input)} ]";
    }
}
