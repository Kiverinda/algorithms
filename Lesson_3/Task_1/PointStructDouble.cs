using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class PointStructDouble
    {
        public double Сoordinate_X { get; set; }
        public double Сoordinate_Y { get; set; }

        public PointStructDouble(double x, double y)
        {
            Сoordinate_X = x;
            Сoordinate_Y = y;
        }

        public double Distance(PointStructDouble point)
        {
            double x = Сoordinate_X - point.Сoordinate_X;
            double y = Сoordinate_Y - point.Сoordinate_Y;
            return Math.Sqrt((x * x) + (y * y));
        }
    }
}