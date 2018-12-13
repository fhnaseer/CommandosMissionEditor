using System.IO;
using Commandos.IO.Entities;

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

        private static int GetStartIndex(string[] tokens, string tokenName, int startPoint)
        {
            for (var i = startPoint; i < tokens.Length; i++)
                if (tokens[i] == tokenName)
                    return i;
            throw new InvalidDataException($"Token {tokenName} not found,");
        }

        private static int GetStartIndex(string[] tokens, int startPoint)
        {
            for (var i = startPoint; i < tokens.Length; i++)
                if (tokens[i].StartsWith(".", System.StringComparison.CurrentCultureIgnoreCase))
                    return i;
            throw new InvalidDataException($"Token not found,");
        }

        internal static (int nameIndex, int startIndex, int endIndex, TokenValueType tokenValueType) GetIndexes(string[] tokens, int startPoint)
        {
            var nameIndex = GetStartIndex(tokens, startPoint);
            var startIndex = nameIndex + 1;
            if (tokens[startIndex] == "[")
                return (nameIndex, startIndex, GetEndIndex(tokens, startIndex, "[", "]"), TokenValueType.MultipleRecords);
            else if (tokens[startIndex] == "(")
            {
                return (nameIndex, startIndex, GetEndIndex(tokens, startIndex, "(", ")"), TokenValueType.MixedValues);

                //if (tokens[startIndex + 1] == "(")
                //    return (nameIndex, startIndex, GetEndIndex(tokens, startIndex, "(", ")"), TokenValueType.MultipleList);
                //else if (tokens[startIndex + 1] == "[")
                //    return (nameIndex, startIndex, GetEndIndex(tokens, startIndex, "(", ")"), TokenValueType.MultipleListRecords);
                //else
                //    return (nameIndex, startIndex, GetEndIndex(tokens, startIndex, "(", ")"), TokenValueType.MultipleValues);
            }
            else
                return (nameIndex, startIndex, startIndex, TokenValueType.SingleValue);
        }

        internal static (int startIndex, int endIndex) GetRecordIndexes(string[] tokens, string tokenName, int startPoint, TokenType tokenType)
        {
            var startIndex = GetStartIndex(tokens, tokenName, startPoint);
            if (tokenType == TokenType.SingleValue)
                return (startIndex, startIndex + 1);
            else if (tokenType == TokenType.MultipleList)
                return (startIndex, GetEndIndex(tokens, startIndex, "(", ")"));
            else if (tokenType == TokenType.MultipleRecords)
                return (startIndex, GetEndIndex(tokens, startIndex, "[", "]"));
            throw new InvalidDataException($"Invalid tokenType {tokenType} for tokenName {tokenName},");
        }

        internal static int GetEndIndex(string[] tokens, int startIndex, string startingElement, string endingElement)
        {
            var counter = 0;
            for (var i = startIndex; i < tokens.Length; i++)
            {
                if (tokens[i] == startingElement)
                    counter++;
                else if (tokens[i] == endingElement)
                {
                    counter--;
                    if (counter == 0)
                        return i;
                }
            }
            throw new InvalidDataException("Invalid data,");
        }
    }
}
