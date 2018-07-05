using ClientCenter.Core;
using System;

namespace ClientCenter.Enity
{
    public class TempConsumeVo
    {
        private int id;
        [ColumnAttr("项目编号", false)]
        [DataAttr(false)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string skillName;
        [ColumnAttr("项目名字", true)]
        [DataAttr(true)]
        public string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }
        private string roomName;
        [ColumnAttr("房间名字", true)]
        [DataAttr(true)]
        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
        private int volume;
        [ColumnAttr("数量", true)]
        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        private double price;
        [ColumnAttr("单价", true)]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private DateTime startTime;
        [ColumnAttr("点单时间", true)]
        public System.DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private string staffName;
        [ColumnAttr("技师", true)]
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
    }
}