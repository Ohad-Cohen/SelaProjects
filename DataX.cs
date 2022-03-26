using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes3
{
    internal class DataX : IComparable
    {
        private Node<DataX> root;
        public Node<DataX> Root { get { return root; } }

        private Tree<DataY> subTree;

        private float _value;

        public float Value { get { return _value; } set { _value = value; } }

        public Tree<DataY> SubTree { get { return subTree; } private set { subTree = value; } }

        public DataX(float dataX)
        {
            subTree = new Tree<DataY>();
            _value = dataX;
        }

        public void AddY(DataY newNode)
        {
            subTree.Insert(newNode);
        }
        public int CompareTo(DataX obj)
        {
            if (obj == null)
                throw new NotImplementedException();

            return _value.CompareTo(obj.Value);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new NotImplementedException();

            return _value.CompareTo(obj);
        }
    }
}
