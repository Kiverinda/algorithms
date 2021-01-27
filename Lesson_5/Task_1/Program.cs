using System;

namespace Task_2
{
    class Program
    {
        static void Main()
        {
            Tree treeTest = new Tree();
            treeTest.Add(100);
            treeTest.Add(99);
            treeTest.Add(98);
            treeTest.Add(97);
            treeTest.Add(96);
            treeTest.Add(95);
            treeTest.Add(94);
            treeTest.Add(93);
            treeTest.Add(200);
            treeTest.Add(50);
            treeTest.Add(30);
            treeTest.Add(24);
            treeTest.Add(123);
            treeTest.Add(150);
            treeTest.Add(3);
            TreePrinter.Print(treeTest.Head);
            Console.WriteLine("FindBFS");
            treeTest.FindBFS(200);
            treeTest.FindBFS(1);
            Console.WriteLine("FindDFS");
            treeTest.FindDFS(200);
            treeTest.FindDFS(1);
            Console.ReadLine();
        }
    }
}
