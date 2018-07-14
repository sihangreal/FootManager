namespace StaffManager.UI
{
    partial class BaseInfoUI
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRandomQueue = new DevExpress.XtraEditors.SimpleButton();
            this.btnQueueLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnQueueFirst = new DevExpress.XtraEditors.SimpleButton();
            this.btnQueueDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnQueueUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(822, 435);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 52);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(798, 371);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnRandomQueue);
            this.panelControl1.Controls.Add(this.btnQueueLast);
            this.panelControl1.Controls.Add(this.btnQueueFirst);
            this.panelControl1.Controls.Add(this.btnQueueDown);
            this.panelControl1.Controls.Add(this.btnQueueUp);
            this.panelControl1.Controls.Add(this.btnDel);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(798, 36);
            this.panelControl1.TabIndex = 4;
            // 
            // btnRandomQueue
            // 
            this.btnRandomQueue.Image = global::StaffManager.Properties.Resources.movedown_16x16;
            this.btnRandomQueue.Location = new System.Drawing.Point(621, 7);
            this.btnRandomQueue.Name = "btnRandomQueue";
            this.btnRandomQueue.Size = new System.Drawing.Size(83, 23);
            this.btnRandomQueue.TabIndex = 7;
            this.btnRandomQueue.Text = "随机排序";
            this.btnRandomQueue.Visible = false;
            // 
            // btnQueueLast
            // 
            this.btnQueueLast.Image = global::StaffManager.Properties.Resources.movedown_16x16;
            this.btnQueueLast.Location = new System.Drawing.Point(528, 7);
            this.btnQueueLast.Name = "btnQueueLast";
            this.btnQueueLast.Size = new System.Drawing.Size(76, 23);
            this.btnQueueLast.TabIndex = 6;
            this.btnQueueLast.Text = "排在最后";
            this.btnQueueLast.Visible = false;
            // 
            // btnQueueFirst
            // 
            this.btnQueueFirst.Image = global::StaffManager.Properties.Resources.moveup_16x16;
            this.btnQueueFirst.Location = new System.Drawing.Point(433, 7);
            this.btnQueueFirst.Name = "btnQueueFirst";
            this.btnQueueFirst.Size = new System.Drawing.Size(76, 23);
            this.btnQueueFirst.TabIndex = 5;
            this.btnQueueFirst.Text = "排在最前";
            this.btnQueueFirst.Visible = false;
            // 
            // btnQueueDown
            // 
            this.btnQueueDown.Image = global::StaffManager.Properties.Resources.movedown_16x16;
            this.btnQueueDown.Location = new System.Drawing.Point(339, 7);
            this.btnQueueDown.Name = "btnQueueDown";
            this.btnQueueDown.Size = new System.Drawing.Size(76, 23);
            this.btnQueueDown.TabIndex = 4;
            this.btnQueueDown.Text = "退后一位";
            this.btnQueueDown.Visible = false;
            // 
            // btnQueueUp
            // 
            this.btnQueueUp.Image = global::StaffManager.Properties.Resources.moveup_16x16;
            this.btnQueueUp.Location = new System.Drawing.Point(246, 7);
            this.btnQueueUp.Name = "btnQueueUp";
            this.btnQueueUp.Size = new System.Drawing.Size(76, 23);
            this.btnQueueUp.TabIndex = 3;
            this.btnQueueUp.Text = "提前一位";
            this.btnQueueUp.Visible = false;
            // 
            // btnDel
            // 
            this.btnDel.Image = global::StaffManager.Properties.Resources.cancel_16x16;
            this.btnDel.Location = new System.Drawing.Point(169, 7);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(60, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "删除";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::StaffManager.Properties.Resources.apply_16x16;
            this.btnSave.Location = new System.Drawing.Point(91, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::StaffManager.Properties.Resources.add_16x16;
            this.btnAdd.Location = new System.Drawing.Point(15, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "增加";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(822, 435);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(5, 5);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(802, 40);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(802, 375);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // BaseInfoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "BaseInfoUI";
            this.Size = new System.Drawing.Size(822, 435);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        protected DevExpress.XtraGrid.GridControl gridControl1;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        protected DevExpress.XtraEditors.SimpleButton btnDel;
        protected DevExpress.XtraEditors.SimpleButton btnSave;
        protected DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        protected DevExpress.XtraEditors.SimpleButton btnQueueDown;
        protected DevExpress.XtraEditors.SimpleButton btnQueueUp;
        protected DevExpress.XtraEditors.SimpleButton btnQueueLast;
        protected DevExpress.XtraEditors.SimpleButton btnQueueFirst;
        protected DevExpress.XtraEditors.SimpleButton btnRandomQueue;
    }
}
