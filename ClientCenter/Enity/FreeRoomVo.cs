using ClientCenter.Core;

namespace ClientCenter.Enity
{
    public class FreeRoomVo
    {
        private string roomId;
        [ColumnAttr("钟房编号", true)]
        public string RoomId
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
