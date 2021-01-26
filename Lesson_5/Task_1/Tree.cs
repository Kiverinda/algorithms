using System;
using System.Collections.Generic;

namespace Task_2
{
    public class Tree
    {
        public Node Head { get; set; }

        public Tree()
        {
        }

        public void Add(int data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Head = Insert(Head, newNode);
            }
        }
        private Node Insert(Node current, Node node)
        {
            if (current == null)
            {
                current = node;
                return current;
            }
            else if (node.Data < current.Data)
            {
                current.Left = Insert(current.Left, node);
                current = BalanceTree(current);
            }
            else if (node.Data > current.Data)
            {
                current.Right = Insert(current.Right, node);
                current = BalanceTree(current);
            }
            return current;
        }
        private Node BalanceTree(Node current)
        {
            int b_factor = BalanceFactor(current);
            if (b_factor > 1)
            {
                if (BalanceFactor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        public void Delete(int target)
        {
            Head = Delete(Head, target);
        }
        private Node Delete(Node current, int target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
            {
                if (target < current.Data)
                {
                    current.Left = Delete(current.Left, target);
                    if (BalanceFactor(current) == -2)
                    {
                        if (BalanceFactor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }

                else if (target > current.Data)
                {
                    current.Right = Delete(current.Right, target);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }

                else
                {
                    if (current.Right != null)
                    {
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Data = parent.Data;
                        current.Right = Delete(current.Right, parent.Data);
                        if (BalanceFactor(current) == 2)
                        {
                            if (BalanceFactor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {
                        return current.Left;
                    }
                }
            }
            return current;
        }
        public void Find(int key)
        {
            if (Find(key, Head)?.Data == key)
            {
                Console.WriteLine("{0} найден", key);
            }
            else
            {
                Console.WriteLine("{0} Не найден", key);
            }
        }
        private Node Find(int target, Node current)
        {
            if (current == null) return null;
            if (target < current.Data)
            {
                if (target == current.Data)
                {
                    return current;
                }
                else
                    return Find(target, current.Left);
            }
            else
            {
                if (target == current.Data)
                {
                    return current;
                }
                else
                    return Find(target, current.Right);
            }

        }

        public void FindBFS(int target)
        {
            Queue<Node> queueNodes = new Queue<Node>();
            queueNodes.Enqueue(Head);
            List<int> path = new List<int>();
            while (queueNodes.Count != 0)
            {
                Node current = queueNodes.Dequeue();
                path.Add(current.Data);
                if (current.Data == target)
                {
                    Console.WriteLine($"Значение {target} найдено");
                    Console.WriteLine("Путь:");
                    foreach (int data in path)
                    {
                        Console.Write($" -> {data} ");
                    }
                    Console.WriteLine();
                    return;
                }
                else
                {
                    if (current.Left != null)
                    {
                        queueNodes.Enqueue(current.Left);
                    }
                    if (current.Right != null)
                    {
                        queueNodes.Enqueue(current.Right);
                    }
                }
            }
            Console.WriteLine($"Значение {target} не найдено");
            Console.WriteLine("Путь:");
            foreach (int data in path)
            {
                Console.Write($" -> {data}");
            }
            Console.WriteLine();
        }

        public void FindDFS(int target)
        {
            Stack<Node> stackNodes = new Stack<Node>();
            stackNodes.Push(Head);
            List<int> path = new List<int>();
            while (stackNodes.Count != 0)
            {
                Node current = stackNodes.Pop();
                path.Add(current.Data);
                if (current.Data == target)
                {
                    Console.WriteLine($"Значение {target} найдено");
                    Console.WriteLine("Путь:");
                    foreach (int data in path)
                    {
                        Console.Write($" -> {data} ");
                    }
                    Console.WriteLine();
                    return;
                }
                else
                {
                    if (current.Right != null)
                    {
                        stackNodes.Push(current.Right);
                    }
                    if (current.Left != null)
                    {
                        stackNodes.Push(current.Left);
                    }
                }
            }
            Console.WriteLine($"Значение {target} не найдено");
            Console.WriteLine("Путь:");
            foreach (int data in path)
            {
                Console.Write($" -> {data}");
            }
            Console.WriteLine();
        }

        private int GetHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int heightLeft = GetHeight(current.Left);
                int heightRight = GetHeight(current.Right);
                int m = Math.Max(heightLeft, heightRight);
                height = m + 1;
            }
            return height;
        }
        private int BalanceFactor(Node current)
        {
            int heightLeft = GetHeight(current.Left);
            int heightRight = GetHeight(current.Right);
            int b_factor = heightLeft - heightRight;
            return b_factor;
        }
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}

