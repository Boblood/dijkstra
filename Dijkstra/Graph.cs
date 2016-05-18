using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Graph
    {
        private List<Path> _paths = new List<Path>();
        private Algorithm Al;

        public void Addpath(Path path)
        {
            _paths.Add(path);
        }

        public string FindShortestPath()
        {
            Al = new Algorithm(_paths);
            return Al.PrintBestPath();
        }

        
    }
}
