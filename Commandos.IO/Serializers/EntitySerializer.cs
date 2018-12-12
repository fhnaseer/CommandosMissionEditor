using System.Globalization;
using Commandos.Model.Common;

namespace Commandos.IO.Serializers
{
    internal static class EntitySerializer
    {
        internal static Escape ToEscape(string[] tokens, int startIndex)
        {
            return new Escape { Value = tokens[startIndex + 1] };
        }


        internal static Position ToPosition(string[] tokens, int startIndex)
        {
            return new Position
            {
                X = double.Parse(tokens[startIndex + 2], CultureInfo.CurrentCulture),
                Y = double.Parse(tokens[startIndex + 3], CultureInfo.CurrentCulture),
                Z = double.Parse(tokens[startIndex + 4], CultureInfo.CurrentCulture),
            };
        }
    }
}
