using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class Search
    {
        public static int Binary(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
        /*
       Допустим что поиск закончится через k итераций

       При длине массива n после первой итерации длина станет n/2 
       после второй (n/2)/2 или  n/2^2 
       после третьей  ((n/2)/2)/2  или   n/2^3
       тогда после k-итерации длина будет равна n/2^k

       Также известно, что при k-итерации длина равна 1

       Следовательно n/2^k = 1  =>  n = 2^k

       Применяя логарифмирование с двух сторон получаем
       log2(n) = log2(2^k)  => log2(n) = k log2(2)  => log2(n) = k

       Для нахождения решения алгоритму необходимо совершить log2(n) итераций
       Ответ: Асимптотическая сложность алгоритма O(log2(n))
   */
    }
}
