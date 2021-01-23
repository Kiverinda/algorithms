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
        static int numberOfValues = 10000;
        PointClass[] arrayPointClass = new PointClass[numberOfValues];
        PointStructFloat[] arrayPointStructFloat = new PointStructFloat[numberOfValues];
        PointStructDouble[] arrayPointStructDouble = new PointStructDouble[numberOfValues];

        [GlobalSetup]
        public void GlobalSetup()
        {
            float x;
            float y;
            Random random = new Random();

            for (int i = 0; i < numberOfValues; i++)
            {
                x = random.Next(500);
                y = random.Next(500);

                arrayPointClass[i] = new PointClass(x, y);
                arrayPointStructFloat[i] = new PointStructFloat(x, y);
                arrayPointStructDouble[i] = new PointStructDouble(x, y);
            }
        }

        [Benchmark]
        public void CalculationDistance_PointSetByClassWithTypeFloat()
        {
            for (int i = 0; i < arrayPointClass.Length; i++)
            {
                int indexFromEndArray = arrayPointClass.Length - (i + 1);
                arrayPointClass[i].Distance(arrayPointClass[indexFromEndArray]);
            }
        }

        [Benchmark]
        public void CalculationDistance_PointSetByStructWithTypeFloat()
        {
            for (int i = 0; i < arrayPointStructFloat.Length; i++)
            {
                int indexFromEndArray = arrayPointStructFloat.Length - (i + 1);
                arrayPointStructFloat[i].Distance(arrayPointStructFloat[indexFromEndArray]);
            }
        }
        [Benchmark]
        public void CalculationDistance_PointSetByStructWithTypeFloat_Fsrt()
        {
            for (int i = 0; i < arrayPointStructFloat.Length; i++)
            {
                int indexFromEndArray = arrayPointStructFloat.Length - (i + 1); 
                arrayPointStructFloat[i].Distance_Fsrt(arrayPointStructFloat[indexFromEndArray]);
            }
        }
        [Benchmark]
        public void CalculationDistance_PointSetByStructWithTypeFloat_NotSqrt()
        {
            for (int i = 0; i < arrayPointStructFloat.Length; i++)
            {
                int indexFromEndArray = arrayPointStructFloat.Length - (i + 1);
                arrayPointStructFloat[i].Distance_NotSqrt(arrayPointStructFloat[indexFromEndArray]);
            }
        }
        [Benchmark]
        public void CalculationDistance_PointSetByStructWithTypeDouble()
        {
            for (int i = 0; i < arrayPointStructDouble.Length; i++)
            {
                int indexFromEndArray = arrayPointStructDouble.Length - (i + 1); 
                arrayPointStructDouble[i].Distance(arrayPointStructDouble[indexFromEndArray]);
            }
        }

    }
}

