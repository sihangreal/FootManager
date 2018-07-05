using System;
using System.Drawing;
using ClientCenter.Enity;
using System.Windows.Forms;

namespace ClockRoomManager.UI
{
    public partial class Room : DevExpress.XtraEditors.XtraUserControl
    {
        RoomVo roomVo;
        //Color redColor = Color.FromArgb(220, 120, 120);
        //Color greenColor = Color.FromArgb(120, 220, 120);

        Image greenImg = ClockRoomManager.Properties.Resources.green;
        Image orangeImg = ClockRoomManager.Properties.Resources.orange;

        int roomID;
        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        public Room(RoomVo roomVo)
        {
            this.roomVo = roomVo;
            roomID = roomVo.RoomId;
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += Room_Load;
            this.Click += Room_Click;
        }

        private void Room_Click(object sender, EventArgs e)
        {
            //if(roomVo.RoomStatus.Equals("空闲"))
            //{

            //    AddOrderForm addOrderForm = new AddOrderForm();
            //    addOrderForm.ShowDialog();
            //}
            //else
            //{
            //    OrderInfoForm infoForm = new OrderInfoForm();
            //    infoForm.ShowDialog();
            //}
            OrderInfoForm infoForm = new OrderInfoForm(roomVo);
            if(infoForm.ShowDialog()== DialogResult.OK)
            {
                this.BackgroundImage = orangeImg;
            }
        }

        private void Room_Load(object sender, EventArgs e)
        {
            this.labroomId.Text = this.roomVo.RoomId.ToString();
            this.labroomName.Text = this.roomVo.RoomName;
            this.BackgroundImage = this.roomVo.RoomStatus.Equals("空闲") ? greenImg : orangeImg;
        }

        public void UpdateRoomVo(RoomVo roomVo)
        {
            this.roomVo = roomVo;
            this.labroomName.Text = this.roomVo.RoomName;
            this.BackgroundImage = this.roomVo.RoomStatus.Equals("空闲") ? greenImg : orangeImg;
        }

    }
}
