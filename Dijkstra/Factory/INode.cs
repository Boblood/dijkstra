using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Factory
{
    /// <summary>
    /// Interface for the Factory for Nodes
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Name of the Node, just one char, makes printing the nodes easier
        /// </summary>
        char Name { get; set; }

        /// <summary>
        /// Number of the node, makes comparing easier
        /// </summary>
        int Number { get; set; }
    }
}
