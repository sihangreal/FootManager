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
using ReportManager.Enity;
using ClientCenter.Enity;

namespace ReportManager.Report
{
    public partial class ReportControl : DevExpress.XtraEditors.XtraUserControl
    {
   

        public ReportControl()
        {
            InitializeComponent();
            this.Load += ReportControl_Load;
        }

        private void ReportControl_Load(object sender, EventArgs e)
        {

        }

        public void SetSalesData(List<SalesVo> tList)
        {
            SalesReport report = new SalesReport(tList);
            this.documentViewer1.DocumentSource = report;
            report.CreateDocument(false);
        }

        public void SetStaffWorkRecordData(List<StaffWorkRecordVo> tList)
        {
            StaffWorkRecordReport report = new StaffWorkRecordReport(tList);
            this.documentViewer1.DocumentSource = report;
            report.CreateDocument(false);
        }
    }
}
