using System;
using System.Collections.Generic;
using System.IO;
using Commandos.IO.Entities;

namespace Commandos.IO.Serializers.Helpers
{
    public static class TokenParser
    {
        public static string[] GetCleanedTokens(string text)
        {
            var tokens = text.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var finalTokens = new List<string>();
            for (var i = 0; i < tokens.Length; i++)
            {
                // After .record there should be a value,
                if (i != tokens.Length - 1 && tokens[i].StartsWith("."))
                    if (tokens[i + 1].StartsWith(".") || tokens[i + 1].StartsWith(")") || tokens[i + 1].StartsWith("]"))
                        continue;
                finalTokens.Add(tokens[i]);
            }
            return finalTokens.ToArray();
        }

        public static MultipleRecords ParseTokens(string[] tokens)
        {
            if (tokens is null)
                throw new ArgumentNullException(nameof(tokens));
            if (tokens[0] != "[" && tokens[tokens.Length - 1] != "]")
                if (tokens[0] != "(" && tokens[tokens.Length - 1] != ")")
                    throw new InvalidDataException("Invalid data,");
            return ParseMultipleRecords(tokens, 0, tokens.Length - 1);
        }

        private static MultipleRecords ParseMultipleRecords(string[] tokens, int startIndex, int endIndex)
        {
            var record = new MultipleRecords();
            for (var i = startIndex + 1; i < endIndex; i++)
            {
                var indexes = IndexHelper.GetIndexes(tokens, i);
                var result = ParseTokens(tokens, i);
                record.Records.Add(result.Name, result);
                i = indexes.endIndex;
            }
            return record;
        }

        internal static Record ParseTokens(string[] tokens, int startIndex)
        {
            var indexes = IndexHelper.GetIndexes(tokens, startIndex);
            var record = new Record();
            record.Name = tokens[indexes.nameIndex];
            if (indexes.recordDataType == RecordDataType.SingleDataRecord)
                record.Data = ParseSingleDataRecord(tokens, indexes.startIndex);
            else if (indexes.recordDataType == RecordDataType.MultipleRecords)
                record.Data = ParseMultipleRecords(tokens, indexes.startIndex, indexes.endIndex);
            else if (indexes.recordDataType == RecordDataType.MixedDataRecord)
                record.Data = ParseMixedRecords(tokens, indexes.startIndex, indexes.endIndex);
            return record;
        }

        private static MixedDataRecord ParseMixedRecords(string[] tokens, int startIndex, int endIndex)
        {
            var record = new MixedDataRecord();
            for (var i = startIndex + 1; i < endIndex; i++)
            {
                int end;
                if (tokens[i] == "(")
                {
                    end = IndexHelper.GetEndIndex(tokens, i, BracketType.RoundBracket);
                    record.Records.Add(ParseMixedRecords(tokens, i, end));
                }
                else if (tokens[i] == "[")
                {
                    end = IndexHelper.GetEndIndex(tokens, i, BracketType.SquareBracket);
                    record.Records.Add(ParseMultipleRecords(tokens, i, end));
                }
                else
                {
                    record.Records.Add(ParseSingleDataRecord(tokens, i));
                    end = i;
                }
                i = end;
            }
            return record;
        }

        private static SingleDataRecord ParseSingleDataRecord(string[] tokens, int startIndex)
        {
            return new SingleDataRecord { Data = tokens[startIndex] };
        }
    }
}
