using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using ClientCenter.Enity;

namespace ReportManager.Report
{
    public partial class MemberConsumeReport : DevExpress.XtraReports.UI.XtraReport
    {
        public MemberConsumeReport()
        {
            InitializeComponent();
        }
        public MemberConsumeReport(List<MemberConsumeVo> consumeVoList):this()
        {
            InitializeComponent();
            this.DataSource = consumeVoList;
        }
    }
}
