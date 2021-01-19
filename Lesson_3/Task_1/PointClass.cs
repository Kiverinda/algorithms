using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class PointClass
    {
        public float Сoordinate_X { get; set; }
        public float Сoordinate_Y { get; set; }

        
        
        public PointClass(float x, float y)
        {
            Сoordinate_X = x;
            Сoordinate_Y = y;
        }

        public float Distance(PointClass point)
        {
            float x = Сoordinate_X - point.Сoordinate_X;
            float y = Сoordinate_Y - point.Сoordinate_Y;
            float rezult = (x * x) + (y * y);
            return MathF.Sqrt(rezult);
        }
    }
}
