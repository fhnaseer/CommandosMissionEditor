using System.Collections.Generic;

namespace Commandos.Model
{
    public class Point3D : MultipleDataEntity<double>
    {
        public Point3D()
            : this(0, 0, 0)
        { }

        public Point3D(double x, double y)
            : this(x, y, 0)
        { }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string Name => ".XYZ";

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override List<double> Values => new List<double> { X, Y, Z };
    }
}
