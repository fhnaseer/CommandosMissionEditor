using System;
using System.IO;
using Commandos.IO.Entities;

namespace Commandos.IO
{
    public static class TokenParser
    {
        public static MultipleRecords ParseTokens(string[] tokens)
        {
            if (tokens is null)
                throw new ArgumentNullException(nameof(tokens));
            if (tokens[0] != "[" && tokens[tokens.Length - 1] != "]")
                throw new InvalidDataException("Invalid data,");
            return ParseMultipleRecords(tokens, 0, tokens.Length - 1);
        }

        private static MultipleRecords ParseMultipleRecords(string[] tokens, int startIndex, int endIndex)
        {
            var record = new MultipleRecords();
            for (var i = startIndex + 1; i < endIndex; i++)
            {
                var indexes = IndexHelper.GetIndexes(tokens, i);
                record.Records.Add(ParseTokens(tokens, i));
                i = indexes.endIndex;
            }
            return record;
        }

        internal static Record ParseTokens(string[] tokens, int startIndex)
        {
            var indexes = IndexHelper.GetIndexes(tokens, startIndex);
            var record = new Record();
            record.Name = tokens[indexes.nameIndex];
            if (indexes.recordValueType == RecordValueType.SingleValue)
                record.Value = ParseSingleValue(tokens, indexes.startIndex);
            else if (indexes.recordValueType == RecordValueType.MultipleRecords)
                record.Value = ParseMultipleRecords(tokens, indexes.startIndex, indexes.endIndex);
            else if (indexes.recordValueType == RecordValueType.MixedValues)
                record.Value = ParseMixedRecords(tokens, indexes.startIndex, indexes.endIndex);
            return record;
        }

        private static MixedRecords ParseMixedRecords(string[] tokens, int startIndex, int endIndex)
        {
            var record = new MixedRecords();
            for (var i = startIndex + 1; i < endIndex; i++)
            {
                int end;
                if (tokens[i] == "(")
                {
                    end = IndexHelper.GetEndIndex(tokens, i, "(", ")");
                    record.Values.Add(ParseMixedRecords(tokens, i, end));
                }
                else if (tokens[i] == "[")
                {
                    end = IndexHelper.GetEndIndex(tokens, i, "[", "]");
                    record.Values.Add(ParseMultipleRecords(tokens, i, end));
                }
                else
                {
                    record.Values.Add(ParseSingleValue(tokens, i));
                    end = i;
                }
                i = end;
            }
            return record;
        }

        private static SingleValue ParseSingleValue(string[] tokens, int startIndex)
        {
            return new SingleValue { Value = tokens[startIndex] };
        }
    }
}
