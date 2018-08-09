using ClientCenter.Core;
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
        public string DetailID
        {
            get { return detailID; }
            set { detailID = value; }
        }
        private string orderID;
        [DataAttr(true)]
        public string OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        private int skillId;
        [DataAttr(true)]
        public int SkillId
        {
            get { return skillId; }
            set { skillId = value; }
        }
        private double price;
        [DataAttr(true)]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private double tax;
        [DataAttr(true)]
        public double Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        private double totalPrice;
        [DataAttr(true)]
        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        [DataAttr(true)]
        public int CompanyId { get; set; }
    }
}
