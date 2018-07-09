namespace FootManager.UI
{
    partial class UserForm
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
            this.textUserName = new DevExpress.XtraEditors.TextEdit();
            this.comMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textPassword = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(87, 24);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(132, 20);
            this.textUserName.TabIndex = 0;
            // 
            // comMode
            // 
            this.comMode.Location = new System.Drawing.Point(87, 72);
            this.comMode.Name = "comMode";
            this.comMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comMode.Size = new System.Drawing.Size(132, 20);
            this.comMode.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "用户名:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "用户角色:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(67, 170);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Tag = "添加用户";
            this.btnAdd.Text = "确认";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(158, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 121);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "密码:";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(87, 118);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(132, 20);
            this.textPassword.TabIndex = 7;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 205);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.comMode);
            this.Controls.Add(this.textUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加用户";
            ((System.ComponentModel.ISupportInitialize)(this.textUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textUserName;
        private DevExpress.XtraEditors.ComboBoxEdit comMode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textPassword;
    }
}