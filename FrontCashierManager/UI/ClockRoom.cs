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
using FrontCashierManager.Enity;

namespace FrontCashierManager.UI
{
    public partial class ClockRoom : DevExpress.XtraEditors.XtraUserControl
    {
        private List<Room> roomList;

        public ClockRoom()
        {
            InitializeComponent();
            InitEvents(); 
        }

        #region private method
        private void InitEvents()
        {
            this.Load += ClockRoom_Load;
            this.vScrollBar1.Scroll += VScrollBar1_Scroll;
            this.groupControl1.SizeChanged += GroupControl1_SizeChanged;
        }

        public void SetRoomList(List<Room> roomList)
        {
            this.roomList = roomList;
        }

        int winterval = 20; int hinterval = 20;
        int ctrW = 130; int ctrH = 100;
        private void LayoutRooms()
        {
            int count = 0;
            int totalHight = 0;
            int wfre = 0;
            int hfre = 0;
            int wcount = this.groupControl1.Width / (winterval + ctrW);
            while (count < this.roomList.Count)
            {
                Room room = roomList[count];
                room.Size = new Size(ctrW, ctrH);
                room.Location = new Point(winterval + wfre * (ctrW + winterval), hinterval + hfre * (ctrH + hinterval));
                this.groupControl1.Controls.Add(room);
                if (wfre < wcount-1)
                {
                    wfre++;
                }
                else
                {
                    wfre = 0;
                    hfre++;
                }
                count++;
                if (count == this.roomList.Count - 1)
                {
                    totalHight = hinterval + hfre * (ctrH + hinterval);
                }
            }
            SetGroupHeight(totalHight);
            SetScrollHeight();
        }

        private void SetGroupHeight(int totalHight)
        {
            if (totalHight > this.Height)
            {
                this.vScrollBar1.Visible = true;
                this.groupControl1.Height = totalHight + hinterval;
            }
            else
            {
                this.vScrollBar1.Visible = false;
                this.groupControl1.Dock = DockStyle.Fill;
            }
        }
        private void SetScrollHeight()
        {
            vScrollBar1.Maximum = this.groupControl1.Height - this.Height;
            vScrollBar1.LargeChange = this.Height / (this.groupControl1.Height / (ctrH + hinterval));
        }
        #endregion

        #region events
        private void ClockRoom_Load(object sender, EventArgs e)
        {

        }
        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Point p = this.groupControl1.Location;
            p.Y = 0 - (int)(e.NewValue);
            groupControl1.Location = p;
        }
        private void GroupControl1_SizeChanged(object sender, EventArgs e)
        {
            if (roomList != null)
            {
                LayoutRooms();
            }
        }
        #endregion
    }
}
