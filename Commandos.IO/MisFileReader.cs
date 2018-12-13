using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Commandos.IO.Serializers;
using Commandos.Model.Map;

namespace Commandos.IO
{
    public static class MisFileReader
    {
        public static Mission ReadMisFile(string path)
        {
            var tokens = GetTokens(path);
            return MissionSerializer.ToMission(tokens);
        }

        internal static string[] GetTokens(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            lines = GetCleanedLines(lines);
            var fullText = string.Join(" ", lines);
            return fullText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static List<string> GetCleanedLines(List<string> lines)
        {
            var cleanedLines = new List<string>();
            foreach (var line in lines)
            {
                var index = line.IndexOf("#", StringComparison.CurrentCultureIgnoreCase);
                if (index == 0)
                    continue;
                else if (index > 0)
                    cleanedLines.Add(line.Substring(0, index));
                else
                    cleanedLines.Add(line);
            }
            return cleanedLines;
        }
    }
}
