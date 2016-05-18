using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra.Factory;

namespace Dijkstra
{
    public class Node : INode
    {
        private char _name;
        private int _number;

        public char Name
        {
            get { return _name; } 
            set { value = _name; }
        }

        public int Number
        {
            get { return _number; }
            set { value = _number; }
        }

        public Node()
        {
            
        }

        public Node(char name, int number)
        {
            _name = name;
            _number = number;
        }
    }
}
