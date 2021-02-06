using System;

namespace Task_1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите кол-во строк в матрице");
            Int32.TryParse(Console.ReadLine(), out int row);
            Console.WriteLine("Введите кол-во столбцов в матрице");
            Int32.TryParse(Console.ReadLine(), out int column);

            int[,] matrix = new int[row, column];
            //Forbidden Cells
            matrix[2, 2] = -1;
            matrix[1, 5] = -1;
            matrix[3, 4] = -1;
            matrix[6, 8] = -1;


            Console.WriteLine(MethodWithMatrix(matrix));
            Console.Read();
        }

        public static int MethodWithMatrix(int[,] matrix)
        {
            Console.Clear();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == 0 || j == 0)
                    {
                        matrix[i, j] = 1;
                        Console.SetCursorPosition(6 * j, i);
                        Console.Write($"  {matrix[i, j]}  ");
                    }
                    else if(matrix[i,j] == -1)
                    {
                        matrix[i, j] = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(6 * j, i);
                        Console.Write($"  {matrix[i, j]}  ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
                        Console.SetCursorPosition(6 * j, i);
                        Console.Write($"  {matrix[i,j]}  ");
                    }
                }
                Console.WriteLine();
            }

            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        }
    }
}
