using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClientCenter.DB;
using ClientCenter.Core;
using ClientCenter.Event;
using ClientCenter.Enity;

namespace ClockRoomManager.UI
{
    public partial class AddRoomForm : DevExpress.XtraEditors.XtraForm
    {
        public AddRoomForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.btnAdd.Click += BtnAdd_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private bool CheckRoomId()
        {
            if(FilterUtil.isNumberic(this.textRoomId.Text))
            {
                int roomId = Convert.ToInt32(this.textRoomId.Text);
                return SelectDao.CheckRoomExist(roomId);
            }
            return false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.textRoomId.Text)|| string.IsNullOrWhiteSpace(this.textRoomName.Text))
            {
                XtraMessageBox.Show("请填写完整信息!");
                return;
            }
            if(CheckRoomId())
            {
                XtraMessageBox.Show("房间编号必须为数字或者房间编号已存在!");
                return;
            }
            RoomVo vo = new RoomVo() { RoomId = Convert.ToInt32(this.textRoomId.Text), RoomName = this.textRoomName.Text ,RoomStatus=this.comboStatus.Text};
            if(InsertDao.InsertData(vo,typeof(RoomVo))>0)
            {
                XtraMessageBox.Show("添加房间成功!");
                EventBus.PublishEvent("AddRoomSuccessed",this,vo);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}