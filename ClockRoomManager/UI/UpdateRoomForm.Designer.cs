namespace ClockRoomManager.UI
{
    partial class UpdateRoomForm
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
            this.textRoomId = new DevExpress.XtraEditors.TextEdit();
            this.textRoomName = new DevExpress.XtraEditors.TextEdit();
            this.comboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textRoomId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRoomName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textRoomId
            // 
            this.textRoomId.Enabled = false;
            this.textRoomId.Location = new System.Drawing.Point(100, 19);
            this.textRoomId.Name = "textRoomId";
            this.textRoomId.Size = new System.Drawing.Size(141, 20);
            this.textRoomId.TabIndex = 0;
            // 
            // textRoomName
            // 
            this.textRoomName.Location = new System.Drawing.Point(100, 69);
            this.textRoomName.Name = "textRoomName";
            this.textRoomName.Size = new System.Drawing.Size(141, 20);
            this.textRoomName.TabIndex = 1;
            // 
            // comboStatus
            // 
            this.comboStatus.EditValue = "空闲";
            this.comboStatus.Location = new System.Drawing.Point(100, 120);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboStatus.Properties.Items.AddRange(new object[] {
            "空闲",
            "占用"});
            this.comboStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboStatus.Size = new System.Drawing.Size(141, 20);
            this.comboStatus.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "钟房编号:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "钟房名字:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 123);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "钟房状态:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(52, 171);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "修改";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            // 
            // UpdateRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 219);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.textRoomName);
            this.Controls.Add(this.textRoomId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "UpdateRoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更新钟房";
            ((System.ComponentModel.ISupportInitialize)(this.textRoomId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRoomName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textRoomId;
        private DevExpress.XtraEditors.TextEdit textRoomName;
        private DevExpress.XtraEditors.ComboBoxEdit comboStatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}