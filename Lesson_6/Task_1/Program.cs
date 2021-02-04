using System;

namespace Task_1
{
    class Program
    {
        static void Main()
        {
            Graph<char> graph = new Graph<char>();
            graph.AddVertex('a');
            graph.AddVertex('v');
            graph.AddVertex('f');
            graph.AddVertex('2');
            graph.AddVertex('w');
            graph.AddVertex('h');
            graph.AddVertex('l');
            graph.AddVertex('u');
            graph.AddVertex('o');
            graph.AddVertex('k');
            graph.AddVertex('m');

            graph.AddEdges(0, 1, 2);
            graph.AddEdges(1, 2, 1);
            graph.AddEdges(1, 6, 1);
            graph.AddEdges(1, 7, 1);
            graph.AddEdges(2, 3, 1);
            graph.AddEdges(3, 5, 1);
            graph.AddEdges(3, 4, 1);
            graph.AddEdges(4, 5, 1);
            graph.AddEdges(5, 6, 1);
            graph.AddEdges(6, 7, 1);
            graph.AddEdges(7, 8, 1);
            graph.AddEdges(8, 2, 1);
            graph.PrintAdjacencyMatrix();

            graph.RemoveVertex(3);
            Console.WriteLine("После удаления вершины 3"); 
            graph.PrintAdjacencyMatrix();
            graph.RebuildArrayEdges();
            Console.WriteLine("После ребилдинга матрицы смежности");
            graph.PrintAdjacencyMatrix();
            Console.WriteLine("Поиск 'o', начиная с 4 вершины");
            graph.FindDFS(4, 'o');
            graph.FindBFS(4, 'o');
            Console.WriteLine("Поиск 'u'");
            graph.FindDFS('u');
            graph.FindBFS('u');
            Console.WriteLine("Поиск 'm' в вершине, не имеющей связей");
            graph.FindDFS('m');
            graph.FindBFS('m');
            Console.WriteLine("Поиск отсутствующего значения 'z'");
            graph.FindDFS('z');
            graph.FindBFS('z');
            Console.Read();
        }
    }
}
