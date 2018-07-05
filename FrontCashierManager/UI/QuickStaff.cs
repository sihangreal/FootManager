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
using FrontCashierManager.Enity;
using ClientCenter.Core;

namespace FrontCashierManager.UI
{
    public partial class QuickStaff : DevExpress.XtraEditors.XtraUserControl
    {
        public QuickStaff(Type type)
        {
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, type);
        }

        #region private method
        private void InitEvents()
        {
            this.Load += MonitorRoom_Load;
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
            //test
            List<QuickStaffVo> voList = new List<QuickStaffVo>() {
                new QuickStaffVo() { StaffName="张三",Sequence=20,StaffSex="男", Count=5},
                new QuickStaffVo() { StaffName="春梅",Sequence=21,StaffSex="女",Count=10}
            };
            SetData(voList);
        }
        #endregion
    }
}
