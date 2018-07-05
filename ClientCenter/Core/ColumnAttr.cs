using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Core
{
    public class ColumnAttr:Attribute
    {
        private string caption;
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }
        private bool visble;
        public bool Visble
        {
            get { return visble; }
            set { visble = value; }
        }

        public ColumnAttr()
        {

        }

        public ColumnAttr(string caption)
        {
            this.caption = caption;
        }

        public ColumnAttr(string caption, bool visble)
        {
            this.caption = caption;
            this.visble = visble;
        }
    }
}
