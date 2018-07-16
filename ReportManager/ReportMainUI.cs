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
using DevExpress.XtraReports.UI;

namespace ReportManager
{
    public partial class ReportMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        private Dictionary<string, XtraReport> reportDic = new Dictionary<string, XtraReport>();

        public ReportMainUI()
        {
            InitializeComponent();
            InitEvents();
            InitReportDic();
        }

        #region private method
        private void InitEvents()
        {
            this.Load += ReportMainUI_Load;
            this.btnQuery.ItemClick += BtnQuery_ItemClick;
        }

        private void BtnQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport report = reportDic[barEditItem1.EditValue.ToString()];
            this.documentViewer1.DocumentSource = report;
            report.CreateDocument(false);
        }

        private void InitReportDic()
        {
            reportDic.Add("营业报表",new SalesReport());
            reportDic.Add("员工做工报表", new SalesReport());
            reportDic.Add("详细订单报表", new SalesReport());
            foreach(string key in reportDic.Keys)
            {
                this.repositoryItemComboBox1.Items.Add(key);
            }
            this.barEditItem1.EditValue = "营业报表";
        }
        #endregion

        #region events
        private void ReportMainUI_Load(object sender, EventArgs e)
        {
            //XtraReportTest reportTest = new XtraReportTest();
            //this.documentViewer1.DocumentSource = reportTest;
            //reportTest.CreateDocument(false);
        }
        #endregion
    }
}
