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
                Area = multipleRecords.GetStringValue(StringConstants.Escape),
                CameraDirection = multipleRecords.GetIntegerValue(StringConstants.CameraDirection)
            };
        }

        private static Position GetPosition(MixedDataRecord mixedValues)
        {
            var values = mixedValues.Data;
            var x = mixedValues.GetDoubleValue(0);
            var y = mixedValues.GetDoubleValue(1);
            var z = mixedValues.GetDoubleValue(2);
            return new Position(x, y, z);
        }

        //public static Record GetRecord(Camera camera)
        //{
        //    var record = new Record(StringConstants.Camera);

        //}
    }
}
