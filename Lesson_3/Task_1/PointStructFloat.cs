using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Task_1
{
    public class PointStructFloat
    {
        public float Сoordinate_X { get; set; }
        public float Сoordinate_Y { get; set; }

        public PointStructFloat(float x, float y)
        {
            Сoordinate_X = x;
            Сoordinate_Y = y;
        }

        public float Distance(PointStructFloat point)
        {
            float x = Сoordinate_X - point.Сoordinate_X;
            float y = Сoordinate_Y - point.Сoordinate_Y;
            float rezult = (x * x) + (y * y);
            return MathF.Sqrt(rezult);
        }

        public float Distance_Fsrt(PointStructFloat point)
        {
            float x = Сoordinate_X - point.Сoordinate_X;
            float y = Сoordinate_Y - point.Сoordinate_Y;
            return Fsrt((x * x) + (y * y));
        }

        public float Distance_NotSqrt(PointStructFloat point)
        {
            float x = Сoordinate_X - point.Сoordinate_X;
            float y = Сoordinate_Y - point.Сoordinate_Y;
            return (x * x) + (y * y);
        }

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct FloatIntUnion
        {
            [FieldOffset(0)]
            public int i;
            [FieldOffset(0)]
            public float f;
        }
        public static float Fsrt(float z)
        {
            if (z == 0) return 0;
            FloatIntUnion u;
            u.i = 0;
            u.f = z;
            u.i -= 1 << 23; /* Subtract 2^m. */
            u.i >>= 1; /* Divide by 2. */
            u.i += 1 << 29; /* Add ((b + 1) / 2) * 2^m. */
            return u.f;
        }
    }
}

