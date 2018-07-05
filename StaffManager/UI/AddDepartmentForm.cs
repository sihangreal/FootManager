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
using ClientCenter.Core;
using ClientCenter.Enity;
using ClientCenter.DB;
using ClientCenter.Event;

namespace StaffManager.UI
{
    public partial class AddDepartmentForm : DevExpress.XtraEditors.XtraForm
    {
        public AddDepartmentForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += AddDepartmentForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }
        private void AddDepartmentForm_Load(object sender, EventArgs e)
        {

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!FilterUtil.isNumberic(this.textId.Text))
            {
                XtraMessageBox.Show("请输入正确的数字!");
                return;
            }
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
            if (InsertDao.InsertData(vo, typeof(DepartmentVo)) > 0)
            {
                XtraMessageBox.Show("添加部门成功!");
                EventBus.PublishEvent("AddDepartmentSuccessed");
            }
        }
    }
}