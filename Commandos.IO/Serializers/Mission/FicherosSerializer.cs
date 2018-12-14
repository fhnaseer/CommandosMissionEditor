//using Commandos.Model.Map;

//namespace Commandos.IO.Serializers.Mission
//{
//    public static class FicherosSerializer
//    {
//        public static Ficheros GetFicheros(string[] tokens, int startIndex)
//        {
//            var indexes = GetIndexes(tokens, startIndex);
//            return new Ficheros
//            {
//                FileName = EntitySerializer.GetStringValue(tokens, StringConstants.FicherosStrFile, indexes.startIndex)
//            };
//        }

//        private static (int startIndex, int endIndex) GetIndexes(string[] tokens, int startPoint = 0)
//        {
//            return IndexHelper.GetRecordIndexes(tokens, StringConstants.Ficheros, startPoint, TokenType.MultipleRecords);
//        }
//    }
//}
