using Commandos.Model.Map;

namespace Commandos.IO.Serializers
{
    public static class BriefingSerializer
    {
        public static Briefing GetBriefing(string[] tokens, int startIndex)
        {
            var indexes = GetBriefingIndexes(tokens, startIndex);
            return new Briefing
            {
                FileName = EntitySerializer.GetStringValue(tokens, StringConstants.BriefingFile, indexes.startIndex)
            };
        }

        private static (int startIndex, int endIndex) GetBriefingIndexes(string[] tokens, int startPoint = 0)
        {
            return IndexHelper.GetIndexes(tokens, StringConstants.Briefing, startPoint, TokenType.SquareBracket);
        }
    }
}
