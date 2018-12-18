using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Files;
using Commandos.IO.Serializers.Map;
using Commandos.Model.Map;

namespace Commandos.IO.Files
{
    public static class MisFileSerializer
    {
        public static Mission ReadMisFile(string path)
        {
            return MissionSerializer.GetMission(GetMultipleRecords(path));
        }

        internal static MultipleRecords GetMultipleRecords(string path)
        {
            var tokens = GetTokens(path);
            return TokenParser.ParseTokens(tokens);
        }

        internal static string[] GetTokens(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            lines = GetCleanedLines(lines);
            var fullText = string.Join(" ", lines);
            return fullText.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static List<string> GetCleanedLines(List<string> lines)
        {
            var cleanedLines = new List<string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                var text = line.Trim();
                var index = text.IndexOf("#", StringComparison.CurrentCultureIgnoreCase);
                if (index == 0)
                    continue;
                else if (index > 0)
                    text = line.Substring(0, index).Trim();
                AddCleanedLines(text, cleanedLines);
                //cleanedLines.Add(line);
            }
            return cleanedLines;
        }

        private static void AddCleanedLines(string line, List<string> lines)
        {
            if (line.StartsWith("[", StringComparison.CurrentCultureIgnoreCase) || line.StartsWith("]", StringComparison.CurrentCultureIgnoreCase) ||
                line.StartsWith("(", StringComparison.CurrentCultureIgnoreCase) || line.StartsWith(")", StringComparison.CurrentCultureIgnoreCase))
            {
                if (line.Length > 1)
                {
                    lines.Add(line.Substring(0, 1));
                    AddCleanedLines(line.Substring(1, line.Length - 1), lines);
                    return;
                }
            }
            lines.Add(line);
        }

        public static void WriteMisFile(string path, Mission mission)
        {
            if (mission is null)
                throw new ArgumentNullException(nameof(mission));

            var multipleRecords = MissionSerializer.GetMultipleRecords(mission);
            var writer = new RecordWriter(multipleRecords);
            var lines = writer.GetTextLines();
            File.WriteAllLines(path, lines);
        }
    }
}
