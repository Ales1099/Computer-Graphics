using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    public class Function
    {
        public static double f1(double x, double z)
        {
            return (Math.Sin(x + z));
        }

        public static double f2(double x, double z)
        {
            return (x * Math.Cos(2 * z) - z * Math.Sin(2 * x)) / 4;
        }

        public static double f3(double x, double z)
        {
            return (Math.Exp(Math.Sin(Math.Sqrt(x * x + z * z))));
        }
    }
}
