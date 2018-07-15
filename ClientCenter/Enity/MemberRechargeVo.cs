using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("memberRecharge")]
    public class MemberRechargeVo
    {
        private int id;
        [ColumnAttr("ID", false)]
        [DataAttr(false)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string mId;
        [ColumnAttr("会员编号", true,false)]
        [DataAttr(true)]
        public string MId
        {
            get { return mId; }
            set { mId = value; }
        }
        private string mName;
        [ColumnAttr("会员名字", true,false)]
        [DataAttr(true)]
        public string MName
        {
            get { return mName; }
            set { mName = value; }
        }
        private double amount;
        [ColumnAttr("金额", true,false)]
        [DataAttr(true)]
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private DateTime updateTime;
        [ColumnAttr("充值时间", true,false)]
        [DataAttr(true)]
        public System.DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }
        private int companyId;
        [ColumnAttr("公司ID", true,false)]
        [DataAttr(true)]
        public int CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }
    }
}
