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
    public partial class UpdateStaffForm : DevExpress.XtraEditors.XtraForm
    {
        StaffInfoVo staffInfo;
        public UpdateStaffForm(StaffInfoVo staffInfo)
        {
            this.staffInfo = staffInfo;
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += UpdateStaffForm_Load;
            this.btnQuery.Click += BtnQuery_Click;
            this.btnCancel.Click += BtnCancel_Click;
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
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (!CheckParam())
            {
                XtraMessageBox.Show("员工信息不完整!", "提示");
            }
            StaffInfoVo vo = new StaffInfoVo()
            {
                StaffId = this.textId.Text,
                StaffName = this.textName.Text,
                StaffLevel = this.comLevel.Text,
                StaffPlace = this.textPlace.Text,
                StaffSex = this.comSex.Text,
                BasicSalary = Convert.ToDouble(this.textSalary.Text),
                Department = this.comboPartment.Text,
                Commision = this.checkCommsion.Checked ? "是" : "否",
                IdNumber = this.textIdNum.Text
            };
            if (UpdateDao.UpdateByID(vo) > 0)
            {
                XtraMessageBox.Show("操作成功!", "提示");
                EventBus.PublishEvent("AddStaffSuccessed");
            }
            else
            {
                XtraMessageBox.Show("操作失败!", "提示");
            }
        }

        private void UpdateStaffForm_Load(object sender, EventArgs e)
        {
            FillDepartment();
            this.textId.Text = staffInfo.StaffId;
            this.textName.Text = staffInfo.StaffName;
            this.comLevel.Text = staffInfo.StaffLevel;
            this.textPlace.Text = staffInfo.StaffPlace;
            this.comSex.Text = staffInfo.StaffSex;
            this.textSalary.Text = staffInfo.BasicSalary.ToString();
            this.comboPartment.Text = staffInfo.Department;
            this.checkCommsion.Checked = staffInfo.Commision == "是" ? true : false;
            this.textIdNum.Text = staffInfo.IdNumber;
        }
    }
}