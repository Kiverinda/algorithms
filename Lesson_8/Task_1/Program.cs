using System;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        static void Main()
        {
            List<int> listRandomNumbers = InitializingListOfNumbersElements(30);
            int numberBucket = 5;

            Console.WriteLine("Исходный лист значений");
            foreach(int i in listRandomNumbers)
            {
                Console.Write($" {i} ");
            }
            Console.WriteLine();

            BucketSorting myStruct = new BucketSorting(listRandomNumbers, numberBucket);
            myStruct.BucketSort();
            Console.WriteLine("После сортировки корзин и слияния:");
            foreach (int i in myStruct.ListValue)
            { 
                Console.Write($" {i} ");
            }
            Console.Read();
        }

        static List<int> InitializingListOfNumbersElements(int number)
        {
            List<int> list = new List<int>();
            Random randomize = new Random();
            for(int i = 0; i < number; i++)
            {
                list.Add(randomize.Next(300));
            }
            
            return list;
        }
    }
}
