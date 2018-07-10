using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("StaffQueue")]
    public class StaffQueueVo
    {
        private int queueId;
        [ColumnAttr("顺序", true)]
        [DataAttr(true)]
        public int QueueId
        {
            get { return queueId; }
            set { queueId = value; }
        }
        private string staffID;
        [ColumnAttr("员工工号", true)]
        [DataAttr(true)]
        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
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
        [ColumnAttr("技师性别", true)]
        [DataAttr(true)]
        public string StaffSex
        {
            get { return staffSex; }
            set { staffSex = value; }
        }
    }
}
