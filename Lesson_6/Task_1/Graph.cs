using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task_1
{
    class Graph<T>
    {
        private T[] vertex;
        private int[,] edges;
        private int countVertex = 0;

        public Graph()
        {
            vertex = new T[1];
            edges = new int[1, 1];
        }

        public void AddVertex(T value)
        {
            if (vertex.Length <= countVertex)
            {
                Resize();
            }
            vertex[countVertex] = value;
            countVertex++;
        }

        public void RemoveVertex(int numberVertex)
        {
            vertex[numberVertex] = default;

            for(int i = 0; i < countVertex; i++)
            {
                edges[numberVertex, i] = default;
                edges[i, numberVertex] = default; // Для направленного графа эту строку удалить 
            }
            // Для перестраивания матрицы после каждого удаления вершины нужно раскоментировать метод RebuildArrayEdges(numberVertex)
            // RebuildArrayEdges(numberVertex); 
        }

        public void RebuildArrayEdges()
        {
            for(int i = 0; i < countVertex; i++)
            {
                Console.WriteLine(vertex[i]);
                T target = default;
                if (vertex[i].Equals(target))
                {
                    RebuildArrayEdges(i);
                }
            }
        }

        private void RebuildArrayEdges(int numberVertex)
        {
            for (int i = numberVertex; i < countVertex - 1; i++)
            {
                vertex[i] = vertex[i + 1];
            }
            countVertex--;

            for (int i = numberVertex; i < countVertex; i++) // Сдвиг матрицы влево
            {
                for (int j = 0; j < countVertex; j++)
                {
                    edges[j, i] = edges[j, i + 1];
                    edges[j, i + 1] = default;
                }
            }
            for (int i = numberVertex; i < countVertex; i++) // Сдвиг матрицы вверх
            {
                for (int j = 0; j < countVertex; j++)
                {
                    edges[i, j] = edges[i + 1, j];
                    edges[i + 1, j] = default;
                }
            }
        }

        public void AddEdges(int vertex_1, int vertex_2, int weight)
        {
            if (vertex_1 < countVertex && vertex_2 < countVertex)
            {
                edges[vertex_1, vertex_2] = weight;
                edges[vertex_2, vertex_1] = weight;
            }
            else
            {
                Console.WriteLine($"incorrect data entry: AddEdges({vertex_1}, {vertex_2}, {weight})");
            }

        }

        private void Resize()
        {
            int newSize = vertex.Length * 2;
            Array.Resize(ref vertex, newSize);
            int[,] newArray = new int[newSize, newSize];
            Array.Copy(edges, newArray, edges.Length);
            edges = newArray;
        }

        public void PrintAdjacencyMatrix()
        {
            Console.WriteLine("Матрица смежности");
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.Write("         ");
            for (int k = 0; k < countVertex; k++)
            {
                Console.Write($"  {k}:{vertex[k]}   ");
            }
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            for (int i = 0; i < countVertex; i++)
            {
                Console.Write($"  {i}:{vertex[i]}   ");
                for (int j = 0; j < countVertex; j++)
                {
                    Console.Write($"   {edges[i, j]}    ");
                }
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------");
            }


        }

        public void FindDFS(T target)
        {
            FindDFS(0, target);
        }

        public void FindDFS(int numberVertex, T target)
        {
            List<int> visitedVertex = new List<int>();
            Stack<int> stackVertex = new Stack<int>();
            int currentVertex;
            stackVertex.Push(numberVertex);
            while (stackVertex.Count != 0)
            {
                currentVertex = stackVertex.Pop();
                if (!SearchToVisitedVertex(currentVertex, visitedVertex))
                {
                    if (vertex[currentVertex].Equals(target))
                    {
                        Console.WriteLine($"Найдена вершина {currentVertex} со значением {target}");
                        PrintPath(visitedVertex);
                        Console.Write($" {currentVertex} \n");
                        return;
                    }
                    else
                    {
                        visitedVertex.Add(currentVertex);
                        for (int i = 0; i < countVertex; i++)
                        {
                            if (edges[currentVertex, i] != 0)
                            {
                                stackVertex.Push(i);
                            }
                        }
                    }
                }
                if (stackVertex.Count == 0)
                {
                    for (int i = 0; i < countVertex; i++)
                    {
                        if (!SearchToVisitedVertex(i, visitedVertex))
                        {
                            stackVertex.Push(i);
                            break;
                        }

                    }
                }

            }
            Console.WriteLine($"\nЗначение {target} не найдено");
            PrintPath(visitedVertex);
        }

        public void FindBFS(T target)
        {
            FindBFS(0, target);
        }

        public void FindBFS(int numberVertex, T target)
        {
            List<int> visitedVertex = new List<int>();
            Queue<int> queueVertex = new Queue<int>();
            int currentVertex;
            queueVertex.Enqueue(numberVertex);
            while (queueVertex.Count != 0)
            {
                currentVertex = queueVertex.Dequeue();
                if (!SearchToVisitedVertex(currentVertex, visitedVertex))
                {
                    if (vertex[currentVertex].Equals(target))
                    {
                        Console.WriteLine($"Найдена вершина {currentVertex} со значением {target}");
                        PrintPath(visitedVertex);
                        Console.Write($" {currentVertex} \n");
                        return;
                    }
                    else
                    {
                        visitedVertex.Add(currentVertex);
                        for (int i = 0; i < countVertex; i++)
                        {
                            if (edges[currentVertex, i] != 0)
                            {
                                queueVertex.Enqueue(i);
                            }
                        }
                    }
                }
                if (queueVertex.Count == 0)
                {
                    for (int i = 0; i < countVertex; i++)
                    {
                        if (!SearchToVisitedVertex(i, visitedVertex))
                        {
                            queueVertex.Enqueue(i);
                            break;
                        }

                    }
                }
            }
            Console.WriteLine($"\nЗначение {target} не найдено");
            PrintPath(visitedVertex);
        }

        private bool SearchToVisitedVertex(int targetItem, List<int> visitedVertex)
        {
            foreach (int item in visitedVertex)
            {
                if (targetItem == item) return true;
            }
            return false;
        }

        private void PrintPath(List<int> path)
        {
            Console.WriteLine("Путь:");
            foreach (int item in path)
            {
                Console.Write($" {item} -> ");
            }
        }
    }
}
