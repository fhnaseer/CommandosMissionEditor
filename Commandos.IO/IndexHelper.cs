using System.IO;

namespace Commandos.IO
{
    public enum TokenType
    {
        SingleValue,
        MultipleRecords,
        MultipleValues,
        MultipleList
    }

    public static class IndexHelper
    {
        public static (int startIndex, int endIndex) GetPositionIndexes(string[] tokens, int startPoint)
        {
            return GetRecordIndexes(tokens, StringConstants.Position, startPoint, TokenType.SingleValue);
        }

        internal static (int startIndex, int endIndex, int count, int elementCount) GetListIndexes(string[] tokens, string tokenName, int startPoint, TokenType tokenType)
        {
            var startIndex = GetStartIndex(tokens, tokenName, startPoint);
            //if (tokenType == TokenType.MultipleValues)
            //{
            //    var indexes = (startIndex, startIndex + 1);
            //}
            //else if (tokenType == TokenType.MultipleList)
            //    return (startIndex, GetRecordIndexes(tokens, startIndex, "(", ")").endIndex);
            //else if (tokenType == TokenType.MultipleRecords)
            //    return (startIndex, GetRecordIndexes(tokens, startIndex, "[", "]").endIndex);
            throw new InvalidDataException($"Invalid tokenType {tokenType} for tokenName {tokenName},");
        }

        private static int GetStartIndex(string[] tokens, string tokenName, int startPoint)
        {
            for (var i = startPoint; i < tokens.Length; i++)
                if (tokens[i] == tokenName)
                    return i;
            throw new InvalidDataException($"Token {tokenName} not found,");
        }

        internal static (int startIndex, int endIndex) GetRecordIndexes(string[] tokens, string tokenName, int startPoint, TokenType tokenType)
        {
            var startIndex = GetStartIndex(tokens, tokenName, startPoint);
            if (tokenType == TokenType.SingleValue)
                return (startIndex, startIndex + 1);
            else if (tokenType == TokenType.MultipleList)
                return (startIndex, GetRecordIndexes(tokens, startIndex, "(", ")").endIndex);
            else if (tokenType == TokenType.MultipleRecords)
                return (startIndex, GetRecordIndexes(tokens, startIndex, "[", "]").endIndex);
            throw new InvalidDataException($"Invalid tokenType {tokenType} for tokenName {tokenName},");
        }

        private static (int endIndex, int childCount) GetRecordIndexes(string[] tokens, int startIndex, string startingElement, string endingElement)
        {
            var counter = 0;
            var childCount = 0;
            for (var i = startIndex + 1; i < tokens.Length; i++)
            {
                if (tokens[i] == startingElement)
                {
                    counter++;
                    childCount++;
                }
                else if (tokens[i] == endingElement)
                {
                    counter--;
                    if (counter == 0)
                        return (i, childCount);
                }
            }
            throw new InvalidDataException("Invalid data,");
        }
    }
}
