using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.Core;

namespace FrontCashierManager.Enity
{
    public class RoomVo
    {
        //房间ID
        private int roomId;
        [ColumnAttr("钟房编号", true)]
        public int RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }
        //房间名字
        private string roomName;
        [ColumnAttr("钟房名字", true)]
        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
        //房间状态 //0空闲 1 占用
        private int roomStatus;
        [ColumnAttr("钟房状态", true)]
        public int RoomStatus
        {
            get { return roomStatus; }
            set { roomStatus = value; }
        }
    }
}
