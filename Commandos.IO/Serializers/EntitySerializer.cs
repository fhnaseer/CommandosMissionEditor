using System.Globalization;
using Commandos.Model.Common;

namespace Commandos.IO.Serializers
{
    internal static class EntitySerializer
    {
        internal static string ToStringValue(string[] tokens, string tokenName, int startIndex)
        {
            var indexes = IndexHelper.GetIndexes(tokens, tokenName, startIndex, TokenType.SingleValue);
            return tokens[indexes.startIndex + 1];
        }

        internal static double ToDoubleValue(string[] tokens, string tokenName, int startIndex)
        {
            var indexes = IndexHelper.GetIndexes(tokens, tokenName, startIndex, TokenType.SingleValue);
            return double.Parse(tokens[indexes.startIndex + 1], CultureInfo.CurrentCulture);
        }

        internal static int ToIntValue(string[] tokens, string tokenName, int startIndex)
        {
            var indexes = IndexHelper.GetIndexes(tokens, tokenName, startIndex, TokenType.SingleValue);
            return int.Parse(tokens[indexes.startIndex + 1], CultureInfo.CurrentCulture);
        }

        internal static string ToEscape(string[] tokens, int startIndex)
        {
            return ToStringValue(tokens, StringConstants.Escape, startIndex);
        }

        internal static Position ToPosition(string[] tokens, int startIndex)
        {
            var indexes = IndexHelper.GetPositionIndexes(tokens, startIndex);
            return new Position
            {
                X = double.Parse(tokens[indexes.startIndex + 2], CultureInfo.CurrentCulture),
                Y = double.Parse(tokens[indexes.startIndex + 3], CultureInfo.CurrentCulture),
                Z = double.Parse(tokens[indexes.startIndex + 4], CultureInfo.CurrentCulture),
            };
        }
    }
}
