using System;
using BenchmarkDotNet.Running;

namespace Task_1
{
    class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<Benchmarks>();
            Console.ReadLine();
        }

    }
}
