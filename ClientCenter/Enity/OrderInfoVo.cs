using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("OrderInfo")]
    public class OrderInfoVo
    {
        private string orderID;
        [ColumnAttr("订单编号", false)]
        [DataAttr(true, true)]
        public string OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        private int roomID;
        [ColumnAttr("房间编号", false)]
        [DataAttr(true)]
        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
        private string staffName;
        [ColumnAttr("技师", true)]
        [DataAttr(true)]
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        //private DateTime? startTime;
        //[ColumnAttr("开始时间", true)]
        //[DataAttr(true)]
        //public DateTime? StartTime
        //{
        //    get { return startTime; }
        //    set { startTime = value; }
        //}
        private DateTime endTime;
        [ColumnAttr("时间", true)]
        [DataAttr(true)]
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private string priceType;
        [ColumnAttr("收费类型", true)]
        [DataAttr(true)]
        public string PriceType
        {
            get { return priceType; }
            set { priceType = value; }
        }
        private double price;
        [ColumnAttr("价格", true)]
        [DataAttr(true)]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private double tax;
        [ColumnAttr("税", true)]
        [DataAttr(true)]
        public double Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        private double totalPrice;
        [ColumnAttr("总价", true)]
        [DataAttr(true)]
        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        //private string status;
        //[ColumnAttr("状态", true)]
        //[DataAttr(true)]
        //public string Status
        //{
        //    get { return status; }
        //    set { status = value; }
        //}
    }
}
