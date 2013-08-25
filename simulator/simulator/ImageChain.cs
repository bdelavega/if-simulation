using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulator
{
    class ImageChain : LinkedList<Image>
    {
        private const double intervalMinutes = 15;

        public ImageChain()
        {
            AddFirst(new LinkedListNode<Image>(new Image()));
        }

        public void AddIncrementalImage(double intervalMinutes)
        {
            var img = new Image(this.First.Value, intervalMinutes);
            AddFirst(new LinkedListNode<Image>(img));
        }
    }
}
