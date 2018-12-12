using System.Collections.Generic;

namespace Commandos.Model.Common
{
    public class Position : MultipleDataEntity<double>
    {
        public Position()
            : this(0, 0, 0)
        { }

        public Position(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string Name => ".XYZ";

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override IList<double> Values => new List<double> { X, Y, Z };
    }
}
