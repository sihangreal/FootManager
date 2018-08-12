using ClientCenter.Core;
using ClientCenter.GridViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("DetailedOrder")]
    public class DetailedOrderVo
    {
        private string detailID;
        [DataAttr(true, true)]
        [ColumnAttr("详细订单号")]
        public string DetailID
        {
            get { return detailID; }
            set { detailID = value; }
        }
        private string orderID;
        [DataAttr(true)]
        [ColumnAttr("订单号")]
        public string OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        private int skillId;
        [DataAttr(true)]
        [ColumnAttr("项目ID")]
        public int SkillId
        {
            get { return skillId; }
            set { skillId = value; }
        }
        private double price;
        [DataAttr(true)]
        [ColumnAttr("价格")]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private double tax;
        [DataAttr(true)]
        [ColumnAttr("消费税")]
        public double Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        private double totalPrice;
        [DataAttr(true)]
        [ColumnAttr("总价格")]
        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        [DataAttr(true)]
        [ColumnAttr("公司ID",false)]
        public int CompanyId { get; set; }
    }
}
