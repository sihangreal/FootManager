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
using MemberManager.Enity;
using ClientCenter.DB;
using ClientCenter.Event;

namespace MemberManager.UI
{
    public partial class MemberRecharge : DevExpress.XtraEditors.XtraUserControl
    {
        public MemberRecharge()
        {
            EventBus.RegisterEvent(this);
            InitializeComponent();
            InitEvents();
            GridViewUtil.CreateColumnForData(this.gridView1, typeof(MemberRechargeVo));
        }

        private void InitEvents()
        {
            this.btnQuery.Click += BtnQuery_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnRecharge.Click += BtnRecharge_Click;
        }

        private void BtnRecharge_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            FillMemberRecharge();
        }

        private void FillMemberRecharge()
        {
            DataTable dt = SelectDao.GetMemberRechargeByName(this.textName.Text);
            this.gridControl1.DataSource = dt;
            this.gridControl1.RefreshDataSource();
            this.gridView1.BestFitColumns();
        }
    }
}
