using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes3
{
    internal class Manager
    {
        public Manager() { }

        public Tree<DataX> storage = new Tree<DataX>();
        
        public void Supply(float x, float y, int count)
        {
            DataX dataX = new DataX(x);
            DataY dataY = new DataY(y);

            if(storage.Find(dataX) == null)
            {               
                storage.Insert(dataX);                
                dataY.AddToCount(count);
                dataX.AddY(dataY);
            }
            else
            {
                var foundX = storage.Find(dataX);
                var foundY = foundX.Data.SubTree.Find(dataY);
                if(foundY == null)
                {
                    dataY.AddToCount(count);
                    foundX.Data.AddY(dataY);
                }
                else
                {
                    foundY.Data.AddToCount(count);
                }
            }
        }
    }
}
