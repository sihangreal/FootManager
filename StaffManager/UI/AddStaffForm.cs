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
    public partial class AddStaffForm : DevExpress.XtraEditors.XtraForm
    {
        public AddStaffForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += AddStaffForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnReset.Click += BtnReset_Click;
        }
        private bool CheckParam()
        {
            return (!this.textId.Text.Equals("") && !this.textName.Text.Equals("") && !this.comLevel.Text.Equals("")
                && !this.comSex.Text.Equals("") && !this.textSalary.Text.Equals(""));
        }
        private void FillDepartment()
        {
            List<DepartmentVo> daoVoList = new List<DepartmentVo>();
            SelectDao.SelectData(ref daoVoList);
            this.comboPartment.Properties.Items.Clear();
            foreach (DepartmentVo vo in daoVoList)
            {
                this.comboPartment.Properties.Items.Add(vo.DepName);
            }
        }
        private void FillLevel()
        {
            List<StaffLevelVo> daoVoList = new List<StaffLevelVo>();
            SelectDao.SelectData(ref daoVoList);
            this.comLevel.Properties.Items.Clear();
            foreach (StaffLevelVo vo in daoVoList)
            {
                this.comLevel.Properties.Items.Add(vo.StaffLevel);
            }
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckParam())
            {
                XtraMessageBox.Show("员工信息不完整!", "提示");
                return;
            }
            object[] infoArry = new object[]
            {
                this.textId.Text,
                this.textName.Text,
                this.comSex.Text,
                this.textPlace.Text,
                this.comLevel.Text,
                this.comboPartment.Text,
                this.textIdNum.Text,
                Convert.ToDouble(this.textSalary.Text),
                this.checkCommsion.Checked ? "是" : "否"
            };
            if (ProcedureDao.StaffRegister(infoArry) > 0)
            {
                XtraMessageBox.Show("操作成功!", "提示");
                this.DialogResult = DialogResult.OK;
                //EventBus.PublishEvent("AddStaffSuccessed");
                EventBus.PublishEvent("StaffWorkStatusChange");
            }
            else
            {
                XtraMessageBox.Show("操作失败!", "提示");
            }
        }

        private void AddStaffForm_Load(object sender, EventArgs e)
        {
            FillDepartment();
            FillLevel();
        }
    }
}