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
using StaffManager.Enity;
using ClientCenter.Core;
using ClientCenter.DB;
using ClientCenter.Enity;

namespace StaffManager.UI
{
    public partial class StaffSkillForm : DevExpress.XtraEditors.XtraForm
    {
        private string staffID;
        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
        private string staffName;
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        public StaffSkillForm(Type type)
        {
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, type);
        }
        #region private method
        private void InitEvents()
        {
            this.Load += StaffSkillManager_Load;
            this.gridView1.MouseUp += GridView1_MouseUp;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnDel.ItemClick += BtnDel_ItemClick;
            this.FormClosing += StaffSkillForm_FormClosing;
        }
        private void FillSkill()
        {
            List<SkillVo> voList = new List<SkillVo>();
            SelectDao.SelectData(ref voList);
            foreach(SkillVo vo in voList)
            {
                this.comSkill.Properties.Items.Add(vo.SkillName);
            }
        }
        #endregion

        #region events

        private void StaffSkillManager_Load(object sender, EventArgs e)
        {
            FillSkill();
           List<string> nameList= SelectDao.GetSkillByStaffID(staffID);
            List<StaffSkillVo> voList = new List<StaffSkillVo>();
            foreach (string name in nameList)
            {
                StaffSkillVo vo = new StaffSkillVo();
                vo.SkillName = name;
                vo.StaffName = staffName;
                voList.Add(vo);
            }
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        private void GridView1_MouseUp(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = this.gridView1.CalcHitInfo(e.Location);
            if (hi.InRow && e.Button == MouseButtons.Right)
            {
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }
        private void BtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
          if(ProcedureDao.AddStaffSkill(staffID,this.comSkill.Text)>0)
            {
                StaffSkillVo vo = new StaffSkillVo() { SkillName= this.comSkill.Text,StaffName=this.staffName};
                List<StaffSkillVo> voList = (List<StaffSkillVo>)this.gridView1.DataSource;
                voList.Add(vo);
                this.gridControl1.RefreshDataSource();
            }
        }
        private void StaffSkillForm_FormClosing(object sender, FormClosingEventArgs e)
        {
    
        }
        #endregion
    }
}