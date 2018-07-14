using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("MemberConsume")]
    public class StaffWorkRecordVo
    {
        [DataAttr(true)]
        public string ID { set; get; }
        [DataAttr(true)]
        public string StaffId { set; get; }
        [DataAttr(true)]
        public string StaffName { set; get; }
        [DataAttr(true)]
        public string OrderID { set; get; }
        [DataAttr(true)]
        public double Amount { set; get; }
        [DataAttr(true)]
        public DateTime WorkTime { set; get; }
    }
}
