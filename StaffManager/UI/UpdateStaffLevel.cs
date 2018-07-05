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
using ClientCenter.Event;
using ClientCenter.DB;

namespace StaffManager.UI
{
    public partial class UpdateStaffLevel : DevExpress.XtraEditors.XtraForm
    {
        StaffLevelVo levelVo;
        public UpdateStaffLevel(StaffLevelVo levelVo)
        {
            InitializeComponent();
            InitEvents();
            this.levelVo = levelVo;
        }

        private void InitEvents()
        {
            this.Load += UpdateStaffLevel_Load;
            this.btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textLevel.Text))
            {
                XtraMessageBox.Show("信息不完整!", "提示");
            }
            StaffLevelVo vo = new StaffLevelVo()
            {
                Id = levelVo.Id,
                StaffLevel = this.textLevel.Text,
                Remark = this.memoRemark.Text
            };
            if (UpdateDao.UpdateByID(vo) > 0)
            {
                XtraMessageBox.Show("操作成功!", "提示");
                EventBus.PublishEvent("AddLevelSuccessed");
            }
            else
            {
                XtraMessageBox.Show("操作失败!", "提示");
            }
        }

        private void UpdateStaffLevel_Load(object sender, EventArgs e)
        {
            this.textLevel.Text = levelVo.StaffLevel;
            this.memoRemark.Text = levelVo.Remark;
        }
    }
}