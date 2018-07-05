namespace StaffManager.UI
{
    partial class UpdateStaffLevel
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textLevel = new DevExpress.XtraEditors.TextEdit();
            this.memoRemark = new DevExpress.XtraEditors.MemoEdit();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "员工级别:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 50);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "备注:";
            // 
            // textLevel
            // 
            this.textLevel.Location = new System.Drawing.Point(70, 9);
            this.textLevel.Name = "textLevel";
            this.textLevel.Size = new System.Drawing.Size(273, 20);
            this.textLevel.TabIndex = 3;
            // 
            // memoRemark
            // 
            this.memoRemark.Location = new System.Drawing.Point(70, 49);
            this.memoRemark.Name = "memoRemark";
            this.memoRemark.Size = new System.Drawing.Size(273, 96);
            this.memoRemark.TabIndex = 5;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(78, 168);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 30);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Tag = "添加员工级别";
            this.btnUpdate.Text = "更新";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(214, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            // 
            // UpdateStaffLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 213);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.memoRemark);
            this.Controls.Add(this.textLevel);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "UpdateStaffLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加员工级别";
            ((System.ComponentModel.ISupportInitialize)(this.textLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textLevel;
        private DevExpress.XtraEditors.MemoEdit memoRemark;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}