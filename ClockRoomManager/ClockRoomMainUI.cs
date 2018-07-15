using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClockRoomManager.UI;
using ClientCenter.Core;
using ClientCenter.DB;
using ClientCenter.Event;
using ClientCenter.Enity;
using DevExpress.XtraEditors;
using System.Linq;

namespace ClockRoomManager
{
    public partial class ClockRoomMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        ClockRoom clockRoom; //钟房
        StaffQueryUI staffQuery;
        private List<RoomVo> roomVoList = new List<RoomVo>();

        public ClockRoomMainUI()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += ClockRoomMainUI_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnUpdate.Click += BtnUpdate_Click;
            this.btnDel.Click += BtnDel_Click;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            RoomVo vo = (RoomVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (vo == null)
                return;
            DeleteDao.DelRoomByID(vo.RoomId);
            XtraMessageBox.Show("删除成功!");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            RoomVo vo = (RoomVo)this.gridView2.GetRow(this.gridView2.FocusedRowHandle);
            if (vo == null)
                return;
            UpdateRoomForm updateRoom = new UpdateRoomForm(vo);
            updateRoom.ShowDialog();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddRoomForm addRoom = new AddRoomForm();
            addRoom.ShowDialog();
        }

        private void ClockRoomMainUI_Load(object sender, EventArgs e)
        {
            GridViewUtil.CreateColumnForData(this.gridView2, typeof(RoomVo));
            GridViewUtil.CreateColumnForData(this.gridView1, typeof(TempConsumeVo));

            clockRoom = new ClockRoom();
            clockRoom.Dock = DockStyle.Fill;
            this.panelRoom.Controls.Add(clockRoom);

            staffQuery = new StaffQueryUI();
            staffQuery.Dock = DockStyle.Fill;
            this.panelStaff.Controls.Add(staffQuery);

            RefreshRoom();
        }
        private void RefreshRoom()
        {
            roomVoList = SelectDao.SelectData<RoomVo>();
            List<Room> roomList = new List<Room>();
            this.gridControl2.DataSource = roomVoList;
            this.gridControl2.RefreshDataSource();
            foreach (RoomVo vo in roomVoList)
            {
                roomList.Add(new Room(vo));
            }
            clockRoom.SetRoomList(roomList);
        }
        private void ShowRoom()
        {

        }
       private void FillRoom()
        {
            List<RoomVo> voList = SelectDao.SelectData<RoomVo>();
            this.gridControl2.DataSource = voList;
            this.gridControl2.RefreshDataSource();
        }

        #region eventbus
        [EventAttr("AddRoomSuccessed")]
        public void AddRoomSuccessed(object sender,RoomVo roomVo)
        {
            clockRoom.AddRoom(new Room(roomVo));
            FillRoom();
        }
        [EventAttr("UpdateRoomSuccessed")]
        public void UpdateRoomSuccessed(object sender, RoomVo updateVo)
        {
            clockRoom.UpdateRoom(updateVo);
        }
        #endregion
    }
}
