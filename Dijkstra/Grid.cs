using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Grid
    {
        public List<GridNode> _allNodes = new List<GridNode>();

        public Grid(int height, int width)
        {
            BuildGrid(width, height);
            BuildNeighbors();
        }

        public Grid(int height, int width, GridNode startPoint, GridNode endPoint)
        {
            BuildGrid(width, height);
            BuildNeighbors();
        }

        private void BuildGrid(int width, int height)
        {
            string name;
            int nameNumber = 1;
            char nameLetter = 'A';
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    name = nameLetter + nameNumber.ToString();
                    var temp = new GridNode(name, j, i);
                    _allNodes.Add(temp);
                    nameNumber++;
                }

                nameLetter++;
            }
        }

        private void BuildNeighbors()
        {

        }

        public void MarkObstacle(int x, int y)
        {
            foreach (var node in _allNodes)
            {
                if (node.X == x && node.Y == y)
                {
                    node.IsBlocked = true;
                }
            }

        }

        public string DrawGrid()
        {
            string results = "";

            foreach (var node in _allNodes)
            {
                if (node.X == 0)
                {
                    results = results + "\n";
                }

                if (node.IsBlocked)
                {
                    results = results + "[x]";
                }
                else
                {
                    results = results + "[ ]";
                }
            }

            return results;
        }
    }
}
