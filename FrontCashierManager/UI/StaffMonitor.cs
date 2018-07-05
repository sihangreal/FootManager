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
using FrontCashierManager.Enity;

namespace FrontCashierManager.UI
{
    public partial class StaffMonitor : DevExpress.XtraEditors.XtraUserControl
    {
        public StaffMonitor(Type type)
        {
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, type);
        }

        #region private method
        private void InitEvents()
        {
            this.Load += StaffMonitor_Load;
        }
        #endregion

        #region public method
        public void SetData(List<StaffMonitorVo> voList)
        {
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        #endregion


        #region events
        private void StaffMonitor_Load(object sender, EventArgs e)
        {
            //test
            List<StaffMonitorVo> voList = new List<StaffMonitorVo>() {
                new StaffMonitorVo() { StaffName="张三",RoomName="杭州",StaffSex="男", Oppoint="否",StartTime="2017-8-9 22:00",EndTime="2017-8-9 23:00",OverTime="0",ProjectName="按摩" },
                new StaffMonitorVo() { StaffName="春梅",RoomName="上海",StaffSex="女", Oppoint="否",StartTime="2017-8-9 22:00",EndTime="2017-8-9 23:00",OverTime="0",ProjectName="按摩" },
            };
            SetData(voList);
        }
        #endregion
    }
}
