using System;
using System.IO;
using Commandos.IO.Entities;

namespace Commandos.IO
{
    public static class TokenParser
    {
        public static MultipleRecord ParseTokens(string[] tokens)
        {
            if (tokens is null)
                throw new ArgumentNullException(nameof(tokens));
            if (tokens[0] != "[" && tokens[tokens.Length - 1] != "]")
                throw new InvalidDataException("Invalid data,");
            return ParseMultipleRecords(tokens, 0, tokens.Length - 1);
        }

        private static MultipleRecord ParseMultipleRecords(string[] tokens, int startIndex, int endIndex)
        {
            var record = new MultipleRecord();
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
            if (indexes.tokenValueType == TokenValueType.SingleValue)
                record.Value = ParseSingleValue(tokens, indexes.startIndex);
            else if (indexes.tokenValueType == TokenValueType.MultipleRecords)
                record.Value = ParseMultipleRecords(tokens, indexes.startIndex, indexes.endIndex);
            else if (indexes.tokenValueType == TokenValueType.MixedValues)
                record.Value = ParseMixedRecords(tokens, indexes.startIndex, indexes.endIndex);

            //record.Value = ParseMultipleValues(tokens, indexes.startIndex, indexes.endIndex);
            //else if (indexes.tokenValueType == TokenValueType.MultipleList)
            //    record.Value = ParseMultipleList(tokens, indexes.startIndex, indexes.endIndex);
            //else if (indexes.tokenValueType == TokenValueType.MultipleListRecords)
            //    record.Value = ParseMultipleListRecords(tokens, indexes.startIndex, indexes.endIndex);
            //else
            //    record.Value = ParseMultipleRecords(tokens, indexes.startIndex, indexes.endIndex);
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

        private static SingleRecord ParseSingleValue(string[] tokens, int startIndex)
        {
            return new SingleRecord { Value = tokens[startIndex] };
        }

        private static MultipleValues ParseMultipleValues(string[] tokens, int startIndex, int endIndex)
        {
            var result = new MultipleValues();
            for (var i = startIndex + 1; i < endIndex; i++)
                result.Values.Add(tokens[i]);
            return result;
        }

        //private static MultipleList ParseMultipleList(string[] tokens, int startIndex, int endIndex)
        //{
        //    var result = new MultipleList();
        //    for (var i = startIndex + 1; i < endIndex; i++)
        //    {
        //        var end = IndexHelper.GetEndIndex(tokens, i, "(", ")");
        //        result.Values.Add(ParseMultipleValues(tokens, i, end));
        //        i = end;
        //    }
        //    return result;
        //}

        //private static MultipleRecord ParseMultipleListRecords(string[] tokens, int startIndex, int endIndex)
        //{
        //    var result = new MultipleRecord();
        //    for (var i = startIndex + 1; i < endIndex; i++)
        //    {
        //        var end = IndexHelper.GetEndIndex(tokens, i, "[", "]");
        //        result.Records.Add(ParseMultipleRecords(tokens, i, end));
        //        i = end;
        //    }
        //    return result;
        //}
    }
}
