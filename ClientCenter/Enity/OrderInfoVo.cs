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
        private string startTime;
        [ColumnAttr("开始时间", true)]
        [DataAttr(true)]
        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private string endTime;
        [ColumnAttr("结束时间", true)]
        [DataAttr(true)]
        public string EndTime
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
        private string status;
        [DataAttr(true)]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
