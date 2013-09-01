using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulator
{
    /// <summary>
    /// Defines a time span of a rollup epoch.  Conceptually, each epoch has:
    /// a minimum age (images must be this old to be in this epoch)
    /// a maximum age (images older than this age are in an older epoch)
    /// a retention policy (how far apart images should be in this epoch).
    /// 
    /// Epochs are meant to be in a linked list, ordered by age.  
    /// This allows for these simplifications:
    /// the first epoch is assumed to start with a minimum age of 0
    /// the last epoch will have a null MaxAge
    /// 
    /// </summary>
    class RollupEpoch
    {
        private int maximumAgeInMinutes;

        internal int MaximumAgeInMinutes
        {
            get { return maximumAgeInMinutes; }
            set { maximumAgeInMinutes = value; }
        }

        private int desiredTimeBetweenImages;

        public int DesiredTimeBetweenImages
        {
            get { return desiredTimeBetweenImages; }
            set { desiredTimeBetweenImages = value; }
        }
    }
}
