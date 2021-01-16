using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = new int[] { 1, 7, 9, 12, 15, 23, 45, 47, 56, 68, 69, 70, 75, 82, 93, 99 };
            int searchValue = 12;
            int result = Search.Binary(inputArray, searchValue);
            if (result != -1)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("элемент не найден");
            }

            Console.ReadLine();
        }


    }

}
