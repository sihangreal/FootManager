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
using ClientCenter.DB;
using ClientCenter.Enity;
using ClientCenter.Core;
using ClientCenter.Event;
using ClientCenter.GridViews;

namespace ClockRoomManager.UI
{
    public partial class StaffQueryUI : DevExpress.XtraEditors.XtraUserControl
    {

        public StaffQueryUI()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += StaffQueryUI_Load;
            this.gridView1.CustomDrawCell += GridView1_CustomDrawCell;
        }

        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.FieldName.Equals("StaffStatus"))
            {
                string strstatus = e.CellValue.ToString();
                if (strstatus.Equals("空闲"))
                    e.Appearance.BackColor = Color.FromArgb(80,220,80);
                    
                else
                    e.Appearance.BackColor = Color.FromArgb(220, 220, 50);
            }
        }

        public void RefeshStaffInfo()
        {
           DataTable dt = SelectDao.SelectData(typeof(StaffWorkInfoVo)); 
            this.gridControl1.DataSource = dt;
            this.gridControl1.RefreshDataSource();
            this.gridView1.BestFitColumns();
        }

        private void RefeshStaffInfoByGender(string sex)
        {
            DataTable dt = SelectDao.SelectStaffByGender(sex);
            this.gridControl1.DataSource = dt;
            this.gridControl1.RefreshDataSource();
            this.gridView1.BestFitColumns();
        }
        private void StaffQueryUI_Load(object sender, EventArgs e)
        {
            GridViewUtil.InitGridView(this.gridView1, typeof(StaffWorkInfoVo));
            RefeshStaffInfo();
        }

        [EventAttr("StaffWorkStatusChange")]
        public void StaffWorkStatusChange()
        {
            RefeshStaffInfo();
        }
    }
}
