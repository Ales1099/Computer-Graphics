using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    public class Point2D
    {
        public double x;
        public double y;

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point2D()
        {

        }

        public static implicit operator Point(Point2D point)
        {
            return new Point((int)Math.Round(point.x), (int)Math.Round(point.y));
        }


    }
}
