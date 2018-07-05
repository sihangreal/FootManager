namespace MemberManager.UI
{
    partial class UpdateCardForm
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
            this.textCardName = new DevExpress.XtraEditors.TextEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.textDisCount = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textCardName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDisCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "会员卡名称:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "会员卡折扣:";
            // 
            // textCardName
            // 
            this.textCardName.Location = new System.Drawing.Point(105, 9);
            this.textCardName.Name = "textCardName";
            this.textCardName.Size = new System.Drawing.Size(111, 20);
            this.textCardName.TabIndex = 2;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(41, 86);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 30);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Tag = "修改会员卡";
            this.btnQuery.Text = "确定";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(151, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            // 
            // textDisCount
            // 
            this.textDisCount.Location = new System.Drawing.Point(105, 51);
            this.textDisCount.Name = "textDisCount";
            this.textDisCount.Size = new System.Drawing.Size(111, 20);
            this.textDisCount.TabIndex = 3;
            // 
            // UpdateCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 128);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.textCardName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textDisCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改会员卡";
            ((System.ComponentModel.ISupportInitialize)(this.textCardName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDisCount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textCardName;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit textDisCount;
    }
}