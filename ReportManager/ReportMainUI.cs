﻿using System;
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
using DevExpress.XtraBars.Navigation;
using ReportManager.Enity;
using ClientCenter.DB;
using ClientCenter.Enity;

namespace ReportManager
{
    public partial class ReportMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        private ReportControl reportControl = new ReportControl();
        private Dictionary<string, Type> reportDic = new Dictionary<string, Type>();

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
            this.accordionControlElement4.Click += AccordionControlElement_Click;
            this.accordionControlElement5.Click += AccordionControlElement_Click;
            this.accordionControlElement6.Click += AccordionControlElement_Click;
            this.accordionControlElement7.Click += AccordionControlElement_Click;
            this.accordionControlElement8.Click += AccordionControlElement_Click;
            this.accordionControlElement9.Click += AccordionControlElement_Click;
            this.accordionControlElement10.Click += AccordionControlElement_Click;
            this.accordionControlElement11.Click += AccordionControlElement_Click;
            this.accordionControlElement12.Click += AccordionControlElement_Click;

            this.dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
        }

        private void AccordionControlElement_Click(object sender, EventArgs e)
        {
            string key = (sender as AccordionControlElement).Text;
            Type type = reportDic[key];
            List<OrderInfoVo> orderVoList = SelectDao.SelectData<OrderInfoVo>();
            reportControl.SetData(orderVoList);

        }

        private void InitReportDic()
        {
            reportDic.Add("日营业报表",typeof(SalesVo));
            reportDic.Add("周营业报表", typeof(SalesVo));
            reportDic.Add("月营业报表", typeof(SalesVo));
            reportDic.Add("年营业报表", typeof(SalesVo));

            reportDic.Add("日员工做工报表", typeof(SalesVo));
            reportDic.Add("周员工做工报表", typeof(SalesVo));
            reportDic.Add("月员工做工报表", typeof(SalesVo));
            reportDic.Add("年员工做工报表", typeof(SalesVo));

            reportDic.Add("会员充值报表", typeof(SalesVo));
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
