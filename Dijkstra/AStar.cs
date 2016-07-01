using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class AStar
    {
        private List<GridNode> _allNodes;
        private GridNode _startNode;
        private GridNode _endNode;

        public AStar(List<GridNode> gridNodes, GridNode startNode, GridNode endNode)
        {
            _allNodes = gridNodes;
            _startNode = startNode;
            _endNode = endNode;
        }

        public void Calculate()
        {
            float weightToNextNode;
            float weightToEndNode; //straight line distance to end node
        }

        private List<GridNode> GetAdjacentNodes(GridNode node)
        {
            List<GridNode> adjacentNodes = new List<GridNode>();
            foreach (GridNode n in _allNodes)
            {
                if(n.X <= node.X + 1 && n.X >= node.X - 1 &&
                    n.Y <= node.Y + 1 && n.Y >= node.Y - 1)
                {
                    adjacentNodes.Add(n);
                }
            }

            return adjacentNodes;
        }

        private List<GridNode> GetAdjacentWalkableNodes(GridNode currentNode)
        {
            List<GridNode> walkableNodes = new List<GridNode>();


            return walkableNodes;
        }
    }
}
