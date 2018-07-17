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
using System.Globalization;
using ReportManager.Report;

namespace ReportManager
{
    public partial class ReportMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        private ReportControl reportControl = new ReportControl();
        private Dictionary<string, XtraReport> reportDic = new Dictionary<string, XtraReport>();

        public ReportMainUI()
        {
            InitializeComponent();
            InitEvents();
            InitReportDic();
        }

        private static int WeekOfYear(DateTime dt, CultureInfo ci)
        {
            return ci.Calendar.GetWeekOfYear(dt, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
        }

        private static int MonthOfYear(DateTime dt)
        {
            return dt.Month;
        }

        #region private method
        private void InitEvents()
        {
            this.Load += ReportMainUI_Load;
            this.dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
        }

        private void InitReportDic()
        {
            reportDic.Add("日营业报表", new SalesReport());
            reportDic.Add("周营业报表", new SalesReport());
            reportDic.Add("月营业报表", new SalesReport());
            reportDic.Add("年营业报表", new SalesReport());

            reportDic.Add("日营业报表", new SalesReport());
            reportDic.Add("周营业报表", new SalesReport());
            reportDic.Add("月营业报表", new SalesReport());
            reportDic.Add("年营业报表", new SalesReport());

            reportDic.Add("会员充值报表", new SalesReport());
        }
        #endregion

        #region events
        private void ReportMainUI_Load(object sender, EventArgs e)
        {
            reportControl.Dock = DockStyle.Fill;
            this.reportPanel.Controls.Add(reportControl);
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }
        #endregion
    }
}
