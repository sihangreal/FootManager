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
using StaffManager.Enity;
using ClientCenter.DB;
using ClientCenter.Event;
using ClientCenter.Core;
using ClientCenter.Enity;

namespace StaffManager.UI
{
    public partial class StaffManagerUI : DevExpress.XtraEditors.XtraUserControl
    {
        public StaffManagerUI()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
        }

        #region private method
        private void InitEvents()
        {
            this.Load += StaffManagerUI_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnReset.Click += BtnReset_Click;
            this.textSalary.KeyUp += TextSalary_KeyUp;
        }
        private bool CheckParam()
        {
            return (!this.textId.Text.Equals("") && !this.textName.Text.Equals("") && !this.comLevel.Text.Equals("")
                &&!this.comSex.Text.Equals("")&&!this.textSalary.Text.Equals("")&&
                !this.checkCommsion.Text.Equals(""));
        }
        private void FillDepartment()
        {
            List<ClientCenter.Enity.DepartmentVo> daoVoList = new List<DepartmentVo>();
            SelectDao.SelectData(ref daoVoList);
            this.comboPartment.Properties.Items.Clear();
            foreach (DepartmentVo vo in daoVoList)
            {
                this.comboPartment.Properties.Items.Add(vo.DepName);
            }
        }
        private void FillLevel()
        {
                this.comLevel.Properties.Items.AddRange(new string[] { "低级", "中级", "高级" });
        }
        #endregion

        #region event
        private void StaffManagerUI_Load(object sender, EventArgs e)
        {
            this.comSex.Properties.Items.AddRange(new string[] { "男","女"});
            FillDepartment();
            FillLevel();
        }
        private void TextSalary_KeyUp(object sender, KeyEventArgs e)
        {
            if(!FilterUtil.isNumberic(this.textSalary.Text))
            {
                this.textSalary.Text = "";
                XtraMessageBox.Show("请输入正确的数字!", "提示");
            }
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
    
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(!CheckParam())
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
                Commision = this.checkCommsion.Checked ? "是": "否",
                IdNumber = this.textIdNum.Text
            };
            if(InsertDao.InsertData(vo,typeof(StaffInfoVo))>0)
            {
                XtraMessageBox.Show("操作成功!","提示");
                EventBus.PublishEvent("AddStaffSuccess");
            }
            else
            {
                XtraMessageBox.Show("操作失败!", "提示");
            }
        }
        [EventAttr("AddDepartmentSuccess")]
        public void AddDepartmentSuccess()
        {
            FillDepartment();
        }
        [EventAttr("DelDepartmentSuccess")]
        public void DelDepartmentSuccess()
        {
            FillDepartment();
        }
        [EventAttr("AddSkillSuccess")]
        public void AddSkillSuccess()
        {
            //FillSkill();
        }
        [EventAttr("DelSkillSuccess")]
        public void DelSkillSuccess()
        {
            //FillSkill();
        }
        #endregion
    }
}
