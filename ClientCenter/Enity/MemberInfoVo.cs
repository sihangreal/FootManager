using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.GridViews;

namespace ClientCenter.Enity
{
    [DataAttr("member")]
    public class MemberInfoVo
    {
        private string mId;
        [ColumnAttr("会员编号", true,false)]
        [DataAttr(true,true)]
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
        private string cardName;
        [ColumnAttr("会员卡名称", true, false)]
        [DataAttr(true)]
        public string CardName
        {
            get { return cardName; }
            set { cardName = value; }
        }
        private string mStatus;
        [ColumnAttr("会员状态", true, false)]
        [DataAttr(true)]
        public string MStatus
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
        private double mBalance;
        [ColumnAttr("会员余额", true, false)]
        [DataAttr(true)]
        public double MBalance
        {
            get { return mBalance; }
            set { mBalance = value; }
        }
        private string mPhone;
        [ColumnAttr("会员电话", true, false)]
        [DataAttr(true)]
        public string MPhone
        {
            get { return mPhone; }
            set { mPhone = value; }
        }
        private DateTime mCreateTime;
        [ColumnAttr("开卡时间", true,false)]
        [DataAttr(true)]
        public System.DateTime MCreateTime
        {
            get { return mCreateTime; }
            set { mCreateTime = value; }
        }
        private int companyId;
        [ColumnAttr("开卡店", true,false)]
        [DataAttr(true)]
        public int CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }
    }
}
