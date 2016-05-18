using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra.Factory;

namespace Dijkstra.Iterator
{
    public class ConcreteAggregate : IAggregate
    {
        private List<INode> _items = new List<INode>();

        public INodeIterator CreateIterator()
        {
            return new ConcreteNodeIterator(this);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public void Add(INode n)
        {
            _items.Add(n);
        }

        public Node this[int index]
        {
            get { return (Node)_items[index]; }
            set { _items.Insert(index, value); }
        }
    }
}
