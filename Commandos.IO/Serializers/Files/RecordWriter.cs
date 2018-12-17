﻿using System;
using System.Collections.Generic;
using System.Text;
using Commandos.IO.Entities;

namespace Commandos.IO.Serializers.Files
{
    public class RecordWriter
    {
        private readonly MultipleRecords _records;

        public RecordWriter(MultipleRecords records)
        {
            if (records is null)
                throw new ArgumentNullException(nameof(records));

            _records = records;
        }

        private List<string> _lines;

        public IList<string> GetTextLines()
        {
            _lines = new List<string>();
            _lines.Add("# Generated by Commandos Mission Editor,");
            var tabCount = 0;
            AddSquareOpenningBracket(tabCount);
            foreach (var record in _records.Records.Values)
                AppendRecord(record, tabCount + 1);
            AddSquareClosingBracket(tabCount);

            return _lines;
        }

        private void AppendRecord(Record record, int tabCount)
        {
            if (record.Data is SingleDataRecord singleDataRecord)
                AddLine($"{record.Name} {singleDataRecord.Data}", tabCount);
            else if (record.Data is MultipleRecords multipleRecords)
            {
                AddLine(record.Name, tabCount);
                AppendMultipleRecords(multipleRecords.Records.Values, tabCount);
            }
            else if (record.Data is MixedDataRecord mixedDataRecord)
            {
                AddLine(record.Name, tabCount);
                AppendMixedDataRecord(mixedDataRecord.Data, tabCount);
            }
        }

        private void AppendMultipleRecords(ICollection<Record> children, int tabCount)
        {
            var childTabCount = tabCount + 1;
            AddSquareOpenningBracket(tabCount);
            foreach (var child in children)
                AppendRecord(child, childTabCount);
            AddSquareClosingBracket(tabCount);
        }

        private void AppendMixedDataRecord(IList<RecordData> data, int tabCount)
        {
            var childTabCount = tabCount + 1;
            AddRoundOpenningBracket(tabCount);
            if (SameClass(data, typeof(SingleDataRecord)))
                AddSingleDataRecords(data, childTabCount);
            else
            {
                foreach (var d in data)
                {
                    if (d is SingleDataRecord singleDataRecord)
                        AddLine(singleDataRecord.Data, childTabCount);
                    else if (d is MixedDataRecord mixedDataRecord)
                        AppendMixedDataRecord(mixedDataRecord.Data, childTabCount);
                    else if (d is MultipleRecords multipleRecords)
                        AppendMultipleRecords(multipleRecords.Records.Values, childTabCount);
                }
            }
            AddRoundClosingBracket(tabCount);
        }

        private static bool SameClass(IList<RecordData> items, Type objectType)
        {
            foreach (var item in items)
                if (item.GetType() != objectType)
                    return false;
            return true;
        }

        private void AddSingleDataRecords(IList<RecordData> data, int tabCount)
        {
            var stringBuilder = new StringBuilder();
            foreach (SingleDataRecord d in data)
                stringBuilder.Append($"{d} ");
            var finalString = stringBuilder.ToString().Trim();
            AddLine(finalString, tabCount);
        }

        private void AddSquareOpenningBracket(int tabCount)
        {
            AddLine("[", tabCount);
        }

        private void AddSquareClosingBracket(int tabCount)
        {
            AddLine("]", tabCount);
        }

        private void AddRoundOpenningBracket(int tabCount)
        {
            AddLine("(", tabCount);
        }

        private void AddRoundClosingBracket(int tabCount)
        {
            AddLine(")", tabCount);
        }

        private void AddLine(string text, int tabCount)
        {
            _lines.Add(text.PadLeft(text.Length + tabCount * 4));
        }
    }
}
