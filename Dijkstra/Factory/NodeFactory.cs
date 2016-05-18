using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Factory
{
    /// <summary>
    /// Instaniates A node
    /// </summary>
    public class NodeFactory : INodeFactory
    {
        /// <summary>
        /// Returns an INode empty object
        /// </summary>
        /// <returns>INode</returns>
        public INode GetNode()
        {
            return new Node();
        }

        /// <summary>
        /// Returns a fully instaniated INode Object
        /// </summary>
        /// <param name="name">Char representing the Node</param>
        /// <param name="number">Number of the Node</param>
        /// <returns>INode</returns>
        public INode GetNode(char name, int number)
        {
            return new Node(name, number);
        }
    }
}
