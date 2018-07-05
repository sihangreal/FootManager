using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.Core;

namespace StaffManager.Enity
{
    public class QuickStaffVo
    {
        private string staffID;
        [ColumnAttr("技师编号", true)]
        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
        private string staffName;
        [ColumnAttr("技师姓名", true)]
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
        private string serverName;
        [ColumnAttr("服务项目",true)]
        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }
        private string time;
        [ColumnAttr("服务时间",true)]
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
