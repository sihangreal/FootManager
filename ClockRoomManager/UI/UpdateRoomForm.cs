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
using ClientCenter.Enity;
using ClientCenter.DB;
using ClientCenter.Event;

namespace ClockRoomManager.UI
{
    public partial class UpdateRoomForm : DevExpress.XtraEditors.XtraForm
    {
        RoomVo roomVo = new RoomVo();

        public UpdateRoomForm(RoomVo roomVo)
        {
            this.roomVo = roomVo;
            InitializeComponent();
            InitEvents();
        }

        #region private method
        private void InitEvents()
        {
            this.Load += UpdateRoomForm_Load;
            this.btnUpdate.Click += BtnUpdate_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }
        #endregion

        #region events
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            roomVo.RoomName = this.textRoomName.Text;
            roomVo.RoomStatus = this.comboStatus.Text;
            if (UpdateDao.UpdateByID(roomVo) > 0)
            {
                XtraMessageBox.Show("操作成功!", "提示");
                EventBus.PublishEvent("UpdateRoomSuccessed",this,roomVo);
            }
        }

        private void UpdateRoomForm_Load(object sender, EventArgs e)
        {
            textRoomId.Text = roomVo.RoomId.ToString();
            textRoomName.Text = roomVo.RoomName;
            comboStatus.Text = roomVo.RoomStatus;
        }
        #endregion
    }
}