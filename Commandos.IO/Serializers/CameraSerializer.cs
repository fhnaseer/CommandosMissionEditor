using System.Globalization;
using Commandos.Model;

namespace Commandos.IO.Serializers
{
    public static class CameraSerializer
    {
        public static Camera ToCamera(string[] tokens, (int startIndex, int endIndex) range)
        {
            var camera = new Camera();
            var result = IndexHelper.GetPositionIndexes(tokens, range.startIndex);
            camera.Position = EntitySerializer.ToPosition(tokens, result.startIndex);
            result = IndexHelper.GetEscapeIndexes(tokens, range.startIndex);
            camera.Escape = EntitySerializer.ToEscape(tokens, result.startIndex);
            result = GetCameraDirection(tokens, range.startIndex);
            camera.CameraDirection = ToCameraDirection(tokens, result.startIndex);
            return camera;
        }

        private static (int startIndex, int endIndex) GetCameraDirection(string[] tokens, int startPoint = 0)
        {
            return IndexHelper.GetIndexes(tokens, StringConstants.CameraDirection, startPoint, TokenType.SingleValue);
        }

        private static CameraDirection ToCameraDirection(string[] tokens, int startIndex)
        {
            return (CameraDirection)int.Parse(tokens[startIndex + 1], CultureInfo.CurrentCulture);
        }
    }
}
