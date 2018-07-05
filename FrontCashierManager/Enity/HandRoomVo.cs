using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontCashierManager.Enity
{
    public class HandRoomVo
    {
        private string projectName;
        [ColumnAttr("项目名字", true)]
        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private int roomId;
        [ColumnAttr("钟房ID", true)]
        public int RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }
        private string roomName;
        [ColumnAttr("钟房名字", true)]
        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
    }
}
