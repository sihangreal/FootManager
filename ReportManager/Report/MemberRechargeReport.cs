using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using ClientCenter.Enity;

namespace ReportManager.Report
{
    public partial class MemberRechargeReport : DevExpress.XtraReports.UI.XtraReport
    {
        public MemberRechargeReport()
        {
            InitializeComponent();
        }

        public MemberRechargeReport(List<MemberRechargeVo> rechargeVoList):this()
        {
            InitializeComponent();
            this.DataSource = rechargeVoList;
        }
    }
}
