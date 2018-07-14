using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("StaffClass")]
    public class StaffClassVo
    {
        private int staffclassID;
        [ColumnAttr("班次编号", false)]
        [DataAttr(false,true)]
        public int StaffClassID
        {
            get { return staffclassID; }
            set { staffclassID = value; }
        }
        private string staffclassName;
        [ColumnAttr("班次名字", true)]
        [DataAttr(true)]
        public string StaffClassName
        {
            get { return staffclassName; }
            set { staffclassName = value; }
        }
        private int startTime;
        [ColumnAttr("开始时间", true)]
        [DataAttr(true)]
        public int StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private int endTime;
        [ColumnAttr("结束时间", true)]
        [DataAttr(true)]
        public int EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private string remark;
        [ColumnAttr("说明", true)]
        [DataAttr(true)]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
