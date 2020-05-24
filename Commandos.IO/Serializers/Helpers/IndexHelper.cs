using System.IO;
using Commandos.IO.Entities;

namespace Commandos.IO.Serializers.Helpers
{
    public enum BracketType
    {
        RoundBracket,
        SquareBracket
    }

    public static class IndexHelper
    {
        internal static (int nameIndex, int startIndex, int endIndex, RecordDataType recordDataType) GetIndexes(string[] tokens, int startPoint)
        {
            var nameIndex = GetStartIndex(tokens, startPoint);
            var startIndex = nameIndex + 1;
            if (tokens[startIndex] == "[")
                return (nameIndex, startIndex, GetEndIndex(tokens, startIndex, "[", "]"), RecordDataType.MultipleRecords);
            else if (tokens[startIndex] == "(")
            {
                return (nameIndex, startIndex, GetEndIndex(tokens, startIndex, "(", ")"), RecordDataType.MixedDataRecord);
            }
            else
                return (nameIndex, startIndex, startIndex, RecordDataType.SingleDataRecord);
        }

        private static int GetStartIndex(string[] tokens, int startPoint)
        {
            for (var i = startPoint; i < tokens.Length; i++)
                //if (tokens[i] == "(" || tokens[i] == ")" || tokens[i] == "[" || tokens[i] == "]")
                //    continue;
                //else
                if (tokens[i].StartsWith(".", System.StringComparison.CurrentCultureIgnoreCase))
                    return i;
            throw new InvalidDataException($"Token not found,");
        }

        internal static int GetEndIndex(string[] tokens, int startIndex, BracketType bracketType)
        {
            if (bracketType == BracketType.RoundBracket)
                return GetEndIndex(tokens, startIndex, "(", ")");
            else
                return GetEndIndex(tokens, startIndex, "[", "]");
        }

        private static int GetEndIndex(string[] tokens, int startIndex, string startingElement, string endingElement)
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
