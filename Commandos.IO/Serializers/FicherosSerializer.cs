using Commandos.Model.Map;

namespace Commandos.IO.Serializers
{
    public static class FicherosSerializer
    {
        public static Ficheros GetFicheros(string[] tokens, int startIndex)
        {
            var indexes = GetFicherosIndexes(tokens, startIndex);
            return new Ficheros
            {
                FileName = EntitySerializer.GetStringValue(tokens, StringConstants.FicherosStrFile, indexes.startIndex)
            };
        }

        private static (int startIndex, int endIndex) GetFicherosIndexes(string[] tokens, int startPoint = 0)
        {
            return IndexHelper.GetIndexes(tokens, StringConstants.Ficheros, startPoint, TokenType.SquareBracket);
        }
    }
}
