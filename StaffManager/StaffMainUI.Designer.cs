namespace StaffManager
{
    partial class StaffMainUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.classPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.staffLevelPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.departmentPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.staffPrePage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.staffQuePage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.staffWorkPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.staffInfoPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPane1 = new DevExpress.XtraBars.Navigation.NavigationPane();
            this.navigationPane1.SuspendLayout();
            this.SuspendLayout();
            // 
            // classPage
            // 
            this.classPage.Caption = "班次维护";
            this.classPage.Image = global::StaffManager.Properties.Resources.boscheduler_32x32;
            this.classPage.Name = "classPage";
            this.classPage.Size = new System.Drawing.Size(588, 509);
            // 
            // staffLevelPage
            // 
            this.staffLevelPage.Caption = "员工级别维护";
            this.staffLevelPage.Image = global::StaffManager.Properties.Resources.chart_32x32;
            this.staffLevelPage.Name = "staffLevelPage";
            this.staffLevelPage.Size = new System.Drawing.Size(588, 509);
            this.staffLevelPage.Tag = "会员消费记录查询";
            // 
            // departmentPage
            // 
            this.departmentPage.Caption = "部门管理";
            this.departmentPage.Image = global::StaffManager.Properties.Resources.bonote_32x32;
            this.departmentPage.Name = "departmentPage";
            this.departmentPage.Size = new System.Drawing.Size(588, 509);
            // 
            // staffPrePage
            // 
            this.staffPrePage.Caption = "员工预订维护";
            this.staffPrePage.Image = global::StaffManager.Properties.Resources.boperson_32x32;
            this.staffPrePage.Name = "staffPrePage";
            this.staffPrePage.Size = new System.Drawing.Size(588, 509);
            // 
            // staffQuePage
            // 
            this.staffQuePage.Caption = "员工排钟维护";
            this.staffQuePage.Image = global::StaffManager.Properties.Resources.bodepartment_32x32;
            this.staffQuePage.Name = "staffQuePage";
            this.staffQuePage.Size = new System.Drawing.Size(588, 509);
            this.staffQuePage.Tag = "会员查询与充值";
            // 
            // staffWorkPage
            // 
            this.staffWorkPage.Caption = "员工状态维护";
            this.staffWorkPage.Image = global::StaffManager.Properties.Resources.borole_32x32;
            this.staffWorkPage.Name = "staffWorkPage";
            this.staffWorkPage.Size = new System.Drawing.Size(588, 509);
            this.staffWorkPage.Tag = "员工状态维护";
            // 
            // staffInfoPage
            // 
            this.staffInfoPage.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffInfoPage.Appearance.Options.UseFont = true;
            this.staffInfoPage.Caption = "员工基本资料维护";
            this.staffInfoPage.Image = global::StaffManager.Properties.Resources.boresume_32x32;
            this.staffInfoPage.Name = "staffInfoPage";
            this.staffInfoPage.Size = new System.Drawing.Size(588, 509);
            this.staffInfoPage.Tag = "会员基本资料维护";
            // 
            // navigationPane1
            // 
            this.navigationPane1.Controls.Add(this.staffInfoPage);
            this.navigationPane1.Controls.Add(this.staffPrePage);
            this.navigationPane1.Controls.Add(this.staffLevelPage);
            this.navigationPane1.Controls.Add(this.departmentPage);
            this.navigationPane1.Controls.Add(this.staffWorkPage);
            this.navigationPane1.Controls.Add(this.staffQuePage);
            this.navigationPane1.Controls.Add(this.classPage);
            this.navigationPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPane1.Location = new System.Drawing.Point(0, 0);
            this.navigationPane1.Name = "navigationPane1";
            this.navigationPane1.PageProperties.AllowHtmlDraw = false;
            this.navigationPane1.PageProperties.ShowCollapseButton = false;
            this.navigationPane1.PageProperties.ShowExpandButton = false;
            this.navigationPane1.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.navigationPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.staffInfoPage,
            this.staffWorkPage,
            this.staffQuePage,
            this.staffPrePage,
            this.departmentPage,
            this.staffLevelPage,
            this.classPage});
            this.navigationPane1.RegularSize = new System.Drawing.Size(752, 556);
            this.navigationPane1.SelectedPage = this.staffPrePage;
            this.navigationPane1.SelectedPageIndex = 0;
            this.navigationPane1.Size = new System.Drawing.Size(752, 556);
            this.navigationPane1.TabIndex = 0;
            this.navigationPane1.Text = "员工";
            // 
            // StaffMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationPane1);
            this.Name = "StaffMainUI";
            this.Size = new System.Drawing.Size(752, 556);
            this.navigationPane1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationPage classPage;
        private DevExpress.XtraBars.Navigation.NavigationPage staffLevelPage;
        private DevExpress.XtraBars.Navigation.NavigationPage departmentPage;
        private DevExpress.XtraBars.Navigation.NavigationPage staffPrePage;
        private DevExpress.XtraBars.Navigation.NavigationPage staffQuePage;
        private DevExpress.XtraBars.Navigation.NavigationPage staffWorkPage;
        private DevExpress.XtraBars.Navigation.NavigationPage staffInfoPage;
        private DevExpress.XtraBars.Navigation.NavigationPane navigationPane1;
    }
}
