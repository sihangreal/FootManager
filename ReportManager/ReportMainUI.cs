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
using DevExpress.XtraBars.Navigation;
using ReportManager.Enity;
using ClientCenter.DB;
using ClientCenter.Enity;
using System.Reflection;

namespace ReportManager
{
    public partial class ReportMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        private ReportControl reportControl = new ReportControl();

        public ReportMainUI()
        {
            InitializeComponent();
            InitEvents();
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
            string methodName = (sender as AccordionControlElement).Text;
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(methodName);
            method.Invoke(this,null);
        }

        public void 日营业报表()
        {
            List<SalesVo> salesVoList = new List<SalesVo>();
            List<OrderInfoVo> orderVoList = SelectDao.SelectData<OrderInfoVo>();
            var orderDic = orderVoList.GroupBy(v => v.EndTime.Date).ToDictionary(v => v.First().EndTime, v => v.ToList());
            foreach(var key in orderDic.Keys)
            {
                SalesVo vo = new SalesVo();
                vo.Date = key.Date;
                foreach(var item in orderDic[key])
                {
                    if (item.PriceType.Equals("现金"))
                        vo.Cash += item.Price;
                    else if (item.PriceType.Equals("Visa卡"))
                        vo.CCard += item.Price;
                    else
                        vo.MemberUse += item.Price;
                    vo.Gst += item.Tax;
                    vo.Sales += item.TotalPrice;
                }
                salesVoList.Add(vo);
            }
            reportControl.SetSalesData(salesVoList);
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
