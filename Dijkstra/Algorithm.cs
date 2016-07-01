using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Algorithm
    {
        private List<Path> _allPaths = new List<Path>();
        private List<Node> _allNodes = new List<Node>();
        private List<List<int>> _distance; // temp list for the row being worked on
        private List<List<int>> _completedPaths; // final list
        private Dictionary<int, List<Path>> _possiblePathsPerNode = new Dictionary<int, List<Path>>();
        private bool[] _visited;

        public Algorithm(List<Path> paths)
        {
            _allPaths = paths;
            FindAllNodes();
            FindAllPossable();
            _distance = new List<List<int>>(_allNodes.Count);
            _completedPaths = new List<List<int>>(_allNodes.Count); //first number is node number/subscript letter second is distance
            _visited = new bool[_allNodes.Count];
            _visited[0] = true;
            Calculate();
        }

        #region [ Instantiation Methods ]
        private void FindAllNodes()
        {
            foreach (Path p in _allPaths)
            {
                if (!_allNodes.Contains(p.Node1))
                {
                    _allNodes.Add(p.Node1);
                }

                if (!_allNodes.Contains(p.Node2))
                {
                    _allNodes.Add(p.Node2);
                }
            }
            var _allNodesTemp = _allNodes.OrderBy(x => x.Number);
            _allNodes = _allNodesTemp.ToList();
        }

        private void FindAllPossable()
        {
            foreach (Node n in _allNodes)
            {
                _possiblePathsPerNode.Add(n.Number, new List<Path>()); // adds each node to dict

                Path temp;

                foreach (Path p in _allPaths)
                {
                    if (n.Number == p.Node1.Number || n.Number == p.Node2.Number)
                    {
                        if (!_possiblePathsPerNode[n.Number].Contains(p))
                        {
                            _possiblePathsPerNode[n.Number].Add(p);// adds each path connected to each node
                        }
                    }
                }
            }
        }
        #endregion

        #region [ Business Methods ]
        private void Calculate()
        {
            for (int j = _allNodes.Count; j > 0; j--)// sets each distance to "infinity"
            {
                _distance.Add(new List<int> {0, 999}); // dummy node
                _completedPaths.Add(new List<int> { 0, 999 });
            }

            //finds all node with only one path and marks them with that path
            foreach (KeyValuePair<int, List<Path>> keyValuePair in _possiblePathsPerNode)
            {
                if (keyValuePair.Value.Count == 1)
                {
                    int otherNodeIndex;
                    if (_allNodes[keyValuePair.Key - 1] == keyValuePair.Value[0].Node1)
                    {
                        otherNodeIndex = keyValuePair.Value[0].Node2.Number;
                    }
                    else
                    {
                        otherNodeIndex = keyValuePair.Value[0].Node1.Number;
                    }
                    _distance[keyValuePair.Key - 1][0] = otherNodeIndex;
                }
            }

            _distance[0] = new List<int> { 1, 0 }; // this sets the first step to 0 because going from one node to the same node is 0
            _completedPaths[0] = new List<int> { 1, 0 }; // same thing as this ^
            Node nextNode;
            Node currentNode = _allNodes[0];
            bool allRowsComplete = false;

            while (!allRowsComplete)
            {
                //switches the next node to the the node that is not current so that it doesn't go back
                foreach (Path p in _possiblePathsPerNode[currentNode.Number])
                {
                    if (p.Node1 == currentNode)
                    {
                        nextNode = p.Node2;
                    }
                    else
                    {
                        nextNode = p.Node1;
                    }

                    if (_visited[nextNode.Number - 1] && _possiblePathsPerNode[currentNode.Number].Count > 1)
                    {
                        continue;
                    }

                    int totalWeight = CalcTotalWeight(nextNode, currentNode);

                    if (_distance[nextNode.Number - 1][1] > totalWeight)
                    {
                        _distance[nextNode.Number - 1] = new List<int> {currentNode.Number, totalWeight};
                    }
                }

                int smallestPathWeight = 999;
                int smallestPathIndex = 0;
                int index = 0;

                //switch current node to the smallest distance and record in final list
                foreach (var l in _distance)
                {
                    if (l[1] < smallestPathWeight && l[1] != 0 && !_visited[index])
                    {
                        smallestPathIndex = index;
                        smallestPathWeight = l[1];
                    }
                    index++;
                }

                //records completed path
                _completedPaths[smallestPathIndex] = new List<int> 
                    { _distance[smallestPathIndex][0], _distance[smallestPathIndex][1] };

                currentNode = _allNodes[smallestPathIndex]; // changes current node to the next node to be evaluated

                if (_visited[currentNode.Number - 1])
                {
                    int tempWeight = 999;
                    int tempNodeNumber = 0;
                    bool foundAtLeastOne = false;
                    foreach (Node n in _allNodes)
                    {
                        if (!_visited[n.Number - 1])
                        {
                            //finds the next smallest number that wasn't visited yet
                            if (_distance[n.Number - 1][1] < tempWeight)
                            {
                                tempWeight = _distance[n.Number - 1][1];
                                tempNodeNumber = _distance[n.Number - 1][0];
                                foundAtLeastOne = true;
                            }
                            if (!foundAtLeastOne)
                            {
                                tempNodeNumber = _allNodes[n.Number - 1].Number;
                            }
                        }
                    }
                    currentNode = _allNodes[tempNodeNumber - 1];
                }

                _visited[smallestPathIndex] = true;
                //determins if all the paths are complete
                allRowsComplete = true;
                foreach (var l in _completedPaths)
                {
                    if (l[1] == 999)
                    {
                        allRowsComplete = false;
                        break;
                    }
                }
            }
        }

        //private int CalcTotalWeight

        private int CalcTotalWeight(Node nextNode, Node currentNode) //needs to be fixed so more than 2 paths work
        {
            Node startingNode = new Node('A', 1); // magic number
            Node finalNode = nextNode;
            Node currentNodeTemp = currentNode;
            int total = 0;
            int temp = 999;

            while (finalNode.Number != startingNode.Number)
            {
                try // if the path doesn't follow the best path or it doesn't exist then return "infinity"
                {
                    temp = _allPaths.Where(x => (x.Node1.Number == currentNodeTemp.Number || x.Node2.Number == currentNodeTemp.Number)
                                && (x.Node1.Number == finalNode.Number || x.Node2.Number == finalNode.Number)).ToList()[0].Weight;
                }
                catch (Exception)
                {
                    return 999;
                }

                total += temp;

                int finalNodeIndex = finalNode.Number - 1;
                finalNode = currentNodeTemp;
                if (_distance[currentNodeTemp.Number - 1][0] - 1 >= 0) // only not true for the first row
                {
                    currentNodeTemp = _allNodes[_distance[currentNodeTemp.Number - 1][0] - 1];
                }

                
            }

            return total;
        }
        #endregion

        private List<Path> GetCompletePath()
        {
            Node currentNode, nextNode; //next node is the previous node in the final path
            currentNode = _allNodes[_completedPaths.Count - 1];
            nextNode = _allNodes[_completedPaths[currentNode.Number - 1][0] - 1];
            List<Path> tempList = new List<Path>();
            while (currentNode != _allNodes[0]) //Not final node (first node)
            {
                tempList.Add(_allPaths.Where(x => (x.Node1.Number == currentNode.Number || x.Node2.Number == currentNode.Number)
                                && (x.Node1.Number == nextNode.Number || x.Node2.Number == nextNode.Number)).ToList()[0]);

                currentNode = nextNode;
                nextNode = _allNodes[_completedPaths[nextNode.Number - 1][0] - 1];

            }
            tempList.Reverse();

            return tempList;
        }

        public string PrintBestPath()
        {
            string tempString = "";
            List<Path> tempList = GetCompletePath();
            List<Node> tempNodes = new List<Node>();
            tempNodes.Add(tempList[0].Node1);

            foreach (var path in tempList)
            {
                if (!tempNodes.Contains(path.Node1))
                    tempNodes.Add(path.Node1);
                if (!tempNodes.Contains(path.Node2))
                    tempNodes.Add(path.Node2);
            }

            tempString = tempNodes[0].Name.ToString();
            tempNodes.RemoveAt(0);
            foreach (var n in tempNodes)
            {
                tempString += " => " + n.Name;
            }

            return tempString;
        }
    }
}
