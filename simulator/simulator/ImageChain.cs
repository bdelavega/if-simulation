using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulator
{
    // Linked list of volume images.  The first image is the base the simulation 
    // starts with, therefore the oldest.  The last is the most recent incremental.
    class ImageChain : LinkedList<Image>
    {
        private const double intervalMinutes = 15;

        public ImageChain()
        {
            AddFirst(new LinkedListNode<Image>(new Image()));
        }

        public void AddIncrementalImage(double intervalMinutes)
        {
            var img = new Image(this.Last.Value, intervalMinutes);
            AddLast(new LinkedListNode<Image>(img));
        }
    }
}
