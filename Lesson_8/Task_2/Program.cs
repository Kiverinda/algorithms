using System;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text;
using System.Linq;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\SourceValue\value.txt";
            int numberElements = 35;
            int numberElementsInBucket = 10;
            CreatingFileWithSourceData(path, numberElements);
            BucketSortingValuesInFile files = new BucketSortingValuesInFile(path, numberElementsInBucket);
            Console.WriteLine(files.PathToSortedData);
            Console.Read();
        }

        static void CreatingFileWithSourceData(string path, int number)
        {
            Random randomize = new Random();
            string[] value = new string[number];
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = Convert.ToString(randomize.Next(500));
                Console.WriteLine(value[i]);
            }
            File.WriteAllLines(path, value);
        }
        
    }
}
