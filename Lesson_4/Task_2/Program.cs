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
            treeTest.Delete(98);
            TreePrinter.Print(treeTest.Head);
            treeTest.Find(96);
            treeTest.Find(90);
            Console.ReadLine();
        }
    }
}
