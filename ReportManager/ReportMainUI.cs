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

namespace ReportManager
{
    public partial class ReportMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        public ReportMainUI()
        {
            InitializeComponent();
            InitEvents();
        }

        #region private method
        private void InitEvents()
        {
            this.Load += ReportMainUI_Load;
        }
        #endregion

        #region events
        private void ReportMainUI_Load(object sender, EventArgs e)
        {
            XtraReportTest reportTest = new XtraReportTest();
            this.documentViewer1.DocumentSource = reportTest;
            reportTest.CreateDocument(false);
        }
        #endregion
    }
}
