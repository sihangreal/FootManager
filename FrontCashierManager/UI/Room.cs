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
    public partial class Room : DevExpress.XtraEditors.XtraUserControl
    {
        RoomVo roomVo;
        Color redColor = Color.FromArgb(140,60,60);
        Color greenColor = Color.FromArgb(60, 140, 60);

        public Room(RoomVo roomVo)
        {
            this.roomVo = roomVo;
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += Room_Load;
        }

        private void Room_Load(object sender, EventArgs e)
        {
            this.labroomId.Text = this.roomVo.RoomId.ToString();
            this.labroomName.Text = this.roomVo.RoomName;
            this.BackColor= this.roomVo.RoomStatus==0?this.greenColor:this.redColor;
        }
    }
}
