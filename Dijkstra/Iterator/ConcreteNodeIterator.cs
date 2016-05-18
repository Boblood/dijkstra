using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra.Factory;

namespace Dijkstra.Iterator
{
    public class ConcreteNodeIterator : INodeIterator
    {
        private ConcreteAggregate _ca;
        private int _current;

        public ConcreteNodeIterator(ConcreteAggregate CA)
        {
            _ca = CA;
        }

        public INode First()
        {
            return _ca[0];
        }

        public INode Next()
        {
            if (_current < _ca.Count - 1)
            {
                return _ca[++_current];
            }

            return null;
        }

        public INode CurrentNode
        {
            get { return _ca[_current]; }
        }

        public bool IsDone
        {
            get { return _current >= _ca.Count; }
        }
    }
}
