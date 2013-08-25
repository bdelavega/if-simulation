using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulator
{
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
        private DateTime createTime;

        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
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
