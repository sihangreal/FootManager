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
using StaffManager.Enity;

namespace StaffManager.UI
{ 
    public partial class StaffsUI : DevExpress.XtraEditors.XtraUserControl
    {
        private List<Staff> staffList;

        public StaffsUI()
        {
            InitializeComponent();
            InitEvents();
        }

        #region private method
        private void InitEvents()
        {
            this.Load += StaffsUI_Load;
            this.vScrollBar1.Scroll += VScrollBar1_Scroll;
            this.groupControl1.SizeChanged += GroupControl1_SizeChanged;
        }

        public void SetStaffList(List<Staff> staffList)
        {
            this.staffList = staffList;
        }

        int winterval = 15; int hinterval = 20;
        int ctrW = 150; int ctrH = 120;
        private void LayoutRooms()
        {
            int count = 0;
            int totalHight = 0;
            int wfre = 0;
            int hfre = 0;
            int wcount = this.groupControl1.Width / (winterval + ctrW);
            while (count < this.staffList.Count)
            {
                Staff staff = staffList[count];
                //测试
                staff.MouseDown += Staff_MouseDown;
                staff.MouseUp += Staff_MouseUp;
                staff.MouseMove += Staff_MouseMove;


                staff.Size = new Size(ctrW, ctrH);
                staff.Location = new Point(winterval + wfre * (ctrW + winterval), hinterval + hfre * (ctrH + hinterval));
                this.groupControl1.Controls.Add(staff);
                if (wfre < wcount - 1)
                {
                    wfre++;
                }
                else
                {
                    wfre = 0;
                    hfre++;
                }
                count++;
                if (count == this.staffList.Count - 1)
                {
                    totalHight = hinterval + hfre * (ctrH + hinterval);
                }
            }
            SetGroupHeight(totalHight);
            SetScrollHeight();
        }

        Point pt;
        bool moves = true;

        private void Staff_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = (sender as Control);
            if (e.Button == MouseButtons.Left)
            {
                int px = Cursor.Position.X - pt.X;
                int py = Cursor.Position.Y - pt.Y;
                control.Location = new Point(control.Location.X + px, control.Location.Y + py);
                pt = Cursor.Position;
                moves = false;
            }
        }

        private void Staff_MouseDown(object sender, MouseEventArgs e)
        {
            pt = Cursor.Position;
        }

        private void Staff_MouseUp(object sender, MouseEventArgs e)
        {
            moves = true;
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
        private void StaffsUI_Load(object sender, EventArgs e)
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
            if (staffList != null)
            {
                LayoutRooms();
            }
        }
        #endregion
    }
}
