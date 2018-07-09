namespace FootManager
{
    partial class LoginForm
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
            this.textName = new DevExpress.XtraEditors.TextEdit();
            this.textPsw = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.loginBtn = new DevExpress.XtraEditors.SimpleButton();
            this.hyperlinkLabelControl1 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.hyperlinkLabelControl2 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPsw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(129, 241);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(125, 20);
            this.textName.TabIndex = 1;
            // 
            // textPsw
            // 
            this.textPsw.Location = new System.Drawing.Point(129, 278);
            this.textPsw.Name = "textPsw";
            this.textPsw.Properties.UseSystemPasswordChar = true;
            this.textPsw.Size = new System.Drawing.Size(125, 20);
            this.textPsw.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(70, 242);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "账号";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(70, 279);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "密码";
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(147, 308);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(92, 23);
            this.loginBtn.TabIndex = 5;
            this.loginBtn.Text = "登录";
            // 
            // hyperlinkLabelControl1
            // 
            this.hyperlinkLabelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperlinkLabelControl1.Appearance.LinkColor = System.Drawing.Color.Gray;
            this.hyperlinkLabelControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hyperlinkLabelControl1.LineColor = System.Drawing.Color.Gray;
            this.hyperlinkLabelControl1.Location = new System.Drawing.Point(260, 242);
            this.hyperlinkLabelControl1.Name = "hyperlinkLabelControl1";
            this.hyperlinkLabelControl1.Size = new System.Drawing.Size(48, 14);
            this.hyperlinkLabelControl1.TabIndex = 6;
            this.hyperlinkLabelControl1.Text = "用户注册";
            this.hyperlinkLabelControl1.Visible = false;
            // 
            // hyperlinkLabelControl2
            // 
            this.hyperlinkLabelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperlinkLabelControl2.Appearance.LinkColor = System.Drawing.Color.Gray;
            this.hyperlinkLabelControl2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hyperlinkLabelControl2.LineColor = System.Drawing.Color.Gray;
            this.hyperlinkLabelControl2.Location = new System.Drawing.Point(260, 279);
            this.hyperlinkLabelControl2.Name = "hyperlinkLabelControl2";
            this.hyperlinkLabelControl2.Size = new System.Drawing.Size(48, 14);
            this.hyperlinkLabelControl2.TabIndex = 7;
            this.hyperlinkLabelControl2.Text = "忘记密码";
            this.hyperlinkLabelControl2.Visible = false;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(260, 309);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "记住密码";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 8;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureEdit1.EditValue = global::FootManager.Properties.Resources.logo;
            this.pictureEdit1.Location = new System.Drawing.Point(100, 7);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.InitialImage = null;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(190, 190);
            this.pictureEdit1.TabIndex = 10;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(94, 207);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(196, 18);
            this.progressBarControl1.TabIndex = 11;
            // 
            // LoginForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 339);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.hyperlinkLabelControl2);
            this.Controls.Add(this.hyperlinkLabelControl1);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textPsw);
            this.Controls.Add(this.textName);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPsw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit textName;
        private DevExpress.XtraEditors.TextEdit textPsw;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton loginBtn;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControl1;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControl2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}