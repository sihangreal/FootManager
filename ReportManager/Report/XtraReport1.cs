using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using System.Reflection;

namespace ReportManager.Report
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        protected int XRTableCellHeight = 5;

        public XtraReport1()
        {
            InitializeComponent();
        }

        public void SetTableSource<T>(List<T> tList)
        {
            InitDetailsBasedonXRTable(tList);//用XRTable显示报表
        }


        private XRTableCell GetHeaderCell(string text, int colWidth)
        {
            XRTableCell headerCell = new XRTableCell();
            headerCell.Width = colWidth;
            headerCell.Borders = DevExpress.XtraPrinting.BorderSide.All;
            headerCell.Text = text;
            return headerCell;
        }

        private XRTableCell GetDetailCell(string text, int colWidth)
        {
            XRTableCell detailCell = new XRTableCell();
            detailCell.Width = colWidth;
            detailCell.Text = text;
            detailCell.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
            return detailCell;
        }

        private void InitDetailsBasedonXRTable<T>(List<T> tList)
        {
            int colCount = tList.Count;
            int colWidth = (this.PageWidth - (this.Margins.Left + this.Margins.Right)) / colCount;

            // 创建表来显示页眉
            XRTable tableHeader = new XRTable();
            tableHeader.Width = (this.PageWidth - (this.Margins.Left + this.Margins.Right));
            tableHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            tableHeader.Font = new System.Drawing.Font("宋体", 12.75F, System.Drawing.FontStyle.Bold);

            // 创建表来显示数据
            XRTable tableDetail = new XRTable();
            tableDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            tableDetail.Width = (this.PageWidth - (this.Margins.Left + this.Margins.Right));
            tableDetail.Font = new System.Drawing.Font("宋体", 12.75F, System.Drawing.FontStyle.Regular);

            //创建列
            XRTableRow headerRow = new XRTableRow();

            Type type = typeof(T);
            PropertyInfo[] infos = type.GetProperties();
            foreach (PropertyInfo info in infos)
            {
                headerRow.Cells.Add(GetHeaderCell(info.Name, colWidth));
            }
            headerRow.Width = tableHeader.Width;
            tableHeader.Rows.Add(headerRow);
            PageHeader.HeightF = tableHeader.HeightF;

            //填充数据
            foreach (T item in tList)
            {
                XRTableRow detailRow = new XRTableRow();
                foreach (PropertyInfo info in infos)
                {
                    string text = string.Empty;
                    object obj = info.GetValue(item);
                    if (obj == null)
                        text = "";
                    else
                        text = obj.ToString();
                    detailRow.Cells.Add(GetDetailCell(text, colWidth));
                }
                detailRow.Width = tableDetail.Width;
                tableDetail.Rows.Add(detailRow);
            }

            PageHeader.Controls.Add(tableHeader);
            Detail.Controls.Add(tableDetail);
            tableDetail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, XRTableCellHeight, XRTableCellHeight);
            tableHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, XRTableCellHeight, XRTableCellHeight);
        }
    }
}
