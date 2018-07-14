using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("Level")]
    public class StaffLevelVo
    {
        private int id;
        [ColumnAttr("编号", false)]
        [DataAttr(false,true)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string staffLevel;
        [ColumnAttr("员工级别", true)]
        [DataAttr(true)]
        public string StaffLevel
        {
            get { return staffLevel; }
            set { staffLevel = value; }
        }
        private string remark;
        [ColumnAttr("备注", true)]
        [DataAttr(true)]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
