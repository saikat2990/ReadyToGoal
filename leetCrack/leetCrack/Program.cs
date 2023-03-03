using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace leetCrack
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class characterData{
        public int totalOccur { get; set; }
        public int serial { get; set; }
        public char ch { get; set; }
    }

    public class Program
    {
       public static void Main(string[] args)
        {
            Console.WriteLine();
        }


    }
   
}