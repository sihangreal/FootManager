namespace FootManager
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.helpBarBtn = new DevExpress.XtraBars.BarButtonItem();
            this.videoBarBtn = new DevExpress.XtraBars.BarButtonItem();
            this.exitBarBtn = new DevExpress.XtraBars.BarButtonItem();
            this.systemBarBtn = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.cashierItem = new DevExpress.XtraNavBar.NavBarItem();
            this.reservationItem = new DevExpress.XtraNavBar.NavBarItem();
            this.staffItem = new DevExpress.XtraNavBar.NavBarItem();
            this.memberItem = new DevExpress.XtraNavBar.NavBarItem();
            this.repertoryItem = new DevExpress.XtraNavBar.NavBarItem();
            this.reportItem = new DevExpress.XtraNavBar.NavBarItem();
            this.mainPanel = new DevExpress.XtraEditors.PanelControl();
            this.DataBarBtn = new DevExpress.XtraBars.BarButtonItem();
            this.businesstem = new DevExpress.XtraNavBar.NavBarItem();
            this.guestItem = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.helpBarBtn,
            this.videoBarBtn,
            this.exitBarBtn,
            this.systemBarBtn,
            this.DataBarBtn});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 19;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(1350, 147);
            // 
            // helpBarBtn
            // 
            this.helpBarBtn.Caption = "帮助";
            this.helpBarBtn.Glyph = global::FootManager.Properties.Resources.question_16x16;
            this.helpBarBtn.Id = 12;
            this.helpBarBtn.LargeGlyph = global::FootManager.Properties.Resources.question_32x32;
            this.helpBarBtn.Name = "helpBarBtn";
            // 
            // videoBarBtn
            // 
            this.videoBarBtn.Caption = "视频教学";
            this.videoBarBtn.Glyph = global::FootManager.Properties.Resources.video_16x16;
            this.videoBarBtn.Id = 15;
            this.videoBarBtn.LargeGlyph = global::FootManager.Properties.Resources.video_32x32;
            this.videoBarBtn.Name = "videoBarBtn";
            // 
            // exitBarBtn
            // 
            this.exitBarBtn.Caption = "退出";
            this.exitBarBtn.Glyph = global::FootManager.Properties.Resources.cancel_16x16;
            this.exitBarBtn.Id = 16;
            this.exitBarBtn.LargeGlyph = global::FootManager.Properties.Resources.cancel_32x32;
            this.exitBarBtn.Name = "exitBarBtn";
            // 
            // systemBarBtn
            // 
            this.systemBarBtn.Caption = "系统设置";
            this.systemBarBtn.Glyph = global::FootManager.Properties.Resources.technology_16x16;
            this.systemBarBtn.Id = 17;
            this.systemBarBtn.LargeGlyph = global::FootManager.Properties.Resources.technology_32x32;
            this.systemBarBtn.Name = "systemBarBtn";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup5,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "菜单";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.videoBarBtn);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.DataBarBtn);
            this.ribbonPageGroup5.ItemLinks.Add(this.systemBarBtn);
            this.ribbonPageGroup5.ItemLinks.Add(this.helpBarBtn);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.exitBarBtn);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.cashierItem,
            this.reservationItem,
            this.memberItem,
            this.staffItem,
            this.repertoryItem,
            this.reportItem,
            this.businesstem,
            this.guestItem});
            this.navBarControl1.Location = new System.Drawing.Point(0, 147);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 114;
            this.navBarControl1.Size = new System.Drawing.Size(114, 616);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Appearance.Options.UseTextOptions = true;
            this.navBarGroup1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBarGroup1.Caption = "功能模块";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.cashierItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.reservationItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.staffItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.memberItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.repertoryItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.reportItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.businesstem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.guestItem)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // cashierItem
            // 
            this.cashierItem.Caption = "前台收银";
            this.cashierItem.LargeImage = global::FootManager.Properties.Resources.bosale_32x32;
            this.cashierItem.Name = "cashierItem";
            this.cashierItem.Tag = 1;
            // 
            // reservationItem
            // 
            this.reservationItem.Caption = "预约管理";
            this.reservationItem.LargeImage = global::FootManager.Properties.Resources.topbottomrules_32x32;
            this.reservationItem.Name = "reservationItem";
            this.reservationItem.Tag = 2;
            // 
            // staffItem
            // 
            this.staffItem.Caption = "员工管理";
            this.staffItem.LargeImage = global::FootManager.Properties.Resources.team_32x32;
            this.staffItem.Name = "staffItem";
            this.staffItem.Tag = 3;
            // 
            // memberItem
            // 
            this.memberItem.Caption = "会员管理";
            this.memberItem.LargeImage = global::FootManager.Properties.Resources.bocustomer_32x32;
            this.memberItem.Name = "memberItem";
            this.memberItem.Tag = 4;
            // 
            // repertoryItem
            // 
            this.repertoryItem.Caption = "库存管理";
            this.repertoryItem.LargeImage = global::FootManager.Properties.Resources.boproductgroup_32x32;
            this.repertoryItem.Name = "repertoryItem";
            this.repertoryItem.Tag = 5;
            // 
            // reportItem
            // 
            this.reportItem.Caption = "报表分析";
            this.reportItem.LargeImage = global::FootManager.Properties.Resources.area3_32x32;
            this.reportItem.Name = "reportItem";
            this.reportItem.Tag = 6;
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(114, 147);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1236, 616);
            this.mainPanel.TabIndex = 3;
            // 
            // DataBarBtn
            // 
            this.DataBarBtn.Caption = "数据设置";
            this.DataBarBtn.Id = 18;
            this.DataBarBtn.LargeGlyph = global::FootManager.Properties.Resources.managedatasource_32x32;
            this.DataBarBtn.Name = "DataBarBtn";
            // 
            // businesstem
            // 
            this.businesstem.Caption = "营业收入";
            this.businesstem.LargeImage = global::FootManager.Properties.Resources.botask_32x32;
            this.businesstem.Name = "businesstem";
            this.businesstem.Tag = 7;
            // 
            // guestItem
            // 
            this.guestItem.Caption = "客情分析";
            this.guestItem.LargeImage = global::FootManager.Properties.Resources.cleartablestyle_32x32;
            this.guestItem.Name = "guestItem";
            this.guestItem.Tag = 8;
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 763);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XXX足浴管理软件";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraBars.BarButtonItem helpBarBtn;
        private DevExpress.XtraNavBar.NavBarItem cashierItem;
        private DevExpress.XtraNavBar.NavBarItem reservationItem;
        private DevExpress.XtraNavBar.NavBarItem staffItem;
        private DevExpress.XtraNavBar.NavBarItem memberItem;
        private DevExpress.XtraNavBar.NavBarItem repertoryItem;
        private DevExpress.XtraNavBar.NavBarItem reportItem;
        private DevExpress.XtraBars.BarButtonItem videoBarBtn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem exitBarBtn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem systemBarBtn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraEditors.PanelControl mainPanel;
        private DevExpress.XtraBars.BarButtonItem DataBarBtn;
        private DevExpress.XtraNavBar.NavBarItem businesstem;
        private DevExpress.XtraNavBar.NavBarItem guestItem;
    }
}

