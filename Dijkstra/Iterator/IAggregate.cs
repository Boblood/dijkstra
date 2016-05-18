using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Iterator
{
    public interface IAggregate
    {
        INodeIterator CreateIterator();
    }
}
