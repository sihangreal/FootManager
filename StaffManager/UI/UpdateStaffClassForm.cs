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

namespace StaffManager.UI
{
    public partial class UpdateStaffClassForm : DevExpress.XtraEditors.XtraForm
    {
        StaffClassVo classVo = new StaffClassVo();

        public UpdateStaffClassForm(StaffClassVo classVo)
        {
            this.classVo = classVo;
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += UpdateStaffClassForm_Load;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txetName.Text))
            {
                XtraMessageBox.Show("信息不完整，请重新输入！");
                return;
            }
            StaffClassVo vo = new StaffClassVo()
            {
                StaffClassID = classVo.StaffClassID,
                StaffClassName = this.txetName.Text,
                StartTime = Convert.ToInt32(this.dateStart.Text),
                EndTime = Convert.ToInt32(this.dateEnd.Text),
                Remark = this.memoRemark.Text
            };
            if (UpdateDao.UpdateByID(vo) > 0)
            {
                XtraMessageBox.Show("操作成功!");
                EventBus.PublishEvent("AddClassSuccessed");
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateStaffClassForm_Load(object sender, EventArgs e)
        {
            this.txetName.Text = classVo.StaffClassName;
            this.dateStart.Text = classVo.StartTime.ToString();
            this.dateEnd.Text = classVo.EndTime.ToString();
        }
    }
}