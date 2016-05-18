using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra.Factory;

namespace Dijkstra.Iterator
{
    public interface INodeIterator
    {
        INode First();
        INode Next();
        INode CurrentNode { get; }
        bool IsDone { get; }
    }
}
