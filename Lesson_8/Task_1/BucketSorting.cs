using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    struct BucketSorting
    {
        public List<int> ListValue { get; set; }
        public int NumberBucket { get; set; }

        public BucketSorting(List<int> list, int number)
        {
            ListValue = list;
            NumberBucket = number;
        }

        public void BucketSort()
        {
            List<int>[] buckets = new List<int>[NumberBucket];

            int rangeOfValues = RangeOfValuesForBucket(ListValue, NumberBucket - 1);

            for (int i = 0; i < NumberBucket; i++)
            {
                buckets[i] = new List<int>();
            }

            for (int i = 0; i < ListValue.Count; i++)
            {
                int bucket = (ListValue[i] / rangeOfValues);
                buckets[bucket].Add(ListValue[i]);
            }

            ListValue.Clear();

            Console.WriteLine("Корзины:");          // Удалить
            for (int i = 0; i < NumberBucket; i++)
            {
                
                foreach(int val in buckets[i])      // Удалить
                {                                   // Удалить
                    Console.Write($" {val} ");      // Удалить
                }                                   // Удалить

                Console.WriteLine();
                List<int> temp = QuickSort(buckets[i], 0, buckets[i].Count - 1);
                ListValue.AddRange(temp);
            }
        }

        int RangeOfValuesForBucket(List<int> listToSorted, int numberBuckets)
        {
            int max = 0;
            int min = 0;

            for (int i = 0; i < listToSorted.Count; i++)
            {
                max = Math.Max(max, listToSorted[i]);
                min = Math.Min(min, listToSorted[i]);
            }

            return (max - min) / numberBuckets;
        }

        List<int> QuickSort(List<int> list, int first, int last)
        {
            int i = first, j = last, x = list[(first + last) / 2];
            do
            {
                while (list[i] < x)
                    i++;
                while (list[j] > x)
                    j--;
                if (i <= j)
                {
                    if (list[i] > list[j])
                    {
                        int tmp = list[i];
                        list[i] = list[j];
                        list[j] = tmp;
                    }
                    i++;
                    j--;
                }
            } while (i <= j);
            if (i < last)
                QuickSort(list, i, last);
            if (first < j)
                QuickSort(list, first, j);
            return list;
        }
    }
}
