using System;

namespace Task_1
{
    public class Node
    {
        public int Value { get; set; } 
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    
        public Node()
        {
            Value = 0;
            NextNode = null;
            PrevNode = null;
        }

        public Node(int value)
        {
            Value = value;
            NextNode = null;
            PrevNode = null;
        }

        public bool Equals(Node node)
        {
            return Value == node.Value;
        }

        public void Print()
        {
            Console.WriteLine($"Value = {Value}");
        }
    }
}
