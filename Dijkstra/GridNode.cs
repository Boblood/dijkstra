using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class GridNode
    {
        public string Name;
        public int X;
        public int Y;
        public bool IsBlocked;

        public GridNode(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }
    }
}
