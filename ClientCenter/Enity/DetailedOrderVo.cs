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
        private int detailID;
        [DataAttr(false, true)]
        public int DetailID
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
    }
}
