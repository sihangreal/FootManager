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
using ClientCenter.Enity;
using ClientCenter.DB;

namespace OrderInfoManager
{
    public partial class OrderInfoMainUI : DevExpress.XtraEditors.XtraUserControl
    {
        public OrderInfoMainUI()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.accordionControlElement2.Click += AccordionControlElement2_Click;
            this.accordionControlElement3.Click += AccordionControlElement3_Click;
        }
        //详细订单
        private void AccordionControlElement3_Click(object sender, EventArgs e)
        {
           DataTable dt= SelectDao.GetOrderInfoForTime(dateTimeStart.Value,dateTimeEnd.Value);

        }
        //订单
        private void AccordionControlElement2_Click(object sender, EventArgs e)
        {
            DataTable dt = SelectDao.GetOrderInfoForTime(dateTimeStart.Value, dateTimeEnd.Value);
        }
    }
}
