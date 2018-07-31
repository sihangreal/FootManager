using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.GridViews
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
        private bool isEdit;
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public ColumnAttr()
        {

        }

        public ColumnAttr(string caption)
        {
            this.caption = caption;
        }

        public ColumnAttr(string caption, bool visble,bool isEdit=true)
        {
            this.caption = caption;
            this.visble = visble;
            this.isEdit = isEdit;
        }
    }
}
