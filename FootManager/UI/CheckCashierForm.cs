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
using ClientCenter.Core;
using ClientCenter.Enity;
using ClientCenter.DB;

namespace FootManager.UI
{
    public partial class CheckCashierForm : DevExpress.XtraEditors.XtraForm
    {
        public CheckCashierForm()
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

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            
        }

    }
}