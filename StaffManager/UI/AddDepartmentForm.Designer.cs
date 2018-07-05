namespace StaffManager.UI
{
    partial class AddDepartmentForm
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
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.memoRemark = new DevExpress.XtraEditors.MemoEdit();
            this.textId = new DevExpress.XtraEditors.TextEdit();
            this.textName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "部门编号:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(194, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "部门名字:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "说明:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(95, 167);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 30);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Tag = "添加部门";
            this.btnAdd.Text = "添加";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(237, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 30);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            // 
            // memoRemark
            // 
            this.memoRemark.Location = new System.Drawing.Point(73, 51);
            this.memoRemark.Name = "memoRemark";
            this.memoRemark.Size = new System.Drawing.Size(283, 96);
            this.memoRemark.TabIndex = 15;
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(73, 12);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(100, 20);
            this.textId.TabIndex = 16;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(256, 12);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(100, 20);
            this.textName.TabIndex = 17;
            // 
            // AddDepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 212);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.memoRemark);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDepartmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "部门管理";
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.MemoEdit memoRemark;
        private DevExpress.XtraEditors.TextEdit textId;
        private DevExpress.XtraEditors.TextEdit textName;
    }
}