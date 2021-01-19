using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task_1
{
    public class Benchmarks
    {
        public PointClass point_1;
        public PointClass point_2;
        public PointStructFloat point_3;
        public PointStructFloat point_4;
        public PointStructDouble point_5;
        public PointStructDouble point_6;

        [Params(234, 18)]
        public int X1;
        [Params(134, 98)]
        public int X2;
        [Params(34, 572)]
        public int Y1;
        [Params(24, 34)]
        public int Y2;

        [GlobalSetup]
        public void Setup()
        {
            point_1 = new PointClass(X1, Y1);
            point_2 = new PointClass(X2, Y2);
            point_3 = new PointStructFloat(X1, Y1);
            point_4 = new PointStructFloat(X2, Y2);
            point_5 = new PointStructDouble(X1, Y1);
            point_6 = new PointStructDouble(X2, Y2);
        }

        [Benchmark]
        public void CalculationDistance_PointSetByClassWithTypeFloat()
        {
            point_1.Distance(point_2);
        }

        [Benchmark]
        public void CalculationDistance_PointSetByStructWithTypeFloat()
        {
            point_3.Distance(point_4);
        }
        [Benchmark]
        public void CalculationDistance_PointSetByStructWithTypeFloat_Fsrt()
        {
            point_3.Distance_Fsrt(point_4);
        }
        [Benchmark]
        public void CalculationDistance_PointSetByStructWithTypeFloat_NotSqrt()
        {
            point_3.Distance_NotSqrt(point_4);
        }
        [Benchmark]
        public void CalculationDistance_PointSetByStructWithTypeDouble()
        {
            point_5.Distance(point_6);
        }

    }
}

