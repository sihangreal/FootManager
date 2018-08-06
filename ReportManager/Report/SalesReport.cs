using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using ReportManager.Enity;

namespace ReportManager.Report
{
    public partial class SalesReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SalesReport()
        {
            InitializeComponent();
        }
        public SalesReport(List<SalesVo> salesVoList):this()
        {
            InitializeComponent();
            this.DataSource = salesVoList;
        }
    }
}
