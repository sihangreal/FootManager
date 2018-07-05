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
using ClientCenter.Enity;

namespace StaffManager.UI
{
    public partial class StaffWorkInfoUI : DevExpress.XtraEditors.XtraUserControl
    {
        public StaffWorkInfoUI(Type type)
        {
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, type);
        }

        #region private method
        private void InitEvents()
        {
            this.Load += StaffWorkInfoUI_Load;
        }
        #endregion

        #region public method
        public void SetData(List<StaffWorkInfoVo> voList)
        {
            this.gridControl1.DataSource = voList;
            this.gridControl1.RefreshDataSource();
        }
        #endregion

        #region events

        private void StaffWorkInfoUI_Load(object sender, EventArgs e)
        {
            //-test
            //List<StaffWorkInfoVo> voList = new List<StaffWorkInfoVo>() {
            //    new StaffWorkInfoVo() { StaffName="张三",StaffSex="男",StaffSatus="空闲",LatestStartTime="2017-11-7 20:30",LatestendTime="2017-11-7 22:30"},
            //    new StaffWorkInfoVo() { StaffName="春梅",StaffSex="女",StaffSatus="空闲",LatestStartTime="2017-11-7 20:30",LatestendTime="2017-11-7 22:30"},
            //};
            //SetData(voList);
        }
        #endregion
    }
}
