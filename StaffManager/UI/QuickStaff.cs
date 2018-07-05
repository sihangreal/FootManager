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
using StaffManager.Enity;

namespace StaffManager.UI
{
    public partial class QuickStaff : DevExpress.XtraEditors.XtraUserControl
    {
        public QuickStaff(Type type)
        {
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, type);
        }

        #region
        private void InitEvents()
        {
            this.Load += MonitorRoom_Load;
        }

        private void FillCombox()
        {
           // List<SeverVo> 
        }
        #endregion

        #region public method
        public void SetData(List<QuickStaffVo> voList)
        {
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        #endregion

        #region events
        private void MonitorRoom_Load(object sender, EventArgs e)
        {
            //-test
            List<QuickStaffVo> voList = new List<QuickStaffVo>() {
                new QuickStaffVo() { StaffID="A001", StaffName="张三",ServerName="按摩",StaffSex="男", Time="30分钟"},
                new QuickStaffVo() { StaffID="B002",StaffName="春梅",ServerName="按摩",StaffSex="女",Time="30分钟"}
            };
            SetData(voList);
        }
        #endregion
    }
}
