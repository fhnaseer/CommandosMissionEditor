using System.Globalization;
using Commandos.Model;

namespace Commandos.IO.Serializers
{
    public static class CameraSerializer
    {
        public static Camera ToCamera(string[] tokens, int startIndex)
        {
            var indexes = GetCameraIndexes(tokens, startIndex);
            var camera = new Camera
            {
                Position = EntitySerializer.ToPosition(tokens, indexes.startIndex),
                Escape = EntitySerializer.ToStringValue(tokens, StringConstants.Escape, indexes.startIndex),
                CameraDirection = ToCameraDirection(tokens, indexes.startIndex)
            };
            return camera;
        }

        private static (int startIndex, int endIndex) GetCameraIndexes(string[] tokens, int startPoint = 0)
        {
            return IndexHelper.GetIndexes(tokens, StringConstants.Camera, startPoint, TokenType.SquareBracket);
        }

        private static (int startIndex, int endIndex) GetCameraDirection(string[] tokens, int startPoint = 0)
        {
            return IndexHelper.GetIndexes(tokens, StringConstants.CameraDirection, startPoint, TokenType.SingleValue);
        }

        private static CameraDirection ToCameraDirection(string[] tokens, int startIndex)
        {
            var indexes = GetCameraDirection(tokens, startIndex);
            return (CameraDirection)int.Parse(tokens[indexes.startIndex + 1], CultureInfo.CurrentCulture);
        }
    }
}
