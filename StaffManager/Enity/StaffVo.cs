using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.Core;

namespace StaffManager.Enity
{
    public class StaffVo
    {
        private int staffId;
        [ColumnAttr("员工编号",true)]
        public int StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }
        private string staffName;
        [ColumnAttr("员工姓名", true)]
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        private int staffSex;
        [ColumnAttr("员工性别", true)]
        public int StaffSex
        {
            get { return staffSex; }
            set { staffSex = value; }
        }
    }
}
