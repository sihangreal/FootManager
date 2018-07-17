using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Enity
{
    public class SalesVo
    {
        [ColumnAttr("日期")]
        public DateTime Date { get; set; }
        [ColumnAttr("现金")]
        public double Cash { get; set; }
        [ColumnAttr("银行卡")]
        public double CCard { get; set; }
        [ColumnAttr("会员卡")]
        public double MemberUse { get; set; }
        [ColumnAttr("免单")]
        public double Foc{ get; set; }
        [ColumnAttr("消费税")]
        public double Gst { get; set; }
        [ColumnAttr("消费额")]
        public double Sales { get; set; }
    }
}
