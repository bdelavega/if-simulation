using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulator
{
    /// <summary>
    /// volume image types as supported by AppAssure 5
    /// </summary>
    enum ImageType
    {
        Base,
        Incremental,
        Synthetic
    }

    class Image
    {
        private ImageType type;

        internal ImageType Type
        {
            get { return type; }
            set { type = value; }
        }
        
        // for base and incremental images, createTime will be the same as modified
        // for synthetic images, the createTime will be the oldest createTime
        private DateTime createTime;

        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        // for synthetic images, modifiedTime will be the newest createTime of the images
        // synthesized
        private DateTime modifiedTime;

        public DateTime ModifiedTime
        {
            get { return modifiedTime; }
            set { modifiedTime = value; }
        }

        public Image()
        {
            type = ImageType.Base;
            createTime = modifiedTime = DateTime.Now;
            modifiedTime = createTime;
        }

        public Image(Image parent, double intervalMinutes)
        {
            type = ImageType.Incremental;
            createTime = parent.createTime.AddMinutes(intervalMinutes);
            modifiedTime = createTime;
        }
    }
}
