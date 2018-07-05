namespace StaffManager.UI
{
    partial class UpdateStaffClassForm
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txetName = new DevExpress.XtraEditors.TextEdit();
            this.memoRemark = new DevExpress.XtraEditors.MemoEdit();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.dateStart = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateEnd = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txetName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "班次名字:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "开始时间:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(186, 50);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "结束时间:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 90);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 14);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "备注:";
            // 
            // txetName
            // 
            this.txetName.Location = new System.Drawing.Point(70, 9);
            this.txetName.Name = "txetName";
            this.txetName.Size = new System.Drawing.Size(100, 20);
            this.txetName.TabIndex = 6;
            // 
            // memoRemark
            // 
            this.memoRemark.Location = new System.Drawing.Point(70, 89);
            this.memoRemark.Name = "memoRemark";
            this.memoRemark.Size = new System.Drawing.Size(278, 96);
            this.memoRemark.TabIndex = 9;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(83, 202);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 34);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Tag = "更新班次";
            this.btnUpdate.Text = "更新";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 34);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(70, 47);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.DisplayFormat.FormatString = "d";
            this.dateStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateStart.Properties.EditFormat.FormatString = "d";
            this.dateStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateStart.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateStart.Size = new System.Drawing.Size(100, 20);
            this.dateStart.TabIndex = 7;
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(248, 47);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.DisplayFormat.FormatString = "d";
            this.dateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.EditFormat.FormatString = "d";
            this.dateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 8;
            // 
            // UpdateStaffClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 248);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.memoRemark);
            this.Controls.Add(this.txetName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.dateEnd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "UpdateStaffClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加班次";
            ((System.ComponentModel.ISupportInitialize)(this.txetName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txetName;
        private DevExpress.XtraEditors.MemoEdit memoRemark;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.ComboBoxEdit dateStart;
        private DevExpress.XtraEditors.ComboBoxEdit dateEnd;
    }
}