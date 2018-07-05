using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("StaffSort")]
    public class StaffSortVo
    {
        private int sort;
        [ColumnAttr("顺序", true)]
        [DataAttr(true)]
        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        private string staffName;
        [ColumnAttr("员工姓名", true)]
        [DataAttr(true)]
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        private string staffSex; 
        [ColumnAttr("员工性别", true)]
        [DataAttr(true)]
        public string StaffSex
        {
            get { return staffSex; }
            set { staffSex = value; }
        }
    }
}
