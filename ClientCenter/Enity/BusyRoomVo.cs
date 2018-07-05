using ClientCenter.Core;

namespace ClientCenter.Enity
{
    public class BusyRoomVo
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
        private string projectName;
        [ColumnAttr("项目名字", true)]
        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private string staffName;
        [ColumnAttr("技师姓名", true)]
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        private string staffSex;
        [ColumnAttr("技师性别", true)]
        public string StaffSex
        {
            get { return staffSex; }
            set { staffSex = value; }
        }
        private string oppoint;
        [ColumnAttr("是否点钟", true)]
        public string Oppoint
        {
            get { return oppoint; }
            set { oppoint = value; }
        }
        private string startTime;
        [ColumnAttr("上钟时间", true)]
        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private string endTime;
        [ColumnAttr("下钟时间", true)]
        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private string overTime;
        [ColumnAttr("超过时间", true)]
        public string OverTime
        {
            get { return overTime; }
            set { overTime = value; }
        }
    }
}
