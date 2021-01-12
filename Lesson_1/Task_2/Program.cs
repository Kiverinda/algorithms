using System;


namespace Task_2
{
    class Program
    {
        static void Main()
        {
            // Сложность равна O(N^3)

            // Решение:
            // O(2 + N * N * 2N + N * N * (N - 1))
            // O(3N^3 - N^2 + 2)
            // После использования правил 3 и 5 сложность равна O(N^3)
        }
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) 
            {
                for (int j = 0; j < inputArray.Length; j++) 
                {
                    for (int k = 0; k < inputArray.Length; k++) 
                    {
                        int y = 0; // O(N * N * N)
                        if (j != 0) 
                        {
                            y = k / j; // O(N * N * (N - 1))
                        }
                        sum += inputArray[i] + i + k + j + y; // O(N * N * N)
                    }
                }
            }
            return sum; // O(1)
        }
    }
}
