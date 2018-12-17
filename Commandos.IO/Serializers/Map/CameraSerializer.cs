using System.Collections.Generic;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Map
{
    public static class CameraSerializer
    {
        public static Camera GetCamera(MultipleRecords multipleRecords)
        {
            return new Camera
            {
                Position = GetPosition(multipleRecords.GetMixedDataRecord(StringConstants.Position)),
                Area = multipleRecords.GetStringValue(StringConstants.Area),
                CameraDirection = multipleRecords.GetStringValue(StringConstants.CameraDirection)
            };
        }

        private static Position GetPosition(IList<RecordData> mixedDataRecord)
        {
            var x = mixedDataRecord[0].GetStringValue();
            var y = mixedDataRecord[1].GetStringValue();
            var z = mixedDataRecord[2].GetStringValue();
            return new Position(x, y, z);
        }

        public static Record GetRecord(Camera camera)
        {
            var record = RecordExtensions.GetMultipleDataRecord(StringConstants.Camera);
            var data = (MultipleRecords)record.Data;
            data.AddSingleDataRecord(StringConstants.CameraDirection, camera.CameraDirection);
            data.AddSingleDataRecord(StringConstants.Area, camera.Area);
            data.AddMixedDataRecord(StringConstants.Position, GetPositionRecord(camera.Position));
            return record;
        }

        private static Record GetPositionRecord(Position position)
        {
            var record = RecordExtensions.GetMixedDataRecord(StringConstants.Position);
            var data = (MixedDataRecord)record.Data;
            data.Data.Add(new SingleDataRecord(position.X));
            data.Data.Add(new SingleDataRecord(position.Y));
            data.Data.Add(new SingleDataRecord(position.Z));
            return record;
        }
    }
}
