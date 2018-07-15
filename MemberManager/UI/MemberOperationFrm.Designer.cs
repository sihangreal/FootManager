namespace MemberManager.UI
{
    partial class MemberOperationFrm
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
            this.textMId = new DevExpress.XtraEditors.TextEdit();
            this.textMName = new DevExpress.XtraEditors.TextEdit();
            this.comCardLevel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textBalance = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textMId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comCardLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPhone.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textMId
            // 
            this.textMId.Location = new System.Drawing.Point(71, 26);
            this.textMId.Name = "textMId";
            this.textMId.Properties.ReadOnly = true;
            this.textMId.Size = new System.Drawing.Size(126, 20);
            this.textMId.TabIndex = 14;
            // 
            // textMName
            // 
            this.textMName.EditValue = "";
            this.textMName.Location = new System.Drawing.Point(286, 26);
            this.textMName.Name = "textMName";
            this.textMName.Size = new System.Drawing.Size(126, 20);
            this.textMName.TabIndex = 15;
            // 
            // comCardLevel
            // 
            this.comCardLevel.EditValue = "";
            this.comCardLevel.Location = new System.Drawing.Point(71, 85);
            this.comCardLevel.Name = "comCardLevel";
            this.comCardLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comCardLevel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comCardLevel.Size = new System.Drawing.Size(126, 20);
            this.comCardLevel.TabIndex = 16;
            // 
            // comStatus
            // 
            this.comStatus.EditValue = "";
            this.comStatus.Location = new System.Drawing.Point(286, 85);
            this.comStatus.Name = "comStatus";
            this.comStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comStatus.Size = new System.Drawing.Size(126, 20);
            this.comStatus.TabIndex = 17;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "会员编号:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(218, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "会员姓名:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "会员级别:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(218, 88);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 14);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "会员状态:";
            // 
            // textBalance
            // 
            this.textBalance.EditValue = "";
            this.textBalance.Location = new System.Drawing.Point(71, 146);
            this.textBalance.Name = "textBalance";
            this.textBalance.Size = new System.Drawing.Size(126, 20);
            this.textBalance.TabIndex = 22;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 149);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 14);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "会员余额:";
            // 
            // textPhone
            // 
            this.textPhone.EditValue = "";
            this.textPhone.Location = new System.Drawing.Point(71, 208);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(267, 20);
            this.textPhone.TabIndex = 24;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(13, 211);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 14);
            this.labelControl6.TabIndex = 25;
            this.labelControl6.Text = "会员电话:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(90, 261);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 30);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "确定";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(239, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 30);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "取消";
            // 
            // MemberOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 316);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.textPhone);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.textBalance);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.comStatus);
            this.Controls.Add(this.comCardLevel);
            this.Controls.Add(this.textMName);
            this.Controls.Add(this.textMId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemberOperationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加会员";
            ((System.ComponentModel.ISupportInitialize)(this.textMId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comCardLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPhone.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textMId;
        private DevExpress.XtraEditors.TextEdit textMName;
        private DevExpress.XtraEditors.ComboBoxEdit comCardLevel;
        private DevExpress.XtraEditors.ComboBoxEdit comStatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textBalance;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textPhone;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
