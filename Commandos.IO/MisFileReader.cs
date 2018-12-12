using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Commandos.IO
{
    public static class MisFileReader
    {
        public static void ReadMisFile(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            lines = GetCleanedLines(lines);
            var fullText = string.Join(" ", lines);
            var tokens = fullText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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

        public static string[] GetTokens(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            lines = GetCleanedLines(lines);
            var fullText = string.Join(" ", lines);
            return fullText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static (int startIndex, int endIndex) GetCameraIndex(string[] tokens)
        {
            var startIndex = 0;
            for (var i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == StringConstants.Viewer)
                {
                    startIndex = i;
                    break;
                }
            }
            if (tokens[startIndex + 1] != "[")
                return (startIndex, startIndex + 1);
            var counter = 0;
            for (var i = startIndex + 1; i < tokens.Length; i++)
            {
                if (tokens[i] == "[")
                    counter++;
                if (tokens[i] == "]")
                {
                    counter--;
                    if (counter == 0)
                        return (startIndex, i);
                }
            }
            throw new InvalidDataException("Wrong file,");
        }
    }
}
