namespace ClockRoomManager.UI
{
    partial class AddOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrderForm));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenOder = new DevExpress.XtraEditors.SimpleButton();
            this.memoRemark = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textNumber = new DevExpress.XtraEditors.TextEdit();
            this.textMemberId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMemberId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(549, 450);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnCancel);
            this.xtraTabPage1.Controls.Add(this.btnOpenOder);
            this.xtraTabPage1.Controls.Add(this.memoRemark);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.textNumber);
            this.xtraTabPage1.Controls.Add(this.textMemberId);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(543, 421);
            this.xtraTabPage1.Text = "本次开单钟房";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(351, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 34);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            // 
            // btnOpenOder
            // 
            this.btnOpenOder.Location = new System.Drawing.Point(86, 378);
            this.btnOpenOder.Name = "btnOpenOder";
            this.btnOpenOder.Size = new System.Drawing.Size(98, 34);
            this.btnOpenOder.TabIndex = 8;
            this.btnOpenOder.Text = "开单";
            // 
            // memoRemark
            // 
            this.memoRemark.Location = new System.Drawing.Point(326, 291);
            this.memoRemark.Name = "memoRemark";
            this.memoRemark.Size = new System.Drawing.Size(198, 67);
            this.memoRemark.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(271, 296);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "备注:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 334);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "人数:";
            // 
            // textNumber
            // 
            this.textNumber.Location = new System.Drawing.Point(69, 331);
            this.textNumber.Name = "textNumber";
            this.textNumber.Size = new System.Drawing.Size(132, 20);
            this.textNumber.TabIndex = 4;
            // 
            // textMemberId
            // 
            this.textMemberId.Location = new System.Drawing.Point(69, 290);
            this.textMemberId.Name = "textMemberId";
            this.textMemberId.Size = new System.Drawing.Size(132, 20);
            this.textMemberId.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 293);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "会员编号:";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.treeList2);
            this.panelControl1.Controls.Add(this.btnDel);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Controls.Add(this.treeList1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(543, 274);
            this.panelControl1.TabIndex = 1;
            // 
            // treeList2
            // 
            this.treeList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2});
            this.treeList2.Dock = System.Windows.Forms.DockStyle.Right;
            this.treeList2.Location = new System.Drawing.Point(314, 0);
            this.treeList2.Name = "treeList2";
            this.treeList2.OptionsView.ShowHorzLines = false;
            this.treeList2.OptionsView.ShowIndicator = false;
            this.treeList2.OptionsView.ShowVertLines = false;
            this.treeList2.Size = new System.Drawing.Size(229, 274);
            this.treeList2.TabIndex = 3;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "选择钟房";
            this.treeListColumn2.FieldName = "选择钟房";
            this.treeListColumn2.MinWidth = 34;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDel.Location = new System.Drawing.Point(224, 179);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 25);
            this.btnDel.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(224, 77);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 1;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.Size = new System.Drawing.Size(205, 274);
            this.treeList1.TabIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "钟房";
            this.treeListColumn1.FieldName = "钟房";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 450);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "开单操作";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMemberId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.TextEdit textMemberId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOpenOder;
        private DevExpress.XtraEditors.MemoEdit memoRemark;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textNumber;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
    }
}