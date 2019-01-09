using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Commandos.IO.Entities;
using Commandos.IO.Helpers;
using Commandos.IO.Serializers.Files;
using Commandos.IO.Serializers.Map;
using Commandos.Model.Map;
[assembly: InternalsVisibleTo("Commandos.IO.Tests")]

namespace Commandos.IO.Files
{
    public static class MisFileSerializer
    {
        public static Mission ReadMisFile(string path)
        {
            var tokens = GetTokens(path);
            return MissionSerializer.GetMission(TokenParser.ParseTokens(tokens));
        }

        public static Mission ReadMisFile(IList<string> lines)
        {
            var tokens = GetTokens(lines);
            return MissionSerializer.GetMission(TokenParser.ParseTokens(tokens));
        }

        internal static MultipleRecords GetMultipleRecords(string path)
        {
            var tokens = GetTokens(path);
            return TokenParser.ParseTokens(tokens);
        }

        internal static string[] GetTokens(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            return GetTokens(lines);
        }

        private static string[] GetTokens(IList<string> lines)
        {
            lines = GetCleanedLines(lines);
            var fullText = string.Join(" ", lines);
            fullText = fullText.Replace("[", " [ ");
            fullText = fullText.Replace("]", " ] ");
            fullText = fullText.Replace("(", " ( ");
            fullText = fullText.Replace(")", " ) ");
            var commentPattern = @"/\*(?:(?!\*/).)*\*/";
            var matches = Regex.Matches(fullText, commentPattern);
            foreach (Match match in matches)
                fullText = fullText.Replace(match.Value, " ");
            return fullText.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static List<string> GetCleanedLines(IList<string> lines)
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
                //cleanedLines.Add(line);

                AddCleanedLines(text, cleanedLines);
            }
            return cleanedLines;
        }

        private static void AddCleanedLines(string line, List<string> lines)
        {
            line = line.Trim();
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
            var lines = GetMisFileText(mission);
            File.WriteAllLines(path, lines);
        }

        public static IList<string> GetMisFileText(Mission mission)
        {
            if (mission is null)
                throw new ArgumentNullException(nameof(mission));

            var multipleRecords = MissionSerializer.GetMultipleRecords(mission);
            var writer = new RecordWriter(multipleRecords);
            return writer.GetTextLines();
        }
    }
}
