using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Task_1
{
    public class Benchmarks
    {
        static readonly int numberValues = 10000;
        static readonly int numberTests = 10;
        string[] arrayString = new string[numberValues];
        HashSet<string> hashsetString = new HashSet<string>(); 

        [GlobalSetup]
        public void GlobalSetup()
        {
            int count = 0;
            while (count < numberValues)
            {
                string newString = Generator.GeneratorString(20);
                if (hashsetString.Add(newString))
                {
                    arrayString[count] = newString;
                    count++;
                }
            }
        }

        [Benchmark]
        public void SearchInHashSet()
        {
            for (int i = 1; i < numberTests; i++)
            {
                hashsetString.Contains(i.ToString());
            }
        }
        
        [Benchmark]
        public void SearchInArray()
        {
            for (int i = 1; i < numberTests; i++)
            {
                Array.IndexOf(arrayString, i.ToString());
            }
        }

    }
}
