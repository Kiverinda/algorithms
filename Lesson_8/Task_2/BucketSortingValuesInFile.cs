using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public class BucketSortingValuesInFile
    {
        public int NumberValuesInBucket { get; set; }
        public string PathToIncomingData { get; set; }
        public string PathToSortedData { get; set; }

        public BucketSortingValuesInFile(string path, int numberValuesInBucket)
        {
            PathToIncomingData = path;
            NumberValuesInBucket = numberValuesInBucket;
            PathToSortedData = CreatingSortedBuckets();
        }

        string CreatingSortedBuckets()
        {
            List<string> pathsToBacket = new List<string>();
            string secondLine = File.ReadLines(this.PathToIncomingData).First();

            int countArray = 0;

            while (secondLine != null)
            {
                int count = 0;
                List<string> listValues = new List<string>();
                while (secondLine != null && count < this.NumberValuesInBucket)
                {
                    listValues.Add(secondLine);
                    count++;
                    try
                    {
                        secondLine = File.ReadLines(this.PathToIncomingData).Skip(countArray * 10 + count).First();
                    }
                    catch
                    {
                        secondLine = null;
                    }
                }

                List<int> temp = QuickSortBucket(ConvertStringListToIntList(listValues), 0, listValues.Count - 1);
                File.WriteAllLines($"C:\\SourceValue\\backet_{countArray}.txt", ConvertIntListToStringList(temp));
                pathsToBacket.Add($"C:\\SourceValue\\backet_{countArray}.txt");
                countArray++;

            }

            //return pathsToBacket;
            return MergingBuckets(pathsToBacket);
        }

        List<int> QuickSortBucket(List<int> list, int first, int last)
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
                QuickSortBucket(list, i, last);
            if (first < j)
                QuickSortBucket(list, first, j);
            return list;
        }

        List<int> ConvertStringListToIntList(List<string> stringList)
        {
            List<int> intList = new List<int>(stringList.Count);
            for (int i = 0; i < stringList.Count; i++)
            {
                intList.Add(Convert.ToInt32(stringList[i]));
            }

            return intList;
        }

        List<string> ConvertIntListToStringList(List<int> intList)
        {
            List<string> stringList = new List<string>(intList.Count);
            for (int i = 0; i < intList.Count; i++)
            {
                stringList.Add(Convert.ToString(intList[i]));
            }

            return stringList;
        }

        string MergingBuckets(List<string> list)
        {
            string targetPath = $"C:\\SourceValue\\result.txt";
            List<FirstValueInFile> listValue = new List<FirstValueInFile>();
            for(int i = 0; i < list.Count; i++)
            {
                string pathToFile = $"C:\\SourceValue\\backet_{i}.txt";
                listValue.Add(new FirstValueInFile(pathToFile));
            }
                
            while(list.Count != 0)
            {
                for (int i = 0; i < listValue.Count; i++)
                {
                    try
                    {
                        string str = File.ReadLines(listValue[i].Path).Skip(listValue[i].NumberString).First();
                        listValue[i].Value = int.Parse(str);
                    }
                    catch
                    {
                        if(listValue.Count > 1)
                        {
                            listValue.Remove(listValue[i]);
                        }
                        else
                        {
                            return targetPath;
                        }
                    }
                }

                if (listValue.Count > 1)
                {
                    FirstValueInFile min = listValue[0];
                    for (int i = 1; i < listValue.Count; i++)
                    {
                        if (min.Value > listValue[i].Value)
                        {
                            min = listValue[i];
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(targetPath, true, Encoding.UTF8))
                    {
                        writer.WriteLine(min.Value);
                    }

                    min.NumberString++;
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(targetPath, true, Encoding.UTF8))
                    {
                        writer.WriteLine(listValue[0].Value);
                    }

                    listValue[0].NumberString++;
                }
            }
                
            return targetPath;
        }

    }
}
