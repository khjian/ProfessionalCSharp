using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    struct Vector:IFormattable
    {
        public double x, y, z;


        public Vector(double x, double y, double z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(Vector rhs)
        {
            x = rhs.x;
            y = rhs.y;
            z = rhs.z;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                return ToString();
            }

            switch (format.ToUpper())
            {
                case "N":
                    return "||" + Norm().ToString() + "||";
                case "VE":
                    return $"({x:E},{y:E},{z:E})";
                default:
                    return ToString();
            }
        }

        private double Norm()
        {
            return x*x + y*y + z*z;
        }

        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        }
    }
}
