//using System.Globalization;
//using Commandos.Model.Common;

//namespace Commandos.IO.Serializers.Mission
//{
//    internal static class EntitySerializer
//    {
//        internal static string GetStringValue(string[] tokens, string tokenName, int startIndex)
//        {
//            var indexes = IndexHelper.GetRecordIndexes(tokens, tokenName, startIndex, TokenType.SingleValue);
//            return tokens[indexes.startIndex + 1];
//        }

//        internal static double GetDoubleValue(string[] tokens, string tokenName, int startIndex)
//        {
//            var indexes = IndexHelper.GetRecordIndexes(tokens, tokenName, startIndex, TokenType.SingleValue);
//            return double.Parse(tokens[indexes.startIndex + 1], CultureInfo.CurrentCulture);
//        }

//        internal static int GetIntValue(string[] tokens, string tokenName, int startIndex)
//        {
//            var indexes = IndexHelper.GetRecordIndexes(tokens, tokenName, startIndex, TokenType.SingleValue);
//            return int.Parse(tokens[indexes.startIndex + 1], CultureInfo.CurrentCulture);
//        }

//        internal static Position GetPosition(string[] tokens, int startIndex)
//        {
//            var indexes = IndexHelper.GetPositionIndexes(tokens, startIndex);
//            return new Position
//            {
//                X = double.Parse(tokens[indexes.startIndex + 2], CultureInfo.CurrentCulture),
//                Y = double.Parse(tokens[indexes.startIndex + 3], CultureInfo.CurrentCulture),
//                Z = double.Parse(tokens[indexes.startIndex + 4], CultureInfo.CurrentCulture),
//            };
//        }
//    }
//}
