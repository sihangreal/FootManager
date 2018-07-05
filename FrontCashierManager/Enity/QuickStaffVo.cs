using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.Core;

namespace FrontCashierManager.Enity
{
    public class QuickStaffVo
    {
        private string staffName;
        [ColumnAttr("技师姓名",true)]
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        private string staffSex;
        [ColumnAttr("技师性别", true)]
        public string StaffSex
        {
            get { return staffSex; }
            set { staffSex = value; }
        }
        private int count;
        [ColumnAttr("轮钟次数", true)]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int sequence;
        [ColumnAttr("排序",true)]
        public int Sequence
        {
            get { return sequence; }
            set { sequence = value; }
        }
    }
}
