using System;
using DevExpress.XtraEditors;
using ClientCenter.Enity;
using ClientCenter.DB;
using ClientCenter.Event;

namespace StaffManager.UI
{
    public partial class UpdateDepartmentForm : DevExpress.XtraEditors.XtraForm
    {
        DepartmentVo departmentVo = new DepartmentVo();
        public UpdateDepartmentForm(DepartmentVo departmentVo)
        {
            this.departmentVo = departmentVo;
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += UpdateDepartmentForm_Load;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textName.Text))
            {
                XtraMessageBox.Show("信息不完整，请重新输入！");
                return;
            }
            DepartmentVo vo = new DepartmentVo()
            {
                Id = Convert.ToInt32(this.textId.Text),
                DepName = this.textName.Text,
                Remark = this.memoRemark.Text
            };
            if (UpdateDao.UpdateByID(vo) > 0)
            {
                XtraMessageBox.Show("操作成功!");
                EventBus.PublishEvent("AddDepartmentSuccessed");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDepartmentForm_Load(object sender, EventArgs e)
        {
            this.textId.Text = departmentVo.Id.ToString();
            this.textName.Text = departmentVo.DepName;
            this.memoRemark.Text = departmentVo.Remark;
        }
    }
}
