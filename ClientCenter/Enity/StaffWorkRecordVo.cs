using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.GridViews;

namespace ClientCenter.Enity
{
    [DataAttr("StaffWorkRecord")]
    public class StaffWorkRecordVo
    {
        [DataAttr(true)]
        [ColumnAttr("ID",false, false)]
        public string ID { set; get; }
        [DataAttr(true)]
        [ColumnAttr("员工编号", true, false)]
        public string StaffId { set; get; }
        [DataAttr(true)]
        [ColumnAttr("员工姓名", true, false)]
        public string StaffName { set; get; }
        [DataAttr(true)]
        [ColumnAttr("订单编号", true, false)]
        public string OrderID { set; get; }
        [DataAttr(true)]
        [ColumnAttr("金额", true, false)]
        public double Amount { set; get; }
        [DataAttr(true)]
        [ColumnAttr("做工时间", true, false)]
        public DateTime WorkTime { set; get; }
    }
}
