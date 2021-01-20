using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
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
