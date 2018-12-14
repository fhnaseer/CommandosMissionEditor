using System.Globalization;
using Commandos.IO.Entities;
using Commandos.IO.Files;
using Commandos.Model.Common;
using Commandos.Model.Map;

namespace Commandos.IO.Serializers.Mission
{
    public static class CameraSerializer
    {
        public static Camera GetCamera(Record record)
        {
            var cameraRecord = record.GetMultipleRecords();
            cameraRecord.Records.TryGetValue(StringConstants.Position, out Record positionRecord);
            cameraRecord.Records.TryGetValue(StringConstants.Escape, out Record escapeRecord);
            cameraRecord.Records.TryGetValue(StringConstants.CameraDirection, out Record directionRecord);
            return new Camera
            {
                Position = GetPosition(positionRecord),
                Escape = escapeRecord?.GetStringValue(),
                CameraDirection = (CameraDirection)directionRecord?.GetIntegerValue()
            };
        }

        private static Position GetPosition(Record positionRecord)
        {
            var values = (MixedValues)positionRecord.Value;
            var x = double.Parse(((SingleValue)values.Values[0]).Value, CultureInfo.CurrentCulture);
            var y = double.Parse(((SingleValue)values.Values[1]).Value, CultureInfo.CurrentCulture);
            var z = double.Parse(((SingleValue)values.Values[2]).Value, CultureInfo.CurrentCulture);
            return new Position(x, y, z);
        }
    }
}
