using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("MemberConsume")]
    public class MemberConsumeVo
    {
        private string id;
        [ColumnAttr("ID", false, false)]
        [DataAttr(true)]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string memberId;
        [ColumnAttr("会员编号", true, false)]
        [DataAttr(true)]
        public string MId
        {
            get { return memberId; }
            set { memberId = value; }
        }
        private string memberName;
        [ColumnAttr("会员名字", true, false)]
        [DataAttr(true)]
        public string MName
        {
            get { return memberName; }
            set { memberName = value; }
        }
        private double amount;
        [ColumnAttr("金额", true, false)]
        [DataAttr(true)]
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private DateTime consumeTime;
        [ColumnAttr("消费时间", true, false)]
        [DataAttr(true)]
        public DateTime ConsumeTime
        {
            get { return consumeTime; }
            set { consumeTime = value; }
        }
        private int companyId;
        [ColumnAttr("公司ID", true, false)]
        [DataAttr(true)]
        public int CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }
    }
}
