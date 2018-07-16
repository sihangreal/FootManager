namespace ReportManager
{
    partial class SalesReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.endDateLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.startDateLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.companyInfoLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Expanded = false;
            this.Detail.HeightF = 100F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.endDateLabel,
            this.startDateLabel,
            this.xrLabel1,
            this.companyInfoLabel});
            this.TopMargin.HeightF = 84.375F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // endDateLabel
            // 
            this.endDateLabel.Font = new System.Drawing.Font("宋体", 14.25F);
            this.endDateLabel.LocationFloat = new DevExpress.Utils.PointFloat(357.9167F, 55.91668F);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.endDateLabel.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.endDateLabel.StylePriority.UseFont = false;
            this.endDateLabel.Text = "2018-7-30";
            // 
            // startDateLabel
            // 
            this.startDateLabel.Font = new System.Drawing.Font("宋体", 14.25F);
            this.startDateLabel.LocationFloat = new DevExpress.Utils.PointFloat(243.3333F, 55.91668F);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.startDateLabel.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.startDateLabel.StylePriority.UseFont = false;
            this.startDateLabel.Text = "2018-7-5";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 55.91668F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(213.5417F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Sales Report 营业报表";
            // 
            // companyInfoLabel
            // 
            this.companyInfoLabel.Font = new System.Drawing.Font("宋体", 14.25F);
            this.companyInfoLabel.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 10.00001F);
            this.companyInfoLabel.Name = "companyInfoLabel";
            this.companyInfoLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.companyInfoLabel.SizeF = new System.Drawing.SizeF(413.5417F, 23F);
            this.companyInfoLabel.StylePriority.UseFont = false;
            this.companyInfoLabel.Text = "companyInfoLabel";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.HeightF = 100F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // SalesReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(20, 25, 84, 100);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel companyInfoLabel;
        private DevExpress.XtraReports.UI.XRLabel endDateLabel;
        private DevExpress.XtraReports.UI.XRLabel startDateLabel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
    }
}
