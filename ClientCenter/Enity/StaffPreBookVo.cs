using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.GridViews;

namespace ClientCenter.Enity
{
    [DataAttr("StaffPreBook")]
    public class StaffPreBookVo
    {
        private string staffID;
        [ColumnAttr("员工工号",true)]
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
        private DateTime preTime;
        [ColumnAttr("预订时间",true)]
        [DataAttr(true)]
        public System.DateTime PreTime
        {
            get { return preTime; }
            set { preTime = value; }
        }
        private DateTime comTime;
        [ColumnAttr("到店时间",true)]
        [DataAttr(true)]
        public System.DateTime ComTime
        {
            get { return comTime; }
            set { comTime = value; }
        }
        private string remind;
        [ColumnAttr("是否提醒",true)]
        [DataAttr(true)]
        public string Remind
        {
            get { return remind; }
            set { remind = value; }
        }
        private string remark;
        [ColumnAttr("备注",true)]
        [DataAttr(true)]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        [DataAttr(true)]
        public int CompanyId { get; set; }
    }
}
