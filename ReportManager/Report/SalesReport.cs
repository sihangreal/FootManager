using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using ClientCenter.Enity;
using ClientCenter.DB;
using System.Reflection;
using ClientCenter.Core;

namespace ReportManager.Report
{
    public partial class SalesReport : DevExpress.XtraReports.UI.XtraReport
    {
        private DataSet dsSource = new DataSet();
        private List<OrderInfoVo> OrderList;

        protected int XRTableCellHeight = 38;

        public SalesReport()
        {
            InitializeComponent();
            InitDataTable();
        
        }

        private void InitDataTable()
        {
            //DataTable dtSource = new DataTable();
            //dtSource.Columns.Add("Name", typeof(String));
            //dtSource.Columns.Add("Address", typeof(String));
            //dtSource.Columns.Add("Sex", typeof(String));
            //dtSource.Columns.Add("Birthplace", typeof(String));
            //dtSource.Columns.Add("Birthday", typeof(String));
            //dsSource.Tables.Add(dtSource);

            //XtraReport rpt = this;// 建立报表实例
            //rpt.DataSource = dsSource;//设置报表数据源  

            OrderList = SelectDao.SelectData<OrderInfoVo>();
            this.DataSource = OrderList;
            InitBands(this);//添加带区（Bands） 
            InitDetailsBasedonXRTable(this);//用XRTable显示报表 
        }

        private void InitBands(XtraReport rpt)
        {
            DetailBand detail = new DetailBand();
            PageHeaderBand pageHeader = new PageHeaderBand();
            ReportFooterBand reportFooter = new ReportFooterBand();
            detail.Height = XRTableCellHeight;
            reportFooter.Height = 380;
            pageHeader.Height = XRTableCellHeight;

            rpt.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { detail, pageHeader, reportFooter });
        }

        public void InitDetailsBasedonXRTable(XtraReport rpt)
        {
            //DataSet ds = ((DataSet)rpt.DataSource);
            //int colCount = ds.Tables[0].Columns.Count;
            //int colWidth = (rpt.PageWidth - (rpt.Margins.Left + rpt.Margins.Right)) / colCount;
            Type type = typeof(OrderInfoVo);
            PropertyInfo[] propertyInfos = type.GetProperties();
            int colCount = propertyInfos.Length;
            int colWidth = (rpt.PageWidth - (rpt.Margins.Left + rpt.Margins.Right)) / colCount;

            // Create a table to represent headers
            XRTable tableHeader = new XRTable();
            tableHeader.Height = XRTableCellHeight;
            tableHeader.Width = (rpt.PageWidth - (rpt.Margins.Left + rpt.Margins.Right));
            tableHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            tableHeader.Font = new System.Drawing.Font("宋体", 12.75F, System.Drawing.FontStyle.Bold);

            // Create a table to display data
            XRTable tableDetail = new XRTable();
            tableDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            tableDetail.Width = (rpt.PageWidth - (rpt.Margins.Left + rpt.Margins.Right));
            tableDetail.Height = XRTableCellHeight;
            tableDetail.Font = new System.Drawing.Font("宋体", 12.75F, System.Drawing.FontStyle.Regular);


            XRTableRow headerRow = new XRTableRow();
            XRTableRow detailRow = new XRTableRow();
            // Create table cells, fill the header cells with text, bind the cells to data
            foreach (PropertyInfo info  in propertyInfos)
            {
                XRTableCell headerCell = new XRTableCell();
                headerCell.Width = colWidth;
                headerCell.Borders = DevExpress.XtraPrinting.BorderSide.All;

                ColumnAttr columnAttr = (ColumnAttr)info.GetCustomAttribute(typeof(ColumnAttr),false);
                headerCell.Text = columnAttr.Caption;

                XRTableCell detailCell = new XRTableCell();
                detailCell.Width = colWidth;
                detailCell.DataBindings.Add("Text", null, info.Name);
                detailCell.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;

                // Place the cells into the corresponding tables
                headerRow.Cells.Add(headerCell);
                detailRow.Cells.Add(detailCell);
            }

            headerRow.Width = tableHeader.Width;
            tableHeader.Rows.Add(headerRow);

            detailRow.Width = tableDetail.Width;
            tableDetail.Rows.Add(detailRow);

            // Place the table onto a report's Detail band
            rpt.Bands[BandKind.PageHeader].Controls.Add(tableHeader);
            rpt.Bands[BandKind.Detail].Controls.Add(tableDetail);
        }

    }
}
