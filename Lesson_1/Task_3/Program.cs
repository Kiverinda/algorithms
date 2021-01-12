using System;

namespace Task_3
{
    class Program
    {

        static void Main()
        {
            int numberInSeries = GetNumberUser();
            int[] arrayNymberFibonacci = new int[numberInSeries + 1];

            //Вывод только заданного элемента последовательности Фибонначи 
            Console.WriteLine(FibonacciRecursive(numberInSeries, ref arrayNymberFibonacci));
            Console.WriteLine(Fibonacci(numberInSeries, ref arrayNymberFibonacci));
            // Вывод всей последовательности Фибонначи от 0 до заданного элемента
            foreach (int num in arrayNymberFibonacci)
            {
                Console.Write($"{num}  ");
            }

            Console.ReadLine();
        }

        static int GetNumberUser()
        {
            int data;
            do
            {
                Console.WriteLine("Введите целое число");
            }
            while (!int.TryParse(Console.ReadLine(), out data));
            return data;
        }

        static int FibonacciRecursive(int numberInSeries, ref int[] arrayNymberFibonacci)
        {
            if (numberInSeries < 2)
            {
                arrayNymberFibonacci[1] = 1;
                arrayNymberFibonacci[0] = 0;
                return arrayNymberFibonacci[numberInSeries];
            }
            else arrayNymberFibonacci[numberInSeries] = FibonacciRecursive(numberInSeries - 1, ref arrayNymberFibonacci) + FibonacciRecursive(numberInSeries - 2, ref arrayNymberFibonacci);

            return arrayNymberFibonacci[numberInSeries];
        }

        static int Fibonacci(int numberInSeries, ref int[] arrayNymberFibonacci)
        {
            arrayNymberFibonacci[1] = 1;
            arrayNymberFibonacci[0] = 0;
            for(int count = 2; count <= numberInSeries; count++)
            {
                arrayNymberFibonacci[count] = arrayNymberFibonacci[count -1] + arrayNymberFibonacci[count - 2];
            }
            return arrayNymberFibonacci[numberInSeries];
        }

    }
}
