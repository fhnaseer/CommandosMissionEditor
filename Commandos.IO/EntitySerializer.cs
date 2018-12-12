using System;
using System.Globalization;
using System.IO;
using Commandos.Model.Common;

namespace Commandos.IO
{
    public static class EntitySerializer
    {
        //public static Camera ToCamera(string[] tokens)
        //{
        //    if (tokens is null)
        //        throw new ArgumentNullException(nameof(tokens));

        //    if (tokens.Length != 2)
        //        throw new InvalidDataException("Invalid number of tokens,");

        //    //return new Camera
        //    //{
        //    //    Value = (CameraDirection)int.Parse(tokens[1], CultureInfo.CurrentCulture)
        //    //};
        //}

        public static Position ToPosition(string[] tokens)
        {
            if (tokens is null)
                throw new ArgumentNullException(nameof(tokens));

            if (tokens.Length != 6)
                throw new InvalidDataException("Invalid number of tokens,");

            return new Position
            {
                X = double.Parse(tokens[2], CultureInfo.CurrentCulture),
                Y = double.Parse(tokens[3], CultureInfo.CurrentCulture),
                Z = double.Parse(tokens[4], CultureInfo.CurrentCulture),
            };
        }
    }
}
