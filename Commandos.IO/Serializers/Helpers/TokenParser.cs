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
            if (tokens[0] != "[" && tokens[^1] != "]")
                if (tokens[0] != "(" && tokens[^1] != ")")
                    throw new InvalidDataException("Invalid data,");
            return ParseMultipleRecords(tokens[1..^1]);
        }

        private static MultipleRecords ParseMultipleRecords(string[] tokens)
        {
            var record = new MultipleRecords();
            for (var i = 0; i < tokens.Length; i++)
            {
                var tokenMetadata = IndexHelper.GetIndexes(tokens, i);
                var result = ParseTokens(tokenMetadata);
                record.Records.Add(result.Name, result);
                i = tokenMetadata.EndIndex;
            }
            return record;
        }

        internal static Record ParseTokens(TokenMetadata tokenMetadata)
        {
            var record = new Record();
            record.Name = tokenMetadata.Name;
            if (tokenMetadata.RecordDataType == RecordDataType.SingleDataRecord)
                record.Data = ParseSingleDataRecord(tokenMetadata.Tokens);
            else if (tokenMetadata.RecordDataType == RecordDataType.MultipleRecords)
                record.Data = ParseMultipleRecords(tokenMetadata.DataTokens);
            else if (tokenMetadata.RecordDataType == RecordDataType.MixedDataRecord)
                record.Data = ParseMixedRecords(tokenMetadata.DataTokens);
            return record;
        }

        private static MixedDataRecord ParseMixedRecords(string[] tokens)
        {
            var record = new MixedDataRecord();
            for (var i = 0; i < tokens.Length; i++)
            {
                int end;
                if (tokens[i] == "(")
                {
                    end = IndexHelper.GetEndIndex(tokens, i, BracketType.RoundBracket);
                    var subTokens = tokens[(i + 1)..end];
                    record.Records.Add(ParseMixedRecords(subTokens));
                }
                else if (tokens[i] == "[")
                {
                    end = IndexHelper.GetEndIndex(tokens, i, BracketType.SquareBracket);
                    var subTokens = tokens[(i + 1)..end];
                    record.Records.Add(ParseMultipleRecords(subTokens));
                }
                else
                {
                    record.Records.Add(ParseSingleDataRecord(tokens[i..(i + 1)]));
                    end = i;
                }
                i = end;
            }
            return record;
        }

        private static SingleDataRecord ParseSingleDataRecord(string[] tokens)
        {
            return new SingleDataRecord { Data = tokens[^1] };
        }
    }
}
