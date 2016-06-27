using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra.Factory;
using Dijkstra.Iterator;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            //code before factory
            //Node nodeA = new Node('A', 1);//nodes need to start with one/not zero based
            //Node nodeB = new Node('B', 2);
            //Node nodeC = new Node('C', 3);
            //Node nodeD = new Node('D', 4);
            //Node nodeE = new Node('E', 5);

            var listOfNodes = new List<INode>();
            var nf = new NodeFactory();
            char name = 'A';
            for (int i = 1; i < 7; i++)
            {
                listOfNodes.Add(nf.GetNode(name, i));
                name++;
            }

            #region [ Iterator ]
            /*
            ConcreteAggregate CA = new ConcreteAggregate();
            for (int i = 1; i < 7; i++)
            {
                CA.Add(nf.GetNode());
            }

            ConcreteNodeIterator CI = new ConcreteNodeIterator(CA);
            Node item = (Node)CI.First();
            int nodeNumber = 1;
            int index = 0;
            while (item != null)
            {
                CA[index].Name = name;
                CA[index].Number = nodeNumber;
                name++;
                nodeNumber++;
                index++;
                item = (Node)CI.Next();
            }

            #region [ Example 1 ]
            Path pathAB = new Path((Node)CA[0], (Node)CA[1], 5);
            Path pathBC = new Path((Node)CA[1], (Node)CA[2], 4);
            Path pathAC = new Path((Node)CA[0], (Node)CA[2], 10);
            Path pathCD = new Path((Node)CA[2], (Node)CA[3], 6);
            Path pathCE = new Path((Node)CA[2], (Node)CA[4], 2);
            Path pathAD = new Path((Node)CA[0], (Node)CA[3], 1);
            Path pathBE = new Path((Node)CA[1], (Node)CA[4], 3);

            Graph graph1 = new Graph();

            graph1.Addpath(pathAB);
            graph1.Addpath(pathAC);
            graph1.Addpath(pathBC);
            graph1.Addpath(pathCD);
            graph1.Addpath(pathAD);
            graph1.Addpath(pathCE);
            graph1.Addpath(pathBE);
            #endregion

            #region [ Example 2 ]
            Path pathAB2 = new Path((Node)CA[0], (Node)CA[1], 1);
            Path pathAD2 = new Path((Node)CA[0], (Node)CA[3], 4);
            Path pathBC2 = new Path((Node)CA[1], (Node)CA[2], 5);
            Path pathBD2 = new Path((Node)CA[1], (Node)CA[3], 2);
            Path pathCE2 = new Path((Node)CA[2], (Node)CA[4], 1);
            Path pathDE2 = new Path((Node)CA[3], (Node)CA[4], 5);

            Graph graph2 = new Graph();

            graph2.Addpath(pathAB2);
            graph2.Addpath(pathAD2);
            graph2.Addpath(pathBC2);
            graph2.Addpath(pathBD2);
            graph2.Addpath(pathCE2);
            graph2.Addpath(pathDE2);
            #endregion

            #region [ Example 3 ]
            Path pathAB3 = new Path((Node)CA[0], (Node)CA[1], 5);
            Path pathAE3 = new Path((Node)CA[0], (Node)CA[4], 1);
            Path pathBC3 = new Path((Node)CA[1], (Node)CA[2], 4);
            Path pathBD3 = new Path((Node)CA[1], (Node)CA[3], 10);
            Path pathCD3 = new Path((Node)CA[2], (Node)CA[3], 2);
            Path pathCE3 = new Path((Node)CA[2], (Node)CA[4], 3);
            Path pathDF3 = new Path((Node)CA[3], (Node)CA[5], 1);
            Path pathEF3 = new Path((Node)CA[4], (Node)CA[5], 10);

            Graph graph3 = new Graph();

            graph3.Addpath(pathAB3);
            graph3.Addpath(pathAE3);
            graph3.Addpath(pathBC3);
            graph3.Addpath(pathBD3);
            graph3.Addpath(pathCD3);
            graph3.Addpath(pathCE3);
            graph3.Addpath(pathDF3);
            graph3.Addpath(pathEF3);
            #endregion
             */
            #endregion

            #region [ Example 1 ]
            Path pathAB = new Path((Node)listOfNodes[0], (Node)listOfNodes[1], 5);
            Path pathBC = new Path((Node)listOfNodes[1], (Node)listOfNodes[2], 4);
            Path pathAC = new Path((Node)listOfNodes[0], (Node)listOfNodes[2], 10);
            Path pathCD = new Path((Node)listOfNodes[2], (Node)listOfNodes[3], 6);
            Path pathCE = new Path((Node)listOfNodes[2], (Node)listOfNodes[4], 2);
            Path pathAD = new Path((Node)listOfNodes[0], (Node)listOfNodes[3], 1);
            Path pathBE = new Path((Node)listOfNodes[1], (Node)listOfNodes[4], 3);

            Graph graph1 = new Graph();

            graph1.Addpath(pathAB);
            graph1.Addpath(pathAC);
            graph1.Addpath(pathBC);
            graph1.Addpath(pathCD);
            graph1.Addpath(pathAD);
            graph1.Addpath(pathCE);
            graph1.Addpath(pathBE);
            #endregion

            #region [ Example 2 ]
            Path pathAB2 = new Path((Node)listOfNodes[0], (Node)listOfNodes[1], 1);
            Path pathAD2 = new Path((Node)listOfNodes[0], (Node)listOfNodes[3], 4);
            Path pathBC2 = new Path((Node)listOfNodes[1], (Node)listOfNodes[2], 5);
            Path pathBD2 = new Path((Node)listOfNodes[1], (Node)listOfNodes[3], 2);
            Path pathCE2 = new Path((Node)listOfNodes[2], (Node)listOfNodes[4], 1);
            Path pathDE2 = new Path((Node)listOfNodes[3], (Node)listOfNodes[4], 5);

            Graph graph2 = new Graph();

            graph2.Addpath(pathAB2);
            graph2.Addpath(pathAD2);
            graph2.Addpath(pathBC2);
            graph2.Addpath(pathBD2);
            graph2.Addpath(pathCE2);
            graph2.Addpath(pathDE2);
            #endregion

            #region [ Example 3 ]
            Path pathAB3 = new Path((Node)listOfNodes[0], (Node)listOfNodes[1], 5);
            Path pathAE3 = new Path((Node)listOfNodes[0], (Node)listOfNodes[4], 1);
            Path pathBC3 = new Path((Node)listOfNodes[1], (Node)listOfNodes[2], 4);
            Path pathBD3 = new Path((Node)listOfNodes[1], (Node)listOfNodes[3], 10);
            Path pathCD3 = new Path((Node)listOfNodes[2], (Node)listOfNodes[3], 2);
            Path pathCE3 = new Path((Node)listOfNodes[2], (Node)listOfNodes[4], 3);
            Path pathDF3 = new Path((Node)listOfNodes[3], (Node)listOfNodes[5], 1);
            Path pathEF3 = new Path((Node)listOfNodes[4], (Node)listOfNodes[5], 10);

            Graph graph3 = new Graph();

            graph3.Addpath(pathAB3);
            graph3.Addpath(pathAE3);
            graph3.Addpath(pathBC3);
            graph3.Addpath(pathBD3);
            graph3.Addpath(pathCD3);
            graph3.Addpath(pathCE3);
            graph3.Addpath(pathDF3);
            graph3.Addpath(pathEF3);
            #endregion

            Console.WriteLine("Example 1: " + graph1.FindShortestPath());
            Console.WriteLine("Example 2: " + graph2.FindShortestPath());
            Console.WriteLine("Example 3: " + graph3.FindShortestPath());
            

            //A* code
            Grid grid = new Grid(5, 5);
            for (int i =1; i < 4; i++)
            {
                grid.MarkObstacle(2, i);
            }
            Console.WriteLine(grid.DrawGrid());

            Grid grid1 = new Grid(10, 10);
            Console.WriteLine(grid1.DrawGrid());
            Console.ReadLine();
        }
    }
}
