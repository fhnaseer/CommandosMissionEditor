//using Commandos.Model.Map;

//namespace Commandos.IO.Serializers
//{
//    public static class BriefingSerializer
//    {
//        public static Briefing GetBriefing(string[] tokens, int startIndex)
//        {
//            var indexes = GetIndexes(tokens, startIndex);
//            return new Briefing
//            {
//                FileName = EntitySerializer.GetStringValue(tokens, StringConstants.BriefingFile, indexes.startIndex)
//            };
//        }

//        private static (int startIndex, int endIndex) GetIndexes(string[] tokens, int startPoint = 0)
//        {
//            return IndexHelper.GetRecordIndexes(tokens, StringConstants.Briefing, startPoint, TokenType.MultipleRecords);
//        }
//    }
//}
