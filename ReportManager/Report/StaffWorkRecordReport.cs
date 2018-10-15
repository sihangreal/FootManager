using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ClientCenter.Enity;
using System.Collections.Generic;

namespace ReportManager.Report
{
    public partial class StaffWorkRecordReport : DevExpress.XtraReports.UI.XtraReport
    {
        public StaffWorkRecordReport()
        {
            InitializeComponent();
        }

        public StaffWorkRecordReport(List<StaffWorkRecordVo> staffWorkRecordVoList):this()
        {
            InitializeComponent();
            this.DataSource = staffWorkRecordVoList;
        }
    }
}
