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
            //this.documentViewer1.DocumentSource = report;
            //report.CreateDocument(false);
        }

        public void SetData<T>(List<T> tList)
        {
            XtraReport1 report = new XtraReport1();
            this.documentViewer1.DocumentSource = report;
            report.SetTableSource(tList);
            report.CreateDocument(false);
        }
    }
}
