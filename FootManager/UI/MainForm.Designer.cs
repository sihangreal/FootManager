namespace FootManager.UI
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
            this.components = new System.ComponentModel.Container();
            this.btnOpenOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnCheck = new DevExpress.XtraBars.BarButtonItem();
            this.btnSkin = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnCashier = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnStaff = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnRoom = new DevExpress.XtraBars.BarButtonItem();
            this.btnMember = new DevExpress.XtraBars.BarButtonItem();
            this.btnStore = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserSet = new DevExpress.XtraBars.BarButtonItem();
            this.btnSettlement = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.mainPanel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenOrder
            // 
            this.btnOpenOrder.Caption = "开单";
            this.btnOpenOrder.Id = 0;
            this.btnOpenOrder.Name = "btnOpenOrder";
            // 
            // btnSetting
            // 
            this.btnSetting.Caption = "设置";
            this.btnSetting.Id = 2;
            this.btnSetting.Name = "btnSetting";
            // 
            // btnCheck
            // 
            this.btnCheck.Caption = "结账";
            this.btnCheck.Id = 3;
            this.btnCheck.Name = "btnCheck";
            // 
            // btnSkin
            // 
            this.btnSkin.ActAsDropDown = true;
            this.btnSkin.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnSkin.Caption = "换肤";
            this.btnSkin.DropDownControl = this.popupMenu1;
            this.btnSkin.Id = 1;
            this.btnSkin.Name = "btnSkin";
            // 
            // popupMenu1
            // 
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnOpenOrder,
            this.btnSkin,
            this.btnSetting,
            this.btnCheck,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 29;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1459, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1044);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1459, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1044);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1459, 0);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1044);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Office 2013";
            this.barButtonItem1.Id = 4;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.AllowTrimPageText = false;
            this.ribbonControl1.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnCashier,
            this.barButtonItem2,
            this.barButtonItem3,
            this.btnStaff,
            this.barButtonItem5,
            this.barButtonItem6,
            this.btnReport,
            this.btnRoom,
            this.btnMember,
            this.btnStore,
            this.btnExit,
            this.btnUserSet,
            this.btnSettlement});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 23;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowCategoryInCaption = false;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1459, 98);
            this.ribbonControl1.Toolbar.ItemLinks.Add(this.barButtonItem2);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnCashier
            // 
            this.btnCashier.Caption = "前台收银";
            this.btnCashier.Id = 1;
            this.btnCashier.LargeGlyph = global::FootManager.Properties.Resources.bosale_32x32;
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Tag = 1;
            this.btnCashier.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "钟房管理";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.LargeGlyph = global::FootManager.Properties.Resources.home_32x32;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // btnStaff
            // 
            this.btnStaff.Caption = "员工管理";
            this.btnStaff.Id = 4;
            this.btnStaff.LargeGlyph = global::FootManager.Properties.Resources.team_32x32;
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Tag = 3;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "会员管理";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.LargeGlyph = global::FootManager.Properties.Resources.bocustomer_32x32;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "库存管理";
            this.barButtonItem6.Id = 6;
            this.barButtonItem6.LargeGlyph = global::FootManager.Properties.Resources.boproductgroup_32x32;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // btnReport
            // 
            this.btnReport.Caption = "报表分析";
            this.btnReport.Id = 7;
            this.btnReport.LargeGlyph = global::FootManager.Properties.Resources.notes_32x32;
            this.btnReport.Name = "btnReport";
            this.btnReport.Tag = "";
            // 
            // btnRoom
            // 
            this.btnRoom.Caption = "钟房管理";
            this.btnRoom.Id = 13;
            this.btnRoom.LargeGlyph = global::FootManager.Properties.Resources.home_32x32;
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Tag = 9;
            // 
            // btnMember
            // 
            this.btnMember.Caption = "会员管理";
            this.btnMember.Id = 14;
            this.btnMember.LargeGlyph = global::FootManager.Properties.Resources.bocustomer_32x32;
            this.btnMember.Name = "btnMember";
            this.btnMember.Tag = 4;
            // 
            // btnStore
            // 
            this.btnStore.Caption = "商品管理";
            this.btnStore.Id = 15;
            this.btnStore.LargeGlyph = global::FootManager.Properties.Resources.boproductgroup_32x32;
            this.btnStore.Name = "btnStore";
            this.btnStore.Tag = 7;
            // 
            // btnExit
            // 
            this.btnExit.Caption = "退出";
            this.btnExit.Glyph = global::FootManager.Properties.Resources.close_16x16;
            this.btnExit.Id = 17;
            this.btnExit.LargeGlyph = global::FootManager.Properties.Resources.close_32x32;
            this.btnExit.Name = "btnExit";
            // 
            // btnUserSet
            // 
            this.btnUserSet.Caption = "设置";
            this.btnUserSet.Glyph = global::FootManager.Properties.Resources.showall_16x16;
            this.btnUserSet.Id = 21;
            this.btnUserSet.LargeGlyph = global::FootManager.Properties.Resources.showall_32x32;
            this.btnUserSet.Name = "btnUserSet";
            // 
            // btnSettlement
            // 
            this.btnSettlement.Caption = "结账中心";
            this.btnSettlement.Id = 22;
            this.btnSettlement.LargeGlyph = global::FootManager.Properties.Resources.clearformatting_32x32;
            this.btnSettlement.Name = "btnSettlement";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnSettlement);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnRoom);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnStaff);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnMember);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnStore);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnReport);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnUserSet);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "客情分析";
            this.barButtonItem9.Glyph = global::FootManager.Properties.Resources.boperson_16x16;
            this.barButtonItem9.Id = 10;
            this.barButtonItem9.LargeGlyph = global::FootManager.Properties.Resources.boperson_32x32;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 98);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1459, 946);
            this.mainPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1459, 1044);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "足浴管理系统";
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnCashier;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnStaff;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem btnRoom;
        private DevExpress.XtraBars.BarButtonItem btnMember;
        private DevExpress.XtraBars.BarButtonItem btnStore;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarButtonItem btnOpenOrder;
        private DevExpress.XtraBars.BarButtonItem btnSetting;
        private DevExpress.XtraBars.BarButtonItem btnCheck;
        private DevExpress.XtraBars.BarButtonItem btnSkin;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.PanelControl mainPanel;
        private DevExpress.XtraBars.BarButtonItem btnUserSet;
        private DevExpress.XtraBars.BarButtonItem btnSettlement;
    }
}