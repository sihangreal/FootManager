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
using ClientCenter.Enity;
using ClientCenter.DB;

namespace SettlementCenter
{
    public partial class SettlementMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        public SettlementMainUI()
        {
            InitializeComponent();
            Init();
            InitEvents();
        }
        private void Init()
        {
            GridViewUtil.CreateColumnForData(this.gridView1, typeof(TempOrderVo));
        }
        private void InitEvents()
        {
            this.btnQuery.Click += BtnQuery_Click;
            this.btnReadCard.Click += BtnReadCard_Click;
            this.Load += CheckCashierForm_Load;
        }

        private void CheckCashierForm_Load(object sender, EventArgs e)
        {
            List<TempOrderVo> tempList = new List<TempOrderVo>();
            SelectDao.SelectData(ref tempList);
            this.gridControl1.DataSource = tempList;
            this.gridView1.BestFitColumns();
            this.gridControl1.RefreshDataSource();
        }

        private void BtnReadCard_Click(object sender, EventArgs e)
        {
            string errorStr = default(string);
            string memberId = D3Core.ReadMemberCard(out errorStr);
            if (memberId != null)
                this.textMemberId.Text = memberId;
            else
                XtraMessageBox.Show(errorStr);
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {

        }
    }
}
