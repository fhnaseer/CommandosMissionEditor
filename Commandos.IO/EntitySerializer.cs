using System.Globalization;
using System.IO;
using Commandos.Model;

namespace Commandos.IO
{
    public static class EntitySerializer
    {
        public static Camera ToCamera(string[] tokens)
        {
            if (tokens.Length != 2)
                throw new InvalidDataException("Invalid number of tokens,");

            return new Camera
            {
                Value = int.Parse(tokens[1], CultureInfo.CurrentCulture)
            };
        }

        public static Point3D ToPoint3D(string[] tokens)
        {
            if (tokens.Length != 6)
                throw new InvalidDataException("Invalid number of tokens,");

            return new Point3D
            {
                X = double.Parse(tokens[2], CultureInfo.CurrentCulture),
                Y = double.Parse(tokens[3], CultureInfo.CurrentCulture),
                Z = double.Parse(tokens[4], CultureInfo.CurrentCulture),
            };
        }
    }
}
