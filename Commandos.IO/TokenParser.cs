using System;
using System.IO;
using Commandos.IO.Entities;

namespace Commandos.IO
{
    public static class TokenParser
    {
        public static TokenBase ParseTokens(string[] tokens)
        {
            if (tokens is null)
                throw new ArgumentNullException(nameof(tokens));
            if (tokens[0] != "[" && tokens[tokens.Length - 1] != "]")
                throw new InvalidDataException("Invalid data,");
            return ParseMultipleRecords(tokens, 0, tokens.Length - 1);
        }

        internal static TokenBase ParseTokens(string[] tokens, int startIndex)
        {
            var indexes = IndexHelper.GetIndexes(tokens, startIndex);
            TokenBase result;
            if (indexes.tokenValueType == TokenValueType.SingleValue)
                result = ParseSingleValue(tokens, indexes.startIndex);
            else if (indexes.tokenValueType == TokenValueType.MultipleValues)
                result = ParseMultipleValues(tokens, indexes.startIndex, indexes.endIndex);
            else if (indexes.tokenValueType == TokenValueType.MultipleList)
                result = ParseMultipleList(tokens, indexes.startIndex, indexes.endIndex);
            else if (indexes.tokenValueType == TokenValueType.MultipleListRecords)
                result = ParseMultipleListRecords(tokens, indexes.startIndex, indexes.endIndex);
            else
                result = ParseMultipleRecords(tokens, indexes.startIndex, indexes.endIndex);
            result.Name = tokens[indexes.nameIndex];
            return result;
        }

        private static SingleValue ParseSingleValue(string[] tokens, int startIndex)
        {
            return new SingleValue { Value = tokens[startIndex] };
        }

        private static MultipleValues ParseMultipleValues(string[] tokens, int startIndex, int endIndex)
        {
            var result = new MultipleValues();
            for (var i = startIndex + 1; i < endIndex; i++)
                result.Values.Add(tokens[i]);
            return result;
        }

        private static MultipleList ParseMultipleList(string[] tokens, int startIndex, int endIndex)
        {
            var result = new MultipleList();
            for (var i = startIndex + 1; i < endIndex; i++)
            {
                var end = IndexHelper.GetEndIndex(tokens, i, "(", ")");
                result.Values.Add(ParseMultipleValues(tokens, i, end));
                i = end;
            }
            return result;
        }

        private static MultipleRecords ParseMultipleListRecords(string[] tokens, int startIndex, int endIndex)
        {
            var result = new MultipleRecords();
            for (var i = startIndex + 1; i < endIndex; i++)
            {
                var end = IndexHelper.GetEndIndex(tokens, i, "[", "]");
                result.Values.Add(ParseMultipleRecords(tokens, i, end));
                i = end;
            }
            return result;
        }

        private static MultipleRecords ParseMultipleRecords(string[] tokens, int startIndex, int endIndex)
        {
            var result = new MultipleRecords();
            for (var i = startIndex + 1; i < endIndex; i++)
            {
                var indexes = IndexHelper.GetIndexes(tokens, i);
                result.Values.Add(ParseTokens(tokens, i));
                i = indexes.endIndex;
            }
            return result;
        }
    }
}
