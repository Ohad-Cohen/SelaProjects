using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes3
{
    internal class DataY : IComparable
    {
        private float _value;
        private float _count;

        public float Value { get { return _value; } private set { _value = value; } }
        public float Count { get { return _count; } private set { _count = value; } }

        public void AddToCount(int Amount)
        {
            Count += Amount;
        }
        public DataY(float DataY)
        {
            _value = DataY;
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new NotImplementedException();

            return _value.CompareTo(obj);
        }
    }
}
