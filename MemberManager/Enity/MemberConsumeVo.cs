using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.Core;

namespace MemberManager.Enity
{
    [DataAttr("MemberConsume")]
    public class MemberConsumeVo
    {
        private int id;
        [ColumnAttr("ID", false)]
        [DataAttr(false)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string memberId;
        [ColumnAttr("会员编号", true)]
        [DataAttr(true)]
        public string MId
        {
            get { return memberId; }
            set { memberId = value; }
        }
        private string memberName;
        [ColumnAttr("会员名字", true)]
        [DataAttr(true)]
        public string MName
        {
            get { return memberName; }
            set { memberName = value; }
        }
        private double amount;
        [ColumnAttr("税前金额",true)]
        [DataAttr(true)]
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private double taxAmount;
        [ColumnAttr("税后金额", true)]
        [DataAttr(true)]
        public double TaxAmount
        {
            get { return taxAmount; }
            set { taxAmount = value; }
        }
        private string projectName;
        [ColumnAttr("项目名字", true)]
        [DataAttr(true)]
        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private string consumeTime;
        [ColumnAttr("消费时间", true)]
        [DataAttr(true)]
        public string ConsumeTime
        {
            get { return consumeTime; }
            set { consumeTime = value; }
        }
        private int companyId;
        [ColumnAttr("公司ID", true)]
        [DataAttr(true)]
        public int CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }
    }
}
