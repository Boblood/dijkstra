using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Path
    {
        private Node _node1;
        private Node _node2;
        private int _weight;

        public Node Node1 { get { return _node1; } }

        public Node Node2 { get { return _node2; } }

        public int Weight { get { return _weight; } }

        public Path()
        {
            
        }

        public Path(Node node1, Node node2, int weight)
        {
            if (node2.Number < node1.Number)
            {
                _node1 = node2;
                _node2 = node1;
            }
            else
            {
                _node1 = node1;
                _node2 = node2;
            }

            _weight = weight;
        }
    }
}
