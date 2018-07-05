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
        HandRoom handRoom;  //手牌会员
        CashierForm cashierFrm; //下单窗口
        MonitorRoom monitorRoom;//钟房信息
        StaffMonitor staffMonitor;//技师信息

        public ForntCashierMainUI()
        {
            InitializeComponent();
            InitEvents();
        }

        #region private method
        private void InitEvents()
        {
            this.Load += ClockRoomMainUI_Load;
            this.SizeChanged += ClockRoomMainUI_SizeChanged;
            this.openOrderBtn.ItemClick += OpenOrderBtn_ItemClick;
            this.roomManageBtn.ItemClick += RoomManageBtn_ItemClick;
            this.roomshowBtn.ItemClick += RoomshowBtn_ItemClick;
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
            handRoom = new HandRoom();

            this.splitContainerControl1.Panel2.Controls.Add(handRoom);
            handRoom.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Add(clockRoom);
            clockRoom.Dock = DockStyle.Fill;
            //测试数据
            int i = 0;
            List<Room> roomVoList = new List<Room>();
            while (i < 150)
            {
                RoomVo vo = new RoomVo() { RoomId = 1, RoomName = "杭州", RoomStatus = i % 2, HandNumber = 100 };
                roomVoList.Add(new Room(vo));
                i++;
            }
            clockRoom.SetRoomList(roomVoList);
        }
        private void ClockRoomMainUI_SizeChanged(object sender, EventArgs e)
        {
            SetPanelInterval();
        }
        private void OpenOrderBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cashierFrm == null)
            {
                cashierFrm = new CashierForm();
            }
            cashierFrm.ShowDialog();
        }
        private void RoomManageBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!(monitorRoom != null&&staffMonitor!=null))
            {
                monitorRoom = new MonitorRoom();
                staffMonitor = new StaffMonitor();
            }
            this.splitContainerControl1.Panel1.Controls.Clear();
            this.splitContainerControl1.Panel2.Controls.Clear();
            this.splitContainerControl1.Panel1.Controls.Add(monitorRoom);
            this.splitContainerControl1.Panel2.Controls.Add(staffMonitor);
            monitorRoom.Dock = DockStyle.Fill;
            staffMonitor.Dock = DockStyle.Fill;
        }
        private void RoomshowBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!(clockRoom != null && handRoom != null))
            {
                clockRoom = new ClockRoom();
                handRoom = new HandRoom();
            }
            this.splitContainerControl1.Panel1.Controls.Clear();
            this.splitContainerControl1.Panel2.Controls.Clear();
            this.splitContainerControl1.Panel1.Controls.Add(clockRoom);
            this.splitContainerControl1.Panel2.Controls.Add(handRoom);
            handRoom.Dock = DockStyle.Fill;
            clockRoom.Dock = DockStyle.Fill;
        }
        #endregion
    }
}
