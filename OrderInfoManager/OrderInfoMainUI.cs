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
using ClientCenter.GridViews;

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
            this.btnQuery.Click += BtnQuery_Click;
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            DateTime startTime = dateTimeStart.Value.Date;
            DateTime endTime = dateTimeEnd.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            if (this.gridView1.ViewCaption.Equals("订单"))
            {
                List<OrderInfoVo> orderList = SelectDao.SelectData<OrderInfoVo>("EndTime> '" + startTime + "' and EndTime<='" + endTime + "'");
                GridViewUtil.InitGridView(this.gridView1,typeof(OrderInfoVo));
                this.gridControl1.DataSource = orderList;
            }
            if(this.gridView1.ViewCaption.Equals("详细订单"))
            {
                //List<DetailedOrderVo> delorderList = SelectDao.SelectData<DetailedOrderVo>("EndTime> '" + startTime + "' and EndTime<='" + endTime + "'");
                //GridViewUtil.InitGridView(this.gridView1, typeof(DetailedOrderVo));
                //this.gridControl1.DataSource = delorderList;
            }
        }

        //详细订单
        private void AccordionControlElement3_Click(object sender, EventArgs e)
        {
            this.gridView1.ViewCaption = "详细订单";
            this.gridControl1.DataBindings.Clear();
        }
        //订单
        private void AccordionControlElement2_Click(object sender, EventArgs e)
        {
            this.gridView1.ViewCaption = "订单";
            this.gridControl1.DataBindings.Clear();
        }
    }
}
