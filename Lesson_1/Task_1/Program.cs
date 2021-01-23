using System;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        static void Main()
        {
            bool resultOrdinary, expectedOrdinary, matchOrdinary;

            Dictionary<int, bool> numberExpectedResult = new Dictionary<int, bool>
            {
                {1, true},
                {2, true},
                {4, false},
                {8, false}
            };
            
            Dictionary<bool, string> resultOrdinaryMessage = new Dictionary<bool, string>
            {
                {true, "простое"},
                {false, "не простое"},
            };

            Dictionary<bool, string> matchResultMessage = new Dictionary<bool, string>
            {
                {true, "Верно"},
                {false, "Неверно"},
            };

            foreach (int key in numberExpectedResult.Keys)
            {
                resultOrdinary = IsNumberOrdinary(key);
                expectedOrdinary = numberExpectedResult[key];
                matchOrdinary = resultOrdinary == expectedOrdinary;

                Console.WriteLine($"{key} {resultOrdinaryMessage[resultOrdinary]} -  {matchResultMessage[matchOrdinary]}");
            }
            Console.ReadLine();

        }

        public static bool IsNumberOrdinary(int number)
        {
            int countDivisors = 0;
            int devisor = 2;

            while(devisor < number)
            {
                if (number % devisor == 0) countDivisors++;
                devisor++;
            }
               
            return (countDivisors == 0);
        }

    }
}
