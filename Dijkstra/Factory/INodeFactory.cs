using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra.Factory;

namespace Dijkstra
{
    /// <summary>
    /// Interface for the factory
    /// </summary>
    public interface INodeFactory
    {
        /// <summary>
        /// Makes a node of any type
        /// </summary>
        /// <returns>INode of the desired type</returns>
        INode GetNode();
    }
}
