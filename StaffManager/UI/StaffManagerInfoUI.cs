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
using ClientCenter.Core;
using ClientCenter.Event;
using ClientCenter.DB;
using StaffManager.Enity;
using ClientCenter.Enity;

namespace StaffManager.UI
{
    public partial class StaffManagerInfoUI : DevExpress.XtraEditors.XtraUserControl
    {
        private StaffSkillForm skillForm;

        public StaffManagerInfoUI(Type type)
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, type);
        }

        #region private method
        private void InitEvents()
        {
            this.Load += StaffManagerInfoUI_Load;
            this.gridView1.MouseUp += GridView1_MouseUp;
            this.btnLookSkill.ItemClick += BtnLookSkill_ItemClick;
            this.gridView1.CustomDrawCell += GridView1_CustomDrawCell;
        }

        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.FieldName== "StaffSex")
            {
                if (Convert.ToInt32(e.CellValue) == 0)
                    e.CellValue = "女";
                else
                    e.CellValue = "男";
            }
        }
        #endregion

        #region public method
        public void SetData(List<StaffInfoVo> voList)
        {
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        #endregion

        #region 
        private void StaffManagerInfoUI_Load(object sender, EventArgs e)
        {
            List<StaffInfoVo> staffList = new List<StaffInfoVo>();
            SelectDao.SelectData(ref staffList);
            SetData(staffList);
        }
        private void BtnLookSkill_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StaffInfoVo staffVo = (StaffInfoVo)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (skillForm==null)
            {
                skillForm = new StaffSkillForm(typeof(StaffSkillVo)) { StaffID=staffVo.StaffId,StaffName= staffVo .StaffName};
            }
            skillForm.ShowDialog();
        }
        private void GridView1_MouseUp(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = this.gridView1.CalcHitInfo(e.Location);
            if (hi.InRow && e.Button == MouseButtons.Right)
            {
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }
        [EventAttr("AddStaffSuccess")]
         public void AddStaffSuccess()
        {
            List<StaffInfoVo> staffList = new List<StaffInfoVo>();
            SelectDao.SelectData(ref staffList);
            SetData(staffList);
        }
        #endregion
    }
}
