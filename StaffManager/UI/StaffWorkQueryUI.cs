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

namespace StaffManager.UI
{
    public partial class StaffWorkQueryUI : DevExpress.XtraEditors.XtraUserControl
    {
        List<StaffWorkRecordVo> staffRecordList = new List<StaffWorkRecordVo>();
        public StaffWorkQueryUI()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1,typeof(StaffWorkRecordVo));
            staffRecordList = SelectDao.SelectData<StaffWorkRecordVo>();
            this.gridControl1.DataSource = staffRecordList;
            this.gridControl1.RefreshDataSource();
        }

        private void InitEvents()
        {
            this.btnLook.Click += BtnLook_Click;
        }

        private void BtnLook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textEdit1.Text))
                staffRecordList = SelectDao.SelectData<StaffWorkRecordVo>();
            else
                staffRecordList = staffRecordList.Where(v => v.StaffName == this.textEdit1.Text).ToList();
            this.gridControl1.DataSource = staffRecordList;
            this.gridControl1.RefreshDataSource();
        }
    }
}
