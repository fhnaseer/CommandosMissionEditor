//using System.Globalization;
//using Commandos.Model;

//namespace Commandos.IO.Serializers
//{
//    public static class CameraSerializer
//    {
//        public static Camera GetCamera(string[] tokens, int startIndex)
//        {
//            var indexes = GetCameraIndexes(tokens, startIndex);
//            return new Camera
//            {
//                Position = EntitySerializer.GetPosition(tokens, indexes.startIndex),
//                Escape = EntitySerializer.GetStringValue(tokens, StringConstants.Escape, indexes.startIndex),
//                CameraDirection = GetCameraDirection(tokens, indexes.startIndex)
//            };
//        }

//        private static (int startIndex, int endIndex) GetCameraIndexes(string[] tokens, int startPoint = 0)
//        {
//            return IndexHelper.GetRecordIndexes(tokens, StringConstants.Camera, startPoint, TokenType.MultipleRecords);
//        }

//        private static CameraDirection GetCameraDirection(string[] tokens, int startIndex)
//        {
//            var indexes = IndexHelper.GetRecordIndexes(tokens, StringConstants.CameraDirection, startIndex, TokenType.SingleValue);
//            return (CameraDirection)int.Parse(tokens[indexes.startIndex + 1], CultureInfo.CurrentCulture);
//        }
//    }
//}
