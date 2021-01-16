using System;
using System.Collections.Generic;


namespace Task_1
{
    public class LinkedList : ILinkedList
    {
        public Node FirstNode { get; set; }
        public Node LastNode { get; set; }
        public int Count { get; set; }

        public LinkedList()
        {
            FirstNode = null;
            LastNode = null;
            Count = 0;
        }

        public LinkedList(int value) : this()
        {
            AddNode(value);
        }

        public LinkedList(params int[] list) : this()
        {
            int countList = 0;
            while (countList < list.Length)
            {
                AddNode(list[countList]);
                countList++;
            }
        }

        public int GetCount()
        {
            return Count;
        }

        public void AddNode(int value)
        {
            if (LastNode == null)
            {
                FirstNode = new Node(value);
                LastNode = FirstNode;
            }
            else
            {
                LastNode.NextNode = new Node(value);
                LastNode.NextNode.PrevNode = LastNode;
                LastNode = LastNode.NextNode;

            }
            Count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (node.NextNode != null)
            {
                Node newNode = new Node(value);
                Node oldPrevNode = node;
                Node oldNextNode = node.NextNode;
                newNode.PrevNode = oldPrevNode;
                newNode.NextNode = oldNextNode;

                oldNextNode.PrevNode = newNode;
                oldPrevNode.NextNode = newNode;

                Count++;
            }
            else AddNode(value);

        }

        public Node FindNode(int searchValue)
        {
            Node node = FirstNode;
            while (node != null)
            {
                if (node.Value == searchValue)
                {
                    return node;
                }
                node = node.NextNode;
            }
            return null;
        }

        public void RemoveNode(int index)
        {
            if (index == 1)
            {
                RemoveNode(FirstNode);
            }
            else if (index == Count)
            {
                RemoveNode(LastNode);
            }
            else if (index > 1 && index < Count)
            {
                Node node = FirstNode.NextNode;

                for (int count = 2; count < index; count++)
                {
                    node = node.NextNode;
                }

                RemoveNode(node);
            }
        }


        public void RemoveNode(Node node)
        {
            if (node == FirstNode)
            {
                FirstNode = FirstNode.NextNode;
                FirstNode.PrevNode = null;
            }
            else if (node == LastNode)
            {
                LastNode = LastNode.PrevNode;
                LastNode.NextNode = null;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }
            Count--;
        }

        public void Print()
        {
            Node CurrentNode = FirstNode;
            while (CurrentNode != null)
            {
                Console.Write(CurrentNode.Value);
                if (CurrentNode.NextNode != null)
                {
                    Console.Write('_');
                }
                CurrentNode = CurrentNode.NextNode;
            }
            Console.WriteLine();
        }

        public bool Equals(LinkedList linkedList)
        {
            Node actualNode = FirstNode;
            Node expectedNode = linkedList.FirstNode;


            if (Count != linkedList.Count)
            {
                return false;
            }
            while (actualNode != null)
            {
                if (!actualNode.Equals(expectedNode))
                {
                    return false;
                }
                actualNode = actualNode.NextNode;
                expectedNode = expectedNode.NextNode;
            }
            return true;
        }

        public bool Equals(int[] expectedArray)
        {
            Node actualNode = FirstNode;
            if (Count != expectedArray.Length)
            {
                return false;
            }
            foreach(int val in expectedArray)
            {
                if (actualNode.Value != val)
                {
                    return false;
                }
                actualNode = actualNode.NextNode;
            }
            return true;
        }



    }
}
