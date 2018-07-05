using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FrontCashierManager.UI;
using FrontCashierManager.Enity;

namespace FrontCashierManager
{
    public partial class ForntCashierMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        ClockRoom clockRoom; //钟房
        QuickRoom quickRoom;  //快速查找
        CashierForm cashierFrm; //下单窗口
        QuickStaff quickStaff;//钟房信息
        StaffMonitor staffMonitor;//技师信息

        public ForntCashierMainUI()
        {
            InitializeComponent();
            //InitEvents();
        }

        #region private method
        private void InitEvents()
        {
            this.Load += ClockRoomMainUI_Load;
            this.SizeChanged += ClockRoomMainUI_SizeChanged;
            this.btnOpenOrder.ItemClick += btnOpenOrder_ItemClick;
            this.btnRoomManger.ItemClick += btnRoomManger_ItemClick;
            this.btnRoomShow.ItemClick += btnRoomShow_ItemClick;
        }
        //调整split的位置
        private void SetPanelInterval()
        {
            this.splitContainerControl1.SplitterPosition = (7 * this.splitContainerControl1.Size.Width) / 10;
        }
        #endregion

        #region public method

        #endregion

        #region events
        private void ClockRoomMainUI_Load(object sender, EventArgs e)
        {
            clockRoom = new ClockRoom();
            quickRoom = new QuickRoom();
            this.splitContainerControl1.Panel2.Controls.Add(quickRoom);
            quickRoom.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Add(clockRoom);
            clockRoom.Dock = DockStyle.Fill;
            //测试数据
            int i = 0;
            List<Room> roomVoList = new List<Room>();
            while (i < 150)
            {
                RoomVo vo = new RoomVo() { RoomId = i+1, RoomName = "杭州", RoomStatus = i % 2 };
                roomVoList.Add(new Room(vo));
                i++;
            }
            clockRoom.SetRoomList(roomVoList);
        }
        private void ClockRoomMainUI_SizeChanged(object sender, EventArgs e)
        {
            SetPanelInterval();
        }
        private void btnOpenOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cashierFrm == null)
            {
                cashierFrm = new CashierForm();
            }
            cashierFrm.ShowDialog();
        }
        private void btnRoomManger_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!(quickStaff != null && staffMonitor != null))
            {
                quickStaff = new QuickStaff(typeof(QuickStaffVo));
                staffMonitor = new StaffMonitor(typeof(StaffMonitorVo));
            }
            this.splitContainerControl1.Panel1.Controls.Clear();
            this.splitContainerControl1.Panel2.Controls.Clear();
            this.splitContainerControl1.Panel1.Controls.Add(staffMonitor);
            this.splitContainerControl1.Panel2.Controls.Add(quickStaff);
            quickStaff.Dock = DockStyle.Fill;
            staffMonitor.Dock = DockStyle.Fill;
        }
        private void btnRoomShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!(clockRoom != null && quickRoom != null))
            {
                clockRoom = new ClockRoom();
                quickRoom = new QuickRoom();
            }
            this.splitContainerControl1.Panel1.Controls.Clear();
            this.splitContainerControl1.Panel2.Controls.Clear();
            this.splitContainerControl1.Panel1.Controls.Add(clockRoom);
            this.splitContainerControl1.Panel2.Controls.Add(quickRoom);
            quickRoom.Dock = DockStyle.Fill;
            clockRoom.Dock = DockStyle.Fill;
        }
        #endregion

    }
}
