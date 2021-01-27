using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }


        public Node()
        {
        }

        public Node(int value)
        {
            Data = value;
        }
        public Node(int value, Node parent)
        {
            Data = value;
            Parent = parent;
        }
    }
}
