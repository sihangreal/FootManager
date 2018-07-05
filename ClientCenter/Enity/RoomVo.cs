using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("Room")]
    public class RoomVo
    {
        //房间ID
        private int roomId;
        [ColumnAttr("钟房编号", true)]
        [DataAttr(true,true)]
        public int RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }
        //房间名字
        private string roomName;
        [ColumnAttr("钟房名字", true)]
        [DataAttr(true)]
        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
        //房间状态 //0空闲 1 占用
        private string roomStatus;
        [ColumnAttr("钟房状态", true)]
        [DataAttr(true)]
        public string RoomStatus
        {
            get { return roomStatus; }
            set { roomStatus = value; }
        }
    }
}
