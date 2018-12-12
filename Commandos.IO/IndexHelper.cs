using System.IO;

namespace Commandos.IO
{
    public enum TokenType
    {
        SingleValue,
        SquareBracket,
        RoundBrackets
    }

    public static class IndexHelper
    {
        public static (int startIndex, int endIndex) GetPositionIndexes(string[] tokens, int startPoint)
        {
            return GetIndexes(tokens, StringConstants.Position, startPoint, TokenType.RoundBrackets);
        }

        public static (int startIndex, int endIndex) GetEscapeIndexes(string[] tokens, int startPoint = 0)
        {
            return GetIndexes(tokens, StringConstants.Escape, startPoint, TokenType.SingleValue);
        }

        public static (int startIndex, int endIndex) GetCameraIndexes(string[] tokens, int startPoint = 0)
        {
            return GetIndexes(tokens, StringConstants.Camera, startPoint, TokenType.SquareBracket);
        }

        public static (int startIndex, int endIndex) GetIndexes(string[] tokens, string tokenName, int startPoint, TokenType tokenType)
        {
            var startIndex = 0;
            for (var i = startPoint; i < tokens.Length; i++)
            {
                if (tokens[i] != tokenName)
                    continue;
                startIndex = i;
                break;
            }
            if (tokenType == TokenType.SingleValue)
                return (startIndex, startIndex + 1);
            else if (tokenType == TokenType.RoundBrackets)
                return GetIndexes(tokens, startIndex, "(", ")");
            else
                return GetIndexes(tokens, startIndex, "[", "]");
        }

        private static (int startIndex, int endIndex) GetIndexes(string[] tokens, int startIndex, string startingElement, string endingElement)
        {
            var counter = 0;
            for (var i = startIndex + 1; i < tokens.Length; i++)
            {
                if (tokens[i] == startingElement)
                    counter++;
                if (tokens[i] == endingElement)
                {
                    counter--;
                    if (counter == 0)
                        return (startIndex, i);
                }
            }
            throw new InvalidDataException("Wrong data,");
        }
    }
}
