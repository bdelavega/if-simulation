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
            this.AddFirst(new LinkedListNode<Image>(new Image()));
        }
    }
}
