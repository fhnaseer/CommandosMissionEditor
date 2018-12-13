using Commandos.IO.Entities;

namespace Commandos.IO
{
    public static class TokenParser
    {
        //public static IList<TokenBase> ParseTokens(string[] tokens)
        //{
        //    if (tokens is null)
        //        throw new ArgumentNullException(nameof(tokens));
        //    if (tokens[0] != "[" && tokens[tokens.Length - 1] != "]")
        //        throw new InvalidDataException("Invalid data,");


        //}

        internal static TokenBase ParseTokens(string[] tokens, int startIndex)
        {
            var indexes = IndexHelper.GetIndexes(tokens, startIndex);
            if (indexes.tokenValueType == TokenValueType.SingleValue)
                return ParseSingleValue(tokens, indexes.startIndex, indexes.endIndex);
            if (indexes.tokenValueType == TokenValueType.MultipleValues)
                return ParseMultipleValues(tokens, indexes.startIndex, indexes.endIndex);
            if (indexes.tokenValueType == TokenValueType.MultipleValues)
                return ParseMultipleList(tokens, indexes.startIndex, indexes.endIndex);
            return null;
        }

        private static TokenBase ParseSingleValue(string[] tokens, int startIndex, int endIndex)
        {
            return new SingleValue { Name = tokens[startIndex], Value = tokens[endIndex] };
        }

        private static TokenBase ParseMultipleValues(string[] tokens, int startIndex, int endIndex)
        {
            var result = new MultipleValues();
            result.Name = tokens[startIndex];
            for (var i = startIndex + 2; i < endIndex; i++)
                result.Values.Add(tokens[i]);
            return result;
        }

        private static TokenBase ParseMultipleList(string[] tokens, int startIndex, int endIndex)
        {
            var result = new MultipleValues();
            result.Name = tokens[startIndex];
            for (var i = startIndex + 2; i < endIndex; i++)
                result.Values.Add(tokens[i]);
            return result;
        }

        //private static TokenBase ParseMultipleValues(string[] tokens, int startIndex, int endIndex)
        //{

        //}
    }
}
